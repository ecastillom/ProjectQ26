using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text;


public class DB_Gol
{
    public DB_Gol()
    {

    }

    public static List<Gol> getGolList()
    {
        List<Gol> GolDataList = new List<Gol>();
        Gol GolData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" SELECT idGol, GolNo FROM Goles
                                 WHERE Active = 1 
                            ");
            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                GolData = new Gol
                {
                    idGol = Convert.ToInt32(reader["idGol"]),
                    GolNo = Convert.ToString(reader["GolNo"])
                };

                GolDataList.Add(GolData);
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

        return GolDataList;
    }
}
