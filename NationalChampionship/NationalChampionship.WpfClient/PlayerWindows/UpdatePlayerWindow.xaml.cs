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

namespace NationalChampionship.WpfClient.PlayerWindows
{
    /// <summary>
    /// Interaction logic for UpdatePlayerWindow.xaml
    /// </summary>
    public partial class UpdatePlayerWindow : Window
    {
        public string PlayerName { get; set; }
        public string PlayerNationality { get; set; }
        public DateTime PlayerBirthDate { get; set; }
        public PlayerPosition PlayerPosition { get; set; }
        public double PlayerValue { get; set; }

        public UpdatePlayerWindow()
        {
            InitializeComponent();
            GetAllPosition();
        }

        public void GetAllPosition()
        {
            List<PlayerPosition> positions = Enum.GetValues(typeof(PlayerPosition)).Cast<PlayerPosition>().ToList();
            position.ItemsSource = positions;
        }

        public void OkButtonClick(object sender, RoutedEventArgs e)
        {
            PlayerName = name.Text;
            PlayerNationality = nationality.Text;
            PlayerBirthDate = DateTime.Parse(birthdate.Text);
            PlayerPosition = (PlayerPosition)position.SelectedItem;
            PlayerValue = double.Parse(value.Text);
            this.DialogResult = true;
        }

        public void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
