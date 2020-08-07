using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectQ26
{
    public partial class Quinielas : System.Web.UI.Page
    {
        Quiniela DataQuiniela = new Quiniela();
        List<Quiniela> DataQuinielaList = new List<Quiniela>();
        List<Quiniela> DataQuinielaListV2 = new List<Quiniela>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);

                if (!(Usuario.idSecurityUser == 1))
                {
                    Response.Redirect("Error.aspx");
                }

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
            DataQuinielaList = DB_Quiniela.getQuinielasByFilters(ddlSport.SelectedValue, ddlLiga.SelectedValue, ddlTorneo.SelectedValue, ddlJornada.SelectedValue);

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
                    (e.Row.FindControl("btnCalcular") as Button).Visible = false;
                    (e.Row.FindControl("btnProcesar") as Button).Visible = true;
                    (e.Row.FindControl("btnAbrir") as Button).Visible = false;
                    e.Row.Cells[8].Font.Bold = true;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Green;
                }
                else if (idStatus == 7)
                {
                    (e.Row.FindControl("btnCalcular") as Button).Visible = false;
                    (e.Row.FindControl("btnProcesar") as Button).Visible = false;
                    (e.Row.FindControl("btnAbrir") as Button).Visible = false;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[8].Font.Bold = true;
                }
                else if (idStatus == 1)
                {
                    (e.Row.FindControl("btnCalcular") as Button).Visible = false;
                    (e.Row.FindControl("btnProcesar") as Button).Visible = false;
                    (e.Row.FindControl("btnAbrir") as Button).Visible = true;

                    e.Row.Cells[8].Font.Bold = true;
                }
                else if (idStatus == 6)
                {
                    (e.Row.FindControl("btnCalcular") as Button).Visible = false;
                    (e.Row.FindControl("btnProcesar") as Button).Visible = false;
                    (e.Row.FindControl("btnAbrir") as Button).Visible = false;

                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Blue;
                    e.Row.Cells[8].Font.Bold = true;
                }
                else if (idStatus == 3)
                {
                    (e.Row.FindControl("btnCalcular") as Button).Visible = true;
                    (e.Row.FindControl("btnProcesar") as Button).Visible = false;
                    (e.Row.FindControl("btnAbrir") as Button).Visible = false;

                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Black;
                    e.Row.Cells[8].Font.Bold = true;
                }

            }
        }

        protected void btnNewQuiniela_Click(object sender, EventArgs e)
        {
            lblTittleModal.Visible = true;
            pnlQuiniela.Visible = false;

            clearFiltersQuinielaNew();
            getSportFilterNew();
            updateModalNewQuiniela.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaNew", "$('#modalQuinielaNew').modal();", true);
        }
        protected void clearFiltersQuinielaNew()
        {
            ddlLigaNew.Items.Clear();
            ddlTorneoNew.Items.Clear();
            ddlJornadaNew.Items.Clear();
            lblModalMsg.Text = String.Empty;

            ddlLigaNew.Enabled = false;
            ddlTorneoNew.Enabled = false;
            ddlJornadaNew.Enabled = false;
            btnAcceptNew.Enabled = false;

            btnAcceptNew.Visible = true;
            btnAddNew.Visible = false;
        }

        protected void DisabledFiltersQuinielaNew()
        {
            ddlSportNew.Enabled = false;
            ddlLigaNew.Enabled = false;
            ddlTorneoNew.Enabled = false;
            ddlJornadaNew.Enabled = false;
            btnAcceptNew.Visible = false;
        }

        protected void getSportFilterNew()
        {
            ddlSportNew.Enabled = true;
            ddlSportNew.DataSource = DB_Sport.getSportList();
            ddlSportNew.DataValueField = "idSport";
            ddlSportNew.DataTextField = "SportName";
            ddlSportNew.DataBind();
            ddlSportNew.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlSportNew.SelectedIndex = 0;

        }

        protected void getLigaFilterNew(string idSport)
        {
            ddlLigaNew.DataSource = DB_Liga.getLigaList(idSport);
            ddlLigaNew.DataValueField = "idLiga";
            ddlLigaNew.DataTextField = "LigaName";
            ddlLigaNew.DataBind();
            ddlLigaNew.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlLigaNew.SelectedIndex = 0;
            ddlLigaNew.Enabled = true;
        }
        protected void getTorneoFilterNew(string idLiga)
        {
            ddlTorneoNew.DataSource = DB_Torneo.getTorneoList(idLiga);
            ddlTorneoNew.DataValueField = "idTorneo";
            ddlTorneoNew.DataTextField = "TorneoName";
            ddlTorneoNew.DataBind();
            ddlTorneoNew.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlTorneoNew.SelectedIndex = 0;
            ddlTorneoNew.Enabled = true;
        }
        protected void getJornadaFilterNew(string idTorneo)
        {
            ddlJornadaNew.DataSource = DB_Jornada.getJornadaListV2(idTorneo);
            ddlJornadaNew.DataValueField = "idJornada";
            ddlJornadaNew.DataTextField = "JornadaName";
            ddlJornadaNew.DataBind();
            ddlJornadaNew.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlJornadaNew.SelectedIndex = 0;
            ddlJornadaNew.Enabled = true;
        }
        protected void ddlSportNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSportNew.SelectedIndex == 0)
            {
                clearFiltersQuinielaNew();
            }
            else
            {
                ddlTorneoNew.Items.Clear();
                ddlJornadaNew.Items.Clear();

                ddlTorneoNew.Enabled = false;
                ddlJornadaNew.Enabled = false;
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

                ddlLigaNew.Enabled = true;
                getLigaFilterNew(ddlSportNew.SelectedValue);
            }
        }

        protected void ddlLigaNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLigaNew.SelectedIndex == 0)
            {
                ddlTorneoNew.Items.Clear();
                ddlJornadaNew.Items.Clear();

                ddlTorneoNew.Enabled = false;
                ddlJornadaNew.Enabled = false;
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

            }
            else
            {
                ddlJornadaNew.Items.Clear();

                ddlJornadaNew.Enabled = false;
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

                ddlTorneoNew.Enabled = true;
                getTorneoFilterNew(ddlLigaNew.SelectedValue);
            }
        }

        protected void ddlTorneoNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTorneoNew.SelectedIndex == 0)
            {
                ddlJornadaNew.Items.Clear();

                ddlJornadaNew.Enabled = false;
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

            }
            else
            {
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

                ddlJornadaNew.Enabled = true;
                getJornadaFilterNew(ddlTorneoNew.SelectedValue);
            }
        }

        protected void ddlJornadaNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJornadaNew.SelectedIndex == 0)
            {
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

            }
            else
            {
                btnAcceptNew.Enabled = true;
                btnAddNew.Visible = false;

            }
        }
        protected void btnAcceptNew_Click(object sender, EventArgs e)
        {
            if (ddlSportNew.SelectedIndex == 0)
            {
                lblModalMsg.Text = "Seleccionar Sport";
                lblModalMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (ddlLigaNew.SelectedIndex == 0)
            {
                lblModalMsg.Text = "Seleccionar Liga";
                lblModalMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (ddlTorneoNew.SelectedIndex == 0)
            {
                lblModalMsg.Text = "Seleccionar Torneo";
                lblModalMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (ddlJornadaNew.SelectedIndex == 0)
            {
                lblModalMsg.Text = "Seleccionar Jornada";
                lblModalMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string QuinielaNo = "";
                UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);
                QuinielaNo = DB_Quiniela.InsertQuiniela(ddlSportNew.SelectedValue, ddlLigaNew.SelectedValue, ddlTorneoNew.SelectedValue, ddlJornadaNew.SelectedValue, Usuario.idUser.ToString());

                if (QuinielaNo == "Error")
                {
                    pnlQuiniela.Visible = false;
                    lblModalMsg.Text = "Error al agregar el Quiniela. Intente de Nuevo";
                    lblModalMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblTittleModal.Visible = false;
                    pnlQuiniela.Visible = true;
                    txtQuinielaNo.Text = QuinielaNo;
                    lblModalMsg.Text = "Quiniela Agregada Correctamente";
                    lblModalMsg.ForeColor = System.Drawing.Color.Green;
                    DisabledFiltersQuinielaNew();
                    btnAddNew.Visible = true;
                }
            }
        }

        protected void btnCloseNew_Click(object sender, EventArgs e)
        {
            updateModalNewQuiniela.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaNew", "$('#modalQuinielaNew').modal('hide');", true);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            clearFiltersQuinielaNew();
            getSportFilterNew();
        }

        protected void btnAbrir_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string idQuiniela = gridQuinielas.DataKeys[row.RowIndex].Values[0].ToString();
            string QuinielaNo = gridQuinielas.DataKeys[row.RowIndex].Values[3].ToString();
            string idLiga = gridQuinielas.DataKeys[row.RowIndex].Values[1].ToString();
            string idTorneo = gridQuinielas.DataKeys[row.RowIndex].Values[2].ToString();

            string Respuesta = DB_Quiniela.CanOpenQuiniela(idLiga, idTorneo);

            if (Respuesta == "Error")
            {
                pnlTitlesAbrir.Visible = false;
                pnlValuesAbrir.Visible = false;
                btnAcceptQuinielaAbrirConfirm.Visible = false;

                lblMsgAbrir.Text = "Ya hay una Quiniela Abierta o En Proceso del Mismo Torneo y Liga";
                lblMsgAbrir.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblMsgAbrir.Text = String.Empty;

                txtQuinielaNoDetalle.Text = QuinielaNo;
                idQuinielaAbrirHidden.Value = idQuiniela;

                pnlTitlesAbrir.Visible = true;
                pnlValuesAbrir.Visible = false;

                btnAcceptQuinielaAbrirConfirm.Visible = true;
            }

            updateModalAbrirQuinielaConfirm.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaAbrirConfirm", "$('#modalQuinielaAbrirConfirm').modal();", true);
        }
        protected void btnAcceptQuinielaAbrirConfirm_Click(object sender, EventArgs e)
        {
            string QuinielaNo = "";
            UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);

            QuinielaNo = DB_Quiniela.AbrirQuiniela(idQuinielaAbrirHidden.Value);

            if (QuinielaNo == "Error")
            {
                pnlTitlesAbrir.Visible = true;
                pnlValuesAbrir.Visible = false;
                lblMsgAbrir.Text = "Error al Abrir Quiniela. Intente de Nuevo";
                lblMsgAbrir.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                pnlTitlesAbrir.Visible = false;
                pnlValuesAbrir.Visible = true;

                btnAcceptQuinielaAbrirConfirm.Visible = false;

                txtQuinielaAbrir.Text = QuinielaNo;
                lblMsgAbrir.Text = "Quiniela Abierta Correctamente";
                lblMsgAbrir.ForeColor = System.Drawing.Color.Green;

                actualizarGrid();
            }
        }

        protected void btnCloseQuinielaAbrirConfirm_Click(object sender, EventArgs e)
        {
            updateModalAbrirQuinielaConfirm.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaAbrirConfirm", "$('#modalQuinielaAbrirConfirm').modal('hide');", true);

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

            DataQuinielaListV2 = DB_Quiniela.getApuestasByidQuiniela(idQuiniela);

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

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string idQuiniela = gridQuinielas.DataKeys[row.RowIndex].Values[0].ToString();

            idQuinielaProcesarHidden.Value = idQuiniela;

            lblMsgProcesar.Text = String.Empty;

            pnlTitlesProcesar.Visible = true;
            pnlValuesProcesar.Visible = false;

            btnAcceptQuinielaProcesarConfirm.Visible = true;

            updateModalProcesarQuinielaConfirm.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaProcesarConfirm", "$('#modalQuinielaProcesarConfirm').modal();", true);
        }
        protected void btnAcceptQuinielaProcesarConfirm_Click(object sender, EventArgs e)
        {
            string QuinielaNo = "";
            UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);

            QuinielaNo = DB_Quiniela.ProcesarQuiniela(idQuinielaProcesarHidden.Value);

            if (QuinielaNo == "Error")
            {
                pnlTitlesProcesar.Visible = true;
                pnlValuesProcesar.Visible = false;
                lblMsgProcesar.Text = "Error al Procesar Quiniela. Intente de Nuevo";
                lblMsgProcesar.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                pnlTitlesProcesar.Visible = false;
                pnlValuesProcesar.Visible = true;

                btnAcceptQuinielaProcesarConfirm.Visible = false;

                txtQuinielaProcesar.Text = QuinielaNo;
                lblMsgProcesar.Text = "Quiniela Procesada Correctamente";
                lblMsgProcesar.ForeColor = System.Drawing.Color.Green;

                actualizarGrid();
            }
        }

        protected void btnCloseQuinielaProcesarConfirm_Click(object sender, EventArgs e)
        {
            updateModalProcesarQuinielaConfirm.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaProcesarConfirm", "$('#modalQuinielaProcesarConfirm').modal('hide');", true);

        }
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string idQuiniela = gridQuinielas.DataKeys[row.RowIndex].Values[0].ToString();

            idQuinielaHidden.Value = idQuiniela;

            lblMsgCalcular.Text = String.Empty;

            pnlTitles.Visible = true;
            pnlValuesCalculate.Visible = false;

            btnAcceptQuinielaCalcularConfirm.Visible = true;

            updateModalCalcularQuinielaConfirm.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaCalcularConfirm", "$('#modalQuinielaCalcularConfirm').modal();", true);
        }
        protected void btnAcceptQuinielaCalcularConfirm_Click(object sender, EventArgs e)
        {
            string QuinielaNo = "";
            UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);

            QuinielaNo = DB_Quiniela.CalcularQuiniela(idQuinielaHidden.Value);

            if (QuinielaNo == "Error")
            {
                pnlTitles.Visible = true;
                pnlValuesCalculate.Visible = false;
                lblMsgCalcular.Text = "Error al Calcular Quiniela. Intente de Nuevo";
                lblMsgCalcular.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                pnlTitles.Visible = false;
                pnlValuesCalculate.Visible = true;

                btnAcceptQuinielaCalcularConfirm.Visible = false;

                txtQuinielaCalcular.Text = QuinielaNo;
                lblMsgCalcular.Text = "Quiniela Calculada Correctamente";
                lblMsgCalcular.ForeColor = System.Drawing.Color.Green;

                actualizarGrid();
            }
        }

        protected void btnCloseQuinielaCalcularConfirm_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuinielaCalcularConfirm", "$('#modalQuinielaCalcularConfirm').modal('hide');", true);
        }

        
    }
}