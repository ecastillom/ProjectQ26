using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectQ26
{
    public partial class QuinielasGeneral : System.Web.UI.Page
    {
        Quiniela DataQuiniela = new Quiniela();
        List<Quiniela> DataQuielaList = new List<Quiniela>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);
                idSportHidden.Value = StringCipher.Decrypt(Request["idSport"]);
                idLigaHidden.Value = StringCipher.Decrypt(Request["idLiga"]);

                GetDataQuiniela(idSportHidden.Value, idLigaHidden.Value);
                actualizarGrid();
            }
        }

        protected void GetDataQuiniela(string idSportPar, string idLigaPar)
        {
            DataQuiniela = DB_Quiniela.getQuinielaData(idSportPar, idLigaPar);

            if (DataQuiniela.idStatus == 3)
            {
                lblTitleQuinielas.Text = "Quiniela : " + DataQuiniela.QuinielaNo + " (EN PROCESO)";
                btnAddQuiniela.Enabled = false;
            }
            else if (DataQuiniela.idStatus == 6)
            {
                lblTitleQuinielas.Text = "Quiniela : " + DataQuiniela.QuinielaNo + " (Cerrada)";
                btnAddQuiniela.Enabled = false;
            }
            else
            {
                lblTitleQuinielas.Text = "Quiniela : " + DataQuiniela.QuinielaNo;
                btnAddQuiniela.Enabled = true;
            }

            idQuinielaHidden.Value = DataQuiniela.idQuiniela.ToString();

            lblLigaName.Text = DataQuiniela.LigaName + " - " + DataQuiniela.TorneoName;
            lblJornada.Text = DataQuiniela.JornadaName;
            imgLogoLiga.ImageUrl = DataQuiniela.LigaImgURL;
        }

        private void actualizarGrid()
        {
            DataQuielaList = DB_Quiniela.getQuinielaPartidosByidQuiniela(idQuinielaHidden.Value);

            gridQuiniela.DataSource = DataQuielaList;
            gridQuiniela.DataBind();

            gridQuinielaModal.DataSource = DataQuielaList;
            gridQuinielaModal.DataBind();

            updateGridPrincipal.Update();
            UpdatePanelModal.Update();

        }

        protected void gridQuiniela_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.FindControl("imgLocal") as Image).ImageUrl = DataQuielaList[e.Row.RowIndex].EquipoLocalImgURL;
                (e.Row.FindControl("imgVisita") as Image).ImageUrl = DataQuielaList[e.Row.RowIndex].EquipoVisitanteImgURL;

                RadioButtonList rdbOpcion = e.Row.FindControl("rdbOpcion") as RadioButtonList;

                if ((DataQuiniela.idStatus == 3) || (DataQuiniela.idStatus == 6))
                {
                    rdbOpcion.Enabled = false;
                }
            }

        }

        protected void gridQuinielaModal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.FindControl("imgLocal") as Image).ImageUrl = DataQuielaList[e.Row.RowIndex].EquipoLocalImgURL;
                (e.Row.FindControl("imgVisita") as Image).ImageUrl = DataQuielaList[e.Row.RowIndex].EquipoVisitanteImgURL;
                
            }
        }

        protected void btnAddQuiniela_Click(object sender, EventArgs e)
        {
            lblTittleModal.Visible = true;
            pnlBoleto.Visible = false;
            btnBoletos.Visible = false;

            int TotalChecks = 0;
            int CountChecks = 0;

            TotalChecks = gridQuiniela.Rows.Count;
            for (int x = 0; x < TotalChecks; x++)
            {
                RadioButtonList rdbOpcion = gridQuiniela.Rows[x].FindControl("rdbOpcion") as RadioButtonList;

                if (rdbOpcion.SelectedValue == "1" || rdbOpcion.SelectedValue == "2" || rdbOpcion.SelectedValue == "3")
                {
                    CountChecks = CountChecks + 1;
                }
            }

            if (CountChecks == TotalChecks)
            {
                for (int x = 0; x < TotalChecks; x++)
                {
                    RadioButtonList rdbOpcion = gridQuiniela.Rows[x].FindControl("rdbOpcion") as RadioButtonList;
                    Label lblModal = gridQuinielaModal.Rows[x].FindControl("lblOpcion") as Label;
                    
                    if (rdbOpcion.SelectedValue == "1")
                    {
                        lblModal.Text = "L";
                    }
                    else if (rdbOpcion.SelectedValue == "2")
                    {
                        lblModal.Text = "E";
                    }
                    else if (rdbOpcion.SelectedValue == "3")
                    {
                        lblModal.Text = "V";
                    }
                }

                lblModalMsg.Text = "Esta de acuerdo con las opciones seleccionadas?";
                lblModalMsg.ForeColor = System.Drawing.Color.Blue;
                gridQuinielaModal.Visible = true;
                UpdatePanelModal.Update();
                btnAccept.Visible = true;

            }
            else
            {
                lblModalMsg.Text = "Debes llenar todos los partidos";
                lblModalMsg.ForeColor = System.Drawing.Color.Red;
                gridQuinielaModal.Visible = false;
                UpdatePanelModal.Update();

            }

            updateModalNewQuiniela.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuiniela", "$('#modalQuiniela').modal();", true);

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            updateModalNewQuiniela.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalQuiniela", "$('#modalQuiniela').modal('hide');", true);
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            int TotalChecks = 0;
            string Opciones = "";

            TotalChecks = gridQuiniela.Rows.Count;

            for (int x = 0; x < TotalChecks; x++)
            {
                RadioButtonList rdbOpcion = gridQuiniela.Rows[x].FindControl("rdbOpcion") as RadioButtonList;

                if(x == 0)
                {
                    Opciones = rdbOpcion.SelectedValue + ", ";
                }
                else if (x == (TotalChecks - 1))
                {
                    Opciones = Opciones + rdbOpcion.SelectedValue;
                }
                else
                {
                    Opciones = Opciones + rdbOpcion.SelectedValue + ", ";
                }

            }

            string boleto = "";
            UserPlayer Usuario = Utils.Generico.usuarioRegistrado(Session);
            boleto = DB_Quiniela.InsertQuinielaGetBoletoNo(idQuinielaHidden.Value, Usuario.idUser.ToString(), Opciones);

            if(boleto == "Error")
            {
                pnlBoleto.Visible = false;
                btnBoletos.Visible = false;
                lblModalMsg.Text = "Error al agregar la Quiniela. Intente de Nuevo";
                lblModalMsg.ForeColor = System.Drawing.Color.Red;
                updateGridPrincipal.Update();
                updateModalNewQuiniela.Update();
            }
            else
            {
                lblTittleModal.Visible = false;
                pnlBoleto.Visible = true;
                btnBoletos.Visible = true;
                txtBoleto.Text = boleto;
                lblModalMsg.Text = "Quiniela agregada Correctamente";
                lblModalMsg.ForeColor = System.Drawing.Color.Green;
                gridQuinielaModal.Visible = false;
                btnAccept.Visible = false;

                actualizarGrid();
                updateGridPrincipal.Update();
                updateModalNewQuiniela.Update();
                updateGridPrincipal.Update();
            }

        }

        protected void btnBoletos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Boletos.aspx");
        }


        //protected void gridQuiniela_DataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DataRowView dr = (DataRowView)e.Row.DataItem;
        //        (e.Row.FindControl("imgLocal") as Image).ImageUrl = dr["EquipoLocalImgURL"].ToString();
        //    }

        //    //if (e.Row.RowType == DataControlRowType.DataRow)
        //    //{
        //    //}

        //    //foreach (GridViewRow gvC in gridQuiniela.Rows)
        //    //{

        //    //    Image lblSample = (Image)gvC.FindControl("imgLocal");
        //    //    lblSample.ImageUrl = "/Images/Ligas/Equipos/AtleticoSL.png";
        //    //}
        //}
    }
}