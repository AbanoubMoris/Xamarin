using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MicroBus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataBase : ContentPage
    {
        public DataBase()
        {
            InitializeComponent();
            
        }

        async void NewAccBTN_Clicked(object sender, EventArgs e)
        {
            var x = new Register();
            
            await Navigation.PushAsync(x);
        }

        async void LogInBTN_Clicked(object sender, EventArgs e)
        {
            var x = new Register();

            await Navigation.PushAsync(x);
            await Navigation.PopAsync();

            List<UserData> mydata = DependencyService.Get<pop>().getdata();
            bool found = false; int idx = 0;
            string s = "";
            if (mydata!=null)
            for (int i=0;i<mydata.Count; i++)
            {
                if (mydata[i].username == usertxt.Text && mydata[i].Password == passtxt.Text)
                {
                    found = true;
                        s = mydata[i].username;
                    idx = i;
                    break;
                }
            }
            if (found)
            {

                await Navigation.PushAsync(new SingleOrTwo(s));
                /*
                var x = new Register();
                x.GetSignUp().Text = "Update Your Data";
                x.getUsernameTXT().Text = mydata[idx].username;
                x.getPasswordTXT().Text = mydata[idx].Password;
                x.getPhoneTXT().Text = mydata[idx].Phone;
                x.getEmailTXT().Text = mydata[idx].Email;
                await Navigation.PushAsync(x);
                */
            }
            else
            {
                await DisplayAlert("warning", "You need to register first", "OK");
            }

        }
    }
}