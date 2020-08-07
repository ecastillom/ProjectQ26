using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectQ26
{
    public partial class MasterPrincipal : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }
        void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);
                lblUserName.Text = Usuario.UserName;

                if (Usuario.idSecurityUser  == 1)
                {
                    ListAdmin.Visible = true;
                }
                else
                {
                    ListAdmin.Visible = false;
                }

                MenuLinks();
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect(System.Web.Security.FormsAuthentication.LoginUrl);
            System.Web.Security.FormsAuthentication.RedirectToLoginPage();
        }

        protected void MenuLinks()
        {
            hLnkLigaMx.NavigateUrl = "QuinielasGeneral.aspx?idSport=" + StringCipher.Encrypt("1") + "&idLiga=" + StringCipher.Encrypt("1");
            hLnkLaLiga.NavigateUrl = "QuinielasGeneral.aspx?idSport=" + StringCipher.Encrypt("1") + "&idLiga=" + StringCipher.Encrypt("2");
            hLnkPremier.NavigateUrl = "QuinielasGeneral.aspx?idSport=" + StringCipher.Encrypt("1") + "&idLiga=" + StringCipher.Encrypt("3");
            hLnkPremier.NavigateUrl = "QuinielasGeneral.aspx?idSport=" + StringCipher.Encrypt("1") + "&idLiga=" + StringCipher.Encrypt("3");
            hLnkPartidos.NavigateUrl = "Partidos.aspx";
            hLnKQuinielas.NavigateUrl = "Quinielas.aspx";
        }

    }
}