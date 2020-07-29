<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="QuinielasGeneral.aspx.cs" Inherits="ProjectQ26.QuinielasGeneral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:HiddenField runat="server" ID="idLigaHidden" />
    <asp:HiddenField runat="server" ID="idSportHidden" />
    <asp:HiddenField runat="server" ID="idQuinielaHidden" />

    <%-- <div class="modal fade modal" id="modal-default">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Default Modal</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <p>One fine body&hellip;</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>--%>

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
                    <%-- <div class="mt-4 text-center small">
                        <span class="mr-2">
                            <i class="fas fa-circle text-primary"></i>Direct
                    </span>
                        <span class="mr-2">
                            <i class="fas fa-circle text-success"></i>Social
                    </span>
                        <span class="mr-2">
                            <i class="fas fa-circle text-info"></i>Referral
                    </span>
                    </div>--%>
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
                        <%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modal-default2">
                            Launch Default Modal
                        </button>--%>
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
                    <%--<div class="chart-area">
                       

                    </div>--%>
                </div>
            </div>
        </div>


    </div>


    <%--   <!-- Content Row -->
    <div class="row">

        <!-- Earnings (Monthly) Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Earnings (Monthly)</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">$40,000</div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-calendar fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Earnings (Monthly) Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Earnings (Annual)</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">$215,000</div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Earnings (Monthly) Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-info text-uppercase mb-1">Tasks</div>
                            <div class="row no-gutters align-items-center">
                                <div class="col-auto">
                                    <div class="h5 mb-0 mr-3 font-weight-bold text-gray-800">50%</div>
                                </div>
                                <div class="col">
                                    <div class="progress progress-sm mr-2">
                                        <div class="progress-bar bg-info" role="progressbar" style="width: 50%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-clipboard-list fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Pending Requests Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-warning shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">Pending Requests</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">18</div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-comments fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Content Row -->
    <div class="row">

        <!-- Content Column -->
        <div class="col-lg-6 mb-4">

            <!-- Project Card Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Projects</h6>
                </div>
                <div class="card-body">
                    <h4 class="small font-weight-bold">Server Migration <span class="float-right">20%</span></h4>
                    <div class="progress mb-4">
                        <div class="progress-bar bg-danger" role="progressbar" style="width: 20%" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100"></div>
                    </div>
                    <h4 class="small font-weight-bold">Sales Tracking <span class="float-right">40%</span></h4>
                    <div class="progress mb-4">
                        <div class="progress-bar bg-warning" role="progressbar" style="width: 40%" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100"></div>
                    </div>
                    <h4 class="small font-weight-bold">Customer Database <span class="float-right">60%</span></h4>
                    <div class="progress mb-4">
                        <div class="progress-bar" role="progressbar" style="width: 60%" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100"></div>
                    </div>
                    <h4 class="small font-weight-bold">Payout Details <span class="float-right">80%</span></h4>
                    <div class="progress mb-4">
                        <div class="progress-bar bg-info" role="progressbar" style="width: 80%" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100"></div>
                    </div>
                    <h4 class="small font-weight-bold">Account Setup <span class="float-right">Complete!</span></h4>
                    <div class="progress">
                        <div class="progress-bar bg-success" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                    </div>
                </div>
            </div>

            <!-- Color System -->
            <div class="row">
                <div class="col-lg-6 mb-4">
                    <div class="card bg-primary text-white shadow">
                        <div class="card-body">
                            Primary
                     
                            <div class="text-white-50 small">#4e73df</div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 mb-4">
                    <div class="card bg-success text-white shadow">
                        <div class="card-body">
                            Success
                     
                            <div class="text-white-50 small">#1cc88a</div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 mb-4">
                    <div class="card bg-info text-white shadow">
                        <div class="card-body">
                            Info
                     
                            <div class="text-white-50 small">#36b9cc</div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 mb-4">
                    <div class="card bg-warning text-white shadow">
                        <div class="card-body">
                            Warning
                     
                            <div class="text-white-50 small">#f6c23e</div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 mb-4">
                    <div class="card bg-danger text-white shadow">
                        <div class="card-body">
                            Danger
                     
                            <div class="text-white-50 small">#e74a3b</div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 mb-4">
                    <div class="card bg-secondary text-white shadow">
                        <div class="card-body">
                            Secondary
                     
                            <div class="text-white-50 small">#858796</div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="col-lg-6 mb-4">

            <!-- Illustrations -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Illustrations</h6>
                </div>
                <div class="card-body">
                    <div class="text-center">
                        <img class="img-fluid px-3 px-sm-4 mt-3 mb-4" style="width: 25rem;" src="img/undraw_posting_photo.svg" alt="">
                    </div>
                    <p>Add some quality, svg illustrations to your project courtesy of <a target="_blank" rel="nofollow" href="https://undraw.co/">unDraw</a>, a constantly updated collection of beautiful svg images that you can use completely free and without attribution!</p>
                    <a target="_blank" rel="nofollow" href="https://undraw.co/">Browse Illustrations on unDraw &rarr;</a>
                </div>
            </div>

            <!-- Approach -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Development Approach</h6>
                </div>
                <div class="card-body">
                    <p>SB Admin 2 makes extensive use of Bootstrap 4 utility classes in order to reduce CSS bloat and poor page performance. Custom CSS classes are used to create custom components and custom utility classes.</p>
                    <p class="mb-0">Before working with this theme, you should become familiar with the Bootstrap framework, especially the utility classes.</p>
                </div>
            </div>

        </div>
    </div>--%>
</asp:Content>
