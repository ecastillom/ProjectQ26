using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text;

public class DB_Partido
{
    public DB_Partido()
    {

    }

    public static List<Partido> getPartidosByFilters(string idSport, string idLiga, string idTorneo, string idJornada)
    {
        List<Partido> PartidoDataList = new List<Partido>();
        Partido PartidoData;

        Utils.adoDAL ado = new Utils.adoDAL();
        StringBuilder strQry = new StringBuilder();
        StringBuilder strWhere = new StringBuilder("");
        StringBuilder strOrder = new StringBuilder(" ORDER BY S.idSport, L.idLiga, T.idTorneo, J.idJornada ");

        try
        {
            ado.Conectar();

            strQry.Append(" SELECT S.idSport, S.SportName, S.SportNameShort, L.idLiga, L.LigaName, L.LigaNameShort, T.idTorneo, T.TorneoName, ");
            strQry.Append(" T.TorneoNameShort, J.idJornada, J.JornadaName, J.JornadaNameShort, P.idPartido, P.PartidoDate, EL.idEquipo AS idEquipoLocal, EL.EquipoImgURL AS EquipoLocalImgURL,  ");
            strQry.Append(" EL.EquipoName AS EquipoLocal, EL.EquipoShort AS EquipoLocalShort, EV.idEquipo AS idEquipoVisitante, EV.EquipoImgURL AS EquipoVisitanteImgURL, EV.EquipoName AS EquipoVisitante,  ");
            strQry.Append(" EV.EquipoShort AS EquipoVisitanteShort, PR.idResultado, R.ResultadoName, R.ResultadoNameShort, PR.idGolesLocal, GL.GolNo AS GolesLocal, PR.idGolesVisitante, GV.GolNo AS GolesVisitante "); 
            strQry.Append(" FROM Sports S JOIN SportsLigas SL ON SL.idSport = S.idSport JOIN Ligas L ON SL.idLiga = L.idLiga JOIN Torneos T ");
            strQry.Append(" ON T.idLiga = L.idLiga JOIN Jornadas J ON J.idTorneo = T.idTorneo JOIN JornadasPartidos JP ON JP.idJornada = J.idJornada JOIN Partidos P  ");
            strQry.Append(" ON P.idPartido = JP.idPartido INNER JOIN Equipos AS EL ON P.idEquipoLocal = EL.idEquipo INNER JOIN Equipos AS EV ON P.idEquipoVisitante = EV.idEquipo ");
            strQry.Append(" INNER JOIN PartidosResultados PR ON PR.idPartido = P.idPartido INNER JOIN Resultado R ON R.idResultado = PR.idResultado INNER JOIN Goles GL ON GL.idGol = PR.idGolesLocal ");
            strQry.Append(" INNER JOIN Goles GV ON GV.idGol = PR.idGolesVisitante WHERE (S.Active = 1 AND L.Active = 1 AND T.Active = 1 AND J.Active = 1) ");

            if (!String.IsNullOrEmpty(idSport))
                strWhere.Append(" AND S.idSport = @idSport");

            if (!String.IsNullOrEmpty(idLiga))
                strWhere.Append(" AND L.idLiga = @idLiga");

            if (!String.IsNullOrEmpty(idTorneo))
                strWhere.Append(" AND T.idTorneo = @idTorneo");

            if (!String.IsNullOrEmpty(idJornada))
                strWhere.Append(" AND J.idJornada = @idJornada");

            ado.CrearComando(String.Concat(strQry.ToString(), strWhere.ToString(), strOrder.ToString()));

            if (!String.IsNullOrEmpty(idSport))
                ado.Comando.Parameters.Add(new SqlParameter("@idSport", idSport));

            if (!String.IsNullOrEmpty(idLiga))
                ado.Comando.Parameters.Add(new SqlParameter("@idLiga", idLiga));

            if (!String.IsNullOrEmpty(idTorneo))
                ado.Comando.Parameters.Add(new SqlParameter("@idTorneo", idTorneo));

            if (!String.IsNullOrEmpty(idJornada))
                ado.Comando.Parameters.Add(new SqlParameter("@idJornada", idJornada));
            
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                PartidoData = new Partido
                {
                    idSport = Convert.ToInt32(reader["idSport"]),
                    SportName = Convert.ToString(reader["SportName"]),
                    SportNameShort = Convert.ToString(reader["SportNameShort"]),
                    idLiga = Convert.ToInt32(reader["idLiga"]),
                    LigaName = Convert.ToString(reader["LigaName"]),
                    LigaNameShort = Convert.ToString(reader["LigaNameShort"]),
                    idTorneo = Convert.ToInt32(reader["idTorneo"]),
                    TorneoName = Convert.ToString(reader["TorneoName"]),
                    TorneoNameShort = Convert.ToString(reader["TorneoNameShort"]),
                    idJornada = Convert.ToInt32(reader["idJornada"]),
                    JornadaName = Convert.ToString(reader["JornadaName"]),
                    JornadaNameShort = Convert.ToString(reader["JornadaNameShort"]),
                    idPartido = Convert.ToInt32(reader["idPartido"]),
                    PartidoDate = Convert.ToDateTime(reader["PartidoDate"]),
                    idEquipoLocal = Convert.ToInt32(reader["idEquipoLocal"]),
                    EquipoLocal = Convert.ToString(reader["EquipoLocal"]),
                    EquipoLocalShort = Convert.ToString(reader["EquipoLocalShort"]),
                    EquipoLocalImgURL = Convert.ToString(reader["EquipoLocalImgURL"]),
                    idEquipoVisitante = Convert.ToInt32(reader["idEquipoVisitante"]),
                    EquipoVisitante = Convert.ToString(reader["EquipoVisitante"]),
                    EquipoVisitanteShort = Convert.ToString(reader["EquipoVisitanteShort"]),
                    EquipoVisitanteImgURL = Convert.ToString(reader["EquipoVisitanteImgURL"]),
                    idResultado = Convert.ToInt32(reader["idResultado"]),
                    ResultadoName = Convert.ToString(reader["ResultadoName"]),
                    ResultadoNameShort = Convert.ToString(reader["ResultadoNameShort"]),
                    idGolesLocal = Convert.ToInt32(reader["idGolesLocal"]),
                    GolesLocal = Convert.ToString(reader["GolesLocal"]),
                    idGolesVisitante = Convert.ToInt32(reader["idGolesVisitante"]),
                    GolesVisitante = Convert.ToString(reader["GolesVisitante"])
                };

                PartidoDataList.Add(PartidoData);
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

        return PartidoDataList;
    }

    public static string InsertPartidoGetidPartido(string idLiga, string idTorneo, string idJornada, string idEquipoLocal, string idEquipoVisita, string FechaPartido, string idUser)
    {
        string idApuesta = "";
        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Partido_InsertPartido
                                @idLiga, @idTorneo, @idJornada, @idEquipoLocal, @idEquipoVisita, @FechaPartido, @idUser
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idLiga", idLiga));
            ado.Comando.Parameters.Add(new SqlParameter("@idTorneo", idTorneo));
            ado.Comando.Parameters.Add(new SqlParameter("@idJornada", idJornada));
            ado.Comando.Parameters.Add(new SqlParameter("@idEquipoLocal", idEquipoLocal));
            ado.Comando.Parameters.Add(new SqlParameter("@idEquipoVisita", idEquipoVisita));
            ado.Comando.Parameters.Add(new SqlParameter("@FechaPartido", FechaPartido));
            ado.Comando.Parameters.Add(new SqlParameter("@idUser", idUser));
            DbDataReader reader = ado.EjecutarConsulta();

            if (reader.HasRows)
            {
                reader.Read();
                idApuesta = Convert.ToString(reader["idPartido"]);

            }

        }
        catch (SqlException sqlEx)
        {
            idApuesta = "Error";
        }
        catch (Exception ex)
        {
            idApuesta = "Error";
        }
        finally
        {
            ado.Desconectar();
        }

        return idApuesta;
    }

    public static string UpdateResultadosPartido(string idPartido, string idResultado, string idGolesLocal, string idGolesVisitante)
    {
        string Valor = "";
        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Partido_UpdateResultadosPartido
                                @idPartido, @idResultado, @idGolesLocal, @idGolesVisitante
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idPartido", idPartido));
            ado.Comando.Parameters.Add(new SqlParameter("@idResultado", idResultado));
            ado.Comando.Parameters.Add(new SqlParameter("@idGolesLocal", idGolesLocal));
            ado.Comando.Parameters.Add(new SqlParameter("@idGolesVisitante", idGolesVisitante));

            DbDataReader reader = ado.EjecutarConsulta();

            if (reader.HasRows)
            {
                reader.Read();
                Valor = Convert.ToString(reader["VALOR"]);

            }

        }
        catch (SqlException sqlEx)
        {
            Valor = "Error";
        }
        catch (Exception ex)
        {
            Valor = "Error";
        }
        finally
        {
            ado.Desconectar();
        }

        return Valor;
    }

}
