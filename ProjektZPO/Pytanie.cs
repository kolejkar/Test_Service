using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZPO
{
    public class Pytanie
    {
        public List<String> pytania;
        public String tytul;
        public List<bool> odp;

        public Pytanie()
        {
            pytania = new List<string>();
            odp = new List<bool>();
        }

        public Pytanie(String title) : this()
        {
            tytul = title;
        }

        public void AddPytanie(String pyt, bool good)
        {
            pytania.Add(pyt);
            odp.Add(good);
        }

        public bool CheckAnswer(int id)
        {
            return odp[id];
        }

        public int GetMaxPoints()
        {
            int points = 0;
            foreach (bool answer in odp)
            {
                if (answer) points++;
            }
            return points;
        }
    }
}
