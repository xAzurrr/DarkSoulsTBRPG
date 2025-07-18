using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Souls_Game___NoahAzurNacar
{
    public class Ritter : GameCharacter
    {
        public Ritter(string _name) // name wird später von spieler erstelt
                : base(      _name, "Ritter", 300, 50, "Schwert", 30, 10, 0, 0, false) // 1)Name - 2)Klasse 3)Leben - 4)Ausdauer - 5)Waffe - 6)Schaden - 7)Rüstung - 8)Gold - 9)Erfahrungspunkte - 10)Hat Heilung
        {

        }
    }
}
