using System;
using Android.App;
using Android.OS;
using Android.Widget;
using System.IO;
namespace CreateAFragment
{
    [Activity(Label = "Лабораторна робота 3",
        MainLauncher = true,
        Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        FileStream aFile;
        bool fl1 = false, fl2 = false;
        public void creatеfile(string textview)
        {
            aFile = new FileStream("d.txt", FileMode.Create); //OpenOrCreate открывает или создает новый файл
            StreamWriter sw = new StreamWriter(aFile);
            sw.WriteLine(textview);
            sw.Close();
        }
       
        public void OpenFILE(TextView tv)
        {
            FileStream aFile1 = new FileStream("d.txt", FileMode.Open); //OpenOrCreate открывает или создает новый файл
            StreamReader sw1 = new StreamReader(aFile1);
            tv.Text = sw1.ReadToEnd();
            sw1.Close();            
        }
        string buffer;
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.Main);
                Button button = FindViewById<Button>(Resource.Id.button1);
                Button buttonSave = FindViewById<Button>(Resource.Id.button2);
                Button buttonOpen = FindViewById<Button>(Resource.Id.button3);
                EditText edit = FindViewById<EditText>(Resource.Id.editText1);
                CheckBox ch1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
                ch1.Text = "Small sizes";
                button.Text = "Check";
                CheckBox ch2 = FindViewById<CheckBox>(Resource.Id.checkBox2);
                ch2.Text = "1000x500";
                TextView TV = FindViewById<TextView>(Resource.Id.textView3);
                var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var pathToDatabase = Path.Combine(docsFolder, "dt.txt");
                aFile = new FileStream(pathToDatabase, FileMode.Create);
                button.Click += delegate
                {
                    TV.Text = edit.Text + ", ";
                    if (ch1.Checked)
                        TV.Text += ch1.Text + ", ";
                    if (ch2.Checked)
                        TV.Text += ch2.Text + " ";
                   
                    fl1 = true;
                    fl2 = false;
                };
               
                buttonSave.Click += delegate
                {
                    buffer = "Информация с файла: "+TV.Text;
                    StreamWriter sw = new StreamWriter(aFile);
                    sw.WriteLine(buffer);
                    sw.Close();
                    //createfile(buffer);
                    if (fl1)
                    {
                        fl2 = true;
                        fl1 = false;
                    }
                   };               
                buttonOpen.Click += delegate
                {
                    //TV.Text=OpеnFILE();
                    FileStream aFile1 = new FileStream(pathToDatabase, FileMode.Open); //OpenOrCreate открывает или создает новый файл
                    StreamReader sw1 = new StreamReader(aFile1);
                    TV.Text = sw1.ReadToEnd();
                    sw1.Close();
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        //public async Task SaveTextAsync(string filename, string text)
        //{
        //    string filepath = GetFilePath(filename);
        //    using (StreamWriter writer = File.CreateText(filepath))
        //    {
        //        await writer.WriteAsync(text);
        //    }
        //}
        //public Task DeleteAsync(string filename)
        //{
        //    File.Delete(GetFilePath(filename));
        //    return Task.FromResult(true);
        //}

        //public Task<bool> ExistsAsync(string filename)
        //{
        //    string filepath = GetFilePath(filename);
        //    bool exists = File.Exists(filepath);
        //    return Task<bool>.FromResult(exists);
        //}

        //public Task<IEnumerable<string>> GetFilesAsync()
        //{
        //    IEnumerable<string> filenames = from filepath in Directory.EnumerateFiles(GetDocsPath())
        //                                    select Path.GetFileName(filepath);
        //    return Task<IEnumerable<string>>.FromResult(filenames);
        //}

        //public async Task<string> LoadTextAsync(string filename)
        //{
        //    string filepath = GetFilePath(filename);
        //    using (StreamReader reader = File.OpenText(filepath))
        //    {
        //        return await reader.ReadToEndAsync();
        //    }
        //}

        //public async Task SaveTextAsync(string filename, string text)
        //{
        //    string filepath = GetFilePath(filename);
        //    using (StreamWriter writer = File.CreateText(filepath))
        //    {
        //        await writer.WriteAsync(text);
        //    }
        //}

        //string GetFilePath(string filename)
        //{
        //    return Path.Combine(GetDocsPath(), filename);
        //}
        //string GetDocsPath()
        //{
        //    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //}
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await UpdateFileList();
        //}
        //// сохранение текста в файл
        //async void Save(object sender, EventArgs args)
        //{
        //    string filename = fileNameEntry.Text;
        //    if (String.IsNullOrEmpty(filename)) return;
        //    // если файл существует
        //    if (await DependencyService.Get<IFileWorker>().ExistsAsync(filename))
        //    {
        //        // запрашиваем разрешение на перезапись
        //        bool isRewrited = await DisplayAlert("Подверждение", "Файл уже существует, перезаписать его?", "Да", "Нет");
        //        if (isRewrited == false) return;
        //    }
        //    // перезаписываем файл
        //    await DependencyService.Get<IFileWorker>().SaveTextAsync(fileNameEntry.Text, textEditor.Text);
        //    // обновляем список файлов
        //    await UpdateFileList();
        //}
        //async void FileSelect(object sender, SelectedItemChangedEventArgs args)
        //{
        //    if (args.SelectedItem == null) return;
        //    // получаем выделенный элемент
        //    string filename = (string)args.SelectedItem;
        //    // загружем текст в текстовое поле
        //    textEditor.Text = await DependencyService.Get<IFileWorker>().LoadTextAsync((string)args.SelectedItem);
        //    // устанавливаем название файла
        //    fileNameEntry.Text = filename;
        //    // снимаем выделение
        //    filesList.SelectedItem = null;

        //}
        //async void Delete(object sender, EventArgs args)
        //{
        //    // получаем имя файла
        //    string filename = (string)((MenuItem)sender).BindingContext;
        //    // удаляем файл из списка
        //    await DependencyService.Get<IFileWorker>().DeleteAsync(filename);
        //    // обновляем список файлов
        //    await UpdateFileList();
        //}
        //// обновление списка файлов
        //async Task UpdateFileList()
        //{
        //    // получаем все файлы
        //    filesList.ItemsSource = await DependencyService.Get<IFileWorker>().GetFilesAsync();
        //    // снимаем выделение
        //    filesList.SelectedItem = null;
        //}






        public string OpеnFILE()
        {
            return buffer;
          
        }
        public void createfile(string x)
        { }

    }
}