using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektZPO
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                ViewState["LoginErrors" ] = 0;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            String log = Login1.UserName;
            String haslo = Login1.Password;

            if (Startup.students.Exists(s => s.email == log && s.haslo == haslo))
            {
                //ShowUserMenu(log);
                //Response.Write("<script>alert('Student: " + log +"')</script>");
                user = Startup.students.Find(s => s.email == log);
                Student1.ocena = null;
                Server.Transfer("Student.aspx", false);
            }
            else
            {
                if (Startup.wykladowcy.Exists(w => w.email == log && w.haslo == haslo))
                {
                    //ShowAdminMenu(log);
                    //Response.Write("<script>alert('Wykładowca: " + log + "')</script>");
                    admin = Startup.wykladowcy.Find(w => w.email == log);
                    Server.Transfer("Teacher.aspx", false);
                }
                else
                {
                    e.Authenticated = false;
                }
            }
        }

        public static Wykladowca admin;

        public static Student user;
    }
}