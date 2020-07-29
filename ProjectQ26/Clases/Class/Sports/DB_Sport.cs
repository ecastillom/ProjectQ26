using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;

public class DB_Sport
{
    public DB_Sport()
    {

    }

    public static List<Sport> getSportList()
    {
        List<Sport> SportDataList = new List<Sport>();
        Sport SportData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" SELECT idSport, SportName FROM Sports 
                                 WHERE Active = 1
                            ");
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                SportData = new Sport
                {
                    idSport = Convert.ToInt32(reader["idSport"]),
                    SportName = Convert.ToString(reader["SportName"])
                };

                SportDataList.Add(SportData);
            }


        }
        catch (SqlException sqlEx)
        {

        }
        catch (Exception ex)
        {

        }
        finally
        {
            ado.Desconectar();
        }

        return SportDataList;
    }

}
