using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_Frontend
{
    public partial class StudentPortal : System.Web.UI.Page
    {
        static string userEmail2 = null;
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
                // name.Text = userName;
                // email.Text = userEmail2;
            } catch { 
            }
            loadBooksGridView("");
            loadIssueReqGridView();
        }

        public void loadBooksGridView(string search)
        {
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Books where title like '%" + search + "%' or author like '%" + search + "%'", con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            booksListGridView.DataSource = Dt;
            booksListGridView.DataBind();
        }

        public void loadIssueReqGridView()
        {
            SqlDataAdapter Adp = new SqlDataAdapter("select * from IssueRequests where personId=" + userID, con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            MyIssueRequestsGridView.DataSource = Dt;
            MyIssueRequestsGridView.DataBind();
        }

        protected void search_TextChanged(object sender, EventArgs e)
        {
            loadBooksGridView(search.Text);
        }
    }
}