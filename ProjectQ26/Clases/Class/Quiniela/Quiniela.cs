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
    public string Active { get; set; }

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

    public Int32 idEquipoLocal { get; set; }
    public string EquipoLocal { get; set; }
    public string EquipoLocalShort { get; set; }
    public string EquipoLocalImgURL { get; set; }
    public Int32 idEquipoVisitante { get; set; }
    public string EquipoVisitante { get; set; }
    public string EquipoVisitanteShort { get; set; }
    public string EquipoVisitanteImgURL { get; set; }
}
