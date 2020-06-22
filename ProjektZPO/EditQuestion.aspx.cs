using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektZPO
{
    public partial class EditQuestion : System.Web.UI.Page
    {
        public static Pytanie pytanie;

        protected void Page_Load(object sender, EventArgs e)
        {
            menu.Controls.Add(new LiteralControl(String.Format("<h1>Witaj {0} {1}!</h1>", Login.admin.imie, Login.admin.nazwisko)));
            this.question.Text = pytanie.tytul;
            LoadList();
        }

        private void LoadList()
        {
            //odp.Items.Clear();
            for (int i = 0; i < pytanie.pytania.Count; i++)
            {
                ListItem listItem = new ListItem(pytanie.pytania[i]);
                if (pytanie.odp[i])
                {
                    listItem.Attributes.Add("style", "background:GREEN");
                }
                else
                {
                    listItem.Attributes.Add("style", "background:WHITE");
                }
                this.odp.Items.Add(listItem);
            }
        }

        protected void logoff_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx", false);
        }

        protected void add_Click(object sender, EventArgs e)
        {
            ListItem listItem = new ListItem(result.Text);
            if (good.Checked)
            {
                listItem.Attributes.Add("style", "background:GREEN");
            }
            else
            {
                listItem.Attributes.Add("style", "background:#9dee79");
            }
            this.odp.Items.Add(listItem);
            odp.Items.Add(listItem);
            pytanie.pytania.Add(this.result.Text);
            pytanie.odp.Add(this.good.Checked);
            odp.Items.Clear();
            LoadList();
        }

        protected void del_Click(object sender, EventArgs e)
        {
            int id = odp.SelectedIndex;
            pytanie.pytania.RemoveAt(id);
            odp.Items.RemoveAt(id);
            odp.Items.Clear();
            LoadList();
        }

        protected void change_Click(object sender, EventArgs e)
        {
            id = odp.SelectedIndex;
            pytanie.odp[id] = !pytanie.odp[id];
            odp.Items.Clear();
            LoadList();
        }

        private static int id = 0;

        protected void back_Click(object sender, EventArgs e)
        {
            Server.Transfer("Teacher.aspx", false);
        }
    }
}