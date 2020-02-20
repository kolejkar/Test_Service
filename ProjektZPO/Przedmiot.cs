using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZPO
{
    public class Przedmiot
    {
        public String nazwa;

        //public int Ocena ocena;
        ///public List<Student> studenci;
        public List<Pytanie> pytania;

        public Przedmiot()
        {
            pytania = new List<Pytanie>();

            Pytanie pyt = new Pytanie("Zaznacz odp1:");
            pyt.AddPytanie("Zla", false);
            pyt.AddPytanie("Dobra", true);
            pyt.AddPytanie("Zła nr 2", false);
            pytania.Add(pyt);
            pyt = new Pytanie("Zaznacz odp2:");
            pyt.AddPytanie("Tak", true);
            pyt.AddPytanie("Dobra", true);
            pyt.AddPytanie("Zła nr 2", false);
            pytania.Add(pyt);
            pyt = new Pytanie("Zaznacz odp3:");
            pyt.AddPytanie("Nie", false);
            pyt.AddPytanie("Tak", true);
            pyt.AddPytanie("Nie nr 2", false);
            pytania.Add(pyt);
        }
    }

    public class Ocena
    {
        public int stopien;
        public Przedmiot przedmiot;
        public int points;

        public Ocena()
        {
            stopien = 0;
        }
    }
}
