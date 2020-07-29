using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;

public class DB_Jornada
{

    public DB_Jornada()
    {

    }

    public static List<Jornada> getJornadaList(string idTorneo)
    {
        List<Jornada> JornadaDataList = new List<Jornada>();
        Jornada JornadaData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" SELECT idJornada, JornadaName FROM Jornadas
                                 WHERE Active = 1 AND idTorneo = @idTorneo
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idTorneo", idTorneo));
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                JornadaData = new Jornada
                {
                    idJornada = Convert.ToInt32(reader["idJornada"]),
                    JornadaName = Convert.ToString(reader["JornadaName"])
                };

                JornadaDataList.Add(JornadaData);
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

        return JornadaDataList;
    }
}
