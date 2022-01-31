<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibrarianPortal.aspx.cs" Inherits="Library_Management_System_Frontend.LibrarianPortal" %>

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

        .main-card > h2 {
            padding: 5px;
        }

        .text-input {
            width: 50%;
            padding: 5px;
            margin: 5px 0;
        }

        .logout {
            position: absolute;
            right: 0;
            margin-right: 10px;
            background: linear-gradient(to bottom, #ff2b2b, #b80000)
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
                <h1>Librarian Portal</h1>
                <div class="intro">
                    <h2>Hi <asp:Label ID="name" runat="server" Text="Ahmed"></asp:Label>!</h2>
                    <h2>Email: <asp:Label ID="email" runat="server" Text="ahmed@gmail.com"></asp:Label></h2>
                </div>
                <h2>Students Req List</h2>
                <asp:GridView ID="StudentReqGridView" runat="server"></asp:GridView>
                <asp:TextBox ID="reqID" CssClass="text-input" runat="server">Enter Req ID to proceed</asp:TextBox>
                <asp:Button ID="issueButton" CssClass="btn" runat="server" Text="Issue Book" />
            </div>
        </div>
        <div class="footer">
            <p>&copy All rights are reserved | 2022 &reg</p>
        </div>
    </form>
</body>
</html>
