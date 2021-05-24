using NationalChampionship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string token;
        public MainWindow()
        {
            InitializeComponent();

            Login();
        }

        public async Task Login()
        {
            LoginWindow login = new LoginWindow();
            if (login.ShowDialog() == true)
            {
                token = login.Token;
                await this.GetAllClub();
            }
        }

        public async Task GetAllClub()
        {
            cbox.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", "/User/GetAllCLub", token);
            IEnumerable<Club> clubs = await restservice.Get<Club>();

            cbox.ItemsSource = clubs;
            cbox.SelectedIndex = 0;
        }
    }
}
