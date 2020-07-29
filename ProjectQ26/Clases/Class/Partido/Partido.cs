using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Partido
{
    public Partido()
    {

    }



    public Int32 idSport { get; set; }
    public string SportName { get; set; }
    public string SportNameShort { get; set; }
    public Int32 idLiga { get; set; }
    public string LigaName { get; set; }
    public string LigaNameShort { get; set; }
    public Int32 idTorneo { get; set; }
    public string TorneoName { get; set; }
    public string TorneoNameShort { get; set; }
    public Int32 idJornada { get; set; }
    public string JornadaName { get; set; }
    public Int32 idPartido { get; set; }
    public DateTime PartidoDate { get; set; }
    public string JornadaNameShort { get; set; }
    public Int32 idEquipoLocal { get; set; }
    public string EquipoLocal { get; set; }
    public string EquipoLocalShort { get; set; }
    public string EquipoLocalImgURL { get; set; }
    public Int32 idEquipoVisitante { get; set; }
    public string EquipoVisitante { get; set; }
    public string EquipoVisitanteShort { get; set; }
    public string EquipoVisitanteImgURL { get; set; }
    public Int32 idResultado { get; set; }
    public string ResultadoName { get; set; }
    public string ResultadoNameShort { get; set; }
    public Int32 idGolesLocal { get; set; }
    public string GolesLocal { get; set; }
    public Int32 idGolesVisitante { get; set; }
    public string GolesVisitante { get; set; }
    public bool Active { get; set; }

}