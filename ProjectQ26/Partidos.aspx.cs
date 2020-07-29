using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectQ26
{

    public partial class Partidos : System.Web.UI.Page
    {
        Partido DataQuiniela = new Partido();
        List<Partido> DataPartidoList = new List<Partido>();
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
            DataPartidoList = DB_Partido.getPartidosByFilters(ddlSport.SelectedValue, ddlLiga.SelectedValue, ddlTorneo.SelectedValue, ddlJornada.SelectedValue);

            gridPartidos.DataSource = DataPartidoList;
            gridPartidos.DataBind();

            updateGridPrincipal.Update();

        }

        protected void gridPartidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.FindControl("imgLocal") as Image).ImageUrl = DataPartidoList[e.Row.RowIndex].EquipoLocalImgURL;
                (e.Row.FindControl("imgVisita") as Image).ImageUrl = DataPartidoList[e.Row.RowIndex].EquipoVisitanteImgURL;

                int idResultado = DataPartidoList[e.Row.RowIndex].idResultado;

                if (idResultado == 4)
                {
                    (e.Row.FindControl("btnEditar") as Button).Visible = true;
                    e.Row.Cells[15].Font.Bold = true;
                }
                else
                {
                    (e.Row.FindControl("btnEditar") as Button).Visible = false;
                    e.Row.Cells[15].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[15].Font.Bold = true;
                }

            }
        }
        protected void btnNewPartido_Click(object sender, EventArgs e)
        {
            clearFiltersPartidoNew();
            getSportFilterNew();
            updateModalNewPartido.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalPartidoNew", "$('#modalPartidoNew').modal();", true);
        }

        protected void clearFiltersPartidoNew()
        {
            ddlLigaNew.Items.Clear();
            ddlTorneoNew.Items.Clear();
            ddlJornadaNew.Items.Clear();
            ddlEquipoLocalNew.Items.Clear();
            ddlEquipoVisitaNew.Items.Clear();
            txtDatePartidoNew.Text = String.Empty;
            txtHourPartidoNew.Text = String.Empty;
            lblModalMsg.Text = String.Empty;

            ddlLigaNew.Enabled = false;
            ddlTorneoNew.Enabled = false;
            ddlJornadaNew.Enabled = false;
            ddlEquipoLocalNew.Enabled = false;
            ddlEquipoVisitaNew.Enabled = false;
            txtDatePartidoNew.Enabled = false;
            txtHourPartidoNew.Enabled = false;
            btnAcceptNew.Enabled = false;

            btnAcceptNew.Visible = true;
            btnAddNew.Visible = false;
        }

        protected void DisabledFiltersPartidoNew()
        {
            ddlSportNew.Enabled = false;
            ddlLigaNew.Enabled = false;
            ddlTorneoNew.Enabled = false;
            ddlJornadaNew.Enabled = false;
            ddlEquipoLocalNew.Enabled = false;
            ddlEquipoVisitaNew.Enabled = false;
            txtDatePartidoNew.Enabled = false;
            txtHourPartidoNew.Enabled = false;
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
            ddlJornadaNew.DataSource = DB_Jornada.getJornadaList(idTorneo);
            ddlJornadaNew.DataValueField = "idJornada";
            ddlJornadaNew.DataTextField = "JornadaName";
            ddlJornadaNew.DataBind();
            ddlJornadaNew.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlJornadaNew.SelectedIndex = 0;
            ddlJornadaNew.Enabled = true;
        }
        protected void getEquipoLocalFilterNew(string idLiga, string idTorneo, string idJornada)
        {
            ddlEquipoLocalNew.DataSource = DB_Equipo.getEquipoLocalNewPartido(idLiga, idTorneo, idJornada);
            ddlEquipoLocalNew.DataValueField = "idEquipo";
            ddlEquipoLocalNew.DataTextField = "EquipoName";
            ddlEquipoLocalNew.DataBind();
            ddlEquipoLocalNew.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlEquipoLocalNew.SelectedIndex = 0;
            ddlEquipoLocalNew.Enabled = true;
        }
        protected void getEquipoVisitaFilterNew(string idLiga, string idTorneo, string idJornada, string idEquipoLocal)
        {
            ddlEquipoVisitaNew.DataSource = DB_Equipo.getEquipoVisitaNewPartido(idLiga, idTorneo, idJornada, idEquipoLocal);
            ddlEquipoVisitaNew.DataValueField = "idEquipo";
            ddlEquipoVisitaNew.DataTextField = "EquipoName";
            ddlEquipoVisitaNew.DataBind();
            ddlEquipoVisitaNew.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlEquipoVisitaNew.SelectedIndex = 0;
            ddlEquipoVisitaNew.Enabled = true;
        }
        protected void ddlSportNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSportNew.SelectedIndex == 0)
            {
                clearFiltersPartidoNew();
            }
            else
            {
                ddlTorneoNew.Items.Clear();
                ddlJornadaNew.Items.Clear();
                ddlEquipoLocalNew.Items.Clear();
                ddlEquipoVisitaNew.Items.Clear();
                txtDatePartidoNew.Text = String.Empty;
                txtHourPartidoNew.Text = String.Empty;

                ddlTorneoNew.Enabled = false;
                ddlJornadaNew.Enabled = false;
                ddlEquipoLocalNew.Enabled = false;
                ddlEquipoVisitaNew.Enabled = false;
                txtDatePartidoNew.Enabled = false;
                txtHourPartidoNew.Enabled = false;
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
                ddlEquipoLocalNew.Items.Clear();
                ddlEquipoVisitaNew.Items.Clear();
                txtDatePartidoNew.Text = String.Empty;
                txtHourPartidoNew.Text = String.Empty;

                ddlTorneoNew.Enabled = false;
                ddlJornadaNew.Enabled = false;
                ddlEquipoLocalNew.Enabled = false;
                ddlEquipoVisitaNew.Enabled = false;
                txtDatePartidoNew.Enabled = false;
                txtHourPartidoNew.Enabled = false;
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

            }
            else
            {
                ddlJornadaNew.Items.Clear();
                ddlEquipoLocalNew.Items.Clear();
                ddlEquipoVisitaNew.Items.Clear();
                txtDatePartidoNew.Text = String.Empty;
                txtHourPartidoNew.Text = String.Empty;

                ddlJornadaNew.Enabled = false;
                ddlEquipoLocalNew.Enabled = false;
                ddlEquipoVisitaNew.Enabled = false;
                txtDatePartidoNew.Enabled = false;
                txtHourPartidoNew.Enabled = false;
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
                ddlEquipoLocalNew.Items.Clear();
                ddlEquipoVisitaNew.Items.Clear();
                txtDatePartidoNew.Text = String.Empty;
                txtHourPartidoNew.Text = String.Empty;

                ddlJornadaNew.Enabled = false;
                ddlEquipoLocalNew.Enabled = false;
                ddlEquipoVisitaNew.Enabled = false;
                txtDatePartidoNew.Enabled = false;
                txtHourPartidoNew.Enabled = false;
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

            }
            else
            {
                ddlEquipoLocalNew.Items.Clear();
                ddlEquipoVisitaNew.Items.Clear();
                txtDatePartidoNew.Text = String.Empty;
                txtHourPartidoNew.Text = String.Empty;

                ddlEquipoLocalNew.Enabled = false;
                ddlEquipoVisitaNew.Enabled = false;
                txtDatePartidoNew.Enabled = false;
                txtHourPartidoNew.Enabled = false;
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
                ddlEquipoLocalNew.Items.Clear();
                ddlEquipoVisitaNew.Items.Clear();
                txtDatePartidoNew.Text = String.Empty;
                txtHourPartidoNew.Text = String.Empty;

                ddlEquipoLocalNew.Enabled = false;
                ddlEquipoVisitaNew.Enabled = false;
                txtDatePartidoNew.Enabled = false;
                txtHourPartidoNew.Enabled = false;
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

            }
            else
            {
                ddlEquipoVisitaNew.Items.Clear();
                txtDatePartidoNew.Text = String.Empty;
                txtHourPartidoNew.Text = String.Empty;
                ddlEquipoVisitaNew.Enabled = false;
                txtDatePartidoNew.Enabled = false;
                txtHourPartidoNew.Enabled = false;
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

                ddlEquipoLocalNew.Enabled = true;
                getEquipoLocalFilterNew(ddlLigaNew.SelectedValue, ddlTorneoNew.SelectedValue, ddlJornadaNew.SelectedValue);
            }
        }

        protected void ddlEquipoLocalNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEquipoLocalNew.SelectedIndex == 0)
            {
                ddlEquipoVisitaNew.Items.Clear();
                txtDatePartidoNew.Text = String.Empty;
                txtHourPartidoNew.Text = String.Empty;

                ddlEquipoVisitaNew.Enabled = false;
                txtDatePartidoNew.Enabled = false;
                txtHourPartidoNew.Enabled = false;
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

            }
            else
            {
                txtDatePartidoNew.Text = String.Empty;
                txtHourPartidoNew.Text = String.Empty;
                txtDatePartidoNew.Enabled = false;
                txtHourPartidoNew.Enabled = false;
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;

                ddlEquipoVisitaNew.Enabled = true;
                getEquipoVisitaFilterNew(ddlLigaNew.SelectedValue, ddlTorneoNew.SelectedValue, ddlJornadaNew.SelectedValue, ddlEquipoLocalNew.SelectedValue);
            }
        }

        protected void ddlEquipoVisitaNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEquipoVisitaNew.SelectedIndex == 0)
            {
                txtDatePartidoNew.Text = String.Empty;
                txtHourPartidoNew.Text = String.Empty;

                txtDatePartidoNew.Enabled = false;
                txtHourPartidoNew.Enabled = false;
                btnAcceptNew.Enabled = false;

                btnAddNew.Visible = false;
            }
            else
            {
                txtDatePartidoNew.Text = String.Empty;
                txtHourPartidoNew.Text = String.Empty;

                txtDatePartidoNew.Enabled = true;
                txtHourPartidoNew.Enabled = true;
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
            else if (ddlEquipoLocalNew.SelectedIndex == 0)
            {
                lblModalMsg.Text = "Seleccionar Equipo Local";
                lblModalMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (ddlEquipoVisitaNew.SelectedIndex == 0)
            {
                lblModalMsg.Text = "Seleccionar Equipo Visita";
                lblModalMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (String.IsNullOrEmpty(txtDatePartidoNew.Text))
            {
                txtDatePartidoNew.Focus();
                lblModalMsg.Text = "Seleccionar Fecha";
                lblModalMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (String.IsNullOrEmpty(txtHourPartidoNew.Text))
            {
                txtHourPartidoNew.Focus();
                lblModalMsg.Text = "Agregar Hora";
                lblModalMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string idPartido = "";
                UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);
                idPartido = DB_Partido.InsertPartidoGetidPartido(ddlLigaNew.SelectedValue, ddlTorneoNew.SelectedValue, ddlJornadaNew.SelectedValue, ddlEquipoLocalNew.SelectedValue, ddlEquipoVisitaNew.SelectedValue, txtDatePartidoNew.Text + " " + txtHourPartidoNew.Text, Usuario.idUser.ToString());

                if (idPartido == "Error")
                {
                    lblModalMsg.Text = "Error al agregar el Partido. Intente de Nuevo";
                    lblModalMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblModalMsg.Text = "Partido Agregado Correctamente";
                    lblModalMsg.ForeColor = System.Drawing.Color.Green;
                    DisabledFiltersPartidoNew();
                    btnAddNew.Visible = true;
                }
            }
        }

        protected void btnCloseNew_Click(object sender, EventArgs e)
        {
            updateModalNewPartido.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalPartidoNew", "$('#modalPartidoNew').modal('hide');", true);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            clearFiltersPartidoNew();
            getSportFilterNew();
        }

        protected void getResultadoEditar(string idResultado)
        {
            ddlResultadoEdit.DataSource = DB_Resultado.getResultadoList();
            ddlResultadoEdit.DataValueField = "idResultado";
            ddlResultadoEdit.DataTextField = "ResultadoName";
            ddlResultadoEdit.DataBind();
            ddlResultadoEdit.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlResultadoEdit.SelectedValue = idResultado;
            ddlResultadoEdit.Enabled = true;
        }
        protected void getGolesLocalEditar(string idGol)
        {
            ddlGolesLocalEdit.DataSource = DB_Gol.getGolList();
            ddlGolesLocalEdit.DataValueField = "idGol";
            ddlGolesLocalEdit.DataTextField = "GolNo";
            ddlGolesLocalEdit.DataBind();
            ddlGolesLocalEdit.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlGolesLocalEdit.SelectedValue = idGol;
            ddlGolesLocalEdit.Enabled = true;
        }
        protected void getGolesVisitaEditar(string idGol)
        {
            ddlGolesVisitanteEdit.DataSource = DB_Gol.getGolList();
            ddlGolesVisitanteEdit.DataValueField = "idGol";
            ddlGolesVisitanteEdit.DataTextField = "GolNo";
            ddlGolesVisitanteEdit.DataBind();
            ddlGolesVisitanteEdit.Items.Insert(0, new ListItem("- Seleccionar -", String.Empty));
            ddlGolesVisitanteEdit.SelectedValue = idGol;
            ddlGolesVisitanteEdit.Enabled = true;
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            lblMsgModalEdit.Text = String.Empty;
            lblMsgModalEdit.ForeColor = System.Drawing.Color.Green;

            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string idPartido = gridPartidos.DataKeys[row.RowIndex].Values[0].ToString();
            string idResultado = gridPartidos.DataKeys[row.RowIndex].Values[1].ToString();
            string idGolesLocal = gridPartidos.DataKeys[row.RowIndex].Values[2].ToString();
            string idGolesVisita = gridPartidos.DataKeys[row.RowIndex].Values[3].ToString();
            string EquipoLocal = gridPartidos.DataKeys[row.RowIndex].Values[4].ToString();
            string EquipoVisita = gridPartidos.DataKeys[row.RowIndex].Values[5].ToString();

            getResultadoEditar(idResultado);
            getGolesLocalEditar(idGolesLocal);
            getGolesVisitaEditar(idGolesVisita);

            txtPartidoEdit.Text = idPartido;
            txtLocalEdit.Text = EquipoLocal;
            txtVisitaEdit.Text = EquipoVisita;

            EnabledFielsPartidoEdit();

            updateModalEditPartido.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalPartidoEdit", "$('#modalPartidoEdit').modal();", true);
        }

        protected void DisabledFielsPartidoEdit()
        {
            ddlResultadoEdit.Enabled = false;
            ddlGolesLocalEdit.Enabled = false;
            ddlGolesVisitanteEdit.Enabled = false;
            btnAcceptPartidoEdit.Enabled = false;
        }
        protected void EnabledFielsPartidoEdit()
        {
            ddlResultadoEdit.Enabled = true;
            ddlGolesLocalEdit.Enabled = true;
            ddlGolesVisitanteEdit.Enabled = true;
            btnAcceptPartidoEdit.Enabled = true;
        }

        protected void btnAcceptPartidoEdit_Click(object sender, EventArgs e)
        {
            if (ddlResultadoEdit.SelectedIndex == 0)
            {
                lblMsgModalEdit.Text = "Seleccionar Resultado";
                lblMsgModalEdit.ForeColor = System.Drawing.Color.Red;
            }
            else if (ddlResultadoEdit.SelectedValue == "4")
            {
                lblMsgModalEdit.Text = "Seleccionar Local, Empate o Visita";
                lblMsgModalEdit.ForeColor = System.Drawing.Color.Red;
            }
            else if (ddlGolesLocalEdit.SelectedIndex == 0)
            {
                lblMsgModalEdit.Text = "Seleccionar Goles del Local";
                lblMsgModalEdit.ForeColor = System.Drawing.Color.Red;
            }
            else if (ddlGolesVisitanteEdit.SelectedIndex == 0)
            {
                lblMsgModalEdit.Text = "Seleccionar Goles del Visitante";
                lblMsgModalEdit.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                updateModalEditPartidoConfirm.Update();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalPartidoEditConfirm", "$('#modalPartidoEditConfirm').modal();", true);
            }
        }

        protected void btnClosePartidoEdit_Click(object sender, EventArgs e)
        {
            updateModalEditPartido.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalPartidoEdit", "$('#modalPartidoEdit').modal('hide');", true);
        }

        protected void btnAcceptPartidoEditConfirm_Click(object sender, EventArgs e)
        {
            string ValueSP = DB_Partido.UpdateResultadosPartido(txtPartidoEdit.Text, ddlResultadoEdit.SelectedValue, ddlGolesLocalEdit.SelectedValue, ddlGolesVisitanteEdit.SelectedValue);

            if (ValueSP == "UPDATE")
            {
                updateModalEditPartidoConfirm.Update();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalPartidoEditConfirm", "$('#modalPartidoEditConfirm').modal('hide');", true);
                actualizarGrid();
                DisabledFielsPartidoEdit();
                updateModalEditPartido.Update();
                lblMsgModalEdit.Text = "Resultado guardado Exitosamente";
                lblMsgModalEdit.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void btnClosePartidoEditConfirm_Click(object sender, EventArgs e)
        {
            updateModalEditPartidoConfirm.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalPartidoEditConfirm", "$('#modalPartidoEditConfirm').modal('hide');", true);
        }
    }
}