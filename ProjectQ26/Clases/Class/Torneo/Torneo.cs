using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Torneo
{

    public Torneo()
    {

    }

    public Int32 idTorneo { get; set; }
    public string TorneoName { get; set; }
    public string TorneoNameShort { get; set; }
    public bool Active { get; set; }
    public Int32 idLiga { get; set; }

}