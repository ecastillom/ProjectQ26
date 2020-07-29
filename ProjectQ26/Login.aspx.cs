using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProjectQ26
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                clearForm();
            }
            else
            {

            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            divMsg.Visible = false;
            Int64 TestParseUserNum = 0;

            if (String.IsNullOrEmpty(txtUser.Text))
            {
                txtUser.Focus();
                lblMessage.Text = "*Capturar Usuario!";
                divMsg.Visible = true;
            }
            else if (String.IsNullOrWhiteSpace(txtUser.Text))
            {
                txtUser.Text = String.Empty;
                txtUser.Focus();
                lblMessage.Text = "*Capturar Usuario!";
                divMsg.Visible = true;
            }
            else if (Int64.TryParse(txtUser.Text, out TestParseUserNum))
            {
                txtUser.Text = String.Empty;
                txtUser.Focus();
                lblMessage.Text = "*El Usuario no puede ser solo numeros";
                divMsg.Visible = true;
            }
            else if (txtUser.Text.Length > 15)
            {
                txtUser.Focus();
                lblMessage.Text = "*Usuario debe ser Max 15 Caracteres!";
                divMsg.Visible = true;
            }

            /****** END User *******/
            else if (String.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                lblMessage.Text = "*Capturar Password!";
                divMsg.Visible = true;
            }
            else if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = String.Empty;
                txtPassword.Focus();
                lblMessage.Text = "*Capturar Password!";
                divMsg.Visible = true;
            }
            else if (txtPassword.Text.Length < 8)
            {
                txtPassword.Text = String.Empty;
                txtPassword.Focus();
                lblMessage.Text = "*Password Min 8 Caracteres!";
                divMsg.Visible = true;
            }
            /****** END Password *******/

            /****** ReCaptcha *******/

            else if (String.IsNullOrEmpty(hiddenValue.Value))
            {
                lblMessage.Text = "*Pasar Prueba Recaptcha!";
                divMsg.Visible = true;
            }

            /****** END ReCaptcha *******/
            else
            {
                Generico generico = DB_Login.validarUsuario(txtUser.Text, txtPassword.Text);
                UserPlayer Usuario = generico.obj as UserPlayer;

                if (generico.existeError)
                {
                    txtUser.Text = String.Empty;
                    txtUser.Focus();
                    lblMessage.Text = "*Usuario No Existe!";
                    divMsg.Visible = true;

                }
                else if (Usuario.UserPassword == txtPassword.Text)
                {
                    txtPassword.Text = String.Empty;
                    txtPassword.Focus();
                    lblMessage.Text = "*Password Incorrecto!";
                    divMsg.Visible = true;

                }
                else
                {
                    Session.Add("Player", Usuario);
                    btnLogin.Enabled = false;
                    FormsAuthentication.RedirectFromLoginPage(String.Concat(txtUser.Text, ": ", Usuario.FirstName + " " + Usuario.LastName).ToUpper(), false);
                }
            }
        }

        private void clearForm()
        {
            divMsg.Visible = false;
            txtUser.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtUser.Focus();
        }
    }
}