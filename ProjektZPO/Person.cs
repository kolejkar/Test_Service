using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZPO
{
    public class Person
    {
        public String imie;
        public String nazwisko;
        public String email;
        public String haslo;
    }

    public class Student : Person
    {
        public int nr_indeksu;
        //public List<Przedmiot> przedmioty;
        public List<Ocena> oceny;

        public Student(int indeks)
        {
            //przedmioty = new List<Przedmiot>();
            oceny = new List<Ocena>();
            nr_indeksu = indeks;
        }

        public Student()
        {
            //przedmioty = new List<Przedmiot>();
            oceny = new List<Ocena>();
        }

        public Student(Person person, int indeks)
        {
            oceny = new List<Ocena>();
            imie = person.imie;
            nazwisko = person.nazwisko;
            email = person.email;
            haslo = person.haslo;
            nr_indeksu = indeks;
        }
    }

    public class Wykladowca : Person
    {
        public Wykladowca()
        {
            przedmioty = new List<Przedmiot>();
        }

        public Wykladowca(Person person)
        {
            przedmioty = new List<Przedmiot>();
            imie = person.imie;
            nazwisko = person.nazwisko;
            email = person.email;
            haslo = person.haslo;
        }

        public List<Przedmiot> przedmioty;

        public List<Przedmiot> PrzedmiotyStudenta(Student student)
        {
            List<Przedmiot> przedmioty = new List<Przedmiot>();

            foreach (Ocena ocena in student.oceny)
            {
                przedmioty.Add(ocena.przedmiot);
            }
            return przedmioty;
        }

        public void DodajStudenta(Student student, String przedmiot)
        {
            Ocena ocena = new Ocena();
            ocena.przedmiot = przedmioty.Find(p => p.nazwa == przedmiot);
            student.oceny.Add(ocena);
        }
    }
}
