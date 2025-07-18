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
    /// Interaction logic for Zentrale.xaml
    /// </summary>
    public partial class Zentrale : Window
    {       
        private GameCharacter spieler;
        public Zentrale(GameCharacter _spieler)
        {
            InitializeComponent();
            spieler = _spieler;

            spieler.updateCharacterStatsUI(txtKlassenInfo);
            UpdateUpgradeKosten();

        }

        private void btnStaerke_Click(object sender, RoutedEventArgs e)
        {

            int skillLevelPlusKostenStaerke = 200 + (spieler.anzahlAnGekaufteSkillLevelStaerke * 200);

            if (spieler.erfahrungspunkte >= skillLevelPlusKostenStaerke)
            {
                spieler.schaden += 10;
                spieler.erfahrungspunkte -= skillLevelPlusKostenStaerke;
                MessageBox.Show("Dein waffen Schaden wurde um +10 erhöht");
                spieler.anzahlAnGekaufteSkillLevelStaerke++;
                spieler.level++;
                UpdateUpgradeKosten();

                

                spieler.updateCharacterStatsUI(txtKlassenInfo);

            }
            else
            {
                MessageBox.Show("Du hast nicht genug Erfahrungspunkte");

            }

        }

        private void btnVitalitet_Click(object sender, RoutedEventArgs e)
        {

            int skillLevelPlusKostenVitalitet = 200 + (spieler.anzahlAnGekaufteSkillLevelVitalitet * 200);

            if (spieler.erfahrungspunkte >= skillLevelPlusKostenVitalitet)
            {
                spieler.lebenspunkte += 50;
                spieler.maxlebenspunkte += 50;
                spieler.erfahrungspunkte -= skillLevelPlusKostenVitalitet;
                MessageBox.Show("Deine Lebenspunkte wurden um +50 erhöht");
                spieler.anzahlAnGekaufteSkillLevelVitalitet++;
                spieler.level++;
                UpdateUpgradeKosten();

                spieler.updateCharacterStatsUI(txtKlassenInfo);

            }
            else
            {
                MessageBox.Show("Du hast nicht genug Erfahrungspunkte");

            }


        }

        private void btnKondition_Click(object sender, RoutedEventArgs e)
        {

            int skillLevelPlusKostenKondition = 200 + (spieler.anzahlAnGekaufteSkillLevelKondition * 200);

            if (spieler.erfahrungspunkte >= skillLevelPlusKostenKondition)
            {
                spieler.ausdauer    += 15;
                spieler.maxausdauer += 15;
                spieler.erfahrungspunkte -= skillLevelPlusKostenKondition;
                MessageBox.Show("Deine Ausdauer wurde um +15 erhöht");
                spieler.anzahlAnGekaufteSkillLevelKondition++;
                spieler.level++;
                UpdateUpgradeKosten();

                spieler.updateCharacterStatsUI(txtKlassenInfo);

            }
            else
            {
                MessageBox.Show("Du hast nicht genug Erfahrungspunkte");

            }

        }

        private void btnVerbessernRuestungKaufen_Click(object sender, RoutedEventArgs e)
        {

            int verbesserungsKostenRuestung = 50 + (spieler.anzahlAnGekaufteVerbesserungen_RuestungVerbessern * 25);


            if (spieler.gold >= verbesserungsKostenRuestung)
            {
                spieler.ruestung += 2;
                spieler.gold -= verbesserungsKostenRuestung;
                MessageBox.Show("Dein Rüstungs schutz wurde um +2 erhöht");
                spieler.anzahlAnGekaufteVerbesserungen_RuestungVerbessern++;
                UpdateUpgradeKosten();

                spieler.updateCharacterStatsUI(txtKlassenInfo);

            }
            else
            {
                MessageBox.Show("Du hast kein gold ");

            }

        }

        private void btnHeiltrankKaufen_Click(object sender, RoutedEventArgs e)
        {
            int heiltrankKosten = 30 + (spieler.anzahlAnUpgradesGekauftHeiltrank * 25);


            if (spieler.gold >= heiltrankKosten)
            {
                spieler.heiltrank = true;
                spieler.gold -= heiltrankKosten;
                MessageBox.Show("Du hast ein Heiltrank gekauft");
                spieler.anzahlAnUpgradesGekauftHeiltrank++;
                UpdateUpgradeKosten();

                spieler.updateCharacterStatsUI(txtKlassenInfo);

            }
            else if(spieler.heiltrank == true)
            {
                MessageBox.Show("Du hast bereits ein Heiltrank");
            }
            else
            {
                MessageBox.Show("Du hast kein gold ");

            }

        }

        private void btnHeilungKaufen_Click(object sender, RoutedEventArgs e)
        {
            int heilungsKosten = 20 + (spieler.anzahlAnUpgradesGekauftHeilung * 25);


            if (spieler.gold >= heilungsKosten && spieler.lebenspunkte != spieler.maxlebenspunkte)//
            {
                spieler.lebenspunkte = spieler.maxlebenspunkte;
                spieler.gold -= heilungsKosten;
                MessageBox.Show("Du wurdest geheilt");
                spieler.anzahlAnUpgradesGekauftHeilung++;
                UpdateUpgradeKosten();

                spieler.updateCharacterStatsUI(txtKlassenInfo);

            }
            else if(spieler.lebenspunkte == spieler.maxlebenspunkte && spieler.gold >= heilungsKosten)
            {
                MessageBox.Show("Du hast bereits volles leben");
            }
            else
            {
                MessageBox.Show("Du hast kein gold ");

            }

        }

        private void btnStartAbenteuer_Click(object sender, RoutedEventArgs e)
        {
            AbenteuerFenster abenteuerfenster = new AbenteuerFenster(spieler);
            abenteuerfenster.Show();
            this.Close();
        }


        private void UpdateUpgradeKosten()
        {
            int skillLevelPlusKostenStaerke = 200 + (spieler.anzahlAnGekaufteSkillLevelStaerke * 200);
            btnStaerke.Content = "Stärke Lvl+ [Erfahrung " + skillLevelPlusKostenStaerke + "]";

            int skillLevelPlusKostenKondition = 200 + (spieler.anzahlAnGekaufteSkillLevelKondition * 200);
            btnKondition.Content = "Kondition Lvl+ [Erfahrung " + skillLevelPlusKostenKondition + "]";

            int skillLevelPlusKostenVitalitet = 200 + (spieler.anzahlAnGekaufteSkillLevelVitalitet * 200);
            btnVitalitet.Content = "Vitalitet Lvl+ [Erfahrung " + skillLevelPlusKostenVitalitet + "]";

            int ruestungVerbessernKosten = 50 + (spieler.anzahlAnGekaufteVerbesserungen_RuestungVerbessern * 25);
            btnVerbessernRuestungKaufen.Content = "Rüstung Verbessern   (" + ruestungVerbessernKosten + " Gold)";

            int heiltrankKosten = 30 + (spieler.anzahlAnUpgradesGekauftHeiltrank * 25);
            btnHeiltrankKaufen.Content = "Heiltrank  Kaufen  (" + heiltrankKosten + " Gold)";
        }
    }
}
