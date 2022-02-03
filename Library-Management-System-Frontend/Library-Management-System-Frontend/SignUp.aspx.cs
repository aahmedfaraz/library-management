using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows;

namespace Library_Management_System_Frontend
{
    public partial class SignUp : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AHMED\\FARAZSQLSERVER;Initial Catalog=saba;Integrated Security=True");
        public static string userEmail = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // If User is already Logged In then proceed to Login
            if(userEmail != "")
            {
                authorizeAndProceed(userEmail);
            } else if(Login.userEmail != "")
            {
                authorizeAndProceed(Login.userEmail);
            }
        }

        protected void signup_Click1(object sender, EventArgs e)
        {
            string nameInput = name.Text;
            string emailInput = email.Text;
            string passowrdInput = password.Text;
            string passowrdInput2 = password2.Text;
            string roleInput = role.SelectedValue;

            if(nameInput.Length <= 30 && emailInput.Length <= 30 && passowrdInput.Length <= 30)
            {
                if (nameInput != "" && emailInput != "" && passowrdInput != "" && passowrdInput2 != "")
                {
                    if (passowrdInput.Equals(passowrdInput2))
                    {
                        // All Data is provided
                        try
                        {
                            // Find Email
                            SqlCommand comm1 = new SqlCommand("select Count(email) from Persons where email=@email", con);
                            con.Open();
                            comm1.Parameters.AddWithValue("@email", emailInput);
                            int numberOfMatches = (int)comm1.ExecuteScalar();
                            con.Close();
                            if (numberOfMatches == 0)
                            {
                                // Add Person
                                SqlCommand comm2 = new SqlCommand("Insert into Persons values (@name, @email, @password, @role)", con);
                                con.Open();
                                comm2.Parameters.AddWithValue("@name", nameInput);
                                comm2.Parameters.AddWithValue("@email", emailInput);
                                comm2.Parameters.AddWithValue("@password", passowrdInput);
                                comm2.Parameters.AddWithValue("@role", roleInput);
                                comm2.ExecuteNonQuery();
                                con.Close();
                                userEmail = emailInput;
                                // Login
                                switch (roleInput)
                                {
                                    case "student":
                                        Response.Redirect("StudentPortal.aspx");
                                        break;
                                    case "librarian":
                                        Response.Redirect("LibrarianPortal.aspx");
                                        break;
                                    case "admin":
                                        Response.Redirect("AdminPortal.aspx");
                                        break;
                                    default:
                                        MessageBox.Show("There is something wrong with role");
                                        break;
                                }
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
                    else
                    {
                        MessageBox.Show("Passwords are not matching");
                    }
                }
                else
                {
                    MessageBox.Show("Some Credentials are missing");
                }
            } else
            {
                MessageBox.Show("Enter input less than 30 characters");
            }
        }

        public void authorizeAndProceed(string email)
        {
            if (email != "")
            {
                userEmail = email;
                try
                {
                    // Find Role
                    SqlCommand comm = new SqlCommand("", con);
                    con.Open();
                    string roleComm = (string)comm.ExecuteScalar();
                    // Login
                    switch (roleComm)
                    {
                        case "student":
                            Response.Redirect("StudentPortal.aspx");
                            break;
                        case "librarian":
                            Response.Redirect("LibrarianPortal.aspx");
                            break;
                        case "admin":
                            Response.Redirect("AdminPortal.aspx");
                            break;
                        default:
                            MessageBox.Show("There is something wrong with role");
                            break;
                    }
                }
                catch
                {
                }
            }
        }
    }
}