<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="QuinielasGeneral.aspx.cs" Inherits="ProjectQ26.QuinielasGeneral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:HiddenField runat="server" ID="idLigaHidden" />
    <asp:HiddenField runat="server" ID="idSportHidden" />
    <asp:HiddenField runat="server" ID="idQuinielaHidden" />

    <div class="box-body">
        <div class="modal fade bs-example-modal-lg" id="modalQuiniela" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalNewQuiniela" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label runat="server" ID="lblTittleModal" CssClass="modal-title" Text="Agregar Quiniela"></asp:Label>
                                <asp:Panel runat="server" ID="pnlBoleto" Visible="false">
                                    <asp:Label ID="lblBoleto" runat="server" Text="Boleto No:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                    <asp:TextBox ID="txtBoleto" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </asp:Panel>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblModalMsg" runat="server" Font-Bold="true"></asp:Label>
                                <br />
                                <br />
                                <div class="table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanelModal" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="gridQuinielaModal" runat="server" CssClass="TableNewModal" AutoGenerateColumns="false"
                                                DataKeyNames="idPartido" Visible="false" HorizontalAlign="Center"
                                                EnableModelValidation="True" OnRowDataBound="gridQuinielaModal_RowDataBound">

                                                <Columns>
                                                    <asp:BoundField ReadOnly="true" HeaderText="No" DataField="idPartido" ItemStyle-Width="5%" Visible="false"></asp:BoundField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Image runat="server" ID="imgLocal" Width="25px" Height="25px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField ReadOnly="true" HeaderText="Local" DataField="EquipoLocalShort" ItemStyle-Width="20%"></asp:BoundField>

                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-Width="20%">

                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblOpcion"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Image runat="server" ID="imgVisita" Width="25px" Height="25px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField ReadOnly="true" DataField="EquipoVisitanteShort" HeaderText="Visita" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%"></asp:BoundField>
                                                </Columns>

                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="modal-footer">

                                <asp:Button runat="server" ID="btnAccept" CssClass="btn btn-primary" OnClick="btnAccept_Click" Text="Aceptar" Visible="false" />
                                <asp:Button runat="server" ID="btnBoletos" CssClass="btn btn-primary" OnClick="btnBoletos_Click" Text="Boletos" Visible="false" />
                                <asp:Button runat="server" ID="btnClose" CssClass="btn btn-danger" OnClick="btnClose_Click" Text="Cerrar" />
                                <%--<asp:Button ID="btnAcceptNew" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnAcceptNew_Click" />
                                &nbsp&nbsp
                                        <asp:Button ID="btnCancelNew" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancelNew_Click" />--%>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </div>

    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">
            <asp:Label runat="server" ID="lblTitleQuinielas"></asp:Label>
        </h1>

    </div>

    <!-- Content Row -->

    <div class="row">
        <!-- Pie Chart -->
        <div class="col-xl-4 col-lg-5">
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">
                        <asp:Label runat="server" ID="lblLigaName"></asp:Label>
                    </h6>
                    <div class="dropdown no-arrow">
                        &nbsp;
                    </div>

                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <asp:Image runat="server" ID="imgLogoLiga" CssClass="chart-pie" />

                </div>
            </div>
        </div>

        <!-- Area Chart -->
        <div class="col-xl-8 col-lg-7">
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">
                        <asp:Label runat="server" ID="lblJornada"></asp:Label>
                    </h6>
                    <div class="dropdown no-arrow">
                        <asp:Button ID="btnAddQuiniela" runat="server" CssClass="btn btn-primary" Text="Agregar Quiniela" OnClick="btnAddQuiniela_Click" />
                    </div>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:UpdatePanel ID="updateGridPrincipal" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="gridQuiniela" runat="server" CssClass="TableNew" AutoGenerateColumns="false"
                                    DataKeyNames="idPartido"
                                    EnableModelValidation="True" OnRowDataBound="gridQuiniela_RowDataBound">

                                    <Columns>
                                        <asp:BoundField ReadOnly="true" HeaderText="No" DataField="idPartido" ItemStyle-Width="5%" Visible="false"></asp:BoundField>
                                        <asp:BoundField ReadOnly="true" HeaderText="Fecha" DataField="PartidoDate" ItemStyle-Width="22%"></asp:BoundField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Image runat="server" ID="imgLocal" Width="25px" Height="25px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField ReadOnly="true" HeaderText="Local" DataField="EquipoLocal" ItemStyle-Width="20%"></asp:BoundField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-Width="20%">

                                            <ItemTemplate>
                                                <asp:RadioButtonList runat="server" ID="rdbOpcion" RepeatDirection="Horizontal" TextAlign="Left">
                                                    <asp:ListItem Value="1" Text="L"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="E"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="V"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Image runat="server" ID="imgVisita" Width="25px" Height="25px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField ReadOnly="true" DataField="EquipoVisitante" HeaderText="Visita" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%"></asp:BoundField>
                                    </Columns>

                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>


    </div>

</asp:Content>
