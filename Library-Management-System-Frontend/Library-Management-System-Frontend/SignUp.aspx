<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Library_Management_System_Frontend.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="global.css"/>
    <title>Library System | Ahmed & Saba</title>
</head>
<body>
    <form id="form2" class="screen" runat="server">
        <div class="navbar">
            <h1>Library Management System</h1>
        </div>
        <div class="form-container">
            <div class="form">
                <h2>SignUp</h2>
                <table>
                     <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label1" runat="server" Text="Name" ></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox Class="input" type="text" ID="TextBox1" runat="server" Placeholder="Enter Full Name"></asp:TextBox>
                        </td>
                    </tr>

                     <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label3" runat="server" Text="User Name"></asp:Label>
                         </td>
                        <td>
                            <asp:TextBox  Class="input" type="text" ID="TextBox2" runat="server" Placeholder="Enter Email"></asp:TextBox>
                         </td>
                    </tr>

                     <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                         </td>
                        <td>
                            <asp:TextBox ID="TextBox3" Class="input" type="password" runat="server" Placeholder="must be atleast 6 characters"></asp:TextBox>
                         </td>
                    </tr>

                     <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label4" runat="server" Text="Confirm Password"></asp:Label>
                         </td>
                        <td>
                            <asp:TextBox Class="input" type="text" ID="TextBox4" runat="server" Placeholder="Type Password Again"></asp:TextBox>
                         </td>
                    </tr>

                     <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label5" runat="server" Text="Category"></asp:Label>
                         </td>
                        <td>
                            <asp:DropDownList class="input" ID="DropDownList1" runat="server" Height="32px" Width="228px">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Student</asp:ListItem>
                                <asp:ListItem>Faculty</asp:ListItem>
                                <asp:ListItem>Admin</asp:ListItem>
                            </asp:DropDownList>
                         </td>
                    </tr>
                   
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="SignUpButton" BackColor="Black" BorderWidth="0" ForeColor="White" class="btn" runat="server" Text="SignUp" />
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2">
                            <p><b>Already have an account?  <a href="#">Login</a></b></p>
                        </td>

                    </tr>

                </table>
            </div>
        </div>
        <div class="footer">
            <p>&copy All rights are reserved | 2022 &reg</p>
        </div>
    </form>
</body>
</html>
