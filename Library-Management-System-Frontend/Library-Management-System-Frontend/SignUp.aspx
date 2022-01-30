<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Library_Management_System_Frontend.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Library System | Ahmed & Saba</title>
    <style>
        * {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
        }
        body {
            font-family: 'Century Gothic';
            position: relative;
        }

        .screen {
            position: relative;
            width: 100vw;
            height: 100vh;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
        }

        .screen::before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            width: 100vw;
            height: 100vh;
            background-image: url('./images/bg.jpg');
            background-position: center;
            background-size: cover;
            z-index: -10;
            filter: blur(3px);
        }

        .navbar {
            background: linear-gradient(to bottom, #5D00FF, #290070);
            color: white;
            width: 100vw;
            height: 15vh;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
        }
        .form-container {
            width: 100vw;
            height: 80vh;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            margin: 20px;
        }

        .form {
            width: 400px;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            border-radius: 10px;
            box-shadow: 0 0 5px white;
            overflow: hidden;
            background-color: white;
        }
        .form > h2 {
            background-color: black;
            color: white;
            width: 100%;
            text-align: center;
            padding: 10px;
        }
        .form-control {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            padding: 10px;
            width: 100%;
            background-color: red;
        }

        .form-control label {
            background-color: red;
        }

        .footer {
            background: linear-gradient(to bottom, #5D00FF, #290070);
            color: white;
            width: 100vw;
            height: 5vh;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
        }


        .btn {
            background: linear-gradient(to bottom, #5D00FF, #290070);
            color: white;
            border: 0;
            border-radius: 5px;
            padding: 10px 30px;
            margin: 5px auto;
            cursor: pointer;
        }

        .btn:active {
            transform: scale(0.95);
        }

        .flex-center {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            width: 100%;
        }

        .button-center {
            text-align: center;
        }

        table td {
            padding: 5px 10px;
        }
    </style>
</head>
<body>
    <form id="form2" class="screen" runat="server">
        <div class="navbar">
            <h1>Library Management System</h1>
        </div>
        <div class="form-container">
            <div class="form">
                <h2>Register</h2>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="name" runat="server" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Email"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="email" runat="server" TextMode="Email" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Role"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="role" runat="server" Width="100%">
                                <asp:ListItem runat="server" Value="student">Student</asp:ListItem>
                                <asp:ListItem runat="server" Value="librarian">Librarian</asp:ListItem>
                                <asp:ListItem runat="server" Value="admin">Admin</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="password" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Confirm Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="password2" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="button-center">
                            <asp:Button ID="SignUpButton" CssClass="btn" runat="server" Text="Sign Up" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td class="flex-center">
                            <p>Already have an Account? <a href="Login.aspx">Login Yourself</a></p>
                        </td>
                    </tr>
                    <tr>
                        <td class="flex-center">
                            <asp:Label ID="message" runat="server" Font-Size="12px" Font-Bold="true" ForeColor="Red" Text="Instruction: Any Message will be shown here."></asp:Label>
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
