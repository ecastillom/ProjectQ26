using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
public class DB_Torneo
{

    public DB_Torneo()
    {

    }
    public static List<Torneo> getTorneoList(string idLiga)
    {
        List<Torneo> TorneoDataList = new List<Torneo>();
        Torneo TorneoData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" SELECT idTorneo, TorneoName FROM Torneos
                                 WHERE Active = 1 AND idLiga = @idLiga
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idLiga", idLiga));
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                TorneoData = new Torneo
                {
                    idTorneo = Convert.ToInt32(reader["idTorneo"]),
                    TorneoName = Convert.ToString(reader["TorneoName"])
                };

                TorneoDataList.Add(TorneoData);
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

        return TorneoDataList;
    }

}
