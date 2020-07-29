using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Equipo
{
    public Equipo()
    {

    }

    public Int32 idEquipo { get; set; }
    public string EquipoName { get; set; }
    public string EquipoNameShort { get; set; }
    public string EquipoImgURL { get; set; }
    public bool Active { get; set; }
    public int idLiga { get; set; }
}
