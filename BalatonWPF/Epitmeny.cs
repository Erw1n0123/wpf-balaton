using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonWPF
{
    internal class Epitmeny
    {
        public int adoszam { get; set; }
        public string utca { get; set; }
        public string hazszam { get; set; }
        public string adosav { get; set; }
        public int alapterulet { get; set; }

        public Epitmeny(string sor)
        {
            string[] splitted = sor.Split(' ');
            this.adoszam = int.Parse(splitted[0]);
            this.utca = splitted[1];
            this.hazszam = splitted[2];
            this.adosav = splitted[3];
            this.alapterulet = int.Parse(splitted[4]);
        }
    }
}
