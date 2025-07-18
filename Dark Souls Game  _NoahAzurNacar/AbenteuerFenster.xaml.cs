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
using System.Xml.Linq;

namespace Dark_Souls_Game___NoahAzurNacar
{

    public partial class AbenteuerFenster : Window
    {
        private GameCharacter   spieler;
        private Monster         monster;

        private Random          rndSchadenBonus     = new Random(); // RandomGenerator der für die schadensberechnung verwendet wird damit der spieler und der gegner(monster) nicht immer gleichen schaden macht was auf dauer langweilig sein kann
        private Random          rndAusdauerBonus    = new Random();

        private void doSauber() // methode die alle 3 list box einträge die console cleart
        {
            if (spieler.lbSauberHaltenSpieler == 3 || monster.lbSauberHaltenGegner == 3)
            {
                if (spieler.lbSauberHaltenSpieler == 3)
                {
                    lbStatusKampfSpieler.Items.Clear();
                    spieler.lbSauberHaltenSpieler = 0;
                }
                if (monster.lbSauberHaltenGegner == 3)
                {
                    lbStatusKampfGegner.Items.Clear();
                    spieler.lbSauberHaltenGegner = 0;
                }
            }
        }


        public AbenteuerFenster(GameCharacter _spieler)
        {
            InitializeComponent();

            spieler = _spieler;
            spieler.updateTxtSpielerStatsKampf(txtSpielerStatsKampf);

            


            if (spieler.klasse      == "Samurai")
            {
                ImageboxKlassenInfoFenster.Source = new BitmapImage(new Uri("pack://application:,,,/SpielBilder/KlassenBilder/samurai.png"));
            }
            else if (spieler.klasse == "Ritter")
            {
                ImageboxKlassenInfoFenster.Source = new BitmapImage(new Uri("pack://application:,,,/SpielBilder/KlassenBilder/ritter.png"));
            }
            else if (spieler.klasse == "Magier")
            {
                ImageboxKlassenInfoFenster.Source = new BitmapImage(new Uri("pack://application:,,,/SpielBilder/KlassenBilder/magier.png"));
            }

            ImageboxMonster.Source = new BitmapImage(new Uri("pack://application:,,,/SpielBilder/MonsterBilder/zombie.png"));

            ///////////////////Gegner Skalierung///////////////////////////////////////
            monster = new Monster("Skelett", 200, 50, "Dreckiges Schwert", 30, 10);
            monster.level            = spieler.gegnerGetoetet * 1;
            monster.lebenspunkte    += spieler.gegnerGetoetet * 50;
            monster.schaden         += spieler.gegnerGetoetet * 3;
            monster.ruestung        += spieler.gegnerGetoetet * 2;

            monster.updateTxtGegnerStatsKampf(txtGegnerStatsKampf);

        }

        private void btnHeilen_Click(object sender, RoutedEventArgs e)
        {

            doSauber();

            if (spieler.heiltrank == true)
            {
                spieler.lebenspunkte += 100 + (spieler.gegnerGetoetet * 25);
                lbStatusKampfSpieler.Items.Add("Du hast dich geheilt für " + (100 + spieler.gegnerGetoetet * 25) +" Punkte");

                if (spieler.lebenspunkte > spieler.maxlebenspunkte) // check damit man nicht übers max leben heilt 
                {
                    spieler.lebenspunkte = spieler.maxlebenspunkte;
                }
                spieler.heiltrank = false;
            }
            else if(spieler.heiltrank == false)
            {
                lbStatusKampfSpieler.Items.Add("Du hast kein heiltrank");
            }

            spieler.lbSauberHaltenSpieler++;

            spieler.updateTxtSpielerStatsKampf(txtSpielerStatsKampf);
        }

