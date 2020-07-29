using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;

public class DB_Quiniela
{

    public DB_Quiniela()
    {

    }

    public static Quiniela getQuinielaData(string idSportPar, string idLigaPar)
    {
        Quiniela QuinielaData = new Quiniela();

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Quinielas_GetQuinielaByIdTorneoIdSportActiveAbierta
                                @idSport = @idSportPar, @idLiga = @idLigaPar
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idSportPar", idSportPar));
            ado.Comando.Parameters.Add(new SqlParameter("@idLigaPar", idLigaPar));
            DbDataReader reader = ado.EjecutarConsulta();

            if (reader.HasRows)
            {
                reader.Read();
                QuinielaData.idQuiniela = Convert.ToInt32(reader["idQuiniela"]);
                QuinielaData.QuinielaNo = Convert.ToString(reader["QuinielaNo"]);
                QuinielaData.Active = Convert.ToString(reader["Active"]);
                QuinielaData.idSport = Convert.ToInt32(reader["idSport"]);
                QuinielaData.SportName = Convert.ToString(reader["SportName"]);
                QuinielaData.SportNameShort = Convert.ToString(reader["SportNameShort"]);
                QuinielaData.idLiga = Convert.ToInt32(reader["idLiga"]);
                QuinielaData.LigaName = Convert.ToString(reader["LigaName"]);
                QuinielaData.LigaNameShort = Convert.ToString(reader["LigaNameShort"]);
                QuinielaData.LigaImgURL = Convert.ToString(reader["LigaImgURL"]);
                QuinielaData.idTorneo = Convert.ToInt32(reader["idTorneo"]);
                QuinielaData.TorneoName = Convert.ToString(reader["TorneoName"]);
                QuinielaData.TorneoNameShort = Convert.ToString(reader["TorneoNameShort"]);
                QuinielaData.idJornada = Convert.ToInt32(reader["idJornada"]);
                QuinielaData.JornadaName = Convert.ToString(reader["JornadaName"]);
                QuinielaData.JornadaNameShort = Convert.ToString(reader["JornadaNameShort"]);

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

        return QuinielaData;
    }

    public static List<Quiniela> getQuinielaPartidosByidQuiniela(string idQuinielaValue)
    {
        List<Quiniela> QuinielaDataList = new List<Quiniela>();
        Quiniela QuinielaData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Quinielas_GetPartidosByIdQuiniela
                                @idQuiniela = @idQuinielaValue
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idQuinielaValue", idQuinielaValue));
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                QuinielaData = new Quiniela
                {
                    idPartido = Convert.ToInt32(reader["idPartido"]),
                    PartidoDate = Convert.ToDateTime(reader["PartidoDate"]),
                    EquipoLocal = Convert.ToString(reader["EquipoLocal"]),
                    EquipoLocalShort = Convert.ToString(reader["EquipoLocalShort"]),
                    EquipoLocalImgURL = Convert.ToString(reader["EquipoLocalImgURL"]),
                    EquipoVisitante = Convert.ToString(reader["EquipoVisitante"]),
                    EquipoVisitanteShort = Convert.ToString(reader["EquipoVisitanteShort"]),
                    EquipoVisitanteImgURL = Convert.ToString(reader["EquipoVisitanteImgURL"])
                };
                
                QuinielaDataList.Add(QuinielaData);
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

        return QuinielaDataList;
    }

    public static string InsertQuinielaGetBoletoNo(string idQuinielaPar, string idUserPar, string OpcionesPar)
    {
        string ApuestaNo = "";
        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Quinielas_InsertApuestaByPlayer
                                @idQuiniela = @idQuinielaPar, @idUser = @idUserPar, @Opciones = @OpcionesPar
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idQuinielaPar", idQuinielaPar));
            ado.Comando.Parameters.Add(new SqlParameter("@idUserPar", idUserPar));
            ado.Comando.Parameters.Add(new SqlParameter("@OpcionesPar", OpcionesPar));
            DbDataReader reader = ado.EjecutarConsulta();

            if (reader.HasRows)
            {
                reader.Read();
                ApuestaNo = Convert.ToString(reader["ApuestaNo"]);

            }


        }
        catch (SqlException sqlEx)
        {
            ApuestaNo = "Error";
        }
        catch (Exception ex)
        {
            ApuestaNo = "Error";
        }
        finally
        {
            ado.Desconectar();
        }

        return ApuestaNo;
    }


}
