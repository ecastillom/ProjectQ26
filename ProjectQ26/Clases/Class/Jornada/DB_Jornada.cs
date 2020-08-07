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
            ado.CrearComando(@" SELECT J.idJornada, J.JornadaName FROM Jornadas J
                                 WHERE J.Active = 1 AND J.idTorneo = @idTorneo 
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

    public static List<Jornada> getJornadaListV2(string idTorneo)
    {
        List<Jornada> JornadaDataList = new List<Jornada>();
        Jornada JornadaData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" SELECT J.idJornada, J.JornadaName FROM Jornadas J
                                 WHERE J.Active = 1 AND J.idTorneo = @idTorneo AND J.idJornada NOT IN (SELECT QD.idJornada FROM QuinielasDetalle QD WHERE QD.idJornada = J.idJornada)
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
