using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dark_Souls_Game___NoahAzurNacar
{
    public class Monster : GameCharacter
    {
        public Monster(string _name, int _lebenspunkte, double _ausdauer, string _waffe, int _schaden, int _ruestung) // Erscheint geändert mit 
                : base(       _name, "Monster",     _lebenspunkte,        _ausdauer,        _waffe,     _schaden,     _ruestung, 0, 0, false) // 1)Name - 2)Klasse 3)Leben - 4)Ausdauer - 5)Waffe - 6)Schaden - 7)Rüstung - 8)Gold - 9)Erfahrungspunkte - 10)Hat Heilung
        {

        }



        public void updateTxtGegnerStatsKampf(TextBlock txtGegnerStatsKampf)
        {
            txtGegnerStatsKampf.Text =  "Level: " + (level + 1) + "\n" +
                                        "Leben: " + lebenspunkte + "\n" +
                                        "Ausdauer: " + ausdauer + "\n" +
                                        "Waffe: " + waffe + " [" + schaden + "]" + "\n" +
                                        "Rüstung: [" + ruestung + "]" + "\n";
        }

    }
}
