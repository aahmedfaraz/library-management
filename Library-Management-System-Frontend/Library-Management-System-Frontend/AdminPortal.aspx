<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPortal.aspx.cs" Inherits="Library_Management_System_Frontend.AdminPortal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Library System | Faraz & Saba</title>
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
        .main-container {
            width: 100vw;
            height: 80vh;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            margin: 20px;
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

        .main-card {
            background-color: white;
            width: 80vw;
            height: 70vh;
            overflow-y: scroll;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .intro {
            width: 100%;
            display: flex;
            align-items: center;
            justify-content: space-between;
            padding: 10px;
            background-color: #4a00cc;
            color: white;
        }

        .intro h2 {
            font-weight: unset;
        }

        .main-card > h1 {
            padding: 10px;
        }

        .logout {
            position: absolute;
            right: 0;
            margin-right: 10px;
            background: linear-gradient(to bottom, #ff2b2b, #b80000)
        }

        .add {
            background: linear-gradient(to bottom, limegreen, green)
        }
        .update {
            background: linear-gradient(to bottom, dodgerblue, blue)
        }
        .delete {
            background: linear-gradient(to bottom, tomato, red)
        }

    </style>
</head>
<body>
    <form id="form1" runat="server" class="screen">
        <div class="navbar">
            <h1>FARAZ's Library Management System</h1>
            <asp:Button ID="logout" CssClass="btn logout" runat="server" Text="Logout" />
        </div>
        <div class="main-container">
            <div class="main-card">
                <h1>Admin Portal</h1>
                <div class="intro">
                    <h2>Hi <asp:Label ID="name" runat="server" Text="Ahmed"></asp:Label>!</h2>
                    <h2>Email: <asp:Label ID="email" runat="server" Text="ahmed@gmail.com"></asp:Label></h2>
                </div>
                <h2>Multi CRUD Form</h2>
                <table>
                    <tr>
                        <td><label>ID</label></td>
                        <td><asp:TextBox ID="id" Width="300px" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label>Name</label></td>
                        <td><asp:TextBox ID="personName" Width="300px" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label>Email</label></td>
                        <td><asp:TextBox ID="personEmail" Width="300px" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label>Password</label></td>
                        <td><asp:TextBox ID="personPassword" Width="300px" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label>Select Role</label></td>
                        <td>
                            <asp:DropDownList ID="role" Width="300px" runat="server">
                                <asp:ListItem runat="server" Value="student">Student</asp:ListItem>
                                <asp:ListItem runat="server" Value="librarian">Librarian</asp:ListItem>
                                <asp:ListItem runat="server" Value="admin">Admin</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><label>Book ID</label></td>
                        <td><asp:TextBox ID="bookID" Width="300px" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label>Title</label></td>
                        <td><asp:TextBox ID="bookTitle" Width="300px" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label>Author</label></td>
                        <td><asp:TextBox ID="bookAuthor" Width="300px" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label>Category</label></td>
                        <td><asp:TextBox ID="bookCategory" Width="300px" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="add" CssClass="btn add" runat="server" Text="Create" />
                            <asp:Button ID="update" CssClass="btn update" runat="server" Text="Update" />
                            <asp:Button ID="delete" CssClass="btn delete" runat="server" Text="Delete" />
                        </td>
                    </tr>
                </table>
                <h2>All Students</h2>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                <br />
                <h2>All Books</h2>
                <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                <br />
                <h2>All Admins</h2>
                <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                <br />
                <h2>All Librarians</h2>
                <asp:GridView ID="GridView4" runat="server"></asp:GridView>
                <br />
            </div>
        </div>
        <div class="footer">
            <p>&copy All rights are reserved | 2022 &reg</p>
        </div>
    </form>
</body>
</html>
