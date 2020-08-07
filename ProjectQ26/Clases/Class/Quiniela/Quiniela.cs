using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Quiniela
{
    public Quiniela()
    {

    }

    public Int32 idQuiniela { get; set; }
    public string QuinielaNo { get; set; }
    public int idStatus { get; set; }
    public string StatusName { get; set; }
    public string Active { get; set; }

    public Int32 idQuinielaDetalle { get; set; }

    public Int32 idSport { get; set; }
    public string SportName { get; set; }
    public string SportNameShort { get; set; }

    public Int32 idLiga { get; set; }
    public string LigaName { get; set; }
    public string LigaNameShort { get; set; }
    public string LigaImgURL { get; set; }

    public Int32 idTorneo { get; set; }
    public string TorneoName { get; set; }
    public string TorneoNameShort { get; set; }

    public Int32 idJornada { get; set; }
    public string JornadaName { get; set; }
    public string JornadaNameShort { get; set; }

    public Int32 idPartido { get; set; }
    public DateTime PartidoDate { get; set; }

    public Int32 ApuestasTotal { get; set; }

    public Int32 idEquipoLocal { get; set; }
    public string EquipoLocal { get; set; }
    public string EquipoLocalShort { get; set; }
    public string EquipoLocalImgURL { get; set; }
    public Int32 idEquipoVisitante { get; set; }
    public string EquipoVisitante { get; set; }
    public string EquipoVisitanteShort { get; set; }
    public string EquipoVisitanteImgURL { get; set; }

    public Int32 idGolesLocal { get; set; }
    public Int32 GolesLocal { get; set; }

    public Int32 idGolesVisitante { get; set; }
    public Int32 GolesVisitante { get; set; }

    public Int32 idResultado { get; set; }
    public string ResultadoName { get; set; }
    public string ResultadoNameShort { get; set; }

    public Int32 idResultadoApuesta { get; set; }
    public string ResultadoApuestaName { get; set; }
    public string ResultadoApuestaNameShort { get; set; }

    public Int32 idApuesta { get; set; }
    public string ApuestaNo { get; set; }
    public DateTime ApuestaDate { get; set; }

    public Int32 idUser { get; set; }
    public string UserName { get; set; }
    public Int32 Total { get; set; }

    public Int32 idTablaGeneral { get; set; }
    public Int32 Pos { get; set; }

    public Int32 idEquipo{ get; set; }
    public string EquipoName { get; set; }
    public string EquipoShort { get; set; }
    public string EquipoImgURL { get; set; }

    public Int32 JJ { get; set; }
    public Int32 JG { get; set; }
    public Int32 JE { get; set; }
    public Int32 JP { get; set; }
    public Int32 GF { get; set; }
    public Int32 GC { get; set; }
    public Int32 DG { get; set; }

}
