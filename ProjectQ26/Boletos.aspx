<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Boletos.aspx.cs" Inherits="ProjectQ26.Boletos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

    <div class="box-body">
        <!-- .modal -->
        <div class="modal fade bs-example-modal-lg" id="modalQuinielaDetalles" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalDetallesQuiniela" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label runat="server" ID="lblTittleModalDetalle" CssClass="h4 modal-title" Text="Detalle Quiniela"></asp:Label>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblQuinielaNoDetalle" runat="server" Text="Quiniela No:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtQuinielaNoDetalle" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="modal-body">
                                <div class="table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanelModalDetalle" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="gridQuinielaModalDetalle" runat="server" CssClass="TableNewModal100" AutoGenerateColumns="false"
                                                DataKeyNames="idPartido" HorizontalAlign="Center"
                                                EnableModelValidation="True" OnRowDataBound="gridQuinielaModalDetalle_RowDataBound">

                                                <Columns>
                                                    <asp:BoundField ReadOnly="true" HeaderText="No" DataField="idPartido" Visible="false"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" HeaderText="Fecha" DataField="PartidoDate" Visible="false"></asp:BoundField>


                                                    <asp:BoundField ReadOnly="true" HeaderText="Local" DataField="EquipoLocalShort"></asp:BoundField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                                        <ItemTemplate>
                                                            <asp:Image runat="server" ID="imgLocal" Width="25px" Height="25px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField ReadOnly="true" HeaderText="idGolesLocal" DataField="idGolesLocal" Visible="false"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" HeaderText="GL" DataField="GolesLocal" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>

                                                    <asp:BoundField ReadOnly="true" HeaderText="idGolesVisitante" DataField="idGolesVisitante" Visible="false"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" HeaderText="GV" DataField="GolesVisitante" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                                        <ItemTemplate>
                                                            <asp:Image runat="server" ID="imgVisita" Width="25px" Height="25px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField ReadOnly="true" DataField="EquipoVisitanteShort" HeaderText="Visita" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" DataField="idResultadoApuesta" HeaderText="idResultado" Visible="false"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" DataField="ResultadoApuestaNameShort" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" DataField="Total" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30px"></asp:BoundField>
                                                </Columns>

                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <asp:Label ID="lblTotalPuntosDetalle" runat="server" Text="Total:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtTotalPuntosDetalle" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Label ID="lblMsgModalDetalle" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnCloseQuinielaDetalla" CssClass="btn btn-danger" OnClick="btnCloseQuinielaDetalla_Click" Text="Cerrar" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="modal fade bs-example-modal-lg" id="modalQuinielaApuestas" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalApuestasQuiniela" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="idQuinielaApuestasHidden" runat="server" />
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label runat="server" ID="lblTittleModalApuestas" CssClass="h4 modal-title" Text="Apuestas Quiniela"></asp:Label>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblQuinielaNoApuestas" runat="server" Text="Quiniela No:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtQuinielaNoApuestas" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="modal-body">
                                <div class="table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanelModalApuestas" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="gridQuinielaModalApuestas" runat="server" CssClass="TableNewModal100" AutoGenerateColumns="false"
                                                OnRowDataBound="gridQuinielaModalApuestas_RowDataBound" DataKeyNames="idApuesta" HorizontalAlign="Center"
                                                EnableModelValidation="True">

                                                <Columns>
                                                    <asp:BoundField ReadOnly="true" HeaderText="idApuesta" DataField="idApuesta" Visible="false"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" HeaderText="Apuesta No" DataField="ApuestaNo" Visible="false"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" HeaderText="idUser" DataField="idUser" Visible="false"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" HeaderText="Usuario" DataField="UserName"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" HeaderText="Total" DataField="Total"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" HeaderText="Status" DataField="StatusName"></asp:BoundField>
                                                </Columns>

                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <br />
                                <asp:Label ID="lblMsgApuestas" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnCloseQuinielaApuestasConfirm" CssClass="btn btn-danger" OnClick="btnCloseQuinielaApuestasConfirm_Click" Text="Cerrar" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </div>

    <asp:UpdatePanel ID="updPnlFiltros" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <!-- Page Heading -->
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
                <h1 class="h3 mb-0 text-gray-800">Boletos
                </h1>
                <asp:Button runat="server" ID="btnReporte" Text="Buscar" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnReporte_Click" />
                <%--<a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-download fa-sm text-white-50"></i>Generate Report</a>--%>
            </div>

            <!-- Content Row -->

            <div class="row">

                <!-- Sport -->
                <div class="col-xl-3 col-md-6 mb-4">
                    <div class="card">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-1">
                                    <asp:Label runat="server" ID="lblSport" CssClass="mb-0 font-weight-bold text-gray-800" Text="Sport"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlSport" CssClass="btn btn-block dropdown-toggle col mr-1 border" OnSelectedIndexChanged="ddlSport_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Liga -->
                <div class="col-xl-3 col-md-6 mb-4">
                    <div class="card">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-1">
                                    <asp:Label runat="server" ID="lblLiga" CssClass="mb-0 font-weight-bold text-gray-800" Text="Liga"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlLiga" Enabled="false" CssClass="btn btn-block dropdown-toggle col mr-1 border" OnSelectedIndexChanged="ddlLiga_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Torneo -->
                <div class="col-xl-3 col-md-6 mb-4">
                    <div class="card">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-1">
                                    <asp:Label runat="server" ID="lblTorneo" CssClass="mb-0 font-weight-bold text-gray-800" Text="Torneo"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlTorneo" Enabled="false" CssClass="btn btn-block dropdown-toggle col mr-1 border" OnSelectedIndexChanged="ddlTorneo_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Jornada -->
                <div class="col-xl-3 col-md-6 mb-4">
                    <div class="card">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-1">
                                    <asp:Label runat="server" ID="lblJornada" CssClass="mb-0 font-weight-bold text-gray-800" Text="Jornada"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlJornada" Enabled="false" CssClass="btn btn-block dropdown-toggle col mr-1 border" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="row">

        <div class="table-responsive">

            <asp:UpdatePanel ID="updateGridPrincipal" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <%--<asp:Button runat="server" ID="btnNewQuiniela" Text="Nueva Quiniela" CssClass="d-none d-sm-inline-block btn btn-sm btn-dark shadow-sm" OnClick="btnNewQuiniela_Click" />--%>
                    <br />
                    <br />

                    <asp:GridView ID="gridQuinielas" runat="server" CssClass="TableNew" AutoGenerateColumns="false"
                        DataKeyNames="idQuiniela, idLiga, idTorneo, QuinielaNo, idApuesta" EmptyDataText="No hay Boletos con esa Busqueda"
                        EnableModelValidation="True" OnRowDataBound="gridQuinielas_RowDataBound">

                        <Columns>
                            <asp:BoundField ReadOnly="true" HeaderText="idQuiniela" DataField="idQuiniela" Visible="false"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="Sport" DataField="SportNameShort"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="idLiga" DataField="idLiga" Visible="false"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="Liga" DataField="LigaNameShort"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="idTorneo" DataField="idTorneo" Visible="false"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="Torneo" DataField="TorneoNameShort"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="Jornada" DataField="JornadaNameShort"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="Quiniela No" DataField="QuinielaNo"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="idApuesta" DataField="idApuesta" Visible="false"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="ApuestaNo" DataField="ApuestaNo"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="Total" DataField="Total"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="idStatus" DataField="idStatus" Visible="false"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderText="Detalle">
                                <ItemTemplate>
                                    <asp:Button ID="btnDetalle" runat="server" CssClass="btn btn-outline-dark" Text="Detalle" OnClick="btnDetalle_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderText="Apuestas">
                                <ItemTemplate>
                                    <asp:Button ID="btnApuestas" runat="server" CssClass="btn btn-info" Text="Apuestas" OnClick="btnApuestas_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField ReadOnly="true" HeaderText="StatusName" DataField="StatusName"></asp:BoundField>

                        </Columns>

                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>
