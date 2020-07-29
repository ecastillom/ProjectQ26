using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Globalization;
using System.Text.RegularExpressions;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectQ26
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                clearForm();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            divMsg.Visible = false;
            DateTime TestParseDate = DateTime.Today;
            Int64 TestParseUserNum = 0;


            /****** First and Last Name  ******/
            if (String.IsNullOrEmpty(txtFirstName.Text))
            {
                txtFirstName.Focus();
                lblMessage.Text = "*Capturar Nombre!";
                divMsg.Visible = true;
            }
            else if (String.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                txtFirstName.Text = String.Empty;
                txtFirstName.Focus();
                lblMessage.Text = "*Capturar Nombre!";
                divMsg.Visible = true;
            }
            else if (Int64.TryParse(txtFirstName.Text, out TestParseUserNum))
            {
                txtFirstName.Text = String.Empty;
                txtFirstName.Focus();
                lblMessage.Text = "*El Nombre no puede ser solo numeros";
                divMsg.Visible = true;
            }
            else if (String.IsNullOrEmpty(txtLastName.Text))
            {
                txtLastName.Focus();
                lblMessage.Text = "*Capturar Apellido!";
                divMsg.Visible = true;
            }
            else if (String.IsNullOrWhiteSpace(txtLastName.Text))
            {
                txtLastName.Text = String.Empty; ;
                txtLastName.Focus();
                lblMessage.Text = "*Capturar Apellido!";
                divMsg.Visible = true;
            }
            else if (Int64.TryParse(txtLastName.Text, out TestParseUserNum))
            {
                txtLastName.Text = String.Empty;
                txtLastName.Focus();
                lblMessage.Text = "*El Apellido no puede ser solo numeros";
                divMsg.Visible = true;
            }

            /****** END First and Last Name  ******/


            /******  Date of Birth Conditions *******/
            else if (String.IsNullOrEmpty(txtDateOfBirth.Text))
            {
                txtDateOfBirth.Focus();
                lblMessage.Text = "*Capturar Fecha de Nacimiento!";
                divMsg.Visible = true;
            }
            else if (String.IsNullOrWhiteSpace(txtDateOfBirth.Text))
            {
                txtDateOfBirth.Text = String.Empty;
                txtDateOfBirth.Focus();
                lblMessage.Text = "*Capturar Fecha Nacimiento!";
                divMsg.Visible = true;
            }

            else if (DateTime.TryParse(txtDateOfBirth.Text, out TestParseDate) == false)
            {
                txtDateOfBirth.Text = String.Empty;
                txtDateOfBirth.Focus();
                lblMessage.Text = "*Formato de Fecha Incorrecto!";
                divMsg.Visible = true;
            }

            else if (TestParseDate > DateTime.Today.AddYears(-18))
            {
                txtDateOfBirth.Text = String.Empty;
                txtDateOfBirth.Focus();
                lblMessage.Text = "*Debes ser Mayor de Edad!";
                divMsg.Visible = true;
            }

            /****** END Date of Birth *******/

            /****** User *******/

            else if (String.IsNullOrEmpty(txtUser.Text))
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

            /****** Email *******/
            else if (String.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.Focus();
                lblMessage.Text = "*Capturar Email!";
                divMsg.Visible = true;
            }
            else if (String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = String.Empty;
                txtEmail.Focus();
                lblMessage.Text = "*Capturar Email!";
                divMsg.Visible = true;
            }
            else if (IsValidEmail(txtEmail.Text) == false)
            {
                txtEmail.Text = String.Empty;
                txtEmail.Focus();
                lblMessage.Text = "*Formato de Email Incorrecto!";
                divMsg.Visible = true;
            }

            /****** END Email *******/

            /****** Password *******/

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
            else if (txtPassword.Text.Length < 8 || txtPasswordRepeat.Text.Length < 8)
            {
                txtPassword.Text = String.Empty;
                txtPasswordRepeat.Text = String.Empty;
                txtPassword.Focus();
                lblMessage.Text = "*Password Min 8 Caracteres!";
                divMsg.Visible = true;
            }
            else if (String.IsNullOrEmpty(txtPasswordRepeat.Text))
            {
                txtPasswordRepeat.Focus();
                lblMessage.Text = "*Repetir Password!";
                divMsg.Visible = true;
            }
            else if (String.IsNullOrWhiteSpace(txtPasswordRepeat.Text))
            {
                txtPassword.Text = String.Empty;
                txtPassword.Focus();
                lblMessage.Text = "*Repetir Password!";
                divMsg.Visible = true;
            }
            else if (!(txtPassword.Text.ToUpper() == txtPasswordRepeat.Text.ToUpper()))
            {
                txtEmail.Text = String.Empty;
                txtEmail.Focus();
                lblMessage.Text = "*No Coinciden las Contraseñas!";
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
                int ResultSP = 0;
                SqlConnection SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Q26"].ConnectionString);
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd = new SqlCommand("usp_LoginPlayers", SqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
                sqlCmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;
                sqlCmd.Parameters.Add("@DateOfBirth", SqlDbType.VarChar).Value = txtDateOfBirth.Text;
                sqlCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUser.Text;
                sqlCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                sqlCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPasswordRepeat.Text;
                sqlCmd.Parameters.Add("@idSecurity", SqlDbType.Int).Value = 2;
                sqlCmd.Parameters.Add("@Value", SqlDbType.Int);
                sqlCmd.Parameters["@Value"].Direction = ParameterDirection.Output;

                try
                {
                    sqlCmd.Connection.Open();
                    sqlCmd.ExecuteNonQuery();

                    ResultSP = Convert.ToInt32(sqlCmd.Parameters["@Value"].Value);
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    sqlCmd.Connection.Close();
                }

                if(ResultSP == 2)
                {
                    lblMessage.Text = "*El Usuario " + txtUser.Text +" ya esta registrado";
                    txtUser.Text = String.Empty;
                    txtUser.Focus();
                    divMsg.Visible = true;
                }
                else if(ResultSP == 3)
                {
                    lblMessage.Text = "*El Email " + txtEmail.Text + " ya esta registrado";
                    txtEmail.Text = String.Empty;
                    txtEmail.Focus();
                    divMsg.Visible = true;
                }
                else if(ResultSP == 1)
                {
                    string userEncryp = StringCipher.Encrypt(txtUser.Text);
                    clearForm();
                    Response.Redirect("Login.aspx");
                }

            }


        }

        private void clearForm()
        {
            divMsg.Visible = false;
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtDateOfBirth.Text = String.Empty;
            txtUser.Text = String.Empty;
            txtDateOfBirth.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtPasswordRepeat.Text = String.Empty;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

    }
}