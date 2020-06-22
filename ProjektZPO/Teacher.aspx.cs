using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektZPO
{
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            menu.Controls.Add(new LiteralControl(String.Format("<h1>Witaj {0} {1}!</h1>", Login.admin.imie, Login.admin.nazwisko))); 
            foreach (Przedmiot pr in Login.admin.przedmioty)
            {
                LinkButton link = new LinkButton();
                link.Text = pr.nazwa;
                link.ID = pr.nazwa;
                link.Click += new EventHandler(Przedmiot_Click);
                Przedmioty.Controls.Add(link);
                Przedmioty.Controls.Add(new LiteralControl("<br />"));
            }
            if (przedmiot == null && Login.admin.przedmioty.Count > 0)
            {
                przedmiot = Login.admin.przedmioty[0].nazwa;
                info.Text = String.Format("<p>Przedmot: {0}</p>", przedmiot);
                ShowStudents();
            }
        }

        protected void logoff_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx", false);
        }

        protected void Przedmiot_Click(Object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            //Response.Write("<script>alert('"+button.Text+"');</script>");
            przedmiot = button.Text;
            info.Text = String.Format("<p>Przedmot: {0}</p>", przedmiot);
            ShowStudents();
        }

        public static String przedmiot;

        protected void Tab_Click(Object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.ID == "PStudenci")
            {
                ShowStudents();
            }
            if (button.ID == "PZadania")
            {
                ShowPytania();
            }
        }

        public void ShowStudents()
        {
            edit.Visible = false;
            lista.Items.Clear();
            foreach (Student st in Startup.students)
            {
                if (st.oceny.Exists(o => o.przedmiot.nazwa == przedmiot))
                    lista.Items.Add(st.imie + " " + st.nazwisko);
            }
        }

        public void ShowPytania()
        {
            edit.Visible = true;
            lista.Items.Clear();
            foreach (Pytanie pyt in Login.admin.przedmioty.Find(p => p.nazwa == przedmiot).pytania)
            {
                lista.Items.Add(pyt.tytul);
            }
        }

        protected void new_Click(object sender, EventArgs e)
        {
            if (edit.Visible)
            {
                EditQuestion.pytanie = new Pytanie();
                Login.admin.przedmioty.Find(p => p.nazwa == przedmiot).pytania.Add(EditQuestion.pytanie);
                Server.Transfer("EditQuestion.aspx", false);
                ShowPytania();
            }
            else
            {
                AddStudent.przedmiot = Login.admin.przedmioty.Find(p => p.nazwa == przedmiot);
                AddStudent.students = Startup.students;
                Server.Transfer("AddStudent.aspx", false);
                ShowStudents();
            }
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            List<Pytanie> pyt = Login.admin.przedmioty.Find(p => p.nazwa == przedmiot).pytania;
            int id = lista.SelectedIndex;
            EditQuestion.pytanie = pyt[id];
            Server.Transfer("EditQuestion.aspx", false);
            ShowPytania();
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            if (edit.Visible)
            {
                List<Pytanie> pyt = Login.admin.przedmioty.Find(p => p.nazwa == przedmiot).pytania;
                int id = lista.SelectedIndex;
                Pytanie pytanie = pyt[id];
                Login.admin.przedmioty.Find(p => p.nazwa == przedmiot).pytania.Remove(pytanie);
                lista.Items.RemoveAt(lista.SelectedIndex);
            }
            else
            {
                String stu = lista.SelectedItem.ToString();
                String imie = stu.Remove(stu.IndexOf(" "));
                String nazwisko = stu.Remove(0, stu.IndexOf(" ") + 1);
                Student student = null;
                foreach (Student st in Startup.students)
                {
                    if (st.oceny.Exists(o => (o.przedmiot.nazwa == przedmiot)) && st.imie == imie && st.nazwisko == nazwisko)
                        student = st;
                }
                lista.Items.RemoveAt(lista.SelectedIndex);
                student.oceny.Remove(student.oceny.Find(p => p.przedmiot.nazwa == przedmiot));
            }
        }

        protected void create_lesson_Click(object sender, EventArgs e)
        {
            przedmiot = null;
            Przedmiot pr = new Przedmiot();
            pr.nazwa = new_lesson.Text;
            Login.admin.przedmioty.Add(pr);
            Response.Write("<script>alert('Przedmiot dodany.');</script>");
            Response.Redirect(Request.RawUrl);
        }
    }
}