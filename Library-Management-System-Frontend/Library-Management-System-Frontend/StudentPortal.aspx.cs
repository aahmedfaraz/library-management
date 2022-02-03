using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

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
                SqlCommand comm1 = new SqlCommand("select personId, name, email from Persons where email=@email", con);
                comm1.Parameters.AddWithValue("@email", userEmail2);
                con.Open();
                using (SqlDataReader rdr = comm1.ExecuteReader())
                {

                    if (rdr.HasRows)
                    {
                        rdr.Read(); // get the first row

                        userID = rdr.GetInt32(0);
                        name.Text = rdr.GetString(1);
                        email.Text = rdr.GetString(2);
                    }
                }
                con.Close();
            } catch { 
            }
            loadBooksGridView("");
            loadIssueReqGridView();
        }

        public void loadBooksGridView(string search)
        {
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Books where title like '%" + search + "%' or author like '%" + search + "%' or category like '%" + search + "%'", con);
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

        protected void logout_Click(object sender, EventArgs e)
        {
            Login.userEmail = "";
            SignUp.userEmail = "";
            userEmail2 = "";
            Response.Redirect("Login.aspx");
        }

        protected void issueButton_Click(object sender, EventArgs e)
        {
            string bookId = bookID.Text;
            if (bookId.Length < 4)
            {
                // Find Book
                SqlCommand comm1 = new SqlCommand("select Count(bookId) from Books where bookId=@bookId and availablility='true'", con);
                comm1.Parameters.AddWithValue("@bookId", bookId);
                con.Open();
                int numberOfMatches = (int)comm1.ExecuteScalar();
                con.Close();
                if(numberOfMatches == 1)
                {
                    // Add Issue Req
                    SqlCommand comm2 = new SqlCommand("Insert into IssueRequests values ('issued',@personId,@bookId)", con);
                    comm2.Parameters.AddWithValue("@personId", userID);
                    comm2.Parameters.AddWithValue("@bookId", bookId);
                    con.Open();
                    comm2.ExecuteNonQuery();
                    con.Close();
                    // Update Book Availability Status
                    SqlCommand comm3 = new SqlCommand("update books set availablility=@availablility where bookId=@bookId", con);
                    comm3.Parameters.AddWithValue("@availablility", "false");
                    comm3.Parameters.AddWithValue("@bookId", bookId);
                    con.Open();
                    comm3.ExecuteNonQuery();
                    con.Close();
                    loadBooksGridView("");
                    loadIssueReqGridView();
                    bookID.Text = "";
                } else
                {
                    MessageBox.Show("Book Does not exist.");
                    bookID.Text = "";
                }
            } else
            {
                MessageBox.Show("Invalid Data - Please provide valid Book ID");
                bookID.Text = "";
            }
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            string bookId = returningBookID.Text;
            if (bookId.Length < 4)
            {
                // Find Pending Book
                SqlCommand comm1 = new SqlCommand("select count(bookId) from IssueRequests where personId=@personId and bookId=@bookId and status='issued'", con);
                comm1.Parameters.AddWithValue("@personId", userID);
                comm1.Parameters.AddWithValue("@bookId", bookId);
                con.Open();
                int numberOfMatches = (int)comm1.ExecuteScalar();
                con.Close();
                if (numberOfMatches == 1)
                {
                    // Rem Issue Req
                    SqlCommand comm2 = new SqlCommand("delete from IssueRequests where bookId=@bookId", con);
                    comm2.Parameters.AddWithValue("@bookId", bookId);
                    con.Open();
                    comm2.ExecuteNonQuery();
                    con.Close();
                    // Update Book Availability Status
                    SqlCommand comm3 = new SqlCommand("update books set availablility=@availablility where bookId=@bookId", con);
                    comm3.Parameters.AddWithValue("@availablility", "true");
                    comm3.Parameters.AddWithValue("@bookId", bookId);
                    con.Open();
                    comm3.ExecuteNonQuery();
                    con.Close();
                    loadBooksGridView("");
                    loadIssueReqGridView();
                    returningBookID.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid ID - This Book is not valid to perform return.");
                    returningBookID.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Invalid Data - Please provide valid Book ID");
                returningBookID.Text = "";
            }
        }
    }
}