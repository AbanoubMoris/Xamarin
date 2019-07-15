using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;



namespace MicroBus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        SQLiteConnection con;
        public Register()
        {
            InitializeComponent();

            con = DependencyService.Get<pop>().GetConnection();
            con.CreateTable<UserData>();

        }

        private void SignBTN_Clicked(object sender, EventArgs e)
        {

            UserData data = new UserData();
            data.username = usertxt.Text;
            data.Phone = phonetxt.Text;
            data.Email = emailtxt.Text;
            data.Password = passtxt.Text;
            if (SignBTN.Text == "Sign Up") // new account
            {
                bool s = DependencyService.Get<pop>().save(data);
            }
            else //update
            {
                DependencyService.Get<pop>().update(data);
            }

             DisplayAlert(title: "Done!", message: "You have " + SignBTN.Text + " Successfuly", cancel: "ok");
             Navigation.PopAsync();

        }
        public Button GetSignUp()
        {
            return SignBTN;
        }
        public Entry getUsernameTXT()
        {
            return usertxt;
        }
        public Entry getPasswordTXT()
        {
            return passtxt;
        }
        public Entry getPhoneTXT()
        {
            return phonetxt;
        }
        public Entry getEmailTXT()
        {
            return emailtxt;
        }
    }
}