
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace L1
{
    public partial class MainPage : ContentPage
    {
        Label label, label1;
        Label textLabel;
        Entry passwordEntry;
        public MainPage()
        {
            StackLayout stackLayout = new StackLayout();
            
            label= new Label { FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) };
            label.Text = "Enter your password:";
            passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true
            };
            label1= new Label { FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) };
            label1.Text ="Password OFF";
            Switch switcher = new Switch
            {
                IsToggled = false              
               
            };
            switcher.Toggled += switcher_Toggled;
            Button button = new Button
            {
                Text = "Show password!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 1,
            };
            button.Clicked += OnButtonClicked;
           
            textLabel = new Label { FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) };

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(passwordEntry);
            stackLayout.Children.Add(label1);
            stackLayout.Children.Add(switcher);
            stackLayout.Children.Add(button);
            stackLayout.Children.Add(textLabel);
            this.Content = stackLayout;
        }
        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            textLabel.Text = passwordEntry.Text;
        }
        private void passwordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            textLabel.Text = passwordEntry.Text;
        }
        int k = 1;
        private void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            if (k % 2 == 1)
            {
                passwordEntry.IsPassword = false;
                label1.Text = "Password ON";
            }
            else
            {
                passwordEntry.IsPassword = true;
                label1.Text = "Password OFF";
            }
            k++;

        }

        
    }
}
