using NationalChampionship.Data.Models;
using NationalChampionship.Logic.Classes;
using NationalChampionship.WpfClient.ClubWindows;
using NationalChampionship.WpfClient.ManagerWindows;
using NationalChampionship.WpfClient.PlayerWindows;
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
        public string Username { get; set; }

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
                Username = login.username.Text;
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

        public async Task RefreshClubs()
        {
            int index = cbox.SelectedIndex;
            cbox.ItemsSource = null;
            RestService restService = new RestService("https://localhost:5001/", "/User/GetAllCLub", Token);
            IEnumerable<Club> clubs = await restService.Get<Club>();
            cbox.ItemsSource = clubs;
            cbox.SelectedIndex = index;
        }

        public async void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statistics = new StatisticsWindow();
            RestService restservice1 = new RestService("https://localhost:5001/", "/User/AllValue", Token);
            statistics.allvalue.Content = await restservice1.GetOne<double>();
            RestService restservice2 = new RestService("https://localhost:5001/", "/User/AllAverageAge", Token);
            statistics.allaverageage.Content = await restservice2.GetOne<int>();
            RestService restservice3 = new RestService("https://localhost:5001/", "/User/AverageClubValue", Token);
            statistics.averageclubvalue.Content = await restservice3.GetOne<double>();
            RestService restservice4 = new RestService("https://localhost:5001/", "/User/AveragePlayerValue", Token);
            statistics.averageplayervalue.Content = await restservice4.GetOne<double>();
            RestService restservice5 = new RestService("https://localhost:5001/", "/User/GetAllNationality", Token);
            statistics.nationalities.ItemsSource = await restservice5.Get<Nationality>();
            RestService restservice6 = new RestService("https://localhost:5001/", "/User/GetAllPosition", Token);
            statistics.positions.ItemsSource = await restservice6.Get<Position>();
            statistics.ShowDialog();
        }

        public void LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        public void AddClubButtonClick(object sender, RoutedEventArgs e)
        {
            AddClubWindow add = new AddClubWindow();
            if (Username.ToLower().Contains("admin"))
            {
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
                    RefreshClubs();
                }
                else
                {
                    MessageBox.Show("Could not add club!");
                }
            }
            else
            {
                MessageBox.Show("You are not an admin!");
            }
        }

        public void DeleteClubButtonClick(object sender, RoutedEventArgs e)
        {
            if (Username.ToLower().Contains("admin"))
            {
                if (cbox.SelectedItem as Club != null)
                {
                    RestService restService = new RestService("https://localhost:5001/", "/Administrator/DeleteClub", Token);
                    restService.Delete((cbox.SelectedItem as Club).ClubId);
                    MessageBox.Show("Club deleted!");
                    RefreshClubs();
                }
                else
                {
                    MessageBox.Show("Could not delete club!");
                }
            }
            else
            {
                MessageBox.Show("You are not an admin!");
            }
        }

        public void UpdateClubButtonClick(object sender, RoutedEventArgs e)
        {
            if (Username.ToLower().Contains("admin"))
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
                        RefreshClubs();
                    }
                }
                else
                {
                    MessageBox.Show("Could not update club!");
                }
            }
            else
            {
                MessageBox.Show("You are not an admin!");
            }
        }

        public void AddManagerButtonClick(object sender, RoutedEventArgs e)
        {
            if (Username.ToLower().Contains("admin"))
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
                        RefreshClubs();
                    }
                }
                else
                {
                    MessageBox.Show("This club already has a manager!");
                }
            }
            else
            {
                MessageBox.Show("You are not an admin!");
            }
        }

        public void DeleteManagerButtonClick(object sender, RoutedEventArgs e)
        {
            if (Username.ToLower().Contains("admin"))
            {
                if (cbox.SelectedItem as Club != null && (cbox.SelectedItem as Club).Manager != null)
                {
                    RestService restService = new RestService("https://localhost:5001/", "/Administrator/DeleteManager", Token);
                    restService.Delete((cbox.SelectedItem as Club).Manager.ManagerId);
                    MessageBox.Show("Manager deleted!");
                    RefreshClubs();
                }
                else
                {
                    MessageBox.Show("The club does not have a manager!");
                }
            }
            else
            {
                MessageBox.Show("You are not an admin!");
            }
        }

        public void UpdateManagerButtonClick(object sender, RoutedEventArgs e)
        {
            if (Username.ToLower().Contains("admin"))
            {
                if (cbox.SelectedItem as Club != null && (cbox.SelectedItem as Club).Manager != null)
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
                        RefreshClubs();
                    }
                }
                else
                {
                    MessageBox.Show("The club does not have a manager!");
                }
            }
            else
            {
                MessageBox.Show("You are not an admin!");
            }
        }

        public void AddPlayerButtonClick(object sender, RoutedEventArgs e)
        {
            if (Username.ToLower().Contains("admin"))
            {
                if (cbox.SelectedItem as Club != null)
                {
                    AddPlayerWindow add = new AddPlayerWindow();

                    if (add.ShowDialog() == true)
                    {
                        Player player = new Player()
                        {
                            PlayerName = add.PlayerName,
                            PlayerNationality = add.PlayerNationality,
                            PlayerBirthDate = add.PlayerBirthDate,
                            PlayerPosition = add.PlayerPosition,
                            PlayerValue = add.PlayerValue
                        };

                        RestService restservice = new RestService("https://localhost:5001/", "/Administrator/AddPlayer", Token);
                        restservice.Post(player, (cbox.SelectedItem as Club).ClubId);
                        MessageBox.Show("Player added!");
                        RefreshClubs();
                    }
                }
                else
                {
                    MessageBox.Show("Could not add player!");
                }
            }
            else
            {
                MessageBox.Show("You are not an admin!");
            }
        }

        public void DeletePlayerButtonClick(object sender, RoutedEventArgs e)
        {
            if (Username.ToLower().Contains("admin"))
            {
                if (players.SelectedItem as Player != null)
                {
                    RestService restService = new RestService("https://localhost:5001/", "/Administrator/DeletePlayer", Token);
                    restService.Delete((players.SelectedItem as Player).PlayerId);
                    MessageBox.Show("Player deleted!");
                    RefreshClubs();
                }
                else
                {
                    MessageBox.Show("Could not delete player!");
                }
            }
            else
            {
                MessageBox.Show("You are not an admin!");
            }
        }

        public void UpdatePlayerButtonClick(object sender, RoutedEventArgs e)
        {
            if (Username.ToLower().Contains("admin"))
            {
                if (players.SelectedItem as Player != null)
                {
                    UpdatePlayerWindow update = new UpdatePlayerWindow();
                    update.name.Text = (players.SelectedItem as Player).PlayerName;
                    update.nationality.Text = (players.SelectedItem as Player).PlayerNationality;
                    update.birthdate.Text = (players.SelectedItem as Player).PlayerBirthDate.ToShortDateString();
                    update.position.SelectedItem = (players.SelectedItem as Player).PlayerPosition;
                    update.value.Text = (players.SelectedItem as Player).PlayerValue.ToString();
                    if (update.ShowDialog() == true)
                    {
                        RestService restService = new RestService("https://localhost:5001/", "/Administrator/UpdatePlayer", Token);

                        Player player = new Player()
                        {
                            PlayerName = update.PlayerName,
                            PlayerNationality = update.PlayerNationality,
                            PlayerBirthDate = update.PlayerBirthDate,
                            PlayerPosition = update.PlayerPosition,
                            PlayerValue = update.PlayerValue
                        };

                        restService.Put((players.SelectedItem as Player).PlayerId, player);
                        MessageBox.Show("Player updated!");
                        RefreshClubs();
                    }
                }
                else
                {
                    MessageBox.Show("Not selected a player!");
                }
            }
            else
            {
                MessageBox.Show("You are not an admin!");
            }
        }
    }
}
