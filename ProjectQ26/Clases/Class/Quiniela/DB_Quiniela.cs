using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text;

public class DB_Quiniela
{

    public DB_Quiniela()
    {

    }

    public static List<Quiniela> getQuinielasByFilters(string idSport, string idLiga, string idTorneo, string idJornada)
    {
        List<Quiniela> QuinielaDataList = new List<Quiniela>();
        Quiniela QuinielaData;

        Utils.adoDAL ado = new Utils.adoDAL();
        StringBuilder strQry = new StringBuilder();
        StringBuilder strWhere = new StringBuilder("");
        StringBuilder strGroup = new StringBuilder(" GROUP BY Q.idQuiniela, Q.QuinielaNo, QD.idQuinielaDetalle, QD.idSport, S.SportName, S.SportNameShort, QD.idLiga, L.LigaName, L.LigaNameShort, QD.idTorneo, T.TorneoName, T.TorneoNameShort, QD.idJornada, J.JornadaName, J.JornadaNameShort, Q.idStatus, SP.StatusName ");
        StringBuilder strOrder = new StringBuilder(" ORDER BY QD.idSport, QD.idLiga, QD.idTorneo, QD.idJornada ");

        try
        {
            ado.Conectar();

            strQry.Append(" SELECT Q.idQuiniela, Q.QuinielaNo, QD.idQuinielaDetalle, QD.idSport, S.SportName, S.SportNameShort, QD.idLiga, ");
            strQry.Append(" L.LigaName, L.LigaNameShort, QD.idTorneo, T.TorneoName, T.TorneoNameShort, QD.idJornada, J.JornadaName, J.JornadaNameShort, ");
            strQry.Append(" COUNT(A.idApuesta) ApuestasTotal, Q.idStatus, SP.StatusName FROM Quinielas AS Q JOIN QuinielasDetalle AS QD ON QD.idQuiniela = Q.idQuiniela ");
            strQry.Append(" JOIN Sports AS S ON S.idSport = QD.idSport JOIN Ligas AS L ON L.idLiga = QD.idLiga JOIN Torneos AS T ON T.idTorneo = QD.idTorneo  ");
            strQry.Append(" JOIN Jornadas AS J ON J.idJornada = QD.idJornada LEFT JOIN Apuestas A ON A.idQuiniela = Q.idQuiniela JOIN StatusProcess SP ");
            strQry.Append(" ON SP.idStatus = Q.idStatus WHERE Q.Active = 1 AND S.Active = 1 AND L.Active = 1 AND T.Active = 1 AND J.Active = 1 ");

            if (!String.IsNullOrEmpty(idSport))
                strWhere.Append(" AND QD.idSport = @idSport");

            if (!String.IsNullOrEmpty(idLiga))
                strWhere.Append(" AND QD.idLiga = @idLiga");

            if (!String.IsNullOrEmpty(idTorneo))
                strWhere.Append(" AND QD.idTorneo = @idTorneo");

            if (!String.IsNullOrEmpty(idJornada))
                strWhere.Append(" AND QD.idJornada = @idJornada");

            ado.CrearComando(String.Concat(strQry.ToString(), strWhere.ToString(), strGroup.ToString(), strOrder.ToString()));

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
                QuinielaData = new Quiniela
                {
                    idQuiniela = Convert.ToInt32(reader["idQuiniela"]),
                    QuinielaNo = Convert.ToString(reader["QuinielaNo"]),
                    idQuinielaDetalle = Convert.ToInt32(reader["idQuinielaDetalle"]),

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

                    ApuestasTotal = Convert.ToInt32(reader["ApuestasTotal"]),
                    idStatus = Convert.ToInt32(reader["idStatus"]),
                    StatusName = Convert.ToString(reader["StatusName"])
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

    public static List<Quiniela> getQuinielasByFiltersV2(string idSport, string idLiga, string idTorneo, string idJornada)
    {
        List<Quiniela> QuinielaDataList = new List<Quiniela>();
        Quiniela QuinielaData;

        Utils.adoDAL ado = new Utils.adoDAL();
        StringBuilder strQry = new StringBuilder();
        StringBuilder strWhere = new StringBuilder("");
        StringBuilder strGroup = new StringBuilder(" GROUP BY Q.idQuiniela, Q.QuinielaNo, QD.idQuinielaDetalle, QD.idSport, S.SportName, S.SportNameShort, QD.idLiga, L.LigaName, L.LigaNameShort, QD.idTorneo, T.TorneoName, T.TorneoNameShort, QD.idJornada, J.JornadaName, J.JornadaNameShort, Q.idStatus, SP.StatusName ");
        StringBuilder strOrder = new StringBuilder(" ORDER BY QD.idSport, QD.idLiga, QD.idTorneo, QD.idJornada ");

        try
        {
            ado.Conectar();

            strQry.Append(" SELECT Q.idQuiniela, Q.QuinielaNo, QD.idQuinielaDetalle, QD.idSport, S.SportName, S.SportNameShort, QD.idLiga, ");
            strQry.Append(" L.LigaName, L.LigaNameShort, QD.idTorneo, T.TorneoName, T.TorneoNameShort, QD.idJornada, J.JornadaName, J.JornadaNameShort, ");
            strQry.Append(" (SELECT COUNT(A2.idApuesta) FROM Apuestas A2 WHERE A2.idQuiniela = Q.idQuiniela AND A2.idStatus = 1) ApuestasTotal, Q.idStatus, SP.StatusName FROM Quinielas AS Q JOIN QuinielasDetalle AS QD ON QD.idQuiniela = Q.idQuiniela ");
            strQry.Append(" JOIN Sports AS S ON S.idSport = QD.idSport JOIN Ligas AS L ON L.idLiga = QD.idLiga JOIN Torneos AS T ON T.idTorneo = QD.idTorneo  ");
            strQry.Append(" JOIN Jornadas AS J ON J.idJornada = QD.idJornada LEFT JOIN Apuestas A ON A.idQuiniela = Q.idQuiniela JOIN StatusProcess SP ");
            strQry.Append(" ON SP.idStatus = Q.idStatus WHERE Q.Active = 1 AND S.Active = 1 AND L.Active = 1 AND T.Active = 1 AND J.Active = 1 AND Q.idStatus NOT IN (1)  ");

            if (!String.IsNullOrEmpty(idSport))
                strWhere.Append(" AND QD.idSport = @idSport");

            if (!String.IsNullOrEmpty(idLiga))
                strWhere.Append(" AND QD.idLiga = @idLiga");

            if (!String.IsNullOrEmpty(idTorneo))
                strWhere.Append(" AND QD.idTorneo = @idTorneo");

            if (!String.IsNullOrEmpty(idJornada))
                strWhere.Append(" AND QD.idJornada = @idJornada");

            ado.CrearComando(String.Concat(strQry.ToString(), strWhere.ToString(), strGroup.ToString(), strOrder.ToString()));

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
                QuinielaData = new Quiniela
                {
                    idQuiniela = Convert.ToInt32(reader["idQuiniela"]),
                    QuinielaNo = Convert.ToString(reader["QuinielaNo"]),
                    idQuinielaDetalle = Convert.ToInt32(reader["idQuinielaDetalle"]),

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

                    ApuestasTotal = Convert.ToInt32(reader["ApuestasTotal"]),
                    idStatus = Convert.ToInt32(reader["idStatus"]),
                    StatusName = Convert.ToString(reader["StatusName"])
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

    public static List<Quiniela> getApuestaQuinielaByIdUser(string idSport, string idLiga, string idTorneo, string idJornada, string idUser)
    {
        List<Quiniela> QuinielaDataList = new List<Quiniela>();
        Quiniela QuinielaData;

        Utils.adoDAL ado = new Utils.adoDAL();
        StringBuilder strQry = new StringBuilder();
        StringBuilder strWhere = new StringBuilder("");
        StringBuilder strGroup = new StringBuilder(" GROUP BY QD.idSport, S.SportName, S.SportNameShort, QD.idLiga, L.LigaName, L.LigaNameShort, QD.idTorneo, T.TorneoName, T.TorneoNameShort, QD.idJornada, J.JornadaName, J.JornadaNameShort, A.idQuiniela, Q.QuinielaNo, A.idApuesta, A.ApuestaNo, A.DateAdd, A.idStatus, SP.StatusName ");
        StringBuilder strOrder = new StringBuilder(" ORDER BY QD.idSport, QD.idLiga, QD.idTorneo, QD.idJornada, A.idApuesta Desc ");

        try
        {
            ado.Conectar();

            strQry.Append(" SELECT QD.idSport, S.SportName, S.SportNameShort, QD.idLiga, L.LigaName, L.LigaNameShort, QD.idTorneo, T.TorneoName, T.TorneoNameShort, ");
            strQry.Append(" QD.idJornada, J.JornadaName, J.JornadaNameShort, A.idQuiniela, Q.QuinielaNo, A.idApuesta, A.ApuestaNo, A.DateAdd AS ApuestaDate, A.idStatus, ");
            strQry.Append(" SP.StatusName, SUM(AD.Puntos) TotalPuntos FROM Apuestas A JOIN Quinielas Q ON Q.idQuiniela = A.idQuiniela JOIN QuinielasDetalle AS QD ");
            strQry.Append(" ON QD.idQuiniela = Q.idQuiniela JOIN Sports S ON S.idSport = QD.idSport JOIN Ligas L ON L.idLiga = QD.idLiga JOIN Torneos T ON T.idTorneo = QD.idTorneo ");
            strQry.Append(" JOIN Jornadas J ON J.idJornada = QD.idJornada JOIN ApuestasDetalle AD ON AD.idApuesta = A.idApuesta JOIN StatusProcess SP ON SP.idStatus = A.idStatus ");
            strQry.Append(" WHERE A.idUser = @idUser ");

            if (!String.IsNullOrEmpty(idSport))
                strWhere.Append(" AND QD.idSport = @idSport");

            if (!String.IsNullOrEmpty(idLiga))
                strWhere.Append(" AND QD.idLiga = @idLiga");

            if (!String.IsNullOrEmpty(idTorneo))
                strWhere.Append(" AND QD.idTorneo = @idTorneo");

            if (!String.IsNullOrEmpty(idJornada))
                strWhere.Append(" AND QD.idJornada = @idJornada");

            ado.CrearComando(String.Concat(strQry.ToString(), strWhere.ToString(), strGroup.ToString(), strOrder.ToString()));

            ado.Comando.Parameters.Add(new SqlParameter("@idUser", idUser));

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
                QuinielaData = new Quiniela
                {
                    idQuiniela = Convert.ToInt32(reader["idQuiniela"]),
                    QuinielaNo = Convert.ToString(reader["QuinielaNo"]),

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

                    idApuesta = Convert.ToInt32(reader["idApuesta"]),
                    ApuestaNo = Convert.ToString(reader["ApuestaNo"]),
                    ApuestaDate = Convert.ToDateTime(reader["ApuestaDate"]),

                    idStatus = Convert.ToInt32(reader["idStatus"]),
                    StatusName = Convert.ToString(reader["StatusName"]),

                    Total = Convert.ToInt32(reader["TotalPuntos"]),
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
                QuinielaData.idStatus = Convert.ToInt32(reader["idStatus"]);

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
    public static List<Quiniela> getTablaGeneralByIdLigaIdTorneo(string idLiga, string idTorneo)
    {
        List<Quiniela> QuinielaDataList = new List<Quiniela>();
        Quiniela QuinielaData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC GetTablaGeneralByIdLigaIdTorneo
                                @idLiga, @idTorneo 
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idLiga", idLiga));
            ado.Comando.Parameters.Add(new SqlParameter("@idTorneo", idTorneo));
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                QuinielaData = new Quiniela
                {
                    idTablaGeneral = Convert.ToInt32(reader["idTablaGeneral"]),
                    idLiga = Convert.ToInt32(reader["idLiga"]),
                    idTorneo = Convert.ToInt32(reader["idTorneo"]),
                    Pos = Convert.ToInt32(reader["Pos"]),

                    idEquipo = Convert.ToInt32(reader["idEquipo"]),
                    EquipoImgURL = Convert.ToString(reader["EquipoImgURL"]),
                    EquipoShort = Convert.ToString(reader["EquipoShort"]),
                    EquipoName = Convert.ToString(reader["EquipoName"]),

                    JJ = Convert.ToInt32(reader["JJ"]),
                    JG = Convert.ToInt32(reader["JG"]),
                    JE = Convert.ToInt32(reader["JE"]),
                    JP = Convert.ToInt32(reader["JP"]),
                    GF = Convert.ToInt32(reader["GF"]),
                    GC = Convert.ToInt32(reader["GC"]),
                    DG = Convert.ToInt32(reader["DG"]),

                    Total = Convert.ToInt32(reader["Puntos"])
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


    public static List<Quiniela> getQuinielaPartidosResultadosByidQuiniela(string idQuiniela)
    {
        List<Quiniela> QuinielaDataList = new List<Quiniela>();
        Quiniela QuinielaData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Quinielas_GetPartidosResultadosByIdQuiniela
                                @idQuiniela 
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idQuiniela", idQuiniela));
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

                    idGolesLocal = Convert.ToInt32(reader["idGolesLocal"]),
                    GolesLocal = Convert.ToInt32(reader["GolesLocal"]),

                    EquipoVisitante = Convert.ToString(reader["EquipoVisitante"]),
                    EquipoVisitanteShort = Convert.ToString(reader["EquipoVisitanteShort"]),
                    EquipoVisitanteImgURL = Convert.ToString(reader["EquipoVisitanteImgURL"]),

                    idGolesVisitante = Convert.ToInt32(reader["idGolesVisitante"]),
                    GolesVisitante = Convert.ToInt32(reader["GolesVisitante"]),

                    idResultado = Convert.ToInt32(reader["idResultado"]),
                    ResultadoName = Convert.ToString(reader["ResultadoName"]),
                    ResultadoNameShort = Convert.ToString(reader["ResultadoNameShort"])
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

    public static List<Quiniela> getQuinielaPartidosResultadosByidApuesta(string idApuesta)
    {
        List<Quiniela> QuinielaDataList = new List<Quiniela>();
        Quiniela QuinielaData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Apuestas_GetPartidosResultadosByIdApuesta
                                @idApuesta 
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idApuesta", idApuesta));
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

                    idGolesLocal = Convert.ToInt32(reader["idGolesLocal"]),
                    GolesLocal = Convert.ToInt32(reader["GolesLocal"]),

                    EquipoVisitante = Convert.ToString(reader["EquipoVisitante"]),
                    EquipoVisitanteShort = Convert.ToString(reader["EquipoVisitanteShort"]),
                    EquipoVisitanteImgURL = Convert.ToString(reader["EquipoVisitanteImgURL"]),

                    idGolesVisitante = Convert.ToInt32(reader["idGolesVisitante"]),
                    GolesVisitante = Convert.ToInt32(reader["GolesVisitante"]),

                    idResultadoApuesta = Convert.ToInt32(reader["idResultadoApuesta"]),
                    ResultadoApuestaName = Convert.ToString(reader["ResultadoApuestaName"]),
                    ResultadoApuestaNameShort = Convert.ToString(reader["ResultadoApuestaNameShort"]),

                    idResultado = Convert.ToInt32(reader["idResultado"]),
                    ResultadoName = Convert.ToString(reader["ResultadoName"]),
                    ResultadoNameShort = Convert.ToString(reader["ResultadoNameShort"]),

                    Total = Convert.ToInt32(reader["Puntos"])
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

    public static List<Quiniela> getApuestasByidQuiniela(string idQuiniela)
    {
        List<Quiniela> QuinielaDataList = new List<Quiniela>();
        Quiniela QuinielaData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Quinielas_GetApustasByIdQuiniela
                                @idQuiniela 
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idQuiniela", idQuiniela));
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                QuinielaData = new Quiniela
                {
                    idApuesta = Convert.ToInt32(reader["idApuesta"]),
                    ApuestaNo = Convert.ToString(reader["ApuestaNo"]),

                    idUser = Convert.ToInt32(reader["idUser"]),
                    UserName = Convert.ToString(reader["UserName"]),
                    Total = Convert.ToInt32(reader["Total"]),

                    idStatus = Convert.ToInt32(reader["idStatus"]),
                    StatusName = Convert.ToString(reader["StatusName"])
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

    public static List<Quiniela> getApuestasAbiertasByidQuiniela(string idQuiniela)
    {
        List<Quiniela> QuinielaDataList = new List<Quiniela>();
        Quiniela QuinielaData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Quinielas_GetApuestasAbiertasByIdQuiniela
                                @idQuiniela 
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idQuiniela", idQuiniela));
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                QuinielaData = new Quiniela
                {
                    idApuesta = Convert.ToInt32(reader["idApuesta"]),
                    ApuestaNo = Convert.ToString(reader["ApuestaNo"]),

                    idUser = Convert.ToInt32(reader["idUser"]),
                    UserName = Convert.ToString(reader["UserName"]),
                    Total = Convert.ToInt32(reader["Total"]),

                    idStatus = Convert.ToInt32(reader["idStatus"]),
                    StatusName = Convert.ToString(reader["StatusName"])
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

    public static string InsertQuiniela(string idSport, string idLiga, string idTorneo, string idJornada, string idUser)
    {
        string QuinielaNo = "";
        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Quiniela_InsertQuiniela
                                @idSport, @idLiga, @idTorneo, @idJornada, @idUser
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idSport", idSport));
            ado.Comando.Parameters.Add(new SqlParameter("@idLiga", idLiga));
            ado.Comando.Parameters.Add(new SqlParameter("@idTorneo", idTorneo));
            ado.Comando.Parameters.Add(new SqlParameter("@idJornada", idJornada));
            ado.Comando.Parameters.Add(new SqlParameter("@idUser", idUser));
            DbDataReader reader = ado.EjecutarConsulta();

            if (reader.HasRows)
            {
                reader.Read();
                QuinielaNo = Convert.ToString(reader["QuinielaNo"]);

            }

        }
        catch (SqlException sqlEx)
        {
            QuinielaNo = "Error";
        }
        catch (Exception ex)
        {
            QuinielaNo = "Error";
        }
        finally
        {
            ado.Desconectar();
        }

        return QuinielaNo;
    }
    public static string CanOpenQuiniela(string idLiga, string idTorneo)
    {
        string ApuestaNo = "";
        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" IF EXISTS 
	                            (
		                            SELECT 
			                            Q.idQuiniela 
		                            FROM Quinielas Q 
		                            JOIN QuinielasDetalle QD 
		                            ON QD.idQuiniela = Q.idQuiniela
		                            WHERE Q.idStatus in (3, 4) AND QD.idLiga = @idLiga AND QD.idTorneo = @idTorneo
	                            )
		                            BEGIN
			                            SELECT 'Error' Respuesta
		                            END
	                            ELSE
		                            BEGIN
			                            SELECT 'ABRIR' Respuesta
		                            END
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idLiga", idLiga));
            ado.Comando.Parameters.Add(new SqlParameter("@idTorneo", idTorneo));
            DbDataReader reader = ado.EjecutarConsulta();

            if (reader.HasRows)
            {
                reader.Read();
                ApuestaNo = Convert.ToString(reader["Respuesta"]);

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
    public static string CalcularQuiniela(string idQuiniela)
    {
        string QuinielaNo = "";
        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Quinielas_CalcularGanadorApuesta
                                @idQuiniela
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idQuiniela", idQuiniela));
            DbDataReader reader = ado.EjecutarConsulta();

            if (reader.HasRows)
            {
                reader.Read();
                QuinielaNo = Convert.ToString(reader["QuinielaNo"]);

            }

        }
        catch (SqlException sqlEx)
        {
            QuinielaNo = "Error";
        }
        catch (Exception ex)
        {
            QuinielaNo = "Error";
        }
        finally
        {
            ado.Desconectar();
        }

        return QuinielaNo;
    }



    public static string ProcesarQuiniela(string idQuiniela)
    {
        string QuinielaNo = "";
        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Quinielas_ProcesarQuiniela
                                @idQuiniela
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idQuiniela", idQuiniela));
            DbDataReader reader = ado.EjecutarConsulta();

            if (reader.HasRows)
            {
                reader.Read();
                QuinielaNo = Convert.ToString(reader["QuinielaNo"]);

            }

        }
        catch (SqlException sqlEx)
        {
            QuinielaNo = "Error";
        }
        catch (Exception ex)
        {
            QuinielaNo = "Error";
        }
        finally
        {
            ado.Desconectar();
        }

        return QuinielaNo;
    }

    public static string AbrirQuiniela(string idQuiniela)
    {
        string QuinielaNo = "";
        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" EXEC Quinielas_AbrirQuiniela
                                @idQuiniela
                            ");
            ado.Comando.Parameters.Add(new SqlParameter("@idQuiniela", idQuiniela));
            DbDataReader reader = ado.EjecutarConsulta();

            if (reader.HasRows)
            {
                reader.Read();
                QuinielaNo = Convert.ToString(reader["QuinielaNo"]);

            }

        }
        catch (SqlException sqlEx)
        {
            QuinielaNo = "Error";
        }
        catch (Exception ex)
        {
            QuinielaNo = "Error";
        }
        finally
        {
            ado.Desconectar();
        }

        return QuinielaNo;
    }
}
