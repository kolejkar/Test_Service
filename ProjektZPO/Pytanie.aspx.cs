using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektZPO
{
    public partial class Pytanie1 : System.Web.UI.Page
    {
        public static bool finish;

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!finish)
            {
                GenerujPytanie();
            }
            else
            {
                ShowResults();
            }
            menu.Controls.Add(new LiteralControl(String.Format("<h1>Witaj {0} {1}!</h1>", Login.user.imie, Login.user.nazwisko)));
        }

        private static int questionId;

        public static Random random;
        public static int maxPyt;

        public void GenerujPytanie()
        {
            Main.Controls.Clear();
            questionId = random.Next(Student1.ocena.przedmiot.pytania.Count);
            Pytanie pyt = Student1.ocena.przedmiot.pytania[questionId];
            Main.Controls.Add(new LiteralControl("<h2>"+pyt.tytul+"</h2>"));
            Main.Controls.Add(new LiteralControl("<br>"));
            if (pyt.GetMaxPoints() > 1)
            {
                for (int i = 0; i < pyt.pytania.Count; i++)
                {
                    CheckBox ncheckbox = new CheckBox();
                    ncheckbox.ID = "d_check_" + i.ToString();
                    ncheckbox.Text = pyt.pytania[i];
                    Main.Controls.Add(ncheckbox);
                    Main.Controls.Add(new LiteralControl("<br>"));
                }
            }
            else
            {
                for (int i = 0; i < pyt.pytania.Count; i++)
                {
                    RadioButton ncheckbox = new RadioButton();
                    ncheckbox.ID = "d_check_" + i.ToString();
                    ncheckbox.Text = pyt.pytania[i];
                    ncheckbox.GroupName = "d_group_" + questionId.ToString();
                    Main.Controls.Add(ncheckbox);
                    Main.Controls.Add(new LiteralControl("<br>"));
                }
            }
            Button nbutton = new Button();
            nbutton.ID = "d_apply_" + questionId.ToString();
            if (maxPyt < Student1.ocena.przedmiot.pytania.Count)
            {
                nbutton.Text = "Następne pytanie";
            }
            else
            {
                nbutton.Text = "Sprawdź test";
            }
            nbutton.Click += new System.EventHandler(Nbutton_Click);
            Main.Controls.Add(nbutton);
        }

        protected void Nbutton_Click(object sender, EventArgs e)
        {
            Pytanie pyt = Student1.ocena.przedmiot.pytania[questionId];
            if (pyt.GetMaxPoints() > 1)
            {
                for (int i = 0; i < pyt.pytania.Count; i++)
                {
                    CheckBox checkBox = (CheckBox)Main.FindControl("d_check_" + i.ToString());
                    if (checkBox.Checked && pyt.odp[i])
                    {
                        Student1.ocena.points++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < pyt.pytania.Count; i++)
                {
                    RadioButton checkBox = (RadioButton)Main.FindControl("d_check_" + i.ToString());
                    if (checkBox.Checked && pyt.odp[i])
                    {
                        Student1.ocena.points++;
                    }
                }

            }
            maxPyt++;
            if (maxPyt >= Student1.ocena.przedmiot.pytania.Count)
            {
                finish = true;
            }
            Response.Redirect("Pytanie.aspx");
        }

        protected void logoff_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx", false);
        }

        private void ShowResults()
        {
            int maxpoints = 0;
            foreach (Pytanie pytanie in Student1.ocena.przedmiot.pytania)
            {
                maxpoints += pytanie.GetMaxPoints();
            }
            Label nlabel = new Label();
            nlabel.ID = "d_label_" + questionId.ToString();
            nlabel.Text = "Uzyskałeś " + Student1.ocena.points.ToString() + " na " + maxpoints.ToString() + " punktów.";
            if (Student1.ocena.points == maxpoints)
            {
                Student1.ocena.stopien = 5;
            }
            else
            {
                Student1.ocena.stopien = 3;
            }
            Main.Controls.Add(nlabel);
            Main.Controls.Add(new LiteralControl("<br>"));
            Button button = new Button();
            button.ID = "finish";
            button.Text = "Zakończ";
            button.Click += new System.EventHandler(this.back_Click);
            Main.Controls.Add(button);
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Server.Transfer("Student.aspx", false);
        }
    }
}