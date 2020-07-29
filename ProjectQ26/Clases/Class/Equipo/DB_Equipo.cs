using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;


public class DB_Equipo
{

    public DB_Equipo()
    {

    }

    public static List<Equipo> getEquipoLocalNewPartido(string idLiga, string idTorneo, string idJornada)
    {
        List<Equipo> EquipoDataList = new List<Equipo>();
        Equipo EquipoData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC getEquiposListNewPartidoLocal
                                @idLiga , @idTorneo , @idJornada
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idLiga", idLiga));
            ado.Comando.Parameters.Add(new SqlParameter("@idTorneo", idTorneo));
            ado.Comando.Parameters.Add(new SqlParameter("@idJornada", idJornada));
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                EquipoData = new Equipo
                {
                    idEquipo = Convert.ToInt32(reader["idEquipo"]),
                    EquipoName = Convert.ToString(reader["EquipoName"])
                };

                EquipoDataList.Add(EquipoData);
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

        return EquipoDataList;
    }


    public static List<Equipo> getEquipoVisitaNewPartido(string idLiga, string idTorneo, string idJornada, string idEquipo)
    {
        List<Equipo> EquipoDataList = new List<Equipo>();
        Equipo EquipoData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC getEquiposListNewPartidoVisita
                                @idLiga, @idTorneo, @idJornada, @idEquipo
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idLiga", idLiga));
            ado.Comando.Parameters.Add(new SqlParameter("@idTorneo", idTorneo));
            ado.Comando.Parameters.Add(new SqlParameter("@idJornada", idJornada));
            ado.Comando.Parameters.Add(new SqlParameter("@idEquipo", idEquipo));
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                EquipoData = new Equipo
                {
                    idEquipo = Convert.ToInt32(reader["idEquipo"]),
                    EquipoName = Convert.ToString(reader["EquipoName"])
                };

                EquipoDataList.Add(EquipoData);
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

        return EquipoDataList;
    }
}
