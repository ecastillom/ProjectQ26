using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;

public class DB_Login
{
    public DB_Login()
    {

    }

    public static Generico validarUsuario(string usuario, string password)
    {
        Generico generico = new Generico();
        Utils.adoDAL ado = new Utils.adoDAL();
        UserPlayer Usuario = new UserPlayer();
        int idUser;

        try
        {
            ado.Conectar();
            ado.CrearComando(@" IF EXISTS (SELECT UserName FROM Users WHERE UPPER(UserName) = UPPER(@UserName))
                                    BEGIN
                                        SELECT idUser AS VALUE FROM Users WHERE UPPER(UserName) = UPPER(@UserName)
                                    END
                                ELSE
                                    BEGIN
                                        SELECT 0 AS VALUE
                                    END
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@UserName", usuario));
            DbDataReader reader = ado.EjecutarConsulta();

            if (reader.HasRows)
            {
                reader.Read();
                if (Convert.ToInt16(reader["VALUE"]) == 0)
                {
                    generico.existeError = true;
                    generico.mensaje = "Usuario No Existe";
                }
                else
                {
                    idUser = Convert.ToInt16(reader["VALUE"]);
                    reader.Close();
                    ado.CrearComando(@" SELECT U.idUser, U.UserName, U.FirstName, U.LastName, U.DateOfBirth, U.Email, U.idSecurityUser, U.Active, SU.SecurityUserDescr
                                        FROM Users AS U 
                                        JOIN SecurityUser SU 
                                        ON SU.idSecurityUser = U.idSecurityUser 
                                        WHERE idUser = @idUser ");
                    ado.Comando.Parameters.Add(new SqlParameter("@idUser", idUser));
                    reader = ado.EjecutarConsulta();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        Usuario.idUser = Convert.ToInt32(reader["idUser"]);
                        Usuario.UserName = Convert.ToString(reader["UserName"]);
                        Usuario.FirstName = Convert.ToString(reader["FirstName"]);
                        Usuario.LastName = Convert.ToString(reader["LastName"]);
                        Usuario.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                        Usuario.Email = Convert.ToString(reader["Email"]);
                        Usuario.Active = Convert.ToBoolean(reader["Active"]);
                        Usuario.idSecurityUser = Convert.ToInt32(reader["idSecurityUser"]);
                        Usuario.SecurityUserDescr = Convert.ToString(reader["SecurityUserDescr"]);
                        //suario.UserPassword = Convert.ToString(reader["UserPassword"]);
                        generico.obj = Usuario;
                    }
                }

            }
            else
            {
                generico.existeError = true;
                generico.mensaje = "Usuario No Existe";
            }


        }
        catch (SqlException sqlEx)
        {
            generico.existeError = true;
            generico.mensaje = sqlEx.Message;
        }
        catch (Exception ex)
        {
            generico.existeError = true;
            generico.mensaje = ex.Message;
        }
        finally
        {
            ado.Desconectar();
        }

        return generico;
    }
}
