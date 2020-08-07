<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Quinielas.aspx.cs" Inherits="ProjectQ26.Quinielas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <div class="box-body">
        <!-- .modal -->
        <div class="modal fade bs-example-modal-lg" id="modalQuinielaNew" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalNewQuiniela" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label runat="server" ID="lblTittleModal" CssClass="h4 modal-title" Text="Agregar Quiniela"></asp:Label>
                                <asp:Panel runat="server" ID="pnlQuiniela" Visible="false">
                                    <asp:Label ID="lblQuinielaNo" runat="server" Text="Quiniela No:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                    <asp:TextBox ID="txtQuinielaNo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </asp:Panel>
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
                                <br />
                                <br />
                                <asp:Label ID="lblModalMsg" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                            <div class="modal-footer">

                                <asp:Button runat="server" ID="btnAcceptNew" CssClass="btn btn-primary" OnClick="btnAcceptNew_Click" Text="Aceptar" Enabled="false" />
                                <asp:Button runat="server" ID="btnAddNew" CssClass="btn btn-info" OnClick="btnAddNew_Click" Text="Nuevo Quiniela" Visible="false" />
                                <asp:Button runat="server" ID="btnCloseNew" CssClass="btn btn-danger" OnClick="btnCloseNew_Click" Text="Cerrar" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSportNew" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlLigaNew" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlTorneoNew" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlJornadaNew" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnAcceptNew" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <!-- /.modal -->

        <%--<div class="modal fade bs-example-modal-lg" id="modalQuinielaDetalles" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalDetallesQuiniela" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
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
                                    <br />
                                    <br />
                                    <asp:Label ID="lblMsgModalDetalles" runat="server" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button runat="server" ID="btnCloseDetalles" CssClass="btn btn-danger" OnClick="btnCloseDetalles_Click" Text="Cerrar" />
                                </div>
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>--%>

        <!-- .modal -->
        <div class="modal fade bs-example-modal-lg" id="modalQuinielaCalcularConfirm" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalCalcularQuinielaConfirm" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="idQuinielaHidden" runat="server" />
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Panel runat="server" ID="pnlTitles">
                                    <asp:Label runat="server" ID="lblWarning1" CssClass="h4 modal-title">
                                        Estas Seguro de Calcular Ganador de la Quiniela? 
                                    </asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label runat="server" ID="lblWarning2" CssClass="h4 modal-title">
                                        Al hacer esto ya no podras modificar
                                    </asp:Label>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlValuesCalculate" Visible="false">
                                    <asp:Label ID="lblQuinielaCalcular" runat="server" Text="Quiniela No:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                    <asp:TextBox ID="txtQuinielaCalcular" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </asp:Panel>
                                <br />
                                <br />
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblMsgCalcular" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnAcceptQuinielaCalcularConfirm" CssClass="btn btn-primary" OnClick="btnAcceptQuinielaCalcularConfirm_Click" Text="Aceptar" />
                                <asp:Button runat="server" ID="btnCloseQuinielaCalcularConfirm" CssClass="btn btn-danger" OnClick="btnCloseQuinielaCalcularConfirm_Click" Text="Cerrar" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAcceptQuinielaCalcularConfirm" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <!-- /.modal -->

        <div class="modal fade bs-example-modal-lg" id="modalQuinielaProcesarConfirm" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalProcesarQuinielaConfirm" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="idQuinielaProcesarHidden" runat="server" />
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Panel runat="server" ID="pnlTitlesProcesar">
                                    <br />
                                    <asp:Label runat="server" ID="lblWarningProcesar1" CssClass="h4 modal-title">
                                        Estas Seguro de Procesar la Quiniela? 
                                    </asp:Label>
                                    <br />
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlValuesProcesar" Visible="false">
                                    <asp:Label ID="lblQuinielaProcesar" runat="server" Text="Quiniela No:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                    <asp:TextBox ID="txtQuinielaProcesar" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </asp:Panel>
                                <br />
                                <br />
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblMsgProcesar" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnAcceptQuinielaProcesarConfirm" CssClass="btn btn-primary" OnClick="btnAcceptQuinielaProcesarConfirm_Click" Text="Aceptar" />
                                <asp:Button runat="server" ID="btnCloseQuinielaProcesarConfirm" CssClass="btn btn-danger" OnClick="btnCloseQuinielaProcesarConfirm_Click" Text="Cerrar" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAcceptQuinielaProcesarConfirm" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="modal fade bs-example-modal-lg" id="modalQuinielaAbrirConfirm" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalAbrirQuinielaConfirm" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="idQuinielaAbrirHidden" runat="server" />
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Panel runat="server" ID="pnlTitlesAbrir">
                                    <br />
                                    <asp:Label runat="server" ID="lblWarningAbrir1" CssClass="h4 modal-title">
                                        Estas Seguro de Abrir la Quiniela? 
                                    </asp:Label>
                                    <br />
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlValuesAbrir" Visible="false">
                                    <asp:Label ID="lblQuinielaAbrir" runat="server" Text="Quiniela No:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                    <asp:TextBox ID="txtQuinielaAbrir" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </asp:Panel>
                                <br />
                                <br />
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblMsgAbrir" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnAcceptQuinielaAbrirConfirm" CssClass="btn btn-primary" OnClick="btnAcceptQuinielaAbrirConfirm_Click" Text="Aceptar" />
                                <asp:Button runat="server" ID="btnCloseQuinielaAbrirConfirm" CssClass="btn btn-danger" OnClick="btnCloseQuinielaAbrirConfirm_Click" Text="Cerrar" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAcceptQuinielaAbrirConfirm" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

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
                                            <asp:GridView ID="gridQuinielaModalApuestas" runat="server" OnRowDataBound="gridQuinielaModalApuestas_RowDataBound" CssClass="TableNewModal100" AutoGenerateColumns="false"
                                                DataKeyNames="idApuesta" HorizontalAlign="Center"
                                                EnableModelValidation="True">

                                                <Columns>
                                                    <asp:BoundField ReadOnly="true" HeaderText="idApuesta" DataField="idApuesta" Visible="false"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="true" HeaderText="Apuesta No" DataField="ApuestaNo"></asp:BoundField>
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

        <!-- .modal -->
        <%--<div class="modal fade bs-example-modal-lg" id="modalQuinielaEdit" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalEditQuiniela" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label runat="server" ID="lblTitleModalEdit" CssClass="h4 modal-title" Text="Actualizar Quiniela"></asp:Label>
                            </div>
                            <div class="modal-body">
                                
                                <asp:Label ID="lblQuinielaEdit" runat="server" Text="Quiniela No:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtQuinielaEdit" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

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

                                <asp:Button runat="server" ID="btnAcceptQuinielaEdit" CssClass="btn btn-primary" OnClick="btnAcceptQuinielaEdit_Click" Text="Aceptar" />
                                <asp:Button runat="server" ID="btnCloseQuinielaEdit" CssClass="btn btn-danger" OnClick="btnCloseQuinielaEdit_Click" Text="Cerrar" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAcceptQuinielaEdit" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>--%>
        <!-- /.modal -->


        <!-- .modal -->
        <%--<div class="modal fade bs-example-modal-lg" id="modalQuinielaEditConfirm" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="updateModalEditQuinielaConfirm" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label runat="server" ID="Label1" CssClass="h4 modal-title">
                                    Estas seguro de guardar el resultado? 
                                </asp:Label>                              
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnAcceptQuinielaEditConfirm" CssClass="btn btn-primary" OnClick="btnAcceptQuinielaEditConfirm_Click" Text="Aceptar" />
                                <asp:Button runat="server" ID="btnCloseQuinielaEditConfirm" CssClass="btn btn-danger" OnClick="btnCloseQuinielaEditConfirm_Click" Text="Cerrar" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAcceptQuinielaEditConfirm" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>--%>
        <!-- /.modal -->
    </div>

    <asp:UpdatePanel ID="updPnlFiltros" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <!-- Page Heading -->
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
                <h1 class="h3 mb-0 text-gray-800">Quinielas
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
                    <asp:Button runat="server" ID="btnNewQuiniela" Text="Nueva Quiniela" CssClass="d-none d-sm-inline-block btn btn-sm btn-dark shadow-sm" OnClick="btnNewQuiniela_Click" />
                    <br />
                    <br />

                    <asp:GridView ID="gridQuinielas" runat="server" CssClass="TableNew" AutoGenerateColumns="false"
                        DataKeyNames="idQuiniela, idLiga, idTorneo, QuinielaNo" EmptyDataText="No hay Quinielas con esa Busqueda"
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
                            <asp:BoundField ReadOnly="true" HeaderText="Apuestas Total" DataField="ApuestasTotal"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="idStatus" DataField="idStatus" Visible="false"></asp:BoundField>
                            <asp:BoundField ReadOnly="true" HeaderText="StatusName" DataField="StatusName"></asp:BoundField>
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
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderText="Procesar">
                                <ItemTemplate>
                                    <asp:Button ID="btnProcesar" runat="server" CssClass="btn btn-dark" Text="Procesar" OnClick="btnProcesar_Click" Width="89px" />
                                    <asp:Button ID="btnCalcular" runat="server" CssClass="btn btn-primary" Text="Calcular" OnClick="btnCalcular_Click" Width="89px" />
                                    <asp:Button ID="btnAbrir" runat="server" CssClass="btn btn-success" Text="Abrir" OnClick="btnAbrir_Click" Width="89px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>
