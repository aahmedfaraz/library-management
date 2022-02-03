using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Library_Management_System_Frontend
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AHMED\\FARAZSQLSERVER;Initial Catalog=saba;Integrated Security=True");
        public static string userEmail = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // If User is already Logged In then proceed to Login
            if (userEmail != "")
            {
                authorizeAndProceed(userEmail);
            }
            else if (SignUp.userEmail != "")
            {
                authorizeAndProceed(SignUp.userEmail);
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string emailInput = email.Text;
            string passowrdInput = password.Text;
            string roleInput = role.SelectedValue;
            if(emailInput.Length <= 30 && passowrdInput.Length <= 30)
            {
                if (emailInput != "" && passowrdInput != "")
                {
                    // Email and Password is Given
                    try
                    {
                        // Find Email
                        SqlCommand comm1 = new SqlCommand("select Count(email) from Persons where email=@email", con);
                        con.Open();
                        comm1.Parameters.AddWithValue("@email", emailInput);
                        int numberOfMatches = (int)comm1.ExecuteScalar();
                        con.Close();
                        if (numberOfMatches > 0)
                        {
                            // Get Password
                            SqlCommand comm2 = new SqlCommand("select password from Persons where email=@email", con);
                            con.Open();
                            comm2.Parameters.AddWithValue("@email", emailInput);
                            string password = (string)comm2.ExecuteScalar();
                            con.Close();
                            if (passowrdInput == password)
                            {
                                // Get Role
                                SqlCommand comm3 = new SqlCommand("select role from Persons where email=@email", con);
                                con.Open();
                                comm3.Parameters.AddWithValue("@email", emailInput);
                                string roleComm = (string)comm3.ExecuteScalar();
                                con.Close();
                                if (roleInput == roleComm)
                                {
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
                                    MessageBox.Show("Wrong Role Provided");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Wrong Password");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email Does not Exist");
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Some Credentials are missing");
                }
            }
            else
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
                } catch
                {
                }
            }
        }
    }
}