using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{   [Serializable]
    public class Player
    {
        public string Scenario { get; set; }
        public string NickName { get; set; }
        public string Color { get; set; }
       
        public string Points { get; set; }
        public string Level { get; set; }
        public string Time { get; set; }
        public List<Hero> Heros { get; set; }

        public int HeroC
        {

            get
            {
                if (Heros == null)
                    return 0;
                else return Heros.Count;
            }
        }
        public Player() { Heros = new List<Hero>(); }

        public Player(string sc, string nn, string clr,  string pnts, string lvl, string tm, List<Hero> heros)
        {
            Scenario = sc;
            NickName = nn;
            Color = clr;
            Points = pnts;
            Level = lvl;
            Time = tm;
            Heros = heros;
        }
       


    }
}

