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
        public string Token { get; set; }
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
                Token = login.Token;
                await this.GetAllClub();
            }
        }

        public async Task GetAllClub()
        {
            cbox.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", "/User/GetAllCLub", Token);
            IEnumerable<Club> clubs = await restservice.Get<Club>();

            cbox.ItemsSource = clubs;
            cbox.SelectedIndex = 0;
        }

        public void LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow newMW = new MainWindow();
            newMW.Show();
            this.Close();
        }

        public void AddClubButtonClick(object sender, RoutedEventArgs e)
        {
            AddClubWindow add = new AddClubWindow();

            if (add.ShowDialog() == true)
            {
                Club newClub = new Club()
                {
                    ClubName = add.ClubName,
                    ClubColour = add.ClubColour,
                    ClubCity = add.ClubCity,
                    ClubFounded = add.ClubFounded,
                    Stadium = add.Stadium
                };

                RestService restservice = new RestService("https://localhost:5001/", "/Administrator/AddClub", Token);
                restservice.Post(newClub);
                MessageBox.Show("Club added!");
            }
        }

        public void DeleteClubButtonClick(object sender, RoutedEventArgs e)
        {
            if (cbox.SelectedItem as Club != null)
            {
                RestService restService = new RestService("https://localhost:5001/", "/Administrator/DeleteClub", Token);
                restService.Delete((cbox.SelectedItem as Club).ClubId);
                MessageBox.Show("Club deleted!");
            }
            else
            {
                MessageBox.Show("Could not delete club!");
            }
        }

        public void UpdateClubButtonClick(object sender, RoutedEventArgs e)
        {
            if (cbox.SelectedItem as Club != null)
            {
                UpdateClubWindow update = new UpdateClubWindow();
                update.name.Text = (cbox.SelectedItem as Club).ClubName;
                update.colour.Text = (cbox.SelectedItem as Club).ClubColour;
                update.city.Text = (cbox.SelectedItem as Club).ClubCity;
                update.founded.Text = (cbox.SelectedItem as Club).ClubFounded.ToString();
                update.stadium.Text = (cbox.SelectedItem as Club).Stadium;
                if (update.ShowDialog() == true)
                {
                    RestService restService = new RestService("https://localhost:5001/", "/Administrator/UpdateClub", Token);

                    Club club = new Club()
                    {
                        ClubName = update.ClubName,
                        ClubColour = update.ClubColour,
                        ClubCity = update.ClubCity,
                        ClubFounded = update.ClubFounded,
                        Stadium = update.Stadium
                    };

                    restService.Put((cbox.SelectedItem as Club).ClubId, club);
                    MessageBox.Show("Club updated!");
                }
            }
        }

        public void AddManagerButtonClick(object sender, RoutedEventArgs e)
        {
            if (cbox.SelectedItem as Club != null && (cbox.SelectedItem as Club).Manager == null)
            {
                AddManagerWindow add = new AddManagerWindow();

                if (add.ShowDialog() == true)
                {
                    Manager manager = new Manager()
                    {
                        ManagerName = add.ManagerName,
                        ManagerNationality = add.ManagerNationality,
                        ManagerBirthDate = DateTime.Parse(add.ManagerBirthDate),
                        ManagerStartYear = add.ManagerStartYear,
                        WonChampionship = add.WonChampionship
                    };

                    RestService restservice = new RestService("https://localhost:5001/", "/Administrator/AddManager", Token);
                    restservice.Post(manager, (cbox.SelectedItem as Club).ClubId);
                    MessageBox.Show("Manager added!");
                }
            }
            else
            {
                MessageBox.Show("This club already has a manager!");
            }
        }

        public void DeleteManagerButtonClick(object sender, RoutedEventArgs e)
        {
            if (cbox.SelectedItem as Club != null)
            {
                RestService restService = new RestService("https://localhost:5001/", "/Administrator/DeleteManager", Token);
                restService.Delete((cbox.SelectedItem as Club).Manager.ManagerId);
                MessageBox.Show("Manager deleted!");
            }
            else
            {
                MessageBox.Show("Could not delete manager!");
            }
        }

        public void UpdateManagerButtonClick(object sender, RoutedEventArgs e)
        {
            if (cbox.SelectedItem as Club != null)
            {
                UpdateManagerWindow update = new UpdateManagerWindow();
                update.name.Text = (cbox.SelectedItem as Club).Manager.ManagerName;
                update.nationality.Text = (cbox.SelectedItem as Club).Manager.ManagerNationality;
                update.birthdate.Text = (cbox.SelectedItem as Club).Manager.ManagerBirthDate.ToShortDateString();
                update.startyear.Text = (cbox.SelectedItem as Club).Manager.ManagerStartYear.ToString();
                update.wonchampionship.IsChecked = (cbox.SelectedItem as Club).Manager.WonChampionship;
                if (update.ShowDialog() == true)
                {
                    RestService restService = new RestService("https://localhost:5001/", "/Administrator/UpdateManager", Token);

                    Manager manager = new Manager()
                    {
                        ManagerName = update.ManagerName,
                        ManagerNationality = update.ManagerNationality,
                        ManagerBirthDate = DateTime.Parse(update.ManagerBirthDate),
                        ManagerStartYear = update.ManagerStartYear,
                        WonChampionship = update.WonChampionship
                    };

                    restService.Put((cbox.SelectedItem as Club).Manager.ManagerId, manager);
                    MessageBox.Show("Manager updated!");
                }
            }
        }
    }
}
