using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectQ26
{
    public partial class Boletos : System.Web.UI.Page
    {
        Quiniela DataQuiniela = new Quiniela();
        List<Quiniela> DataQuinielaList = new List<Quiniela>();
        List<Quiniela> DataQuinielaListV2 = new List<Quiniela>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);

                actualizarGrid();
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
            UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);
            DataQuinielaList = DB_Quiniela.getApuestaQuinielaByIdUser(ddlSport.SelectedValue, ddlLiga.SelectedValue, ddlTorneo.SelectedValue, ddlJornada.SelectedValue, Usuario.idUser.ToString());

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
                    e.Row.Cells[14].Font.Bold = true;
                    e.Row.Cells[14].BackColor = System.Drawing.ColorTranslator.FromHtml("#1cc88a");
                    e.Row.Cells[14].ForeColor = System.Drawing.Color.Black;
                }
                else if (idStatus == 8)
                {
                    e.Row.Cells[14].BackColor = System.Drawing.ColorTranslator.FromHtml("#1cc88a");
                    e.Row.Cells[14].ForeColor = System.Drawing.Color.Black;
                    e.Row.Cells[14].Font.Bold = true;
                }
                else if (idStatus == 9)
                {
                    e.Row.Cells[14].BackColor = System.Drawing.ColorTranslator.FromHtml("#e74a3b");
                    e.Row.Cells[14].ForeColor = System.Drawing.Color.Black;
                    e.Row.Cells[14].Font.Bold = true;
                }
                else if (idStatus == 7)
                {
                    e.Row.Cells[14].BackColor = System.Drawing.ColorTranslator.FromHtml("#e74a3b");
                    e.Row.Cells[14].ForeColor = System.Drawing.Color.Black;
                    e.Row.Cells[14].Font.Bold = true;
                }
                else if (idStatus == 6)
                {
                    e.Row.Cells[14].BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    e.Row.Cells[14].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[14].Font.Bold = true;
                }
                else if (idStatus == 3)
                {
                    e.Row.Cells[14].BackColor = System.Drawing.ColorTranslator.FromHtml("#858796");
                    e.Row.Cells[14].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[14].Font.Bold = true;
                }

            }
        }
        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;

            string QuinielaNo = gridQuinielas.DataKeys[row.RowIndex].Values[3].ToString();
            string idApuesta = gridQuinielas.DataKeys[row.RowIndex].Values[4].ToString();
            Int32 TotalPuntos = 0;

            lblMsgModalDetalle.Text = String.Empty;

            DataQuinielaListV2 = DB_Quiniela.getQuinielaPartidosResultadosByidApuesta(idApuesta);

            gridQuinielaModalDetalle.DataSource = DataQuinielaListV2;
            gridQuinielaModalDetalle.DataBind();

            UpdatePanelModalDetalle.Update();

            txtQuinielaNoDetalle.Text = QuinielaNo;

            for(int x = 0; x< DataQuinielaListV2.Count; x++)
            {
                TotalPuntos = TotalPuntos + DataQuinielaListV2[x].Total;
            }

            txtTotalPuntosDetalle.Text = TotalPuntos.ToString();

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

                if (e.Row.Cells[12].Text == "1")
                {
                    e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#1cc88a");
                    e.Row.Cells[12].ForeColor = System.Drawing.ColorTranslator.FromHtml("#1cc88a");
                }
                else if (e.Row.Cells[12].Text == "0")
                {
                    e.Row.Cells[12].BackColor = System.Drawing.ColorTranslator.FromHtml("#e74a3b");
                    e.Row.Cells[12].ForeColor = System.Drawing.ColorTranslator.FromHtml("#e74a3b");
                }
                else
                {
                    e.Row.Cells[12].BackColor = System.Drawing.Color.White;
                    e.Row.Cells[12].ForeColor = System.Drawing.Color.White;
                }

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
            //updateModalApuestasQuiniela.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaApuestas", "$('#modalQuinielaApuestas').modal('hide');", true);
        }

        



        //protected void btnProcesar_Click(object sender, EventArgs e)
        //{
        //    Button btn = sender as Button;
        //    GridViewRow row = btn.NamingContainer as GridViewRow;
        //    string idQuiniela = gridQuinielas.DataKeys[row.RowIndex].Values[0].ToString();

        //    idQuinielaProcesarHidden.Value = idQuiniela;

        //    lblMsgProcesar.Text = String.Empty;

        //    pnlTitlesProcesar.Visible = true;
        //    pnlValuesProcesar.Visible = false;

        //    btnAcceptQuinielaProcesarConfirm.Visible = true;

        //    updateModalProcesarQuinielaConfirm.Update();
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaProcesarConfirm", "$('#modalQuinielaProcesarConfirm').modal();", true);
        //}
        //protected void btnAcceptQuinielaProcesarConfirm_Click(object sender, EventArgs e)
        //{
        //    string QuinielaNo = "";
        //    UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);

        //    QuinielaNo = DB_Quiniela.ProcesarQuiniela(idQuinielaProcesarHidden.Value);

        //    if (QuinielaNo == "Error")
        //    {
        //        pnlTitlesProcesar.Visible = true;
        //        pnlValuesProcesar.Visible = false;
        //        lblMsgProcesar.Text = "Error al Procesar Quiniela. Intente de Nuevo";
        //        lblMsgProcesar.ForeColor = System.Drawing.Color.Red;
        //    }
        //    else
        //    {
        //        pnlTitlesProcesar.Visible = false;
        //        pnlValuesProcesar.Visible = true;

        //        btnAcceptQuinielaProcesarConfirm.Visible = false;

        //        txtQuinielaProcesar.Text = QuinielaNo;
        //        lblMsgProcesar.Text = "Quiniela Procesada Correctamente";
        //        lblMsgProcesar.ForeColor = System.Drawing.Color.Green;

        //        actualizarGrid();
        //    }
        //}

        //protected void btnCloseQuinielaProcesarConfirm_Click(object sender, EventArgs e)
        //{
        //    updateModalProcesarQuinielaConfirm.Update();
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaProcesarConfirm", "$('#modalQuinielaProcesarConfirm').modal('hide');", true);

        //}
        //protected void btnCalcular_Click(object sender, EventArgs e)
        //{
        //    Button btn = sender as Button;
        //    GridViewRow row = btn.NamingContainer as GridViewRow;
        //    string idQuiniela = gridQuinielas.DataKeys[row.RowIndex].Values[0].ToString();

        //    idQuinielaHidden.Value = idQuiniela;

        //    lblMsgCalcular.Text = String.Empty;

        //    pnlTitles.Visible = true;
        //    pnlValuesCalculate.Visible = false;

        //    btnAcceptQuinielaCalcularConfirm.Visible = true;

        //    updateModalCalcularQuinielaConfirm.Update();
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaCalcularConfirm", "$('#modalQuinielaCalcularConfirm').modal();", true);
        //}
        //protected void btnAcceptQuinielaCalcularConfirm_Click(object sender, EventArgs e)
        //{
        //    string QuinielaNo = "";
        //    UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);

        //    QuinielaNo = DB_Quiniela.CalcularQuiniela(idQuinielaHidden.Value);

        //    if (QuinielaNo == "Error")
        //    {
        //        pnlTitles.Visible = true;
        //        pnlValuesCalculate.Visible = false;
        //        lblMsgCalcular.Text = "Error al Calcular Quiniela. Intente de Nuevo";
        //        lblMsgCalcular.ForeColor = System.Drawing.Color.Red;
        //    }
        //    else
        //    {
        //        pnlTitles.Visible = false;
        //        pnlValuesCalculate.Visible = true;

        //        btnAcceptQuinielaCalcularConfirm.Visible = false;

        //        txtQuinielaCalcular.Text = QuinielaNo;
        //        lblMsgCalcular.Text = "Quiniela Calculada Correctamente";
        //        lblMsgCalcular.ForeColor = System.Drawing.Color.Green;

        //        actualizarGrid();
        //    }
        //}

        //protected void btnCloseQuinielaCalcularConfirm_Click(object sender, EventArgs e)
        //{
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaCalcularConfirm", "$('#modalQuinielaCalcularConfirm').modal('hide');", true);
        //}
    }
}