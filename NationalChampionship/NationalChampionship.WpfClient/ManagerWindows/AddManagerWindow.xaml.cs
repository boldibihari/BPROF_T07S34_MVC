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

namespace NationalChampionship.WpfClient.ManagerWindows
{
    /// <summary>
    /// Interaction logic for AddManagerWindow.xaml
    /// </summary>
    public partial class AddManagerWindow : Window
    {
        public string ManagerName { get; set; }
        public string ManagerNationality { get; set; }
        public string ManagerBirthDate { get; set; }
        public int ManagerStartYear { get; set; }
        public bool WonChampionship { get; set; }

        public AddManagerWindow()
        {
            InitializeComponent();
        }

        public void OkButtonClick(object sender, RoutedEventArgs e)
        {
            ManagerName = name.Text;
            ManagerNationality = nationality.Text;
            ManagerBirthDate = birthdate.Text;
            ManagerStartYear = int.Parse(startyear.Text);
            WonChampionship = (bool)wonchampionship.IsChecked;
            this.DialogResult = true;
        }

        public void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
