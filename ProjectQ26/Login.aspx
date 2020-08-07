<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectQ26.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Q26 Sports - Login</title>
    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
    <link rel="icon" href="img/q12-16.png" />
</head>

<body class="bg-gradient-dark">
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hiddenValue" />
        <div class="container">

            <!-- Outer Row -->
            <div class="row justify-content-center">

                <div class="col-xl-10 col-lg-12 col-md-9">

                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="row">
                                <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                                <div class="col-lg-6">
                                    <div class="p-5V2">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">Bienvenido!</h1>
                                        </div>
                                        <div class="user">
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtUser" CssClass="form-control form-control-user" placeholder="Usuario" onkeypress="return IsAlphaNumeric(event);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control form-control-user" placeholder="Password" TextMode="Password" onkeypress="return noBlankSpace(event);"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <form action="?" method="POST">
                                                    <div id="example3"></div>
                                                </form>
                                                <script src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit"
                                                    async defer>
                                                </script>
                                            </div>
                                            <div class="form-group" runat="server" id="divMsg" visible="false">
                                                <asp:Label runat="server" ID="lblMessage" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                            </div>
                                            <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-primary btn-user btn-block" Text="Login" OnClick="btnLogin_Click" />
                                        </div>
                                        <hr />
                                        <div class="text-center">
                                            <a class="small" href="forgot-password.html">Olvidaste tu Password?</a>
                                        </div>
                                        <div class="text-center">
                                            <a class="small" href="register.aspx">Registrar una Cuenta!</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            </div>

        </div>
    </form>
   
    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>

    <script type="text/javascript">

        var verifyCallback = function (response) {
            $('#<%=hiddenValue.ClientID%>').val(response);
        };

        var onloadCallback = function () {

            grecaptcha.render('example3', {
                //Usar en LocalHost
                sitekey': '6Lciv6UUAAAAALv0nGbMW2MR21imr9lQyPLtjcN4',
                //'sitekey': '6LezoLsZAAAAAPr-PJdTfjvXuDzwugotreOqm8kN',

                // Usar en Hosting
                //'sitekey': '6LdLpLsZAAAAANcwCppW1Bdo28dkkdxMOZ2EUQRA',
                'callback': verifyCallback,
            });
        };

        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        specialKeys.push(9); //Tab
        specialKeys.push(46); //Delete
        specialKeys.push(36); //Home
        specialKeys.push(35); //End
        specialKeys.push(37); //Left
        specialKeys.push(39); //Right

        function IsAlphaNumeric(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            //document.getElementById("error").style.display = ret ? "none" : "inline";
            return ret;
        }

        function noBlankSpace(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode != 32));
            //document.getElementById("error").style.display = ret ? "none" : "inline";
            return ret;
        }

        function nothingLetters(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            //document.getElementById("error").style.display = ret ? "none" : "inline";
            return ret;
        }

    </script>
</body>
</html>
