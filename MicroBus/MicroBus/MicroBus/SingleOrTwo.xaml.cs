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
    public partial class SingleOrTwo : ContentPage
    {
        public SingleOrTwo(string s)
        {
            InitializeComponent();
            welcome.Text += s;
        }

        private void Select(object sender, EventArgs e)
        {
            if (((Button)sender).Text== "Play with AI")
            {
                Navigation.PushAsync(new Game());
            }
            else
            {
                Navigation.PushAsync(new Game(true));
            }
        }
    }
}