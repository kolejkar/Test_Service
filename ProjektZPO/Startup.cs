using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ProjektZPO.Startup))]

namespace ProjektZPO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        public Startup()
        {
            Init();
        }

        public void Init()
        {
            wykladowcy = new List<Wykladowca>();

            Wykladowca wykladowca = new Wykladowca();
            wykladowca.nazwisko = "Kowalski";
            wykladowca.imie = "Adam";
            wykladowca.email = "adakow@utp.edu.pl";
            wykladowca.haslo = "admin";

            Przedmiot przedmiot = new Przedmiot();
            przedmiot.nazwa = "Programowanie obiektowe";

            wykladowca.przedmioty.Add(przedmiot);
            wykladowcy.Add(wykladowca);

            students = new List<Student>();

            Student student = new Student();
            student.nr_indeksu = 11023;
            student.email = "jannow@utp.edu.pl";
            student.imie = "Jan";
            student.nazwisko = "Nowak";
            student.haslo = "1234";

            Ocena ocena = new Ocena();
            ocena.przedmiot = przedmiot;
            ocena.points = 0;

            student.oceny.Add(ocena);

            students.Add(student);

            student.nr_indeksu = 11024;
            student = new Student();
            student.email = "anikna@utp.edu.pl";
            student.imie = "Ania";
            student.nazwisko = "Knap";
            student.haslo = "1111";

            ocena = new Ocena();
            ocena.przedmiot = przedmiot;
            ocena.points = 0;

            student.oceny.Add(ocena);

            students.Add(student);

            student.nr_indeksu = 11026;
            student = new Student();
            student.email = "karnow@utp.edu.pl";
            student.imie = "Karol";
            student.nazwisko = "Nowak";
            student.haslo = "2222";

            students.Add(student);
        }

        public static List<Student> students;
        public static List<Wykladowca> wykladowcy;

    }
}
