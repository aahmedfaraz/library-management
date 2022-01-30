<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Library_Management_System_Frontend.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="global.css"/>
    <title>Library System | Ahmed & Saba</title>
</head>
<body>
    <form id="form1" class="screen" runat="server">
        <div class="navbar">
            <h1>Library Management System</h1>
        </div>
        <div class="form-container">
            <div class="form">
                <h2>Login</h2>
                <table>
                   <tr>
                      <td class="auto-style1"> Email</td>
                      <td>
                          <asp:TextBox class="input" ID="name" runat="server" type="text"></asp:TextBox>
                      </td>
                         
                 </tr>

                <tr>
                      <td class="auto-style1"> Password</td>
                      <td>                        
                          <asp:TextBox class="input" ID="password"  runat="server" type="Password" ></asp:TextBox>   
                      </td>
                </tr>
                
                <tr>
                      <td class="auto-style1"> Select</td>
                      <td>
                          <asp:DropDownList ID="DropDownMenu" class="input" runat="server" Height="32px" Width="228px">
                              <asp:ListItem>select</asp:ListItem>
                              <asp:ListItem>Student</asp:ListItem>
                              <asp:ListItem>Faculty</asp:ListItem>
                              <asp:ListItem>Admin</asp:ListItem>
                          </asp:DropDownList>
                      </td>
                </tr>
                <tr>
                    <td colspan="2" >
                        <asp:Button ID="LoginButton" BackColor="Black" BorderWidth="0" ForeColor="White" class="btn" runat="server" Text="Login" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                     <p><b>Doesnot have any account? <a href="#">Register Yourself</a></b></p>
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
