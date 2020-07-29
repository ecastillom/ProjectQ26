using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Generico
{

    public Generico()
    {
        existeError = false;

    }

    public string id { get; set; }
    public string clave { get; set; }
    public string descripcion { get; set; }
    public string mensaje { get; set; }
    public bool existeError { get; set; }

    public Object obj { get; set; }

}
