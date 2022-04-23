<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StockManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="fonts/icomoon/style.css">
    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <!-- Style -->
    <link rel="stylesheet" href="css/style.css">

    <title>Login</title>
    <style>
        .caption {
            color: #b3b3b3;
            font-family: "Roboto", sans-serif;
            margin-left: 2%;
            font-size: 15px;
        }

        .errorMessage {
            color: red;
        }
        .btn-primary, .btn-primary:hover, .btn-primary:active{
            background-color: #494ca2 !important;
            border-color: #494ca2 !important;
        }
    </style>
</head>

<body>
    <div class="content">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6 contents">
                    <div class="row justify-content-center">
                        <div class="col-md-12">
                            <div class="form-block">
                                <form runat="server">
                                    <div class="mb-4 text-center">
                                        <h3>Stock Management System (Stonks)</h3>
                                    </div>
                                    <div class="form-group first">
                                        <label for="Email">
                                            Email
                                        </label>
                                        &nbsp;<asp:TextBox ID="Email" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group last mb-4">
                                        <label for="Password">Password</label>
                                        <asp:TextBox ID="Password" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="d-flex mb-3 align-items-center">

                                        <asp:CheckBox ID="IsAdmin" CssClass="checkBox" runat="server" />
                                        <span class="caption">Login as admin</span>

                                    </div>
                                    <div class="mb-2 ml-2">
                                        <asp:Label ID="ErrorMessage" CssClass="errorMessage" Text="" runat="server" />
                                    </div>

                                    <asp:Button ID="LoginButton" CssClass="btn btn-pill text-white btn-block btn-primary" runat="server" Text="Login" OnClick="LoginButton_Click" />
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="./js/jquery-3.3.1.min.js"></script>
    <script src="./js/main.js"></script>

</body>
</html>
