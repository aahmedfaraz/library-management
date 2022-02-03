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
            }
            catch
            {
            }
            loadStudentsGridView();
            loadBooksGridView();
            loadAdminGridView();
            loadLibrarianGridView();
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Login.userEmail = "";
            SignUp.userEmail = "";
            userEmail2 = "";
            Response.Redirect("Login.aspx");
        }
        public void loadStudentsGridView()
        {
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Persons where role='student'", con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            GridView1.DataSource = Dt;
            GridView1.DataBind();
        }

        public void clear_all()
        {
            id.Text = "";
            name2.Text = "";
            email2.Text = "";
            password2.Text = "";
            role2.SelectedValue = "student";

            bookID.Text = "";
            title.Text = "";
            author.Text = "";
            category.Text = "";
        }

        public void loadBooksGridView()
        {
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Books", con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            GridView2.DataSource = Dt;
            GridView2.DataBind();
        }

        public void loadAdminGridView()
        {
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Persons where role='admin'", con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            GridView3.DataSource = Dt;
            GridView3.DataBind();
        }

        public void loadLibrarianGridView()
        {
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Persons where role='librarian'", con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            GridView4.DataSource = Dt;
            GridView4.DataBind();
        }

        protected void add_Click(object sender, EventArgs e)
        {
            string name3 = name2.Text;
            string email3 = email2.Text;
            string password3 = password2.Text;
            string role3 = role2.SelectedValue;

            string title2 = title.Text;
            string author2 = author.Text;
            string category2 = category.Text;

            if(name3 != "" && title2 != "")
            {
                // Perform on Both
                if(name3 != "" && email3 != "" && password3 != "")
                {
                    // All Data is provided
                    try
                    {
                        // Find Email
                        SqlCommand comm1 = new SqlCommand("select Count(email) from Persons where email=@email", con);
                        con.Open();
                        comm1.Parameters.AddWithValue("@email", email3);
                        int numberOfMatches = (int)comm1.ExecuteScalar();
                        con.Close();
                        if (numberOfMatches == 0)
                        {
                            // Add Person
                            SqlCommand comm2 = new SqlCommand("Insert into Persons values (@name, @email, @password, @role)", con);
                            con.Open();
                            comm2.Parameters.AddWithValue("@name", name3);
                            comm2.Parameters.AddWithValue("@email", email3);
                            comm2.Parameters.AddWithValue("@password", password3);
                            comm2.Parameters.AddWithValue("@role", role3);
                            comm2.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Email Already Exist");
                        }
                    }
                    catch
                    {
                    }
                }


                if (title2 != "" && author2 != "" && category2 != "")
                {
                    // All Data is provided
                    try
                    {
                        // Add Person
                        SqlCommand comm2 = new SqlCommand("Insert into Books values (@title, @author, @category, 'true')", con);
                        con.Open();
                        comm2.Parameters.AddWithValue("@title", title2);
                        comm2.Parameters.AddWithValue("@author", author2);
                        comm2.Parameters.AddWithValue("@category", category2);
                        comm2.ExecuteNonQuery();
                        con.Close();
                    }
                    catch
                    {
                    }
                }
            } else if (title2 != "")
            {
                // Perform on Book
                if (title2 != "" && author2 != "" && category2 != "")
                {
                    // All Data is provided
                    try
                    {
                        // Add Person
                        SqlCommand comm2 = new SqlCommand("Insert into Books values (@title, @author, @category, 'true')", con);
                        con.Open();
                        comm2.Parameters.AddWithValue("@title", title2);
                        comm2.Parameters.AddWithValue("@author", author2);
                        comm2.Parameters.AddWithValue("@category", category2);
                        comm2.ExecuteNonQuery();
                        con.Close();
                    }
                    catch
                    {
                    }
                }
            } else if (name3 != "")
            {
                // Perform on Person
                if (name3 != "" && email3 != "" && password3 != "")
                {
                    // All Data is provided
                    try
                    {
                        // Find Email
                        SqlCommand comm1 = new SqlCommand("select Count(email) from Persons where email=@email", con);
                        con.Open();
                        comm1.Parameters.AddWithValue("@email", email3);
                        int numberOfMatches = (int)comm1.ExecuteScalar();
                        con.Close();
                        if (numberOfMatches == 0)
                        {
                            // Add Person
                            SqlCommand comm2 = new SqlCommand("Insert into Persons values (@name, @email, @password, @role)", con);
                            con.Open();
                            comm2.Parameters.AddWithValue("@name", name3);
                            comm2.Parameters.AddWithValue("@email", email3);
                            comm2.Parameters.AddWithValue("@password", password3);
                            comm2.Parameters.AddWithValue("@role", role3);
                            comm2.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Email Already Exist");
                        }
                    }
                    catch
                    {
                    }
                }
            } else
            {
                MessageBox.Show("No Data Found For Person or Book to Create.");
            }
            loadStudentsGridView();
            loadBooksGridView();
            loadAdminGridView();
            loadLibrarianGridView();
            clear_all();
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            string pID = id.Text;
            string bID = bookID.Text;
            if(pID != "" && bID != "")
            {
                // Perform On Both
                // Dek Person ID
                SqlCommand comm1 = new SqlCommand("delete from Persons where personId=@personId", con);
                comm1.Parameters.AddWithValue("@personId", pID);
                con.Open();
                comm1.ExecuteNonQuery();
                con.Close();
                // Del Book ID
                SqlCommand comm2 = new SqlCommand("delete from Books where bookId=@bookId", con);
                comm2.Parameters.AddWithValue("@bookId", bID);
                con.Open();
                comm2.ExecuteNonQuery();
                con.Close();
            } else if (bID != "")
            {
                // Del Book ID
                SqlCommand comm2 = new SqlCommand("delete from Books where bookId=@bookId", con);
                comm2.Parameters.AddWithValue("@bookId", bID);
                con.Open();
                comm2.ExecuteNonQuery();
                con.Close();
            } else if (pID != "")
            {
                // Dek Person ID
                SqlCommand comm1 = new SqlCommand("delete from Persons where personId=@personId", con);
                comm1.Parameters.AddWithValue("@personId", pID);
                con.Open();
                comm1.ExecuteNonQuery();
                con.Close();
            } else
            {
                MessageBox.Show("Provide any ID of Book or Person or Both.");
            }
            loadStudentsGridView();
            loadBooksGridView();
            loadAdminGridView();
            loadLibrarianGridView();
            clear_all();
        }

        protected void update_Click(object sender, EventArgs e)
        {
            string pID = id.Text;
            string name3 = name2.Text;
            string email3 = email2.Text;
            string password3 = password2.Text;
            string role3 = role2.SelectedValue;

            string bID = bookID.Text;
            string title2 = title.Text;
            string author2 = author.Text;
            string category2 = category.Text;

            if (pID != "" && bID != "")
            {
                // Perform on Both
                if (name3 != "" && email3 != "" && password3 != "")
                {
                    // All Data is provided
                    try
                    {
                        // Find Person
                        SqlCommand comm1 = new SqlCommand("select Count(personId) from Persons where personId=@personId", con);
                        con.Open();
                        comm1.Parameters.AddWithValue("@personId", pID);
                        int numberOfMatches = (int)comm1.ExecuteScalar();
                        con.Close();
                        if (numberOfMatches == 1)
                        {
                            // Update Person
                            SqlCommand comm2 = new SqlCommand("Update Persons set name=@name, email=@email, password=@password, role=@role where personId=@personId", con);
                            con.Open();
                            comm2.Parameters.AddWithValue("@personId", pID);
                            comm2.Parameters.AddWithValue("@name", name3);
                            comm2.Parameters.AddWithValue("@email", email3);
                            comm2.Parameters.AddWithValue("@password", password3);
                            comm2.Parameters.AddWithValue("@role", role3);
                            comm2.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Person Does not Exist");
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Some Credentials are missing of Person.");
                }


                if (title2 != "" && author2 != "" && category2 != "")
                {
                    // All Data is provided
                    try
                    {
                        // Find Book
                        SqlCommand comm1 = new SqlCommand("select Count(bookId) from Books where bookId=@bookId", con);
                        con.Open();
                        comm1.Parameters.AddWithValue("@bookId", bID);
                        int numberOfMatches = (int)comm1.ExecuteScalar();
                        con.Close();
                        if (numberOfMatches == 1)
                        {
                            // Update Book
                            SqlCommand comm2 = new SqlCommand("update Books set title=@title, author=@author, category=@category where bookId=@bookId", con);
                            con.Open();
                            comm2.Parameters.AddWithValue("@bookId", bID);
                            comm2.Parameters.AddWithValue("@title", title2);
                            comm2.Parameters.AddWithValue("@author", author2);
                            comm2.Parameters.AddWithValue("@category", category2);
                            comm2.ExecuteNonQuery();
                            con.Close();
                            comm2.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Book Does not Exist");
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Some Credentials are missing of Book.");
                }
            }
            else if (bID != "")
            {
                if (title2 != "" && author2 != "" && category2 != "")
                {
                    // All Data is provided
                    try
                    {
                        // Find Book
                        SqlCommand comm1 = new SqlCommand("select Count(bookId) from Books where bookId=@bookId", con);
                        con.Open();
                        comm1.Parameters.AddWithValue("@bookId", bID);
                        int numberOfMatches = (int)comm1.ExecuteScalar();
                        con.Close();
                        if (numberOfMatches == 1)
                        {
                            // Update Book
                            SqlCommand comm2 = new SqlCommand("update Books set title=@title, author=@author, category=@category where bookId=@bookId", con);
                            con.Open();
                            comm2.Parameters.AddWithValue("@bookId", bID);
                            comm2.Parameters.AddWithValue("@title", title2);
                            comm2.Parameters.AddWithValue("@author", author2);
                            comm2.Parameters.AddWithValue("@category", category2);
                            comm2.ExecuteNonQuery();
                            con.Close();
                            comm2.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Book Does not Exist");
                        }
                    }
                    catch
                    {
                    }
                } else
                {
                    MessageBox.Show("Some Credentials are missing of Book.");
                }
            }
            else if (pID != "")
            {
                // Perform on Both
                if (name3 != "" && email3 != "" && password3 != "")
                {
                    // All Data is provided
                    try
                    {
                        // Find Person
                        SqlCommand comm1 = new SqlCommand("select Count(personId) from Persons where personId=@personId", con);
                        con.Open();
                        comm1.Parameters.AddWithValue("@personId", pID);
                        int numberOfMatches = (int)comm1.ExecuteScalar();
                        con.Close();
                        if (numberOfMatches == 1)
                        {
                            // Add Person
                            SqlCommand comm2 = new SqlCommand("Update Persons set name=@name, email=@email, password=@password, role=@role where personId=@personId", con);
                            con.Open();
                            comm2.Parameters.AddWithValue("@personId", pID);
                            comm2.Parameters.AddWithValue("@name", name3);
                            comm2.Parameters.AddWithValue("@email", email3);
                            comm2.Parameters.AddWithValue("@password", password3);
                            comm2.Parameters.AddWithValue("@role", role3);
                            comm2.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Person Does not Exist");
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Some Credentials are missing of Person.");
                }
            }
            else
            {
                MessageBox.Show("Provide any ID and Data to Update.");
            }
            loadStudentsGridView();
            loadBooksGridView();
            loadAdminGridView();
            loadLibrarianGridView();
            clear_all();
        }
    }
}