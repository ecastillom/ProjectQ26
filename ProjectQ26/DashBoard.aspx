<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="ProjectQ26.DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:HiddenField runat="server" ID="idQuinielaHidden" />
    <div class="row">

        <!-- Content Column -->
        <div class="col-lg-6 mb-4">

            <!-- Color System -->
            <div class="row">

                <!-- Earnings (Monthly) Card Example -->
                <div class="col-lg-6 mb-4">
                    <asp:HyperLink ID="hpLnkBoletos" runat="server" NavigateUrl="~/Boletos.aspx">
                        <div class="card border-left-primary shadow h-100 py-2">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">Mis Boletos</div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-ticket-alt fa-3x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:HyperLink>
                </div>
                <div class="col-lg-6 mb-4">
                    <asp:HyperLink ID="hpLnkQuinielas" runat="server" NavigateUrl="~/QuinielaPlayers.aspx">
                        <div class="card border-left-primary shadow h-100 py-2">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">Lista Quinielas</div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-list-alt fa-3x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:HyperLink>
                </div>
            </div>
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">Tabla General</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:UpdatePanel ID="UpdatePanelModalTablaGeneral" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="gridQuinielaModalTablaGeneral" runat="server" CssClass="TableNewModal100" AutoGenerateColumns="false"
                                    DataKeyNames="idPartido" HorizontalAlign="Center"
                                    EnableModelValidation="True" OnRowDataBound="gridQuinielaModalTablaGeneral_RowDataBound">

                                    <Columns>
                                        <asp:BoundField ReadOnly="true" HeaderText="idTablaGeneral" DataField="idTablaGeneral" Visible="false"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="idLiga" DataField="idLiga" Visible="false"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="idTorneo" DataField="idTorneo" Visible="false"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="Pos." DataField="Pos"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="idEquipo" DataField="idEquipo" Visible="false"></asp:BoundField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:Image runat="server" ID="imgEquipo" Width="25px" Height="25px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:BoundField ReadOnly="true" HeaderText="EquipoNameShort" DataField="EquipoNameShort" Visible="false"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="Equipo" DataField="EquipoName"></asp:BoundField>
                                        
                                        <asp:BoundField ReadOnly="true" HeaderText="JJ" DataField="JJ" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="JG" DataField="JG" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="JE" DataField="JE" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="JP" DataField="JP" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="GF" DataField="GF" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="GC" DataField="GC" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="DG" DataField="DG" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="Puntos" DataField="Total" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        
                                    </Columns>

                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>


        <div class="col-lg-6 mb-4">

            <!-- Illustrations -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <asp:Label runat="server" ID="lblTitleQuinielas" CssClass="m-0 font-weight-bold text-primary"></asp:Label>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:UpdatePanel ID="UpdatePanelModalDetalle" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="gridQuinielaModalDetalle" runat="server" CssClass="TableNewModal100" AutoGenerateColumns="false"
                                    DataKeyNames="idPartido" HorizontalAlign="Center"
                                    EnableModelValidation="True" OnRowDataBound="gridQuinielaModalDetalle_RowDataBound">

                                    <Columns>
                                        <asp:BoundField ReadOnly="true" HeaderText="No" DataField="idPartido" Visible="false"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="Fecha" DataField="PartidoDate"></asp:BoundField>


                                        <asp:BoundField ReadOnly="true" HeaderText="L" DataField="EquipoLocalShort"></asp:BoundField>
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
                                        <asp:BoundField ReadOnly="true" DataField="EquipoVisitanteShort" HeaderText="V" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" DataField="idResultado" HeaderText="idResultado" Visible="false"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" DataField="ResultadoNameShort" HeaderText="Resultado" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                    </Columns>

                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

        </div>
    </div>


    <!-- Content Row -->

</asp:Content>
