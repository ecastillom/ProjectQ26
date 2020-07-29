using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Liga
{
    public Liga()
    {

    }

    public Int32 idLiga { get; set; }
    public string LigaName { get; set; }
    public string LigaNameShort { get; set; }
    public string LigaImgURL { get; set; }
    public bool Active { get; set; }
    public int idCountry { get; set; }
}
