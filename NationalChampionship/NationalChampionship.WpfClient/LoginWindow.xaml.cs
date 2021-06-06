using NationalChampionship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NationalChampionship.WpfClient
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string Token { get; private set; }

        string link = "https://nationalchampionshipapi20210606141430.azurewebsites.net/";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                RestService restservice = new RestService(link, "/Auth");
                TokenViewModel tvm = await restservice.Put<TokenViewModel, LoginViewModel>(new LoginViewModel()
                {
                    Username = username.Text,
                    Password = password.Password
                });
                Token = tvm.Token;
                this.DialogResult = true;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Wrong password or username!");
            }
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService(link, "/Auth");
            restservice.Post<RegisterViewModel>(new RegisterViewModel()
            {
                Email = username.Text,
                Password = password.Password
            });

            MessageBox.Show("You can log in now!");
        }
    }
}