        private void btnAussetzen_Click(object sender, RoutedEventArgs e)
        {

            doSauber();
            if(spieler.ausdauer < spieler.maxausdauer)
            {

                spieler.regenerierteAusdauer = rndAusdauerBonus.Next(20, 45);
                spieler.ausdauer += spieler.regenerierteAusdauer;
                if(spieler.ausdauer > spieler.maxausdauer)
                {
                    spieler.ausdauer = spieler.maxausdauer;
                }
                lbStatusKampfSpieler.Items.Add(spieler.name + " hat " + spieler.regenerierteAusdauer + " Ausdauer regeneriert"); // lbStatusKampfSpieler lbStatusKampfGegner

                if (monster.lebenspunkte > 0 && monster.ausdauer >= 15)
                {
                    monster.bonusSchaden = rndSchadenBonus.Next(0, 20);
                    monster.gesamtSchaden = (monster.schaden + monster.bonusSchaden) - spieler.ruestung;
                    spieler.lebenspunkte -= monster.gesamtSchaden;
                    lbStatusKampfGegner.Items.Add(monster.name + " Verursacht " + monster.gesamtSchaden + " Schaden"); // lbStatusKampfSpieler lbStatusKampfGegner
                    monster.ausdauer -= 15;


                    if (spieler.lebenspunkte <= 0 || monster.lebenspunkte <= 0)
                    {
                        if (spieler.lebenspunkte <= 0)
                        {
                            spieler.lebenspunkte = 0;
                            MessageBox.Show("Du hast Verloren");

                            AbenteuerAbschlussFenster abenteuerAbschlussFenster = new AbenteuerAbschlussFenster(spieler);
                            abenteuerAbschlussFenster.Show();
                            this.Close();
                        }

                    }

                }
                else if (monster.ausdauer < 15)
                {
                    lbStatusKampfGegner.Items.Add(monster.name + " hat keine ausdauer"); // lbStatusKampfSpieler lbStatusKampfGegner
                    monster.regenerierteAusdauer = rndAusdauerBonus.Next(20, 60);
                    monster.ausdauer += monster.regenerierteAusdauer;
                    lbStatusKampfGegner.Items.Add(monster.name + " hat " + monster.regenerierteAusdauer + " Ausdauer regeneriert"); // lbStatusKampfSpieler lbStatusKampfGegner

                }
                 

            }
            else
            {
                lbStatusKampfSpieler.Items.Add("Du hast bereits volle ausdauer");
            }


            spieler.lbSauberHaltenSpieler++;
            monster.lbSauberHaltenGegner++;

            spieler.updateTxtSpielerStatsKampf(txtSpielerStatsKampf);
            monster.updateTxtGegnerStatsKampf(txtGegnerStatsKampf);
        }

        private void btnAngriff_Click(object sender, RoutedEventArgs e)
        {

            doSauber();


            if (spieler.ausdauer >= 15)
            {
                spieler.bonusSchaden    = rndSchadenBonus.Next(5, 25);
                spieler.gesamtSchaden   = (spieler.schaden + spieler.bonusSchaden) - monster.ruestung;
                monster.lebenspunkte   -= spieler.gesamtSchaden;
                lbStatusKampfSpieler.Items.Add(spieler.name + " Verursacht " + spieler.gesamtSchaden +" Schaden"); // lbStatusKampfSpieler lbStatusKampfGegner
                spieler.ausdauer       -= 15;

                if(monster.lebenspunkte > 0 && monster.ausdauer >= 15)
                {
                    monster.bonusSchaden    = rndSchadenBonus.Next(0, 20);
                    monster.gesamtSchaden   = (monster.schaden + monster.bonusSchaden) - spieler.ruestung;
                    spieler.lebenspunkte   -= monster.gesamtSchaden;
                    lbStatusKampfGegner.Items.Add(monster.name + " Verursacht " + monster.gesamtSchaden + " Schaden"); // lbStatusKampfSpieler lbStatusKampfGegner
                    monster.ausdauer       -= 15;
                }
                else if(monster.ausdauer < 15)
                {
                    lbStatusKampfGegner.Items.Add(monster.name + " hat keine ausdauer"); // lbStatusKampfSpieler lbStatusKampfGegner
                    monster.regenerierteAusdauer    = rndAusdauerBonus.Next(20, 60);
                    monster.ausdauer                += monster.regenerierteAusdauer;
                    lbStatusKampfGegner.Items.Add(monster.name + " hat " +monster.regenerierteAusdauer + " Ausdauer regeneriert"); // lbStatusKampfSpieler lbStatusKampfGegner

                }

            }
            else if(spieler.ausdauer <= 0)
            {
                lbStatusKampfSpieler.Items.Add(spieler.name + " hat keine ausdauer mehr");
                MessageBox.Show("Du hast nicht genug ausdauer");
            }

            if (spieler.lebenspunkte <= 0 || monster.lebenspunkte <= 0)
            {
                if (spieler.lebenspunkte <= 0)
                {
                    spieler.lebenspunkte = 0;
                    MessageBox.Show("Du hast Verloren");

                    AbenteuerAbschlussFenster abenteuerAbschlussFenster = new AbenteuerAbschlussFenster(spieler);
                    abenteuerAbschlussFenster.Show();
                    this.Close();
                }
                if (monster.lebenspunkte <= 0)
                {
                    monster.lebenspunkte = 0;
                    MessageBox.Show("Du hast gewonnen");

                    spieler.gegnerGetoetet++; // hier wird nach einen sieg hoch gezählt um 1, damit der nächste erstellte gegner mehr leben hat usw, bsp. monster.level =+ spieler.gegnerGetoetet *1 
                    spieler.ausdauer = spieler.maxausdauer;

                    AbenteuerAbschlussFenster abenteuerAbschlussFenster = new AbenteuerAbschlussFenster(spieler);
                    abenteuerAbschlussFenster.Show();
                    this.Close();
                }
            }

            spieler.lbSauberHaltenSpieler++;
            monster.lbSauberHaltenGegner++;

            spieler.updateTxtSpielerStatsKampf(txtSpielerStatsKampf);
            monster.updateTxtGegnerStatsKampf(txtGegnerStatsKampf);
        }
    }
}
