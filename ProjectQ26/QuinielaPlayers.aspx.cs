using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectQ26
{
    public partial class QuinielaPlayers : System.Web.UI.Page
    {
        Quiniela DataQuiniela = new Quiniela();
        List<Quiniela> DataQuinielaList = new List<Quiniela>();
        List<Quiniela> DataQuinielaListV2 = new List<Quiniela>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);

                getSportFilter();

            }
        }
        protected void getSportFilter()
        {
            ddlSport.DataSource = DB_Sport.getSportList();
            ddlSport.DataValueField = "idSport";
            ddlSport.DataTextField = "SportName";
            ddlSport.DataBind();
            ddlSport.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlSport.SelectedIndex = 0;

        }

        protected void getLigaFilter(string idSport)
        {
            ddlLiga.DataSource = DB_Liga.getLigaList(idSport);
            ddlLiga.DataValueField = "idLiga";
            ddlLiga.DataTextField = "LigaName";
            ddlLiga.DataBind();
            ddlLiga.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlLiga.SelectedIndex = 0;
            ddlLiga.Enabled = true;
        }
        protected void getTorneoFilter(string idLiga)
        {
            ddlTorneo.DataSource = DB_Torneo.getTorneoList(idLiga);
            ddlTorneo.DataValueField = "idTorneo";
            ddlTorneo.DataTextField = "TorneoName";
            ddlTorneo.DataBind();
            ddlTorneo.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlTorneo.SelectedIndex = 0;
            ddlTorneo.Enabled = true;
        }
        protected void getJornadaFilter(string idTorneo)
        {
            ddlJornada.DataSource = DB_Jornada.getJornadaList(idTorneo);
            ddlJornada.DataValueField = "idJornada";
            ddlJornada.DataTextField = "JornadaName";
            ddlJornada.DataBind();
            ddlJornada.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlJornada.SelectedIndex = 0;
            ddlJornada.Enabled = true;
        }
        protected void ddlSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSport.SelectedIndex == 0)
            {
                ddlLiga.Items.Clear();
                ddlTorneo.Items.Clear();
                ddlJornada.Items.Clear();

                ddlLiga.Enabled = false;
                ddlTorneo.Enabled = false;
                ddlJornada.Enabled = false;
                updPnlFiltros.Update();
            }
            else
            {
                ddlTorneo.Items.Clear();
                ddlJornada.Items.Clear();

                ddlTorneo.Enabled = false;
                ddlJornada.Enabled = false;

                ddlLiga.Enabled = true;
                getLigaFilter(ddlSport.SelectedValue);
                updPnlFiltros.Update();
            }
        }
        protected void ddlLiga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLiga.SelectedIndex == 0)
            {
                ddlTorneo.Items.Clear();
                ddlJornada.Items.Clear();

                ddlTorneo.Enabled = false;
                ddlJornada.Enabled = false;
                updPnlFiltros.Update();
            }
            else
            {
                ddlJornada.Items.Clear();
                ddlJornada.Enabled = false;

                ddlTorneo.Enabled = true;
                getTorneoFilter(ddlLiga.SelectedValue);
                updPnlFiltros.Update();
            }
        }
        protected void ddlTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTorneo.SelectedIndex == 0)
            {
                ddlJornada.Items.Clear();

                ddlJornada.Enabled = false;
                updPnlFiltros.Update();
            }
            else
            {
                ddlJornada.Enabled = true;
                getJornadaFilter(ddlTorneo.SelectedValue);
                updPnlFiltros.Update();
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            actualizarGrid();
        }

        private void actualizarGrid()
        {
            DataQuinielaList = DB_Quiniela.getQuinielasByFiltersV2(ddlSport.SelectedValue, ddlLiga.SelectedValue, ddlTorneo.SelectedValue, ddlJornada.SelectedValue);

            gridQuinielas.DataSource = DataQuinielaList;
            gridQuinielas.DataBind();

            updateGridPrincipal.Update();
        }

        protected void gridQuinielas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //(e.Row.FindControl("imgLocal") as Image).ImageUrl = DataQuinielaList[e.Row.RowIndex].EquipoLocalImgURL;
                //(e.Row.FindControl("imgVisita") as Image).ImageUrl = DataQuinielaList[e.Row.RowIndex].EquipoVisitanteImgURL;

                int idStatus = DataQuinielaList[e.Row.RowIndex].idStatus;

                if (idStatus == 4)
                {
                    e.Row.Cells[12].Font.Bold = true;
                    e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#1cc88a");
                    e.Row.Cells[12].ForeColor = System.Drawing.Color.Black;
                }
                else if (idStatus == 7)
                {
                    e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#e74a3b");
                    e.Row.Cells[12].ForeColor = System.Drawing.Color.Black;
                    e.Row.Cells[12].Font.Bold = true;
                }
                else if (idStatus == 6)
                {
                    e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[12].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[12].Font.Bold = true;
                }
                else if (idStatus == 3)
                {
                    e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#858796");
                    e.Row.Cells[12].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[12].Font.Bold = true;
                }

            }
        }
        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string idQuiniela = gridQuinielas.DataKeys[row.RowIndex].Values[0].ToString();
            string QuinielaNo = gridQuinielas.DataKeys[row.RowIndex].Values[3].ToString();

            lblMsgModalDetalle.Text = String.Empty;

            DataQuinielaListV2 = DB_Quiniela.getQuinielaPartidosResultadosByidQuiniela(idQuiniela);

            gridQuinielaModalDetalle.DataSource = DataQuinielaListV2;
            gridQuinielaModalDetalle.DataBind();

            UpdatePanelModalDetalle.Update();

            txtQuinielaNoDetalle.Text = QuinielaNo;

            updateModalDetallesQuiniela.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaDetalles", "$('#modalQuinielaDetalles').modal();", true);

        }
        protected void btnCloseQuinielaDetalla_Click(object sender, EventArgs e)
        {
            updateModalDetallesQuiniela.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaDetalles", "$('#modalQuinielaDetalles').modal('hide');", true);
        }
        protected void gridQuinielaModalDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.FindControl("imgLocal") as Image).ImageUrl = DataQuinielaListV2[e.Row.RowIndex].EquipoLocalImgURL;
                (e.Row.FindControl("imgVisita") as Image).ImageUrl = DataQuinielaListV2[e.Row.RowIndex].EquipoVisitanteImgURL;
            }
        }
        protected void btnCloseDetalles_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaDetalles", "$('#modalQuinielaDetalles').modal('hide');", true);
        }

        protected void btnApuestas_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;

            string idQuiniela = gridQuinielas.DataKeys[row.RowIndex].Values[0].ToString();
            string QuinielaNo = gridQuinielas.DataKeys[row.RowIndex].Values[3].ToString();

            lblMsgApuestas.Text = String.Empty;

            DataQuinielaListV2 = DB_Quiniela.getApuestasAbiertasByidQuiniela(idQuiniela);

            gridQuinielaModalApuestas.DataSource = DataQuinielaListV2;
            gridQuinielaModalApuestas.DataBind();

            UpdatePanelModalApuestas.Update();

            txtQuinielaNoApuestas.Text = QuinielaNo;

            updateModalApuestasQuiniela.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaApuestas", "$('#modalQuinielaApuestas').modal();", true);
        }
        protected void gridQuinielaModalApuestas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int idStatus = DataQuinielaListV2[e.Row.RowIndex].idStatus;

                if (idStatus == 4)
                {
                    e.Row.Cells[5].Font.Bold = true;
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#1cc88a");
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Black;
                }
                else if (idStatus == 8)
                {
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#1cc88a");
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Black;
                    e.Row.Cells[5].Font.Bold = true;
                }
                else if (idStatus == 9)
                {
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#e74a3b");
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Black;
                    e.Row.Cells[5].Font.Bold = true;
                }
                else if (idStatus == 7)
                {
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#e74a3b");
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Black;
                    e.Row.Cells[5].Font.Bold = true;
                }
                else if (idStatus == 6)
                {
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[5].Font.Bold = true;
                }
                else if (idStatus == 3)
                {
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#858796");
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[5].Font.Bold = true;
                }

            }
        }
        protected void btnCloseQuinielaApuestasConfirm_Click(object sender, EventArgs e)
        {
            updateModalApuestasQuiniela.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaApuestas", "$('#modalQuinielaApuestas').modal('hide');", true);
        }

        
    }
}