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

namespace Dark_Souls_Game___NoahAzurNacar
{
    /// <summary>
    /// Interaktionslogik für AbenteuerAbschlussFenster.xaml
    /// </summary>
    public partial class AbenteuerAbschlussFenster : Window
    {

        private GameCharacter spieler;

        public AbenteuerAbschlussFenster(GameCharacter _spieler)
        {
            InitializeComponent();

            spieler = _spieler;

            if (spieler.lebenspunkte > 0)
            {
                spieler.goldGewonnen    = 100 + spieler.gegnerGetoetet * 50;
                spieler.gold            += spieler.goldGewonnen;

                spieler.erfahrungspunkteGewonnen    = 400 + spieler.gegnerGetoetet * 200;
                spieler.erfahrungspunkte            += spieler.erfahrungspunkteGewonnen;

                tbBelohnungGold.Text                = "Gold: +" + spieler.goldGewonnen;
                tbBelohnungErfahrungspunkte.Text    = "Erf Punkte: +" + spieler.erfahrungspunkteGewonnen;

                tbGewonnenVerloren.Text     = "Gewonnen";
                btnWeiterBeenden.Content    = "Fertig";

                btnWeiterBeenden.Click -= btnSpielBeenden_Click;         // Vorherige Button sicher entfernen
                btnWeiterBeenden.Click += btnZurueckZuZentrale_Click;
            }
            else
            {
                tbGewonnenVerloren.Text     = "Verloren";
                btnWeiterBeenden.Content    = "Beenden";

                btnWeiterBeenden.Click -= btnZurueckZuZentrale_Click;    // Vorherige Button sicher entfernen
                btnWeiterBeenden.Click += btnSpielBeenden_Click;

            }

        }

        private void btnZurueckZuZentrale_Click(object sender, RoutedEventArgs e)
        {
            // Logik bei Gewinn
            Zentrale zentralenFenster = new Zentrale(spieler);
            zentralenFenster.Show();
            this.Close();
        }

        private void btnSpielBeenden_Click(object sender, RoutedEventArgs e)
        {
            // Logik bei Niederlage
            this.Close();
        }
    }
}
