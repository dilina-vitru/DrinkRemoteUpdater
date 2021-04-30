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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Squirrel;


namespace DrinkRemoteUpdater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UpdateManager manager;

        public MainWindow ()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded ( object sender, RoutedEventArgs e )
        {
            manager = await UpdateManager.GitHubUpdateManager( @"https://github.com/dilina-vitru/DrinkRemoteUpdater" );

            cver.Content = manager.CurrentlyInstalledVersion().ToString();
        }

        private async void Checkbtn_Click ( object sender, RoutedEventArgs e )
        {
            
                var updateInfo = await manager.CheckForUpdate();
                MessageBox.Show( updateInfo.ToString() );

        }

        private async void updatebtn_Click ( object sender, RoutedEventArgs e )
        {
            await manager.UpdateApp();

            MessageBox.Show( "Updated succesfuly!" );
        }

    }
}
