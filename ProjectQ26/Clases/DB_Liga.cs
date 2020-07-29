using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;

public class DB_Liga
{

    public DB_Liga()
    {

    }


    public static List<Liga> getLigaList(string idSport)
    {
        List<Liga> LigaDataList = new List<Liga>();
        Liga LigaData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" SELECT L.idLiga, L.LigaName FROM Ligas AS L
                                JOIN SportsLigas AS SL ON SL.idLiga = L.idLiga
                                 WHERE L.Active = 1 AND SL.idSport = @idSportPar
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idSportPar", idSport));
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                LigaData = new Liga
                {
                    idLiga = Convert.ToInt32(reader["idLiga"]),
                    LigaName = Convert.ToString(reader["LigaName"])
                };

                LigaDataList.Add(LigaData);
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

        return LigaDataList;
    }

}