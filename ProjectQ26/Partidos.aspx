<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Partidos.aspx.cs" Inherits="ProjectQ26.Partidos" %>
<%@ Register Assembly="AjaxControlToolKit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

    <div class="box-body">
        <div class="modal fade bs-example-modal-lg" id="modalPartidoNew" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalNewPartido" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label runat="server" ID="lblTittleModal" CssClass="h4 modal-title" Text="Agregar Partido"></asp:Label>
                            </div>
                            <div class="modal-body">

                                <asp:Label ID="lblSportNew" runat="server" Text="Sport:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:DropDownList ID="ddlSportNew" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSportNew_SelectedIndexChanged"></asp:DropDownList>
                                <asp:Label ID="lblLigaNew" runat="server" Text="Liga:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:DropDownList ID="ddlLigaNew" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLigaNew_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="lblTorneoNew" runat="server" Text="Torneo:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:DropDownList ID="ddlTorneoNew" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTorneoNew_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="lblJornadaNew" runat="server" Text="Jornada:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:DropDownList ID="ddlJornadaNew" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlJornadaNew_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="lblEquipoLocalNew" runat="server" Text="Local:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:DropDownList ID="ddlEquipoLocalNew" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEquipoLocalNew_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="lblEquipoVisitante" runat="server" Text="Visita:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:DropDownList ID="ddlEquipoVisitaNew" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEquipoVisitaNew_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="lblDatePartidoNew" runat="server" Text="Fecha Partido:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtDatePartidoNew" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                <cc1:calendarextender id="Calendar1" popupbuttonid="imgPopup" runat="server" targetcontrolid="txtDatePartidoNew" format="yyyy-MM-dd"></cc1:calendarextender>
                                <asp:Label ID="lblHourPartidoNew" runat="server" Text="Hora Partido:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtHourPartidoNew" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Label ID="lblModalMsg" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                            <div class="modal-footer">

                                <asp:Button runat="server" ID="btnAcceptNew" CssClass="btn btn-primary" OnClick="btnAcceptNew_Click" Text="Aceptar" Enabled="false" />
                                <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-info" OnClick="btnAddNew_Click" Text="Nuevo Partido" Visible="false" />
                                <asp:Button runat="server" ID="btnCloseNew" CssClass="btn btn-danger" OnClick="btnCloseNew_Click" Text="Cerrar" />
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSportNew" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlLigaNew" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlTorneoNew" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlJornadaNew" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlEquipoLocalNew" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlEquipoVisitaNew" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnAcceptNew" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->

        
        <div class="modal fade bs-example-modal-lg" id="modalPartidoEdit" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalEditPartido" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label runat="server" ID="lblTitleModalEdit" CssClass="h4 modal-title" Text="Actualizar Partido"></asp:Label>
                            </div>
                            <div class="modal-body">
                                
                                <asp:Label ID="lblPartidoEdit" runat="server" Text="Partido No:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtPartidoEdit" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                                <asp:Label ID="lblResultadoEdit" runat="server" Text="Resultado:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:DropDownList ID="ddlResultadoEdit" runat="server" CssClass="form-control"></asp:DropDownList>

                                <asp:Label ID="lblLocalEdit" runat="server" Text="Local:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtLocalEdit" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                                <asp:Label ID="lblGolesLocalEdit" runat="server" Text="Goles Local:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:DropDownList ID="ddlGolesLocalEdit" runat="server" CssClass="form-control"></asp:DropDownList>
                                
                                <asp:Label ID="lblVisitaEdit" runat="server" Text="Visita:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtVisitaEdit" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                                <asp:Label ID="lblGolesVisitanteEdit" runat="server" Text="Goles Visitante:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:DropDownList ID="ddlGolesVisitanteEdit" runat="server" CssClass="form-control"></asp:DropDownList>
                                <br />
                                <br />
                                <asp:Label ID="lblMsgModalEdit" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                            <div class="modal-footer">

                                <asp:Button runat="server" ID="btnAcceptPartidoEdit" CssClass="btn btn-primary" OnClick="btnAcceptPartidoEdit_Click" Text="Aceptar" />
                                <asp:Button runat="server" ID="btnClosePartidoEdit" CssClass="btn btn-danger" OnClick="btnClosePartidoEdit_Click" Text="Cerrar" />
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAcceptPartidoEdit" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->

        
        <div class="modal fade bs-example-modal-lg" id="modalPartidoEditConfirm" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalEditPartidoConfirm" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label runat="server" ID="Label1" CssClass="h4 modal-title">
                                    Estas seguro de guardar el resultado? 
                                </asp:Label>                              
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnAcceptPartidoEditConfirm" CssClass="btn btn-primary" OnClick="btnAcceptPartidoEditConfirm_Click" Text="Aceptar" />
                                <asp:Button runat="server" ID="btnClosePartidoEditConfirm" CssClass="btn btn-danger" OnClick="btnClosePartidoEditConfirm_Click" Text="Cerrar" />
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAcceptPartidoEditConfirm" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </div>

    <asp:UpdatePanel ID="updPnlFiltros" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <!-- Page Heading -->
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
                <h1 class="h3 mb-0 text-gray-800">Partidos
                </h1>
                <asp:Button runat="server" ID="btnReporte" Text="Generar Reporte" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btnReporte_Click" />
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
                    <asp:Button runat="server" ID="btnNewPartido" Text="Nuevo Partido" CssClass="d-none d-sm-inline-block btn btn-sm btn-dark shadow-sm" OnClick="btnNewPartido_Click" />
                    <br />
                    <br />

                    <asp:GridView ID="gridPartidos" runat="server" CssClass="TableNew" AutoGenerateColumns="false"
                        DataKeyNames="idPartido, idResultado, idGolesLocal, idGolesVisitante, EquipoLocal, EquipoVisitante" EmptyDataText="No hay Partidos con esa Busqueda"
                        EnableModelValidation="True" OnRowDataBound="gridPartidos_RowDataBound">

                        <Columns>
                            <asp:BoundField ReadOnly="true" HeaderText="No" DataField="idPartido" Visible="false"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="Sport" DataField="SportNameShort"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="Liga" DataField="LigaNameShort"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="Torneo" DataField="TorneoNameShort"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="Jornada" DataField="JornadaNameShort"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="Fecha" DataField="PartidoDate"></asp:BoundField>

                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:Image runat="server" ID="imgLocal" Width="25px" Height="25px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="true" HeaderText="Local" DataField="EquipoLocal"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="idGolesLocal" DataField="idGolesLocal" Visible="false"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="GL" DataField="GolesLocal" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField ReadOnly="true" HeaderText="idGolesVisitante" DataField="idGolesVisitante" Visible="false"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="GV" DataField="GolesVisitante" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:Image runat="server" ID="imgVisita" Width="25px" Height="25px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="true" DataField="EquipoVisitante" HeaderText="Visita" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" DataField="idResultado" HeaderText="idResultado" Visible="false"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" DataField="ResultadoName" HeaderText="Resultado" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditar" runat="server" CssClass="btn btn-secondary" Text="Editar" OnClick="btnEditar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>

</asp:Content>
