using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Souls_Game___NoahAzurNacar
{
    public class Samurai : GameCharacter
    {
        public Samurai(string _name) // name wird später von spieler erstelt
                : base(       _name, "Samurai", 250, 60, "Katana", 35, 5, 0, 0, false) // 1)Name - 2)Klasse 3)Leben - 4)Ausdauer - 5)Waffe - 6)Schaden - 7)Rüstung - 8)Gold - 9)Erfahrungspunkte - 10)Hat Heilung
        {

        }
    }
}
