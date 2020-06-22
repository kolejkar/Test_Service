using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektZPO
{
    public partial class AddStudent : System.Web.UI.Page
    {

        public static List<Student> students;

        public static Przedmiot przedmiot;

        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (Student st in students)
            {
                if (!st.oceny.Exists(o => o.przedmiot.nazwa == przedmiot.nazwa))
                    listbox.Items.Add(st.imie + " " + st.nazwisko);
            }
        }

        protected void logoff_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx", false);
        }

        protected void add_Click(object sender, EventArgs e)
        {
            Ocena ocena = new Ocena();
            ocena.przedmiot = przedmiot;
            String stu = listbox.SelectedItem.ToString();
            String imie = stu.Remove(stu.IndexOf(" "));
            String nazwisko = stu.Remove(0, stu.IndexOf(" ") + 1);
            foreach (Student st in students)
            {
                if (st.imie == imie && st.nazwisko == nazwisko)
                    st.oceny.Add(ocena);
            }
            Server.Transfer("Teacher.aspx", false);
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Server.Transfer("Teacher.aspx", false);
        }
    }
}