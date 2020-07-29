using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Xml.Linq;

namespace Utils
{
    public class Generico
    {

        public Generico()
        {

        }

        public static bool isNumeric(string numero)
        {
            double num;
            return Double.TryParse(numero, NumberStyles.Currency, CultureInfo.InvariantCulture, out num);
        }

        public static DateTime convertStringToDateTime(string strFecha, string format)
        {
            DateTime date = new DateTime();

            try
            {
                date = DateTime.ParseExact(strFecha, format, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return date;
        }

        public static UserPlayer usuarioRegistrado(System.Web.SessionState.HttpSessionState Session)
        {
            UserPlayer UserLogin = new UserPlayer();
            if (Session == null || Session["Player"] == null || String.IsNullOrEmpty(Session["Player"].ToString()))
            {
                System.Web.Security.FormsAuthentication.SignOut();
                System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                UserLogin = (UserPlayer)Session["Player"];
            }

            return UserLogin;
        }


    }
}