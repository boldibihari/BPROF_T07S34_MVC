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
    /// Interaction logic for AddClubWindow.xaml
    /// </summary>
    public partial class AddClubWindow : Window
    {
        public string ClubName { get; set; }
        public string ClubColour { get; set; }
        public string ClubCity { get; set; }
        public int ClubFounded { get; set; }
        public string Stadium { get; set; }

        public AddClubWindow()
        {
            InitializeComponent();
        }

        public void OkButtonClick(object sender, RoutedEventArgs e)
        {
            ClubName = name.Text;
            ClubColour = colour.Text;
            ClubCity = city.Text;
            ClubFounded = int.Parse(founded.Text);
            Stadium = stadium.Text;
            this.DialogResult = true;
        }

        public void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
