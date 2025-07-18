using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dark_Souls_Game___NoahAzurNacar
{
    public abstract class GameCharacter
    {
        public string   name;               
        public double   lebenspunkte;
        public double   ausdauer;
        public string   waffe;              
        public int      schaden;
        public int      ruestung;
        public int      gold;
        public int      erfahrungspunkte;
        public bool     heiltrank;
        public string   klasse;

        public double   maxlebenspunkte; // check damit (lebenspunkte) nicht über den maxiamlen wert über gehen kann beispiel du hast 250 leben und das ist aber auch zu gleich dein max leben dich dann aber heilst um 50 punkte würde man ohne diesen check 300 leben haben was aber nicht gewollt ist sonder man soll sih nur im window zwichen 0 und 250 bewegen
        public double   maxausdauer;     // Gleiches prinzip wie oben nur für ausdauer
        public int      bonusSchaden;    // hier wird der wert gespeichert der zum (schaden) hinzugefügt wird um ein zufälliges spiel erlebnis zu schaffen damit gegner und spieler nicht immer nur ihren main schaden runter ballern
        public int      gesamtSchaden;   // diese variable wird genutzt um (schaden) + (bonusSchaden) zusammen zurechnen
        public int      regenerierteAusdauer;


        public int      level;
        public int      gegnerGetoetet;
        public int      goldGewonnen;
        public int      erfahrungspunkteGewonnen;

        public int      lbSauberHaltenSpieler;
        public int      lbSauberHaltenGegner;


        // stats 
        public int anzahlAnGekaufteVerbesserungen_RuestungVerbessern;
        public int anzahlAnUpgradesGekauftHeiltrank;
        public int anzahlAnUpgradesGekauftHeilung;

        public int anzahlAnGekaufteSkillLevelStaerke;
        public int anzahlAnGekaufteSkillLevelKondition;
        public int anzahlAnGekaufteSkillLevelVitalitet;


        public GameCharacter(string _name, string _klasse, double _lebenspunkte, double _ausdauer, string _waffe, int _schaden, int _ruestung, int _gold, int _erfahrungspunkte, bool _heiltrank)
        {
            name                =   _name;
            klasse              =   _klasse;
            lebenspunkte        =   _lebenspunkte;
            ausdauer            =   _ausdauer;
            waffe               =   _waffe;
            schaden             =   _schaden;
            ruestung            =   _ruestung;     
            gold                =   _gold;
            erfahrungspunkte    =   _erfahrungspunkte;
            heiltrank           =   _heiltrank;
        }

        public void updateCharacterStatsUI(TextBlock txtKlassenInfo)
        {
            txtKlassenInfo.Text ="Name: " + name + "\n" +
                                 "Level: " + (level+1) + "\n" +
                                 "Klasse: " + klasse + "\n" +
                                 "Leben: " + lebenspunkte + "\n" +
                                 "Ausdauer: " + ausdauer + "\n" +
                                 "Waffe: " + waffe + " [" + schaden + "]" + "\n" +
                                 "Rüstung: [" + ruestung + "]" + "\n" +
                                 "Gold: " + gold + "\n" +
                                 "Erfahrungspunkte: " + erfahrungspunkte + "\n";
        }

        public void updateTxtSpielerStatsKampf(TextBlock txtSpielerStatsKampf)
        {
            txtSpielerStatsKampf.Text = "Level: " + (level+1) + "\n" +
                                        "Leben: " + lebenspunkte + "\n" +
                                        "Ausdauer: " + ausdauer + "\n" +
                                        "Waffe: " + waffe + " [" + schaden + "]" + "\n" +
                                        "Rüstung: [" + ruestung + "]" + "\n";
        }

    }
}
