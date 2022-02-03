using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_Frontend
{
    public partial class AdminPortal : System.Web.UI.Page
    {
        static string userEmail2 = "";
        static int userID;
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AHMED\\FARAZSQLSERVER;Initial Catalog=saba;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Login.userEmail != "")
                {
                    userEmail2 = Login.userEmail;
                }
                if (SignUp.userEmail != "")
                {
                    userEmail2 = SignUp.userEmail;
                }
                SqlCommand comm1 = new SqlCommand("select personId from Persons where email=@email", con);
                con.Open();
                comm1.Parameters.AddWithValue("@email", userEmail2);
                userID = (int)comm1.ExecuteScalar();
                con.Close();
                SqlCommand comm2 = new SqlCommand("select name from Persons where email=@email", con);
                con.Open();
                comm2.Parameters.AddWithValue("@email", userEmail2);
                string userName = (string)comm2.ExecuteScalar();
                con.Close();
                name.Text = userName;
                email.Text = userEmail2;
                con.Close();
            }
            catch
            {
            }
        }
    }
}