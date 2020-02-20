using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektZPO
{
    public partial class Student1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (ocena != null)
                    ShowPrzedmiot();
                menu.Controls.Add(new LiteralControl(String.Format("<h1>Witaj {0} {1}!</h1>", Login.user.imie, Login.user.nazwisko)));
                foreach (Ocena ocena in Login.user.oceny)
                {
                    LinkButton link = new LinkButton();
                    link.Text = ocena.przedmiot.nazwa;
                    link.ID = ocena.przedmiot.nazwa;
                    link.Click += this.Przedmiot_Click;
                    Przedmioty.Controls.Add(link);
                }
        }

        protected void logoff_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx", false);
        }

        public static Ocena ocena;

        protected void Przedmiot_Click(Object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            ocena = Login.user.oceny.Find(o => o.przedmiot.nazwa == button.Text);
            Response.Redirect("Student.aspx");
        }

        private void ShowPrzedmiot()
        {
            Wynik.Controls.Clear();
            Wynik.Controls.Add(new LiteralControl(String.Format("<p>Predmiot: {0}\nOcena z testu: {1}</p>", ocena.przedmiot.nazwa, ocena.stopien)));
            Wynik.Controls.Add(new LiteralControl("<br>"));
            Button run = new Button();
            run.Text = "Rozpocznij test";
            run.ID = "run";
            run.Click += this.Run_Click;
            Wynik.Controls.Add(run);
        }

        protected void Run_Click(object sender, EventArgs e)
        {
            if (ocena.stopien == 0)
            {
                Pytanie1.finish = false;
                Pytanie1.maxPyt = 0;
                Pytanie1.random = new Random();
                Server.Transfer("Pytanie.aspx", false);
            }
        }
    }
}