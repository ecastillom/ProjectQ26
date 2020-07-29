using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Jornada
{
    public Jornada()
    {

    }

    public Int32 idJornada { get; set; }
    public string JornadaName { get; set; }
    public string JornadaNameShort { get; set; }
    public bool Active { get; set; }
    public Int32 idTorneo { get; set; }
}
