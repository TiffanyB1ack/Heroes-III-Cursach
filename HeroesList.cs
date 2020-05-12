using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{
    public class HeroesList
    {
        public int Number { get; set; }
        public string Castle { get; set; }
        public string Name { get; set; }
        public string Sex  { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public int AtakaB { get; set; }
        public int ZashitaB { get; set; }
        public int SilaMagiiB { get; set; }
        public int ZnanieB { get; set; }

        public string Sposobnost { get; set; }
        public string Navyki { get; set; }
        public string History { get; set; }
        public void piece(string line)
        {
        string[] parts = line.Split(';');  //Разделитель в CSV файле.
        Number = Convert.ToInt32(parts[0]);
        Castle = parts[1];
        Name = parts[2];
        Sex = parts[3];
        Class = parts[4];
        Race = parts[5];
        AtakaB = Convert.ToInt32(parts[6]);
        ZashitaB = Convert.ToInt32(parts[7]);
            SilaMagiiB = Convert.ToInt32(parts[8]);
            ZnanieB = Convert.ToInt32(parts[9]);
            Sposobnost = parts[10];
            Navyki = parts[11];
            History = parts[12];
        }
        public static List<HeroesList> ReadFile(string filename)
        {
            List<HeroesList> res = new List<HeroesList>();
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    HeroesList p = new HeroesList();
                    p.piece(line);
                    res.Add(p);
                }
            }

            return res;
        }
    }
}
