using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectQ26
{
    public partial class DashBoard : System.Web.UI.Page
    {
        Quiniela DataQuiniela = new Quiniela();
        List<Quiniela> DataQuielaList = new List<Quiniela>();
        List<Quiniela> DataQuielaListV2 = new List<Quiniela>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);

                GetDataQuiniela("1", "1", "1");
                actualizarGrid();
                actualizarGridTablaGeneral();
            }

        }
        private void actualizarGrid()
        {
            DataQuielaList = DB_Quiniela.getQuinielaPartidosResultadosByidQuiniela(idQuinielaHidden.Value);

            gridQuinielaModalDetalle.DataSource = DataQuielaList;
            gridQuinielaModalDetalle.DataBind();
            
            UpdatePanelModalDetalle.Update();

        }

        protected void GetDataQuiniela(string idSportPar, string idLigaPar, string idTorneo)
        {
            DataQuiniela = DB_Quiniela.getQuinielaData(idSportPar, idLigaPar);
            DataQuielaListV2 = DB_Quiniela.getTablaGeneralByIdLigaIdTorneo(idLigaPar, idTorneo);

            if (DataQuiniela.idStatus == 3)
            {
                lblTitleQuinielas.Text = "Quiniela : " + DataQuiniela.QuinielaNo + " (EN PROCESO)";
            }
            else if (DataQuiniela.idStatus == 6)
            {
                lblTitleQuinielas.Text = "Quiniela : " + DataQuiniela.QuinielaNo + " (Cerrada)";
            }
            else
            {
                lblTitleQuinielas.Text = "Quiniela : " + DataQuiniela.QuinielaNo;
            }

            idQuinielaHidden.Value = DataQuiniela.idQuiniela.ToString();

        }

        protected void gridQuinielaModalDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.FindControl("imgLocal") as Image).ImageUrl = DataQuielaList[e.Row.RowIndex].EquipoLocalImgURL;
                (e.Row.FindControl("imgVisita") as Image).ImageUrl = DataQuielaList[e.Row.RowIndex].EquipoVisitanteImgURL;
            }
        }


        private void actualizarGridTablaGeneral()
        {
            gridQuinielaModalTablaGeneral.DataSource = DataQuielaListV2;
            gridQuinielaModalTablaGeneral.DataBind();

            UpdatePanelModalTablaGeneral.Update();

        }

        protected void gridQuinielaModalTablaGeneral_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.FindControl("imgEquipo") as Image).ImageUrl = DataQuielaListV2[e.Row.RowIndex].EquipoImgURL;
            }
        }
    }
}