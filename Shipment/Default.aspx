<%@ Page Title="Shipment" Language="C#" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" type="text/css" rel="stylesheet" />
    <link href="css/shipment.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.11.1.min.js"></script>
     <script type="text/javascript" src="Scripts/jquery-ui.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.cookie.js"></script>
    <script type="text/javascript" src="Scripts/utility.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" align="center">
            <tr>
                <td valign="top">
                    <table cellspacing="3" cellpadding="3" width="90%" align="center" border="0">
                        <tbody>
                            <tr>
                                <td valign="top" height="800">
                                    <asp:Button runat="server" ID="btnFake" Text="" style="display:none;" OnClick="btnFake_Click" />
                                    <p>
                                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Size="Large" />
                                    </p>
                                    <asp:Panel ID="pnlShippingIframe" runat="server" GroupingText="Shipping Fields" Height="90%" Visible="false">
                                        <iframe runat="server" id="ifrmShipping" width="100%" height="95%"></iframe>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlShippingFields" runat="server" GroupingText="Shipping Fields">
                                        <div runat="server" id="divStep1">
                                            <h2 style="background-color: #BDE5F8; width: 100%;" onclick="ExpandCollapse('expcol_1')">Address Information</h2>
                                            <div id="expcol_1">
                                                <h3>Fill in the shipping from address and the recipient's address</h3>
                                                <h4>From:</h4>
                                                <asp:DetailsView ID="dvShipping_from" runat="server" DefaultMode="Insert" Font-Size="13px" Width="60%" CellPadding="2"
                                                    Font-Names="Verdana" AllowPaging="False" GridLines="None" AutoGenerateRows="False" OnPreRender="dvAddress_PreRender">

                                                    <FieldHeaderStyle Font-Bold="true" HorizontalAlign="right" Width="100" ForeColor="#0466CC" />
                                                    <Fields>
                                                        <asp:TemplateField HeaderText="Company:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtSfName" runat="server" MaxLength="35" AutoCompleteType="Company" Text='<%# Bind("sf_cname") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Name:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtSfAttention" runat="server" MaxLength="35" AutoCompleteType="DisplayName" Text='<%# Bind("sf_attention") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Country:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:DropDownList ID="ddlSfCountry" runat="server" AutoPostBack="True" SelectedValue='<%# Bind("sf_country") %>' Width="90%"
                                                                    DataValueField="sf_country" DataTextField="sf_country" OnSelectedIndexChanged="ddlSfCountry_SelectedIndexChanged">
                                                                    <asp:ListItem Value="US">United States</asp:ListItem>
                                                                    <asp:ListItem Value="CA">Canada</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtSfAddress1" runat="server" MaxLength="35" AutoCompleteType="BusinessStreetAddress" Text='<%# Bind("sf_address1") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtSfAddress2" runat="server" MaxLength="35" Text='<%# Bind("sf_address2") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="City:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtSfCity" runat="server" AutoCompleteType="BusinessCity" Text='<%# Bind("sf_city") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="State:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtSfState" runat="server" AutoCompleteType="BusinessState" Text='<%# Bind("sf_state") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ZIP:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtSfPostcode" runat="server" AutoCompleteType="BusinessZipCode" Text='<%# Bind("sf_postcode") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Phone:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtSfTel" runat="server" AutoCompleteType="BusinessPhone" Text='<%# Bind("sf_tel") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtSfEmail" runat="server" AutoCompleteType="Email" Text='<%# Bind("emailfail") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                    </Fields>
                                                </asp:DetailsView>
                                                <h4>To:</h4>
                                                <asp:DetailsView ID="dvShipping_to" runat="server" DefaultMode="Insert" Font-Size="13px" Width="60%" CellPadding="2"
                                                    Font-Names="Verdana" AllowPaging="False" GridLines="None" AutoGenerateRows="False" OnDataBound="dvShippingTo_DataBound">

                                                    <FieldHeaderStyle Font-Bold="true" HorizontalAlign="right" Width="100" ForeColor="#0466CC" />
                                                    <Fields>
                                                        <asp:TemplateField HeaderText="Company:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                               <asp:TextBox ID="txtCompany" runat="server" MaxLength="35" AutoCompleteType="Company" Text='<%# Bind("company") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Name:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtName" runat="server" AutoCompleteType="DisplayName" Text='<%# Bind("cname") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Country:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" SelectedValue='<%# Bind("country") %>' Width="90%"
                                                                    DataValueField="country" DataTextField="country" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                                    <asp:ListItem Value="US">United States</asp:ListItem>
                                                                    <asp:ListItem Value="CA">Canada</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" AutoCompleteType="HomeStreetAddress" Text='<%# Bind("address1") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" Text='<%# Bind("address2") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="City:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtCity" runat="server" AutoCompleteType="HomeCity" Text='<%# Bind("city") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="State:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtState" runat="server" AutoCompleteType="HomeState" Text='<%# Bind("state") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ZIP:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtPostcode" runat="server" AutoCompleteType="HomeZipCode" Text='<%# Bind("postcode") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Phone:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtTel" runat="server" AutoCompleteType="HomePhone" Text='<%# Bind("tel") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtEmail" runat="server" AutoCompleteType="Email" Text='<%# Bind("email") %>' Width="90%" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Notification:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <label class="switch">
                                                                    <asp:CheckBox runat="server" ID="chkIsemail" />
                                                                    <span class="slider round"></span>
                                                                </label>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                    </Fields>
                                                </asp:DetailsView>
                                                <div style="display:flex; justify-content:flex-end;">
                                                    <asp:Button ID="btnStep1" runat="server" Text="Next" Width="90" Height="40" OnClick="btnStep1_Click" CssClass="btn-next" />
                                                    <asp:Button Visible="false" ID="btnStep1Update" runat="server" Text="Update" Width="90" Height="40" OnCommand="btnUpdate_Click" CssClass="btn-next" CommandName="address" />
                                                </div>
                                            </div>
                                        </div>
                                        <div runat="server" id="divStep2" visible="false">
                                            <h2 style="background-color: #BDE5F8; width: 100%;" onclick="ExpandCollapse('expcol_2')">Shipment Details</h2>
                                            <div id="expcol_2">
                                                <h3>Fill in the package details</h3>
                                                <asp:Menu ID="menuShippingType" Width="200px" runat="server" Orientation="Horizontal" OnMenuItemClick="menuShippingType_MenuItemClick" CssClass="menuShippingType">
                                                    <Items>
                                                        <%--<asp:MenuItem Text="Package" Value="0"></asp:MenuItem>--%>
                                                        <%--<asp:MenuItem Text="Freight" Value="1" Enabled="false"></asp:MenuItem>--%>
                                                    </Items>
                                                </asp:Menu>
                                                <asp:MultiView runat="server" ID="multiView" ActiveViewIndex="0">
                                                    <asp:View ID="tabPackage" runat="server">
                                                        <asp:GridView ID="gvPackages" runat="server" ShowFooter="false" DataKeyNames="id_num"
                                                            GridLines="Both" Font-Size="13px" Font-Names="Verdana" AllowPaging="True" PageSize="10" PagerSettings-Mode="NumericFirstLast"
                                                            AutoGenerateColumns="False" OnRowUpdating="gvPackages_Update" OnRowCreated="gvPackages_RowCreated"
                                                            OnRowEditing="gvPackages_Edit" OnRowCancelingEdit="GridView_Cancel" OnRowDeleting="gvPackages_DeletePackage">

                                                            <RowStyle Height="45" />
                                                            <PagerSettings Mode="NumericFirstLast" />
                                                            <PagerStyle HorizontalAlign="Center" ForeColor="#0466CC" />
                                                            <HeaderStyle ForeColor="#0466CC" HorizontalAlign="Left" Font-Bold="true" CssClass="headerRow" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Identical" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:CheckBox ID="chkIdentical" runat="server" AutoPostBack="true" Text="Identical" OnCheckedChanged="chkIdentical_Checked"></asp:CheckBox>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Part#" ControlStyle-Width="150" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPartno" runat="server" Text='<%# Eval("partno") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtPartNo" runat="server" AutoCompleteType="Notes" Font-Size="Large" Height="30" Width="150" Text='<%# Bind("partno") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtPartNoAdd" runat="server" AutoCompleteType="Notes" Font-Size="Large" Height="30" Width="150"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Weight" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblWeight" runat="server" Text='<%# Eval("weight") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtWeight" runat="server" Font-Size="Large" Height="30" Width="100" Text='<%# Bind("weight") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtWeightAdd" runat="server" Font-Size="Large" Height="30" Width="100"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Length" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLength" runat="server" Text='<%# Eval("length") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtLength" runat="server" Font-Size="Large" Width="100" Height="30"
                                                                            Text='<%# Bind("length") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtLengthAdd" runat="server" Font-Size="Large" Width="100" Height="30"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Width" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblWidth" runat="server" Text='<%# Eval("width") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtWidth" runat="server" Width="100" Font-Size="Large" Height="30" Text='<%# Bind("width") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtWidthAdd" runat="server" Width="100" Font-Size="Large" Height="30"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Height" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHeight" runat="server" Text='<%# Eval("height") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtHeight" runat="server" Width="100" Font-Size="Large" Height="30"
                                                                            Text='<%# Bind("height") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtHeightAdd" runat="server" Width="100" Font-Size="Large" Height="30"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField HeaderText="QTY" ControlStyle-Width="50" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblQty" runat="server" Text='<%# Eval("qty") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtQty" runat="server" Width="50" Font-Size="Large" Height="30"
                                                                            Text='<%# Bind("qty") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtQtyAdd" runat="server" Width="50" Font-Size="Large" Height="30"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderText="Unit Price" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitPrice" runat="server" Text='<%# Eval("unit_price") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtUnitPrice" runat="server" Font-Size="Large" Height="30" Width="100" Text='<%# Bind("unit_price") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtUnitPriceAdd" runat="server" Font-Size="Large" Height="30" Width="100"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Service Type" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlServiceTypeFx" runat="server" AutoPostBack="true" SelectedValue='<%# Bind("service_type_fx") %>'
                                                                            DataValueField="service_type_fx" DataTextField="service_type_fx" CssClass="Adj-DDL-Height" OnSelectedIndexChanged="ddlStep2_SelectedIndexChanged">
                                                                            <asp:ListItem Value="92">FEDEX GROUND</asp:ListItem>
                                                                            <asp:ListItem Value="90">GROUND HOME DELIVERY</asp:ListItem>
                                                                            <asp:ListItem Value="20">FEDEX EXPRESS SAVER</asp:ListItem>
                                                                            <asp:ListItem Value="05">STANDARD OVERNIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="01">PRIORITY OVERNIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="03">FEDEX 2 DAY</asp:ListItem>
                                                                            <asp:ListItem Value="49">FEDEX 2 DAY_AM</asp:ListItem>
                                                                            <asp:ListItem Value="80">FEDEX 2 DAY FREIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="83">FEDEX 3 DAY FREIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="06">FIRST OVERNIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="17">INTERNATIONAL ECONOMY</asp:ListItem>
                                                                            <asp:ListItem Value="86">INTERNATIONAL ECONOMY FREIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="70">INTERNATIONAL PRIORITY FREIGHT</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" ID="lblServiceTypeFx" Text='<%# (FedExAPIWCF.ShippingServiceType)Enum.Parse(typeof(FedExAPIWCF.ShippingServiceType), Eval("service_type_fx").ToString()) %>' Font-Size="Smaller" />
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlServiceTypeAddFx" runat="server" Height="30" AutoPostBack="true" OnSelectedIndexChanged="ddlStep2_SelectedIndexChanged"
                                                                            DataValueField="service_type_fx" DataTextField="service_type_fx" CssClass="Adj-DDL-Height">
                                                                            <asp:ListItem Value="92">FEDEX GROUND</asp:ListItem>
                                                                            <asp:ListItem Value="90">GROUND HOME DELIVERY</asp:ListItem>
                                                                            <asp:ListItem Value="20">FEDEX EXPRESS SAVER</asp:ListItem>
                                                                            <asp:ListItem Value="05">STANDARD OVERNIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="01">PRIORITY OVERNIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="03">FEDEX 2 DAY</asp:ListItem>
                                                                            <asp:ListItem Value="49">FEDEX 2 DAY_AM</asp:ListItem>
                                                                            <asp:ListItem Value="80">FEDEX 2 DAY FREIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="83">FEDEX 3 DAY FREIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="06">FIRST OVERNIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="17">INTERNATIONAL ECONOMY</asp:ListItem>
                                                                            <asp:ListItem Value="86">INTERNATIONAL ECONOMY FREIGHT</asp:ListItem>
                                                                            <asp:ListItem Value="70">INTERNATIONAL PRIORITY FREIGHT</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Service Type" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlServiceTypeUps" runat="server" AutoPostBack="true" SelectedValue='<%# Bind("service_type_ups") %>'
                                                                            DataValueField="service_type_ups" DataTextField="service_type_ups" CssClass="Adj-DDL-Height" OnSelectedIndexChanged="ddlStep2_SelectedIndexChanged">
                                                                            <asp:ListItem Value="GND">Ground</asp:ListItem>
                                                                            <asp:ListItem Value="2DA">2nd Day Air</asp:ListItem>
                                                                            <asp:ListItem Value="2DM">2nd Day Air AM</asp:ListItem>
                                                                            <asp:ListItem Value="3DS">3 Day Select</asp:ListItem>
                                                                            <asp:ListItem Value="1DA">Next Day Air</asp:ListItem>
                                                                            <asp:ListItem Value="1DM">Next Day Air Early AM</asp:ListItem>
                                                                            <asp:ListItem Value="1DP">Next Day Air Saver</asp:ListItem>
                                                                            <asp:ListItem Value="ST">Standard</asp:ListItem>
                                                                            <asp:ListItem Value="EX">Worldwide Expedited</asp:ListItem>
                                                                            <asp:ListItem Value="ES">Worldwide Express</asp:ListItem>
                                                                            <asp:ListItem Value="EP">Worldwide Express Plus</asp:ListItem>
                                                                            <asp:ListItem Value="SV">Worldwide Saver (Express)</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" ID="lblServiceTypeUps" Text='<%# UpsHelper.GetUpsServiceTypeDisplayName(Eval("service_type_ups").ToString()) %>' Font-Size="Smaller" />
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlServiceTypeAddUps" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStep2_SelectedIndexChanged"
                                                                            DataValueField="service_type_ups" DataTextField="service_type_ups" CssClass="Adj-DDL-Height">
                                                                            <asp:ListItem Value="GND">Ground</asp:ListItem>
                                                                            <asp:ListItem Value="2DA">2nd Day Air</asp:ListItem>
                                                                            <asp:ListItem Value="2DM">2nd Day Air AM</asp:ListItem>
                                                                            <asp:ListItem Value="3DS">3 Day Select</asp:ListItem>
                                                                            <asp:ListItem Value="1DA">Next Day Air</asp:ListItem>
                                                                            <asp:ListItem Value="1DM">Next Day Air Early AM</asp:ListItem>
                                                                            <asp:ListItem Value="1DP">Next Day Air Saver</asp:ListItem>
                                                                            <asp:ListItem Value="ST">Standard</asp:ListItem>
                                                                            <asp:ListItem Value="EX">Worldwide Expedited</asp:ListItem>
                                                                            <asp:ListItem Value="ES">Worldwide Express</asp:ListItem>
                                                                            <asp:ListItem Value="EP">Worldwide Express Plus</asp:ListItem>
                                                                            <asp:ListItem Value="SV">Worldwide Saver (Express)</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" ControlStyle-Width="250" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("description") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDescription" runat="server" Font-Size="Large" Height="30" Width="250" TextMode="MultiLine"
                                                                            Text='<%# Bind("description") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtDescriptionAdd" runat="server" Font-Size="Large" Height="30" Width="250" TextMode="MultiLine" MaxLength="35"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ibUpdate" runat="server" ImageUrl="images/action/edit-save.png" Text="Save" ToolTip="Save" CommandName="Update" />
                                                                        <asp:ImageButton ID="ibCancel" runat="server" ImageUrl="images/action/edit-undo.png" Text="Cancel" ToolTip="Cancel" CommandName="Cancel" />
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEdit" runat="server" ImageUrl="images/action/edit.png" Text="Edit" ToolTip="Edit" CommandName="Edit" />
                                                                        <asp:ImageButton ID="ibDelete" runat="server" ImageUrl="images/action/trash.png" Text="Delete" ToolTip="Delete Package" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to Remove the package?')" />
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ibAdd" runat="server" ImageUrl="images/action/add.png" Text="Add" ToolTip="Add" OnClick="gvPackages_Add" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                     </asp:View>
                                                    <asp:View ID="tabFreight" runat="server">
                                                        <asp:GridView ID="gvFreight" runat="server" ShowFooter="false" DataKeyNames="id_num"
                                                            GridLines="Both" Font-Size="13px" Font-Names="Verdana" AllowPaging="True" PageSize="10" PagerSettings-Mode="NumericFirstLast"
                                                            AutoGenerateColumns="False"  OnRowUpdating="gvPackages_Update"
                                                            OnRowEditing="gvPackages_Edit" OnRowCancelingEdit="GridView_Cancel">

                                                            <RowStyle Height="45" />
                                                            <PagerSettings Mode="NumericFirstLast" />
                                                            <PagerStyle HorizontalAlign="Center" ForeColor="#0466CC" />
                                                            <HeaderStyle ForeColor="#0466CC" HorizontalAlign="Left" Font-Bold="true" CssClass="headerRow" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Part#" ControlStyle-Width="150" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPartno" runat="server" Text='<%# Eval("partno") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtPartNo" runat="server" AutoCompleteType="Notes" Font-Size="Large" Height="30" Width="150" Text='<%# Bind("partno") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtPartNoAdd" runat="server" AutoCompleteType="Notes" Font-Size="Large" Height="30" Width="150"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Weight" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblWeight" runat="server" Text='<%# Eval("weight") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtWeight" runat="server" Font-Size="Large" Height="30" Width="100" Text='<%# Bind("weight") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtWeightAdd" runat="server" Font-Size="Large" Height="30" Width="100"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                    <ItemStyle Font-Size="Large" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Billing Option" ItemStyle-HorizontalAlign="Left" ControlStyle-Width="150">
                                                                     <ItemTemplate>
                                                                        <asp:Label ID="lblBilling" runat="server" Text='<%# UpsHelper.GetBillingOptionText(Eval("FreightBilling").ToString()) %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlBilling" runat="server" AutoPostBack="True" SelectedValue='<%# Bind("FreightBilling") %>'
                                                                            DataValueField="FreightBilling" DataTextField="FreightBilling" OnSelectedIndexChanged="ddlStep2_SelectedIndexChanged" CssClass="Adj-DDL-Height">
                                                                            <asp:ListItem Value="30">Bill to Third Party</asp:ListItem>
                                                                            <asp:ListItem Value="40">Collect</asp:ListItem>
                                                                            <asp:ListItem Value="10">Prepaid</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Packaging Type" ItemStyle-HorizontalAlign="Left" ControlStyle-Width="100">
                                                                     <ItemTemplate>
                                                                        <asp:Label ID="lblPckType" runat="server" Text='<%# UpsHelper.GetPackagingTypeText(Eval("FreightPckType").ToString()) %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlPckType" runat="server" AutoPostBack="True" SelectedValue='<%# Bind("FreightPckType") %>'
                                                                            DataValueField="FreightPckType" DataTextField="FreightPckType" OnSelectedIndexChanged="ddlStep2_SelectedIndexChanged" CssClass="Adj-DDL-Height">
                                                                            <asp:ListItem Value="CRT">Crate</asp:ListItem>
                                                                            <asp:ListItem Value="BAG">Bag</asp:ListItem>
                                                                            <asp:ListItem Value="BAL">Bale</asp:ListItem>
                                                                            <asp:ListItem Value="BAR">Barrel</asp:ListItem>
                                                                            <asp:ListItem Value="BDL">Bundle</asp:ListItem>
                                                                            <asp:ListItem Value="BIN">Bin</asp:ListItem>
                                                                            <asp:ListItem Value="BOX">Box</asp:ListItem>
                                                                            <asp:ListItem Value="BSK">Basket</asp:ListItem>
                                                                            <asp:ListItem Value="BUN">Bunch</asp:ListItem>
                                                                            <asp:ListItem Value="CAB">Cabinet</asp:ListItem>
                                                                            <asp:ListItem Value="CAN">Can</asp:ListItem>
                                                                            <asp:ListItem Value="CAR">Carrier</asp:ListItem>
                                                                            <asp:ListItem Value="CAS">Case</asp:ListItem>
                                                                            <asp:ListItem Value="CBY">Carboy</asp:ListItem>
                                                                            <asp:ListItem Value="CON">Container</asp:ListItem>
                                                                            <asp:ListItem Value="CSK">Cask</asp:ListItem>
                                                                            <asp:ListItem Value="CTN">Carton</asp:ListItem>
                                                                            <asp:ListItem Value="CYL">Cylinder</asp:ListItem>
                                                                            <asp:ListItem Value="DRM">Drum</asp:ListItem>
                                                                            <asp:ListItem Value="LOO">Loose</asp:ListItem>
                                                                            <asp:ListItem Value="OTH">Other</asp:ListItem>
                                                                            <asp:ListItem Value="PAL">Pail</asp:ListItem>
                                                                            <asp:ListItem Value="PCS">Pieces</asp:ListItem>
                                                                            <asp:ListItem Value="PKG">Package</asp:ListItem>
                                                                            <asp:ListItem Value="PLN">Pipe Line</asp:ListItem>
                                                                            <asp:ListItem Value="PLT">Pallet</asp:ListItem>
                                                                            <asp:ListItem Value="RCK">Rack</asp:ListItem>
                                                                            <asp:ListItem Value="REL">Reel</asp:ListItem>
                                                                            <asp:ListItem Value="ROL">Roll</asp:ListItem>
                                                                            <asp:ListItem Value="SKD">Skid</asp:ListItem>
                                                                            <asp:ListItem Value="SPL">Spool</asp:ListItem>
                                                                            <asp:ListItem Value="TBE">Tube</asp:ListItem>
                                                                            <asp:ListItem Value="TNK">Tank</asp:ListItem>
                                                                            <asp:ListItem Value="UNT">Unit</asp:ListItem>
                                                                            <asp:ListItem Value="VPK">Van Pack</asp:ListItem>
                                                                            <asp:ListItem Value="WRP">Wrapped</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Pickup Date" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="180">
                                                                     <ItemTemplate>
                                                                        <asp:Label ID="lblPickupDate" runat="server" Text='<%# Eval("pickupDate") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox runat="server" ID="txtPickupDate" Text='<%# Bind("pickupDate") %>' Width="130" Font-Size="Large" Height="30" CssClass="datepicker" />
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Pickup Start Time" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="100">
                                                                     <ItemTemplate>
                                                                        <asp:Label ID="lblStartHour" runat="server" Text='<%# Eval("startHour") %>' />:
                                                                        <asp:Label ID="lblstartMinute" runat="server" Text='<%# Eval("startMinute") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlStartHour" runat="server" AutoPostBack="True" SelectedValue='<%# Bind("startHour") %>'
                                                                            DataValueField="startHour" DataTextField="startHour" OnSelectedIndexChanged="ddlStep2_SelectedIndexChanged" CssClass="Adj-DDL-Height">
                                                                            <asp:ListItem Value="00"></asp:ListItem>
                                                                            <asp:ListItem Value="01"></asp:ListItem>
                                                                            <asp:ListItem Value="02"></asp:ListItem>
                                                                            <asp:ListItem Value="03"></asp:ListItem>
                                                                            <asp:ListItem Value="04"></asp:ListItem>
                                                                            <asp:ListItem Value="05"></asp:ListItem>
                                                                            <asp:ListItem Value="06"></asp:ListItem>
                                                                            <asp:ListItem Value="07"></asp:ListItem>
                                                                            <asp:ListItem Value="08"></asp:ListItem>
                                                                            <asp:ListItem Value="09"></asp:ListItem>
                                                                            <asp:ListItem Value="10"></asp:ListItem>
                                                                            <asp:ListItem Value="11"></asp:ListItem>
                                                                            <asp:ListItem Value="12"></asp:ListItem>
                                                                            <asp:ListItem Value="13"></asp:ListItem>
                                                                            <asp:ListItem Value="14"></asp:ListItem>
                                                                            <asp:ListItem Value="15"></asp:ListItem>
                                                                            <asp:ListItem Value="16"></asp:ListItem>
                                                                            <asp:ListItem Value="17"></asp:ListItem>
                                                                            <asp:ListItem Value="18"></asp:ListItem>
                                                                            <asp:ListItem Value="19"></asp:ListItem>
                                                                            <asp:ListItem Value="20"></asp:ListItem>
                                                                            <asp:ListItem Value="21"></asp:ListItem>
                                                                            <asp:ListItem Value="22"></asp:ListItem>
                                                                            <asp:ListItem Value="23"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlStartMinute" runat="server" AutoPostBack="True" SelectedValue='<%# Bind("startMinute") %>'
                                                                            DataValueField="startMinute" DataTextField="startMinute" OnSelectedIndexChanged="ddlStep2_SelectedIndexChanged" CssClass="Adj-DDL-Height">
                                                                            <asp:ListItem Value="00"></asp:ListItem>
                                                                            <asp:ListItem Value="15"></asp:ListItem>
                                                                            <asp:ListItem Value="30"></asp:ListItem>
                                                                            <asp:ListItem Value="45"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Pickup End Time" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="100">
                                                                     <ItemTemplate>
                                                                        <asp:Label ID="lblEndHour" runat="server" Text='<%# Eval("endHour") %>' />:
                                                                        <asp:Label ID="lblEndMinute" runat="server" Text='<%# Eval("endMinute") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlEndHour" runat="server" AutoPostBack="True" SelectedValue='<%# Bind("endHour") %>'
                                                                            DataValueField="endHour" DataTextField="endHour" OnSelectedIndexChanged="ddlStep2_SelectedIndexChanged" CssClass="Adj-DDL-Height">
                                                                            <asp:ListItem Value="00"></asp:ListItem>
                                                                            <asp:ListItem Value="01"></asp:ListItem>
                                                                            <asp:ListItem Value="02"></asp:ListItem>
                                                                            <asp:ListItem Value="03"></asp:ListItem>
                                                                            <asp:ListItem Value="04"></asp:ListItem>
                                                                            <asp:ListItem Value="05"></asp:ListItem>
                                                                            <asp:ListItem Value="06"></asp:ListItem>
                                                                            <asp:ListItem Value="07"></asp:ListItem>
                                                                            <asp:ListItem Value="08"></asp:ListItem>
                                                                            <asp:ListItem Value="09"></asp:ListItem>
                                                                            <asp:ListItem Value="10"></asp:ListItem>
                                                                            <asp:ListItem Value="11"></asp:ListItem>
                                                                            <asp:ListItem Value="12"></asp:ListItem>
                                                                            <asp:ListItem Value="13"></asp:ListItem>
                                                                            <asp:ListItem Value="14"></asp:ListItem>
                                                                            <asp:ListItem Value="15"></asp:ListItem>
                                                                            <asp:ListItem Value="16"></asp:ListItem>
                                                                            <asp:ListItem Value="17"></asp:ListItem>
                                                                            <asp:ListItem Value="18"></asp:ListItem>
                                                                            <asp:ListItem Value="19"></asp:ListItem>
                                                                            <asp:ListItem Value="20"></asp:ListItem>
                                                                            <asp:ListItem Value="21"></asp:ListItem>
                                                                            <asp:ListItem Value="22"></asp:ListItem>
                                                                            <asp:ListItem Value="23"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlEndMinute" runat="server" AutoPostBack="True" SelectedValue='<%# Bind("endMinute") %>'
                                                                            DataValueField="endMinute" DataTextField="endMinute" OnSelectedIndexChanged="ddlStep2_SelectedIndexChanged" CssClass="Adj-DDL-Height">
                                                                            <asp:ListItem Value="00"></asp:ListItem>
                                                                            <asp:ListItem Value="15"></asp:ListItem>
                                                                            <asp:ListItem Value="30"></asp:ListItem>
                                                                            <asp:ListItem Value="45"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" ControlStyle-Width="250" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("description") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDescription" runat="server" Font-Size="Large" Height="30" Width="250" TextMode="MultiLine"
                                                                            Text='<%# Bind("description") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtDescriptionAdd" runat="server" Font-Size="Large" Height="30" Width="250" TextMode="MultiLine" MaxLength="35"></asp:TextBox>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ibUpdate" runat="server" ImageUrl="images/action/edit-save.png" Text="Save" ToolTip="Save" CommandName="Update" />
                                                                        <asp:ImageButton ID="ibCancel" runat="server" ImageUrl="images/action/edit-undo.png" Text="Cancel" ToolTip="Cancel" CommandName="Cancel" />
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEdit" runat="server" ImageUrl="images/action/edit.png" Text="Edit" ToolTip="Edit" CommandName="Edit" />
                                                                        <%--<asp:ImageButton ID="ibDelete" runat="server" ImageUrl="images/action/trash.png" Text="Delete" ToolTip="Delete Package" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to Remove the package?')" />--%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:ImageButton ID="ibAdd" runat="server" ImageUrl="images/action/add.png" Text="Add" ToolTip="Add" OnClick="gvPackages_Add" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:View>
                                                </asp:MultiView>
                                                <%--<div visible="false" runat="server" id="div_commodity">
                                                    <h4 style="display:inline-block; margin-right:5px;">Please edit commodity!</h4><asp:ImageButton ID="imbCommodity" runat="server" ImageUrl="images/action/pay_by_group.png" OnClick="imbCommodity_Click" />
                                                </div>--%>
                                                <div style="display:flex; justify-content:flex-end; margin-top: 10px;">
                                                    <asp:Button ID="btnStep2Back" runat="server" Text="Back" Width="90" Height="40" OnClick="btnStep2Back_Click" CssClass="btn-back" />
                                                    <asp:Button ID="btnStep2Next" runat="server" Text="Next" Width="90" Height="40" OnClick="btnStep2Next_Click" CssClass="btn-next" />
                                                    <asp:Button Visible="false" ID="btnStep2Update" runat="server" Text="Update" Width="90" Height="40" OnCommand="btnUpdate_Click" CssClass="btn-next" CommandName="package" />
                                                </div>
                                            </div>
                                        </div>
                                        <div id="divStep3" runat="server" visible="false">
                                            <h2 style="background-color: #BDE5F8; width: 100%;" onclick="ExpandCollapse('expcol_3')">Payment</h2>
                                            <div id="expcol_3">
                                                <h3>Enter the payment information</h3>
                                                <asp:DetailsView ID="dvShipping_payment" runat="server" DefaultMode="Insert" Font-Size="13px" Width="60%" CellSpacing="3"
                                                    Font-Names="Verdana" AllowPaging="False" GridLines="None" AutoGenerateRows="False">

                                                    <FieldHeaderStyle Font-Bold="true" HorizontalAlign="right" Height="30" Width="100" ForeColor="#0466CC" />
                                                    <Fields>
                                                        <asp:TemplateField HeaderText="Payor:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:DropDownList ID="ddlPayor" runat="server" AutoPostBack="True" SelectedValue='<%# Bind("bill_to") %>' Width="90%"
                                                                    DataValueField="bill_to" DataTextField="bill_to" CssClass="Adj-DDL-Height" OnDataBound="ddlPayor_DataBound"
                                                                    OnSelectedIndexChanged="ddlPayor_SelectedIndexChanged">
                                                                    <asp:ListItem Value="receiver">Recipient</asp:ListItem>
                                                                    <asp:ListItem Value="third" Enabled="false">Third Party</asp:ListItem>
                                                                    <asp:ListItem Value="sender" Enabled="false">Sender</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Client:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="True" Width="90%" OnPreRender="ddlClient_PreRender" OnDataBound="ddlClient_DataBound"
                                                                     CssClass="Adj-DDL-Height" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="*Account Number:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtAccNum" runat="server" Text='<%# Bind("account_no") %>' Width="90%" Height="30">
                                                                </asp:TextBox>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="*Ship From:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtTpShipFrom" runat="server" Text='<%# Bind("tp_shipfrom") %>' Width="90%" Height="30"
                                                                    AutoCompleteType="Company" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bill To:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtTpBillTo" runat="server" Text='<%# Bind("payorName") %>' Width="90%" Height="30" />
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Country Code:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtCountryCode" runat="server" Text='<%# Bind("tp_country") %>' Width="90%" Height="30" placeholder="US;CA">
                                                                </asp:TextBox>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Postal Code:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtPostCode" runat="server" Text='<%# Bind("tp_postcode") %>' Width="90%" Height="30" AutoCompleteType="BusinessZipCode">
                                                                </asp:TextBox>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="*City:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtCity" runat="server" Text='<%# Bind("payorCity") %>' Width="90%" Height="30">
                                                                </asp:TextBox>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="*Address1:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" Text='<%# Bind("payorAddress1") %>' Width="90%" Height="30">
                                                                </asp:TextBox>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address2:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" Text='<%# Bind("payorAddress2") %>' Width="90%" Height="30">
                                                                </asp:TextBox>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="State:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtState" runat="server" MaxLength="35" Text='<%# Bind("payorState") %>' Width="90%" Height="30">
                                                                </asp:TextBox>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Po Number:" ItemStyle-HorizontalAlign="Left">
                                                            <InsertItemTemplate>
                                                                <asp:TextBox ID="txtPoNo" runat="server" Text='<%# Bind("pono") %>' Width="90%" Height="30" >
                                                                </asp:TextBox>
                                                            </InsertItemTemplate>
                                                        </asp:TemplateField>
                                                    </Fields>
                                                </asp:DetailsView>
                                                <div style="display:flex; justify-content:flex-end;">
                                                    <asp:Button ID="btnStep3Back" runat="server" Text="Back" Width="90" Height="40" OnClick="btnStep3Back_Click" CssClass="btn-back" />
                                                    <asp:Button ID="btnStep3Next" runat="server" Text="Next" Width="90" Height="40" OnClick="btnStep3Next_Click" CssClass="btn-next" />
                                                    <asp:Button Visible="false" ID="btnStep3Update" runat="server" Text="Update" Width="90" Height="40" OnCommand="btnUpdate_Click" CssClass="btn-next" CommandName="payment" />
                                                </div>
                                            </div>
                                        </div>
                                        <div runat="server" id="divStep4" visible="false">
                                            <h2 style="background-color: #BDE5F8; width: 100%;" onclick="ExpandCollapse('expcol_4')">Confirmation</h2>
                                            <div id="expcol_4">
                                                <h3>Please review the shipment</h3>
                                                <h4 style="display:inline-block;margin-bottom:10px; margin-top:10px;">From:</h4>
                                                <asp:ImageButton runat="server" ImageUrl="images/action/edit2.png" OnClick="reviewStep1_Click" />
                                                <asp:DetailsView ID="dvConfirm_From" runat="server" Font-Size="13px" Width="60%"
                                                    Font-Names="Verdana" AllowPaging="False" GridLines="None" AutoGenerateRows="False" CellPadding="3">

                                                    <FieldHeaderStyle Font-Bold="true" HorizontalAlign="right" Width="100" ForeColor="#0466CC" />
                                                    <Fields>
                                                        <asp:TemplateField HeaderText="Name:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSfName" runat="server" Text='<%# Bind("sf_cname") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSfLocation" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Phone:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSfTel" runat="server" Text='<%# Bind("sf_tel") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSfEmail" runat="server" Text='<%# Bind("emailfail") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Fields>
                                                </asp:DetailsView>
                                                <h4 style="display:inline-block;margin-bottom:10px; margin-top:10px;">To:</h4>
                                                <asp:ImageButton runat="server" ImageUrl="images/action/edit2.png" OnClick="reviewStep1_Click" />
                                                <asp:DetailsView ID="dvConfirm_To" runat="server" Font-Size="13px" Width="60%" OnDataBound="dvConfirm_DataBound"
                                                    Font-Names="Verdana" AllowPaging="False" GridLines="None" AutoGenerateRows="False" CellPadding="3">

                                                    <FieldHeaderStyle Font-Bold="true" HorizontalAlign="right" Width="100" ForeColor="#0466CC" />
                                                    <Fields>
                                                        <asp:TemplateField HeaderText="Name:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCName" runat="server" Text='<%# Bind("cname") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLocation" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Phone:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTel" runat="server" Text='<%# Bind("tel") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Fields>
                                                </asp:DetailsView>
                                                <h4 style="display:inline-block;margin-bottom:10px; margin-top:10px;">Packages:</h4>
                                                <asp:ImageButton runat="server" ImageUrl="images/action/edit2.png" OnClick="reviewStep2_Click" />
                                                <asp:GridView ID="gvReview" runat="server"
                                                    GridLines="Both" Font-Size="13px" Font-Names="Verdana" AllowPaging="True" PageSize="10" PagerSettings-Mode="NumericFirstLast"
                                                    AutoGenerateColumns="False" OnRowCreated="gvPackages_RowCreated">

                                                    <RowStyle Height="45" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" ForeColor="#0466CC" />
                                                    <HeaderStyle ForeColor="#0466CC" HorizontalAlign="Left" Font-Bold="true" CssClass="headerRow" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Package#" ControlStyle-Width="50" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Part#" ControlStyle-Width="150" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPartno" runat="server" Text='<%# Eval("partno") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Weight" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblWeight" runat="server" Text='<%# Eval("weight") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Length" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLength" runat="server" Text='<%# Eval("length") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Width" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblWidth" runat="server" Text='<%# Eval("width") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Height" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblHeight" runat="server" Text='<%# Eval("height") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="QTY" ControlStyle-Width="50" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQty" runat="server" Text='<%# Eval("qty") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Unit Price" ControlStyle-Width="100" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUnitPrice" runat="server" Text='<%# Eval("unit_price") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Service Type" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblServiceTypeFx" Text='<%# (FedExAPIWCF.ShippingServiceType)Enum.Parse(typeof(FedExAPIWCF.ShippingServiceType), Eval("service_type_fx").ToString()) %>' Font-Size="Smaller" />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Service Type" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblServiceTypeUps" Text='<%# UpsHelper.GetUpsServiceTypeDisplayName(Eval("service_type_ups").ToString()) %>' Font-Size="Smaller" />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Billing Option" Visible="false" ItemStyle-HorizontalAlign="Left" ControlStyle-Width="120">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBilling" runat="server" Text='<%# UpsHelper.GetBillingOptionText(Eval("FreightBilling").ToString()) %>' />
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Packaging Type" Visible="false" ItemStyle-HorizontalAlign="Left" ControlStyle-Width="100">
                                                            <ItemTemplate>
                                                                 <asp:Label ID="lblPckType" runat="server" Text='<%# UpsHelper.GetPackagingTypeText(Eval("FreightPckType").ToString()) %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Pickup Date" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPickupDate" runat="server" Text='<%# Eval("pickupDate") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Start Time" ItemStyle-Width="90" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStartHour" runat="server" Text='<%# Eval("startHour") %>' />:
                                                                <asp:Label ID="lblStartMinute" runat="server" Text='<%# Eval("startMinute") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="End Time" ItemStyle-Width="90" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEndHour" runat="server" Text='<%# Eval("endHour") %>' />:
                                                                <asp:Label ID="lblEndMinute" runat="server" Text='<%# Eval("endMinute") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description" ControlStyle-Width="250" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("description") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <h4 style="display:inline-block;margin-bottom:10px; margin-top:10px;">Payment:</h4>
                                                <asp:ImageButton runat="server" ImageUrl="images/action/edit2.png" OnClick="reviewStep3_Click" />
                                                <asp:DetailsView ID="dvConfirm_Payment" runat="server" Font-Size="13px" Width="60%" CellSpacing="3"
                                                    Font-Names="Verdana" AllowPaging="False" GridLines="None" AutoGenerateRows="False">

                                                    <FieldHeaderStyle Font-Bold="true" HorizontalAlign="right" Height="30" Width="100" ForeColor="#0466CC" />
                                                    <Fields>
                                                        <asp:TemplateField HeaderText="Payor:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPayor" runat="server" Text='<%# Eval("bill_to") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Client:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblClient" runat="server" Text='<%# Eval("client_display") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Account Number:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAccNum" runat="server" Text='<%# Eval("account_no") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Ship From:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTpShipFrom" runat="server" Text='<%# Eval("tp_shipfrom") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bill To:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTpBillTo" runat="server" Text='<%# Eval("payorName") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Country Code:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCountryCode" runat="server" Text='<%# Eval("tp_country") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Postal Code:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPostCode" runat="server" Text='<%# Eval("tp_postcode") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Po Number:" ItemStyle-HorizontalAlign="Left" HeaderStyle-Height="30" ItemStyle-Height="30" ItemStyle-Font-Size="Larger">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPoNo" runat="server" Text='<%# Eval("pono") %>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Fields>
                                                </asp:DetailsView>
                                                <div style="display:flex; justify-content:flex-end;">
                                                    <asp:Button ID="btnCreate" runat="server" Text="Create" Width="90" Height="40" OnClick="btnCreate_Click" CssClass="btn-next" OnClientClick="var frm = confirm('Are you ready to create the shipment?'); if(frm) stopShipmentLoading(); return frm;" />
                                                </div>
                                            </div>
                                        </div>
                                        <div runat="server" id="div_result" visible="false">
                                            <h2 style="background-color: #BDE5F8; width: 100%;" onclick="ExpandCollapse('expcol_5')">Result</h2>
                                            <div id="expcol_5">
                                                <asp:GridView ID="gvResult" runat="server"
                                                    GridLines="Both" Font-Size="13px" Font-Names="Verdana" AllowPaging="True" PageSize="10" PagerSettings-Mode="NumericFirstLast"
                                                    AutoGenerateColumns="False" OnRowCreated="gvResult_RowCreated" >

                                                    <RowStyle Height="45" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" ForeColor="#0466CC" />
                                                    <HeaderStyle ForeColor="#0466CC" HorizontalAlign="Left" Font-Bold="true" CssClass="headerRow" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Package#" ControlStyle-Width="50" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Part#" ControlStyle-Width="160" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPartno" runat="server" Text='<%# Eval("partno") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tracking Number" ControlStyle-Width="250" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTrackNo" runat="server" Text='<%# Eval("trackno") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Pickup Number" ControlStyle-Width="200" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPickupNo" runat="server" Text='<%# Eval("pickupno") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Error Message" ControlStyle-Width="100%" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblErrMsg" runat="server" Text='<%# Eval("errMsg") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Size="Large" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <div style="display:flex; justify-content:flex-end;">
                                                    <asp:Button ID="btnNew" runat="server" Text="Create New" Width="90" Height="40" OnClick="btnNew_Click" CssClass="btn-next" />
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </form>
    <script type="text/javascript">
        function ExpandCollapse(id) {
            $("#" + id).toggle(800);
            //window.location.hash = id;
        }

        var stopShipmentLoading = function () {
            setTimeout(function () {
                var cookie = $.cookie("created");
                if (!cookie) {
                    stopShipmentLoading(2000);
                }
                else {
                    unloading();
                    document.getElementById("btnFake").click();
                }
            }, 3000);
        };
    </script>
</body>
</html>