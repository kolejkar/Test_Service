using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektZPO
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CreateUser_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {

            Person person = new Person();
            person.email = Email.Text;
            person.imie = Name.Text;
            person.nazwisko = Surname.Text;
            person.haslo = Password.Text;
            if (Indeks.Text == "00000")
            {
                Startup.wykladowcy.Add(new Wykladowca(person));
            }
            else
            {
                int indeks = 0;
                int.TryParse(Indeks.Text, out indeks);
                Startup.students.Add(new Student(person, indeks));
            }
            //Server.Transfer("Login.aspx", false);
        }
    }
}