using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dark_Souls_Game___NoahAzurNacar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ImageboxSamurai.Source  =    new BitmapImage(new Uri("pack://application:,,,/SpielBilder/KlassenBilder/samurai.png"));
            ImageboxRitter.Source   =    new BitmapImage(new Uri("pack://application:,,,/SpielBilder/KlassenBilder/ritter.png"));
            ImageboxMagier.Source   =    new BitmapImage(new Uri("pack://application:,,,/SpielBilder/KlassenBilder/magier.png"));
        }

        private void btnWaehlenSamurai_Click(object sender, RoutedEventArgs e)
        {
            string name;
            name = txtname.Text;
            Samurai samurai             = new Samurai(name);
            samurai.maxlebenspunkte     = samurai.lebenspunkte;
            samurai.maxausdauer         = samurai.ausdauer;

            Zentrale zentralenFenster   = new Zentrale(samurai);
            zentralenFenster.Show();
            this.Close();
        }

        private void btnWaehlenRitter_Click(object sender, RoutedEventArgs e)
        {
            string name;
            name = txtname.Text;
            Ritter ritter               = new Ritter(name);
            ritter.maxlebenspunkte      = ritter.lebenspunkte;
            ritter.maxausdauer          = ritter.ausdauer;    

            Zentrale zentralenFenster   = new Zentrale(ritter);
            zentralenFenster.Show();
            this.Close();
        }

        private void btnWaehlenMagier_Click(object sender, RoutedEventArgs e)
        {
            string name;
            name = txtname.Text;
            Magier magier               = new Magier(name);
            magier.maxlebenspunkte      = magier.lebenspunkte;
            magier.maxausdauer          = magier.ausdauer;

            Zentrale zentralenFenster   = new Zentrale(magier);
            zentralenFenster.Show();
            this.Close();
        }

        

       
    }
}