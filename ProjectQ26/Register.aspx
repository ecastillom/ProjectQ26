<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjectQ26.Register" %>

<%@ Register Assembly="AjaxControlToolKit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Q26 Sports - Registrar</title>
    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
</head>
<body class="bg-gradient-dark">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="SriptMng1"></asp:ScriptManager>

        <asp:HiddenField runat="server" ID="hiddenValue" />
        <div class="container">

            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <!-- Nested Row within Card Body -->
                    <div class="row">
                        <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
                        <div class="col-lg-7">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Haz Una Cuenta!</h1>
                                </div>
                                <div class="user">

                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="form-group row">
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control form-control-user" placeholder="Nombre" onkeypress="return IsAlphaNumeric(event);"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-6">
                                                    <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control form-control-user" placeholder="Apellidos" onkeypress="return IsAlphaNumeric(event);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <asp:TextBox runat="server" ID="txtDateOfBirth" CssClass="form-control form-control-user" placeholder="Fecha Nacimiento" onkeypress="return nothingLetters(event);"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDateOfBirth" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                                </div>
                                                <div class="col-sm-6">
                                                    <asp:TextBox runat="server" ID="txtUser" CssClass="form-control form-control-user" placeholder="Usuario (Max 15 Caracteres)" MaxLength="15" onkeypress="return IsAlphaNumeric(event);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control form-control-user" placeholder="Email" onkeypress="return noBlankSpace(event);"></asp:TextBox>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control form-control-user" TextMode="Password" placeholder="Password (Min 8 Caracteres)" MaxLength="15" onkeypress="return noBlankSpace(event);"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-6">
                                                    <asp:TextBox runat="server" ID="txtPasswordRepeat" CssClass="form-control form-control-user" TextMode="Password" placeholder="Repetir Password" MaxLength="15" onkeypress="return noBlankSpace(event);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group" runat="server" id="divMsg" visible="false">
                                                <asp:Label runat="server" ID="lblMessage" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnRegister" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <div class="form-group">
                                        <form action="?" method="POST">
                                            <div id="example3"></div>
                                        </form>
                                        <script src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit"
                                            async defer>
                                        </script>
                                    </div>
                                    <asp:Button runat="server" ID="btnRegister" CssClass="btn btn-primary btn-user btn-block" Text="Registrar Cuenta" OnClick="btnRegister_Click" />
                                </div>
                                <hr />
                                <div class="text-center">
                                    <asp:HyperLink runat="server" ID="hlnkLogin" NavigateUrl="~/Login.aspx" CssClass="small">
                                        Ya tienes cuenta? Haz Login!
                                    </asp:HyperLink>
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
    <script src="https://www.google.com/recaptcha/api.js"></script>

    <script type="text/javascript">

        var verifyCallback = function (response) {
            $('#<%=hiddenValue.ClientID%>').val(response);
        };

        var onloadCallback = function () {

            grecaptcha.render('example3', {
                //Usar en LocalHost
                'sitekey': '6Lciv6UUAAAAALv0nGbMW2MR21imr9lQyPLtjcN4',
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
