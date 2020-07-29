using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
public class DB_Resultado
{
    public DB_Resultado()
    {

    }

    public static List<Resultado> getResultadoList()
    {
        List<Resultado> ResultadoDataList = new List<Resultado>();
        Resultado ResultadoData;

        Utils.adoDAL ado = new Utils.adoDAL();

        try
        {
            ado.Conectar();
            ado.CrearComando(@" SELECT idResultado, ResultadoName FROM Resultado
                                 WHERE Active = 1
                            ");

            DbDataReader reader = ado.EjecutarConsulta();

            while (reader.Read())
            {
                ResultadoData = new Resultado
                {
                    idResultado = Convert.ToInt32(reader["idResultado"]),
                    ResultadoName = Convert.ToString(reader["ResultadoName"])
                };

                ResultadoDataList.Add(ResultadoData);
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

        return ResultadoDataList;
    }
}