using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FedExShippingWCF;
using FedExShippingWCF.FedExShipService;
using System.Data;
using Newtonsoft.Json;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDataSource();
            CleanUpCookie();
        }
        else
        {
            btnStep1Update.Visible = divStep4.Visible;
            btnStep1.Visible = !divStep4.Visible;

            btnStep2Update.Visible = divStep4.Visible;
            btnStep2Next.Visible = !divStep4.Visible;

            btnStep3Update.Visible = divStep4.Visible;
            btnStep3Next.Visible = !divStep4.Visible;
        }
    }

    #region Stored ViewState Table

    protected DataTable shipmentTable
    {
        get
        {
            if (ViewState["Shipment"] == null)
                CreateShipmentTable();
            return (DataTable)ViewState["Shipment"];
        }
        set
        {
            ViewState["Shipment"] = value;
        }
    }

    protected DataTable packagesTable
    {
        get
        {
            if (ViewState["Packages"] == null)
                CreatePackagesTable();
            return (DataTable)ViewState["Packages"];
        }
        set
        {
            ViewState["Packages"] = value;
        }
    }

    protected DataTable tpClientsTable
    {
        get
        {
            if (ViewState["tpClients"] == null)
                return new DataTable();
            return (DataTable)ViewState["tpClients"];
        }
        set
        {
            ViewState["tpClients"] = value;
        }
    }

    private void CreateShipmentTable()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("sf_cname");
        dt.Columns.Add("sf_attention");
        dt.Columns.Add("sf_country");
        dt.Columns.Add("sf_city");
        dt.Columns.Add("sf_address1");
        dt.Columns.Add("sf_address2");
        dt.Columns.Add("sf_state");
        dt.Columns.Add("sf_postcode");
        dt.Columns.Add("sf_tel");
        dt.Columns.Add("emailfail");
        dt.Columns.Add("cname");
        dt.Columns.Add("company");
        dt.Columns.Add("country");
        dt.Columns.Add("city");
        dt.Columns.Add("address1");
        dt.Columns.Add("address2");
        dt.Columns.Add("state");
        dt.Columns.Add("postcode");
        dt.Columns.Add("tel");
        dt.Columns.Add("email");
        dt.Columns.Add("isemail");
        dt.Columns.Add("bill_to");
        dt.Columns.Add("account_no");
        dt.Columns.Add("client");
        dt.Columns.Add("client_display");
        dt.Columns.Add("tp_shipfrom");
        dt.Columns.Add("payorName");
        dt.Columns.Add("tp_country");
        dt.Columns.Add("tp_postcode");
        dt.Columns.Add("payorCity");
        dt.Columns.Add("payorAddress1");
        dt.Columns.Add("payorAddress2");
        dt.Columns.Add("payorState");
        dt.Columns.Add("pono");
        dt.Columns.Add("reference");

        dt.Rows.Add(dt.NewRow());
        dt.Rows[0].BeginEdit();
        dt.Rows[0]["sf_cname"] = "LA Lakers";
        dt.Rows[0]["sf_attention"] = "James";
        dt.Rows[0]["sf_city"] = "Los Angeles";
        dt.Rows[0]["sf_address1"] = "1111 South Figueroa Street";
        dt.Rows[0]["sf_state"] = "CA";
        dt.Rows[0]["sf_postcode"] = "90015";
        dt.Rows[0]["emailfail"] = "james@lk.nba.com";
        dt.Rows[0]["sf_tel"] = "2424242424";
        dt.Rows[0]["cname"] = "Trump";
        dt.Rows[0]["company"] = "White House";
        dt.Rows[0]["city"] = "Washington";
        dt.Rows[0]["address1"] = "1600 Pennsylvania Ave NW";
        dt.Rows[0]["state"] = "DC";
        dt.Rows[0]["postcode"] = "20500";
        dt.Rows[0]["email"] = "trump@white.com";
        dt.Rows[0]["tel"] = "1234567890";
        dt.Rows[0]["account_no"] = "510087160";
        dt.Rows[0]["payorName"] = "LA Lakers";
        dt.Rows[0]["pono"] = "TEST2020";
        dt.Rows[0]["isemail"] = true;
        dt.Rows[0].EndEdit();
        dt.AcceptChanges();

        shipmentTable = dt;
    }

    private void CreatePackagesTable()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("id_num");
        dt.Columns.Add("weight");
        dt.Columns.Add("length");
        dt.Columns.Add("width");
        dt.Columns.Add("height");
        dt.Columns.Add("qty");
        dt.Columns.Add("partno");
        dt.Columns.Add("unit_price");
        dt.Columns.Add("service_type_fx");
        dt.Columns.Add("service_type_ups");
        dt.Columns.Add("FreightBilling");
        dt.Columns.Add("FreightPckType");
        dt.Columns.Add("pickupDate");
        dt.Columns.Add("startHour");
        dt.Columns.Add("startMinute");
        dt.Columns.Add("endHour");
        dt.Columns.Add("endMinute");
        dt.Columns.Add("description");
        dt.Columns.Add("trackno");
        dt.Columns.Add("pickupno");
        dt.Columns.Add("errMsg");
        dt.Columns.Add("isFreight");

        dt.Rows.Add(dt.NewRow());
        dt.Rows[0].BeginEdit();
        dt.Rows[0]["id_num"] = string.Format("{0}_{1}", DateTime.Today.ToString("MMddyyyy"), 0);
        dt.Rows[0]["weight"] = "2";
        dt.Rows[0]["length"] = "5";
        dt.Rows[0]["width"] = "5";
        dt.Rows[0]["height"] = "5";
        dt.Rows[0]["partno"] = "TEST0101";
        dt.Rows[0]["description"] = "surprise";
        dt.Rows[0]["service_type_fx"] = "90";
        dt.Rows[0]["service_type_ups"] = "GND";
        dt.Rows[0]["isFreight"] = false;
        dt.Rows[0]["FreightBilling"] = "30";
        dt.Rows[0]["FreightPckType"] = "CRT";
        dt.Rows[0]["pickupDate"] = DateTime.Today.ToString("MM/dd/yyyy");
        dt.Rows[0]["startHour"] = "11";
        dt.Rows[0]["startMinute"] = "00";
        dt.Rows[0]["endHour"] = "17";
        dt.Rows[0]["endMinute"] = "00";
        dt.Rows[0].EndEdit();
        dt.AcceptChanges();

        packagesTable = dt;
    }

    #endregion

    #region Step1

    protected void dvAddress_PreRender(object sender, EventArgs e)
    {
        btnStep1Update.Visible = divStep4.Visible;
        btnStep1.Visible = !divStep4.Visible;
        SetDvAddressFields();
    }

    protected void dvShippingTo_DataBound(object sender, EventArgs e)
    {
        DetailsViewRow dvr = dvShipping_to.Rows[0];

        ((CheckBox)dvr.FindControl("chkIsemail")).Checked = Convert.ToBoolean(((DataTable)dvShipping_to.DataSource).Rows[0]["isemail"]);
    }

    protected void ddlSfCountry_SelectedIndexChanged(Object sender, EventArgs e)
    {
        shipmentTable.Rows[0]["sf_country"] = ((DropDownList)sender).SelectedValue;
        StayOnStep1();
    }

    protected void ddlCountry_SelectedIndexChanged(Object sender, EventArgs e)
    {
        shipmentTable.Rows[0]["country"] = ((DropDownList)sender).SelectedValue;
        StayOnStep1();
    }

    private void SetDvAddressFields()
    {
        TextBox sf_cname = (TextBox)dvShipping_from.FindControl("txtSfName");
        sf_cname.Text = shipmentTable.Rows[0]["sf_cname"].ToString();

        TextBox sf_attention = (TextBox)dvShipping_from.FindControl("txtSfAttention");
        sf_attention.Text = shipmentTable.Rows[0]["sf_attention"].ToString();

        DropDownList ddlSfCountry = (DropDownList)dvShipping_from.FindControl("ddlSfCountry");
        ddlSfCountry.SelectedValue = string.IsNullOrEmpty(shipmentTable.Rows[0]["sf_country"].ToString()) ? "US" : shipmentTable.Rows[0]["sf_country"].ToString();

        TextBox sf_address1 = (TextBox)dvShipping_from.FindControl("txtSfAddress1");
        sf_address1.Text = shipmentTable.Rows[0]["sf_address1"].ToString();

        TextBox sf_address2 = (TextBox)dvShipping_from.FindControl("txtSfAddress2");
        sf_address2.Text = shipmentTable.Rows[0]["sf_address2"].ToString();

        TextBox sf_city = (TextBox)dvShipping_from.FindControl("txtSfCity");
        sf_city.Text = shipmentTable.Rows[0]["sf_city"].ToString();

        TextBox sf_state = (TextBox)dvShipping_from.FindControl("txtSfState");
        sf_state.Text = shipmentTable.Rows[0]["sf_state"].ToString();

        TextBox sf_postcode = (TextBox)dvShipping_from.FindControl("txtSfPostcode");
        sf_postcode.Text = shipmentTable.Rows[0]["sf_postcode"].ToString();

        TextBox sf_tel = (TextBox)dvShipping_from.FindControl("txtSfTel");
        sf_tel.Text = shipmentTable.Rows[0]["sf_tel"].ToString();

        TextBox emailfail = (TextBox)dvShipping_from.FindControl("txtSfEmail");
        emailfail.Text = shipmentTable.Rows[0]["emailfail"].ToString();

        TextBox cname = (TextBox)dvShipping_to.FindControl("txtName");
        cname.Text = shipmentTable.Rows[0]["cname"].ToString();

        TextBox company = (TextBox)dvShipping_to.FindControl("txtCompany");
        company.Text = shipmentTable.Rows[0]["company"].ToString();

        DropDownList ddlCountry = (DropDownList)dvShipping_to.FindControl("ddlCountry");
        ddlCountry.SelectedValue = string.IsNullOrEmpty(shipmentTable.Rows[0]["country"].ToString()) ? "US" : shipmentTable.Rows[0]["country"].ToString();

        TextBox address1 = (TextBox)dvShipping_to.FindControl("txtAddress1");
        address1.Text = shipmentTable.Rows[0]["address1"].ToString();

        TextBox address2 = (TextBox)dvShipping_to.FindControl("txtAddress2");
        address2.Text = shipmentTable.Rows[0]["address2"].ToString();

        TextBox city = (TextBox)dvShipping_to.FindControl("txtCity");
        city.Text = shipmentTable.Rows[0]["city"].ToString();

        TextBox state = (TextBox)dvShipping_to.FindControl("txtState");
        state.Text = shipmentTable.Rows[0]["state"].ToString();

        TextBox postcode = (TextBox)dvShipping_to.FindControl("txtPostcode");
        postcode.Text = shipmentTable.Rows[0]["postcode"].ToString();

        TextBox tel = (TextBox)dvShipping_to.FindControl("txtTel");
        tel.Text = shipmentTable.Rows[0]["tel"].ToString();

        TextBox email = (TextBox)dvShipping_to.FindControl("txtEmail");
        email.Text = shipmentTable.Rows[0]["email"].ToString();
    }

    private bool Step1Evaluation()
    {
        bool flag = false;

        TextBox sf_cname = (TextBox)dvShipping_from.FindControl("txtSfName");
        if (IsRequired(dvShipping_from.Rows[0].Cells[1], "sf_cname", sf_cname.Text.Trim()))
            flag = true;

        TextBox sf_attention = (TextBox)dvShipping_from.FindControl("txtSfAttention");
        if (IsRequired(dvShipping_from.Rows[1].Cells[1], "sf_attention", sf_attention.Text.Trim()))
            flag = true;

        DropDownList ddlSfCountry = (DropDownList)dvShipping_from.FindControl("ddlSfCountry");
        shipmentTable.Rows[0]["sf_country"] = ddlSfCountry.SelectedValue;

        TextBox sf_address1 = (TextBox)dvShipping_from.FindControl("txtSfAddress1");
        if (IsRequired(dvShipping_from.Rows[3].Cells[1], "sf_address1", sf_address1.Text.Trim()))
            flag = true;

        TextBox sf_address2 = (TextBox)dvShipping_from.FindControl("txtSfAddress2");
        shipmentTable.Rows[0]["sf_address2"] = sf_address2.Text.Trim();

        TextBox sf_city = (TextBox)dvShipping_from.FindControl("txtSfCity");
        if (IsRequired(dvShipping_from.Rows[5].Cells[1], "sf_city", sf_city.Text.Trim()))
            flag = true;

        TextBox sf_state = (TextBox)dvShipping_from.FindControl("txtSfState");
        if (IsRequired(dvShipping_from.Rows[6].Cells[1], "sf_state", sf_state.Text.Trim()))
            flag = true;

        TextBox sf_postcode = (TextBox)dvShipping_from.FindControl("txtSfPostcode");
        if (IsRequired(dvShipping_from.Rows[7].Cells[1], "sf_postcode", sf_postcode.Text.Trim()))
            flag = true;

        TextBox sf_tel = (TextBox)dvShipping_from.FindControl("txtSfTel");
        if (IsRequired(dvShipping_from.Rows[8].Cells[1], "sf_tel", sf_tel.Text.Trim()))
            flag = true;

        TextBox emailfail = (TextBox)dvShipping_from.FindControl("txtSfEmail");
        if (IsRequired(dvShipping_from.Rows[9].Cells[1], "emailfail", emailfail.Text.Trim()))
            flag = true;

        TextBox company = (TextBox)dvShipping_to.FindControl("txtCompany");
        if (IsRequired(dvShipping_to.Rows[0].Cells[1], "company", company.Text.Trim()))
            flag = true;

        TextBox cname = (TextBox)dvShipping_to.FindControl("txtName");
        if (IsRequired(dvShipping_to.Rows[1].Cells[1], "cname", cname.Text.Trim()))
            flag = true;

        DropDownList ddlCountry = (DropDownList)dvShipping_to.FindControl("ddlCountry");
        shipmentTable.Rows[0]["country"] = ddlCountry.SelectedValue;

        TextBox address1 = (TextBox)dvShipping_to.FindControl("txtAddress1");
        if (IsRequired(dvShipping_to.Rows[3].Cells[1], "address1", address1.Text.Trim()))
            flag = true;

        TextBox address2 = (TextBox)dvShipping_to.FindControl("txtAddress2");
        shipmentTable.Rows[0]["address2"] = address2.Text.Trim();

        TextBox city = (TextBox)dvShipping_to.FindControl("txtCity");
        if (IsRequired(dvShipping_to.Rows[5].Cells[1], "city", city.Text.Trim()))
            flag = true;

        TextBox state = (TextBox)dvShipping_to.FindControl("txtState");
        if (IsRequired(dvShipping_to.Rows[6].Cells[1], "state", state.Text.Trim()))
            flag = true;

        TextBox postcode = (TextBox)dvShipping_to.FindControl("txtPostcode");
        if (IsRequired(dvShipping_to.Rows[7].Cells[1], "postcode", postcode.Text.Trim()))
            flag = true;

        TextBox tel = (TextBox)dvShipping_to.FindControl("txtTel");
        if (IsRequired(dvShipping_to.Rows[8].Cells[1], "tel", tel.Text.Trim()))
            flag = true;

        TextBox email = (TextBox)dvShipping_to.FindControl("txtEmail");
        if (IsRequired(dvShipping_to.Rows[9].Cells[1], "email", email.Text.Trim()))
            flag = true;

        CheckBox chkIsemail = (CheckBox)dvShipping_to.FindControl("chkIsemail");
        shipmentTable.Rows[0]["isemail"] = chkIsemail.Checked;

        return flag;
    }

    protected void btnStep1_Click(Object sender, EventArgs e)
    {
        bool flag = Step1Evaluation();

        if (flag)
        {
            StayOnStep1();
            return;
        }

        BindDataSource();
        //divStep1.Visible = false;
        divStep2.Visible = true;
        //div_commodity.Visible = true;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_4').toggle(false);$('#expcol_5').toggle(false);$('#expcol_2').toggle(800);", true);
    }

    #endregion

    #region Step2

    protected void gvPackages_RowCreated(object sender, EventArgs e)
    {
        gvReview.Columns[3].Visible = multiView.ActiveViewIndex == 0;
        gvReview.Columns[4].Visible = multiView.ActiveViewIndex == 0;
        gvReview.Columns[5].Visible = multiView.ActiveViewIndex == 0;
        gvReview.Columns[6].Visible = multiView.ActiveViewIndex == 0;
        gvReview.Columns[7].Visible = multiView.ActiveViewIndex == 0;
        gvReview.Columns[8].Visible = multiView.ActiveViewIndex == 0;
        gvReview.Columns[9].Visible = multiView.ActiveViewIndex == 1;
        gvReview.Columns[10].Visible = multiView.ActiveViewIndex == 1;
        gvReview.Columns[11].Visible = multiView.ActiveViewIndex == 1;
        gvReview.Columns[12].Visible = multiView.ActiveViewIndex == 1;
        gvReview.Columns[13].Visible = multiView.ActiveViewIndex == 1;

        gvPackages.Columns[7].Visible = true;
        gvPackages.Columns[8].Visible = false;

        gvReview.Columns[7].Visible = true;
        gvReview.Columns[8].Visible = false;

        gvPackages.Columns[6].Visible = IsInternational();
        gvReview.Columns[6].Visible = IsInternational();
    }

    protected void gvPackages_Add(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvr = (GridViewRow)((ImageButton)sender).Parent.Parent; // ImageButton --> DataControlFieldCell --> GridViewRow
            GridView gv = (GridView)gvr.Parent.Parent;

            DataRow dr = packagesTable.NewRow();

            dr["id_num"] = string.Format("{0}_{1}", DateTime.Today.ToString("MMddyyyy"), packagesTable.Rows.Count);
            dr["weight"] = ((TextBox)gvr.FindControl("txtWeightAdd")).Text.Trim();
            dr["length"] = ((TextBox)gvr.FindControl("txtLengthAdd")).Text.Trim();
            dr["width"] = ((TextBox)gvr.FindControl("txtWidthAdd")).Text.Trim();
            dr["height"] = ((TextBox)gvr.FindControl("txtHeightAdd")).Text.Trim();
            //dr["qty"] = ((TextBox)gvr.FindControl("txtQtyAdd")).Text.Trim();
            dr["partno"] = ((TextBox)gvr.FindControl("txtPartNoAdd")).Text.Trim();
            dr["unit_price"] = ((TextBox)gvr.FindControl("txtUnitPriceAdd")).Text.Trim();
            dr["service_type_fx"] = ((DropDownList)gvr.FindControl("ddlServiceTypeAddFx")).SelectedValue;
            dr["service_type_ups"] = "GND";
            dr["description"] = ((TextBox)gvr.FindControl("txtDescriptionAdd")).Text.Trim();

            if (multiView.ActiveViewIndex == 1)
            {
                dr["isFreight"] = true;
            }

            packagesTable.Rows.Add(dr);
            BindDataSource();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        StayOnStep2();
    }

    protected void gvPackages_Edit(object sender, GridViewEditEventArgs e)
    {
        lblMessage.Text = "";

        GridView gv = (GridView)sender;
        gv.EditIndex = e.NewEditIndex;
        BindDataSource();
        StayOnStep2();
    }

    protected void gvPackages_Update(object sender, GridViewUpdateEventArgs e)
    {
        GridView gv = (GridView)sender;

        UpdatePackage(e.RowIndex);
        gv.EditIndex = -1;
        BindDataSource();
        StayOnStep2();
    }

    private void UpdatePackage(int rowIndex)
    {
        DataRow dr = packagesTable.Rows[rowIndex];
        GridViewRow gvr;

        dr.BeginEdit();

        if (multiView.ActiveViewIndex == 1)
        {
            gvr = gvFreight.Rows[rowIndex];
            dr["isFreight"] = true;
            dr["FreightBilling"] = ((DropDownList)gvr.FindControl("ddlBilling")).SelectedValue;
            dr["FreightPckType"] = ((DropDownList)gvr.FindControl("ddlPckType")).SelectedValue;
            dr["pickupDate"] = ((TextBox)gvr.FindControl("txtPickupDate")).Text.Trim();
            dr["startHour"] = ((DropDownList)gvr.FindControl("ddlStartHour")).SelectedValue;
            dr["startMinute"] = ((DropDownList)gvr.FindControl("ddlStartMinute")).SelectedValue;
            dr["endHour"] = ((DropDownList)gvr.FindControl("ddlEndHour")).SelectedValue;
            dr["endMinute"] = ((DropDownList)gvr.FindControl("ddlEndMinute")).SelectedValue;
        }
        else
        {
            gvr = gvPackages.Rows[rowIndex];
            dr["length"] = ((TextBox)gvr.FindControl("txtLength")).Text.Trim();
            dr["width"] = ((TextBox)gvr.FindControl("txtWidth")).Text.Trim();
            dr["height"] = ((TextBox)gvr.FindControl("txtHeight")).Text.Trim();
            //dr["qty"] = ((TextBox)gvr.FindControl("txtQty")).Text.Trim();

            dr["unit_price"] = ((TextBox)gvr.FindControl("txtUnitPrice")).Text.Trim();
            dr["service_type_fx"] = ((DropDownList)gvr.FindControl("ddlServiceTypeFx")).SelectedValue;
        }

        dr["weight"] = ((TextBox)gvr.FindControl("txtWeight")).Text.Trim();
        dr["partno"] = ((TextBox)gvr.FindControl("txtPartNo")).Text.Trim();
        dr["description"] = ((TextBox)gvr.FindControl("txtDescription")).Text.Trim();

        dr.EndEdit();
        dr.AcceptChanges();
    }

    protected void GridView_Cancel(object sender, GridViewCancelEditEventArgs e)
    {
        GridView gv = (GridView)sender;
        gv.EditIndex = -1;
        BindDataSource();
        StayOnStep2();
    }

    protected void gvPackages_DeletePackage(object sender, GridViewDeleteEventArgs e)
    {
        lblMessage.Text = "";

        if (packagesTable.Rows.Count == 1)
        {
            lblMessage.Text =  "Unable to remove the package.";
            StayOnStep2();
            return;
        }

        packagesTable.Rows.RemoveAt(e.RowIndex);
        BindDataSource();
        StayOnStep2();
    }

    protected void chkIdentical_Checked(Object sender, EventArgs args)
    {
        CheckBox isIdentical = sender as CheckBox;

        TextBox weight = (TextBox)gvPackages.FooterRow.FindControl("txtWeightAdd");
        TextBox length = (TextBox)gvPackages.FooterRow.FindControl("txtLengthAdd");
        TextBox width = (TextBox)gvPackages.FooterRow.FindControl("txtWidthAdd");
        TextBox height = (TextBox)gvPackages.FooterRow.FindControl("txtHeightAdd");
        //TextBox qty = (TextBox)gvPackages.FooterRow.FindControl("txtQtyAdd");
        TextBox partno = (TextBox)gvPackages.FooterRow.FindControl("txtPartNoAdd");
        TextBox unitPrice = (TextBox)gvPackages.FooterRow.FindControl("txtUnitPriceAdd");
        DropDownList type;
        TextBox description = (TextBox)gvPackages.FooterRow.FindControl("txtDescriptionAdd");

        if (isIdentical.Checked)
        {
            DataRow dr = packagesTable.Rows[packagesTable.Rows.Count - 1];
            weight.Text = dr["weight"].ToString();
            length.Text = dr["length"].ToString();
            width.Text = dr["width"].ToString();
            height.Text = dr["height"].ToString();
            //qty.Text = dr["qty"].ToString();
            partno.Text = dr["partno"].ToString();
            unitPrice.Text = dr["unit_price"].ToString();
            type = (DropDownList)gvPackages.FooterRow.FindControl("ddlServiceTypeAddFx");
            type.SelectedValue = dr["service_type_fx"].ToString();
            description.Text = dr["description"].ToString();
        }
        else
        {
            weight.Text = string.Empty;
            length.Text = string.Empty;
            width.Text = string.Empty;
            height.Text = string.Empty;
            //qty.Text = string.Empty;
            partno.Text = string.Empty;
            unitPrice.Text = string.Empty;
            type = (DropDownList)gvPackages.FooterRow.FindControl("ddlServiceTypeAddFx");
            type.SelectedValue = "90";
            description.Text = string.Empty;
        }

        StayOnStep2();
    }

    protected void ddlStep2_SelectedIndexChanged(Object sender, EventArgs e)
    {
        StayOnStep2();
    }

    protected void menuShippingType_MenuItemClick(Object sender, MenuEventArgs e)
    {
        multiView.ActiveViewIndex = Convert.ToInt32(e.Item.Value);
        DisplayPayorFields();
        StayOnStep2();
    }

    protected void btnStep2Back_Click(Object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_4').toggle(false);$('#expcol_5').toggle(false);$('#expcol_1').toggle(800);", true);
    }

    protected void btnStep2Next_Click(Object sender, EventArgs e)
    {
        if (gvPackages.EditIndex != -1)
        {
            StayOnStep2();
            return;
        }

        bool flag = Step2Evaluation();

        if (flag)
        {
            StayOnStep2();
            return;
        }

        //divStep2.Visible = false;
        divStep3.Visible = true;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_4').toggle(false);$('#expcol_5').toggle(false);$('#expcol_3').toggle(800);", true);
    }

    private bool Step2Evaluation()
    {
        bool flag = false;

        for (short i = 0; i < gvPackages.Rows.Count; i++)
        {
            if (CheckIsEmpty(gvPackages.Rows[i], packagesTable.Rows[i]))
            {
                flag = true;
                gvPackages.Rows[i].Attributes.Add("class", "required");
            }
            else
            {
                gvPackages.Rows[i].Attributes.Remove("class");
            }
        }

        if (flag)
            gvPackages.Attributes.Add("class", "fix-required-display");
        else
            gvPackages.Attributes.Remove("class");

        return flag;
    }

    private bool CheckIsEmpty(GridViewRow gvRow, DataRow dr)
    {
        bool flag = false;

        Label partno = (Label)gvRow.FindControl("lblPartno");
        if (string.IsNullOrWhiteSpace(partno.Text))
        {
            gvRow.Cells[1].BorderColor = System.Drawing.Color.Red;
            gvRow.Cells[1].BorderStyle = BorderStyle.Solid;
            gvRow.Cells[1].BorderWidth = Unit.Pixel(2);

            flag = true;
        }
        else
        {
            gvRow.Cells[1].BorderColor = System.Drawing.Color.Empty;
            gvRow.Cells[1].BorderWidth = Unit.Pixel(1);
            dr["partno"] = partno.Text.Trim();
        }

        Label weight = (Label)gvRow.FindControl("lblWeight");
        if (string.IsNullOrWhiteSpace(weight.Text))
        {
            gvRow.Cells[2].BorderColor = System.Drawing.Color.Red;
            gvRow.Cells[2].BorderStyle = BorderStyle.Solid;
            gvRow.Cells[2].BorderWidth = Unit.Pixel(2);

            flag = true;
        }
        else
        {
            gvRow.Cells[2].BorderColor = System.Drawing.Color.Empty;
            gvRow.Cells[2].BorderWidth = Unit.Pixel(1);
            dr["weight"] = weight.Text.Trim();
        }

        if (multiView.ActiveViewIndex == 0)
        {
            Label length = (Label)gvRow.FindControl("lblLength");
            if (string.IsNullOrWhiteSpace(length.Text))
            {
                gvRow.Cells[3].BorderColor = System.Drawing.Color.Red;
                gvRow.Cells[3].BorderStyle = BorderStyle.Solid;
                gvRow.Cells[3].BorderWidth = Unit.Pixel(2);

                flag = true;
            }
            else
            {
                gvRow.Cells[3].BorderColor = System.Drawing.Color.Empty;
                gvRow.Cells[3].BorderWidth = Unit.Pixel(1);
                dr["length"] = length.Text.Trim();
            }

            Label width = (Label)gvRow.FindControl("lblWidth");
            if (string.IsNullOrWhiteSpace(width.Text))
            {
                gvRow.Cells[4].BorderColor = System.Drawing.Color.Red;
                gvRow.Cells[4].BorderStyle = BorderStyle.Solid;
                gvRow.Cells[4].BorderWidth = Unit.Pixel(2);

                flag = true;
            }
            else
            {
                gvRow.Cells[4].BorderColor = System.Drawing.Color.Empty;
                gvRow.Cells[4].BorderWidth = Unit.Pixel(1);
                dr["width"] = width.Text.Trim();
            }

            Label height = (Label)gvRow.FindControl("lblHeight");
            if (string.IsNullOrWhiteSpace(height.Text))
            {
                gvRow.Cells[5].BorderColor = System.Drawing.Color.Red;
                gvRow.Cells[5].BorderStyle = BorderStyle.Solid;
                gvRow.Cells[5].BorderWidth = Unit.Pixel(2);

                flag = true;
            }
            else
            {
                gvRow.Cells[5].BorderColor = System.Drawing.Color.Empty;
                gvRow.Cells[5].BorderWidth = Unit.Pixel(1);
                dr["height"] = height.Text.Trim();
            }
        }
        else
        {

        }

        if (IsInternational())
        {
            Label unitPrice = (Label)gvRow.FindControl("lblUnitPrice");
            if (string.IsNullOrWhiteSpace(unitPrice.Text))
            {
                gvRow.Cells[6].BorderColor = System.Drawing.Color.Red;
                gvRow.Cells[6].BorderStyle = BorderStyle.Solid;
                gvRow.Cells[6].BorderWidth = Unit.Pixel(2);

                flag = true;
            }
            else
            {
                gvRow.Cells[6].BorderColor = System.Drawing.Color.Empty;
                gvRow.Cells[6].BorderWidth = Unit.Pixel(1);
                dr["unit_price"] = unitPrice.Text.Trim();
            }
        }


        Label description = (Label)gvRow.FindControl("lblDescription");
        if (string.IsNullOrWhiteSpace(description.Text))
        {
            gvRow.Cells[9].BorderColor = System.Drawing.Color.Red;
            gvRow.Cells[9].BorderStyle = BorderStyle.Solid;
            gvRow.Cells[9].BorderWidth = Unit.Pixel(2);

            flag = true;
        }
        else
        {
            gvRow.Cells[9].BorderColor = System.Drawing.Color.Empty;
            gvRow.Cells[9].BorderWidth = Unit.Pixel(1);
            dr["description"] = description.Text.Trim();
        }

        return flag;
    }

    #endregion

    #region Step3

    protected void ddlPayor_DataBound(object sender, EventArgs e)
    {
        DropDownList ddlPayor = (DropDownList)sender;

        string payor = shipmentTable.Rows[0]["bill_to"].ToString();
        //if (ddlPayor.SelectedValue != payor)
        //{
            if (string.IsNullOrEmpty(payor))
                shipmentTable.Rows[0]["bill_to"] = ddlPayor.SelectedValue;
            else
                ddlPayor.SelectedValue = payor;

            SetPaymentFieldVisibility(ddlPayor.SelectedValue);
        //}
    }

    protected void ddlPayor_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlPayor = (DropDownList)sender;

        shipmentTable.Rows[0]["bill_to"] = ddlPayor.SelectedValue;
        shipmentTable.Rows[0]["client"] = "";
        CleanUpPaymentFields();
        SetPaymentFieldVisibility(ddlPayor.SelectedValue);
        StayOnStep3();
    }

    private void SetPaymentFieldVisibility(string selectedValue)
    {
        if (selectedValue == "receiver")
        {
            dvShipping_payment.Fields[1].Visible = false;

            //CleanUpPaymentFields();
            SetRecipientFields();
        }
        else
        {
            dvShipping_payment.Fields[1].Visible = true;
        }

        DisplayPayorFields();

        if (selectedValue == "third")
        { // required fields
            dvShipping_payment.Fields[5].HeaderText = "*Country Code:";
            dvShipping_payment.Fields[6].HeaderText = "*Postal Code:";
        }
        else
        {
            dvShipping_payment.Fields[5].HeaderText = "Country Code:";
            dvShipping_payment.Fields[6].HeaderText = "Postal Code:";
        }
    }

    protected void ddlClient_PreRender(object sender, EventArgs e)
    {
        if (shipmentTable.Rows[0]["bill_to"].ToString() == "receiver")
        {
            return;
        }
    }

    protected void ddlClient_DataBound(object sender, EventArgs e)
    {
        if (shipmentTable.Rows[0]["bill_to"].ToString() == "receiver") return;

        DropDownList ddlClient = (DropDownList)sender;

        string client = shipmentTable.Rows[0]["client"].ToString();

        if (!string.IsNullOrEmpty(client) && ddlClient.SelectedValue != client)
        {
            ddlClient.SelectedValue = client;
        }

        if (!string.IsNullOrEmpty(ddlClient.SelectedValue))
        {
            DataRow dr = tpClientsTable.Rows.Find(ddlClient.SelectedValue);
            SetAssociatedFieldVal(dr, ddlClient.SelectedValue);
        }
    }

    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlClient = (DropDownList)sender;

        shipmentTable.Rows[0]["client"] = ddlClient.SelectedValue;
        StayOnStep3();
    }

    private void SetRecipientFields()
    {
        ((TextBox)dvShipping_payment.FindControl("txtAccNum")).Text = shipmentTable.Rows[0]["account_no"].ToString();
        ((TextBox)dvShipping_payment.FindControl("txtTpShipFrom")).Text = shipmentTable.Rows[0]["sf_cname"].ToString();
        ((TextBox)dvShipping_payment.FindControl("txtTpBillTo")).Text = shipmentTable.Rows[0]["company"].ToString().Trim();
        ((TextBox)dvShipping_payment.FindControl("txtCountryCode")).Text = shipmentTable.Rows[0]["country"].ToString().Trim();
        ((TextBox)dvShipping_payment.FindControl("txtPostCode")).Text = shipmentTable.Rows[0]["postcode"].ToString().Trim();
        ((TextBox)dvShipping_payment.FindControl("txtPoNo")).Text = shipmentTable.Rows[0]["pono"].ToString();

        if (multiView.ActiveViewIndex == 1) // Freight
        {
            ((TextBox)dvShipping_payment.FindControl("txtCity")).Text = shipmentTable.Rows[0]["payorCity"].ToString().Trim();
            ((TextBox)dvShipping_payment.FindControl("txtAddress1")).Text = shipmentTable.Rows[0]["payorAddress1"].ToString().Trim();
            ((TextBox)dvShipping_payment.FindControl("txtAddress2")).Text = shipmentTable.Rows[0]["payorAddress2"].ToString().Trim();
            ((TextBox)dvShipping_payment.FindControl("txtState")).Text = shipmentTable.Rows[0]["payorState"].ToString().Trim();
        }
    }

    private void SetAssociatedFieldVal(DataRow dr, string selectedValue)
    {
        if (string.IsNullOrWhiteSpace(dr["tp_cname"].ToString())) // sender
        {
            shipmentTable.Rows[0]["tp_shipfrom"] = dr["sf_cname"];
            shipmentTable.Rows[0]["payorName"] = dr["sf_cname"];
            shipmentTable.Rows[0]["tp_country"] = dr["sf_country"];
            shipmentTable.Rows[0]["tp_postcode"] = dr["sf_postcode"];
            shipmentTable.Rows[0]["payorCity"] = dr["sf_city"];
            shipmentTable.Rows[0]["payorAddress1"] = dr["sf_address1"];
            shipmentTable.Rows[0]["payorAddress2"] = dr["sf_address2"];
            shipmentTable.Rows[0]["payorState"] = dr["sf_state"];
            shipmentTable.Rows[0]["account_no"] = dr["sf_fdxaccnum"];

            ((TextBox)dvShipping_payment.FindControl("txtTpShipFrom")).Text = dr["sf_cname"].ToString();
            ((TextBox)dvShipping_payment.FindControl("txtTpBillTo")).Text = dr["sf_cname"].ToString().Trim();
            ((TextBox)dvShipping_payment.FindControl("txtCountryCode")).Text = dr["sf_country"].ToString().Trim();
            ((TextBox)dvShipping_payment.FindControl("txtPostCode")).Text = dr["sf_postcode"].ToString().Trim();
        }
        else // third
        {
            shipmentTable.Rows[0]["sf_attention"] = dr["sf_attention"];
            shipmentTable.Rows[0]["tp_shipfrom"] = dr["sf_cname"];
            shipmentTable.Rows[0]["payorName"] = dr["tp_cname"];
            shipmentTable.Rows[0]["tp_country"] = dr["tp_country"];
            shipmentTable.Rows[0]["tp_postcode"] = dr["tp_postcode"];
            shipmentTable.Rows[0]["payorCity"] = dr["tp_city"];
            shipmentTable.Rows[0]["payorAddress1"] = dr["tp_address1"];
            shipmentTable.Rows[0]["payorAddress2"] = dr["tp_address2"];
            shipmentTable.Rows[0]["payorState"] = dr["tp_state"];

            ((TextBox)dvShipping_payment.FindControl("txtTpShipFrom")).Text = dr["sf_cname"].ToString();
            ((TextBox)dvShipping_payment.FindControl("txtTpBillTo")).Text = dr["tp_cname"].ToString().Trim();
            ((TextBox)dvShipping_payment.FindControl("txtCountryCode")).Text = dr["tp_country"].ToString().Trim();
            ((TextBox)dvShipping_payment.FindControl("txtPostCode")).Text = dr["tp_postcode"].ToString().Trim();

            shipmentTable.Rows[0]["account_no"] = dr["tp_fdxaccnum"];
        }

        ((TextBox)dvShipping_payment.FindControl("txtAccNum")).Text = shipmentTable.Rows[0]["account_no"].ToString().Trim();
        ((TextBox)dvShipping_payment.FindControl("txtPoNo")).Text = shipmentTable.Rows[0]["pono"].ToString();

        if (multiView.ActiveViewIndex == 1)
        {
            ((TextBox)dvShipping_payment.FindControl("txtCity")).Text = shipmentTable.Rows[0]["payorCity"].ToString().Trim();
            ((TextBox)dvShipping_payment.FindControl("txtAddress1")).Text = shipmentTable.Rows[0]["payorAddress1"].ToString().Trim();
            ((TextBox)dvShipping_payment.FindControl("txtAddress2")).Text = shipmentTable.Rows[0]["payorAddress2"].ToString().Trim();
            ((TextBox)dvShipping_payment.FindControl("txtState")).Text = shipmentTable.Rows[0]["payorState"].ToString().Trim();
        }
    }

    private void CleanUpPaymentFields()
    {
        shipmentTable.Rows[0]["account_no"] = "";
        shipmentTable.Rows[0]["tp_shipfrom"] = "";
        shipmentTable.Rows[0]["payorName"] = "";
        shipmentTable.Rows[0]["tp_country"] = "";
        shipmentTable.Rows[0]["tp_postcode"] = "";
        shipmentTable.Rows[0]["payorCity"] = "";
        shipmentTable.Rows[0]["payorAddress1"] = "";
        shipmentTable.Rows[0]["payorAddress2"] = "";
        shipmentTable.Rows[0]["payorState"] = "";
        ((TextBox)dvShipping_payment.FindControl("txtAccNum")).Text = "";
        ((TextBox)dvShipping_payment.FindControl("txtTpShipFrom")).Text = "";
        ((TextBox)dvShipping_payment.FindControl("txtTpBillTo")).Text = "";
        ((TextBox)dvShipping_payment.FindControl("txtCountryCode")).Text = "";
        ((TextBox)dvShipping_payment.FindControl("txtPostCode")).Text = "";
        ((TextBox)dvShipping_payment.FindControl("txtCity")).Text = "";
        ((TextBox)dvShipping_payment.FindControl("txtAddress1")).Text = "";
        ((TextBox)dvShipping_payment.FindControl("txtAddress2")).Text = "";
        ((TextBox)dvShipping_payment.FindControl("txtState")).Text = "";
    }

    protected void btnStep3Back_Click(Object sender, EventArgs e)
    {
        //divStep2.Visible = true;
        //divStep3.Visible = false;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_4').toggle(false);$('#expcol_5').toggle(false);$('#expcol_2').toggle(800);", true);
    }

    protected void btnStep3Next_Click(Object sender, EventArgs e)
    {
        bool flag = Step3Evaluation();

        if (flag)
        {
            StayOnStep3();
            return;
        }

        divStep4.Visible = true;
        GoToStep4();
    }

    private bool Step3Evaluation()
    {
        bool flag = false;

        if (shipmentTable.Rows[0]["bill_to"].ToString() == "receiver")
        {
            TextBox txtAccNum = (TextBox)dvShipping_payment.FindControl("txtAccNum");
            if (IsRequired(dvShipping_payment.Rows[2].Cells[1], "account_no", txtAccNum.Text.Trim()))
                flag = true;
            TextBox txtTpShipFrom = (TextBox)dvShipping_payment.FindControl("txtTpShipFrom");
            if (IsRequired(dvShipping_payment.Rows[3].Cells[1], "tp_shipfrom", txtTpShipFrom.Text.Trim()))
                flag = true;

            TextBox txtCountryCode = (TextBox)dvShipping_payment.FindControl("txtCountryCode");
            shipmentTable.Rows[0]["tp_country"] = txtCountryCode.Text.Trim();

            TextBox txtPostCode = (TextBox)dvShipping_payment.FindControl("txtPostCode");
            shipmentTable.Rows[0]["tp_postcode"] = txtPostCode.Text.Trim();

            shipmentTable.Rows[0]["client_display"] = shipmentTable.Rows[0]["company"];
        }
        else
        {
            DropDownList ddlClient = (DropDownList)dvShipping_payment.FindControl("ddlClient");

            shipmentTable.Rows[0]["client_display"] = ddlClient.SelectedItem.Text;

            TextBox txtTpShipFrom = (TextBox)dvShipping_payment.FindControl("txtTpShipFrom");
            if (IsRequired(dvShipping_payment.Rows[3].Cells[1], "tp_shipfrom", txtTpShipFrom.Text.Trim()))
                flag = true;

            if (shipmentTable.Rows[0]["bill_to"].ToString() == "third")
            {
                TextBox txtCountryCode = (TextBox)dvShipping_payment.FindControl("txtCountryCode");
                if (IsRequired(dvShipping_payment.Rows[5].Cells[1], "tp_country", txtCountryCode.Text.Trim()))
                    flag = true;

                TextBox txtPostCode = (TextBox)dvShipping_payment.FindControl("txtPostCode");
                if (IsRequired(dvShipping_payment.Rows[6].Cells[1], "tp_postcode", txtPostCode.Text.Trim()))
                    flag = true;
            }
        }

        TextBox txtTpBillTo = (TextBox)dvShipping_payment.FindControl("txtTpBillTo");
        if (multiView.ActiveViewIndex == 1)
        {
            if (IsRequired(dvShipping_payment.Rows[4].Cells[1], "payorName", txtTpBillTo.Text.Trim()))
                flag = true;
        }
        else shipmentTable.Rows[0]["payorName"] = txtTpBillTo.Text.Trim();

        TextBox txtPoNo = (TextBox)dvShipping_payment.FindControl("txtPoNo");
        if (IsRequired(dvShipping_payment.Rows[11].Cells[1], "pono", txtPoNo.Text.Trim()))
            flag = true;

        shipmentTable.Rows[0]["reference"] = string.Format("{0}_{1}", DateTime.Today.ToString("MM/dd/yyyy"), shipmentTable.Rows[0]["pono"]);

        if (multiView.ActiveViewIndex == 1)
        {
            TextBox payorCity = (TextBox)dvShipping_payment.FindControl("txtCity");
            if (IsRequired(dvShipping_payment.Rows[7].Cells[1], "payorCity", payorCity.Text.Trim()))
                flag = true;

            TextBox payorAddress1 = (TextBox)dvShipping_payment.FindControl("txtAddress1");
            if (IsRequired(dvShipping_payment.Rows[8].Cells[1], "payorAddress1", payorAddress1.Text.Trim()))
                flag = true;

            TextBox payorAddress2 = (TextBox)dvShipping_payment.FindControl("txtAddress2");
            if (IsRequired(dvShipping_payment.Rows[9].Cells[1], "payorAddress2", payorAddress2.Text.Trim()))
                flag = true;

            TextBox payorState = (TextBox)dvShipping_payment.FindControl("txtState");
            shipmentTable.Rows[0]["payorState"] = payorState.Text.Trim();
        }

        return flag;
    }

    #endregion

    #region Step4

    protected void dvConfirm_DataBound(object sender, EventArgs e)
    {
        Label lblSfLocation = (Label)dvConfirm_From.FindControl("lblSfLocation");
        lblSfLocation.Text = string.Format("{0}{1}, {2}, {3} {4}, {5}", shipmentTable.Rows[0]["sf_address1"],
            !string.IsNullOrWhiteSpace(shipmentTable.Rows[0]["sf_address2"].ToString()) ? " " + shipmentTable.Rows[0]["sf_address2"] : "",
            shipmentTable.Rows[0]["sf_city"], shipmentTable.Rows[0]["sf_state"], shipmentTable.Rows[0]["sf_postcode"], shipmentTable.Rows[0]["sf_country"]);

        Label lblLocation = (Label)dvConfirm_To.FindControl("lblLocation");
        lblLocation.Text = string.Format("{0}{1}, {2}, {3} {4}, {5}", shipmentTable.Rows[0]["address1"],
            !string.IsNullOrWhiteSpace(shipmentTable.Rows[0]["address2"].ToString()) ? " " + shipmentTable.Rows[0]["address2"] : "",
            shipmentTable.Rows[0]["city"], shipmentTable.Rows[0]["state"], shipmentTable.Rows[0]["postcode"], shipmentTable.Rows[0]["country"]);
    }

    protected void reviewStep1_Click(Object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_5').toggle(false);$('#expcol_1').toggle(800);", true);
        btnStep1Update.Visible = true;
        btnStep1.Visible = false;
    }

    protected void reviewStep2_Click(Object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_5').toggle(false);$('#expcol_2').toggle(800);", true);
        btnStep2Update.Visible = true;
        btnStep2Next.Visible = false;
    }

    protected void reviewStep3_Click(Object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_5').toggle(false);$('#expcol_3').toggle(800);", true);
        btnStep3Update.Visible = true;
        btnStep3Next.Visible = false;
    }

    protected void btnCreate_Click(Object sender, EventArgs e)
    {
        if (Step1Evaluation()) { StayOnStep1(); return; }
        if (Step2Evaluation()) { StayOnStep2(); return; }
        if (Step3Evaluation()) { StayOnStep3(); return; }

        List<byte[]> labelList = new List<byte[]>();

        labelList = ExecuteFedExShipment();

        div_result.Visible = true;
        BindDataSource();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_4').toggle(false);", true);

        // export labels
        if (labelList.Count > 0)
        {
            // set cookie for stopping loading
            HttpCookie cookie = new HttpCookie("created");
            for (var i = 0; i < packagesTable.Rows.Count; i++)
            {
                DataRow dr = packagesTable.Rows[i];
                cookie[i.ToString()] = string.Format("{0}^{1}^{2}", dr["trackno"], dr["pickupno"], dr["errMsg"]);
            }
            Response.SetCookie(cookie);

            FedExHelper.WriteFileToResponse(HttpContext.Current, labelList[0], string.Format("ShippingLabels_{0}.pdf", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")));
        }
    }

    #endregion

    #region Shipment

    private List<byte[]> ExecuteFedExShipment()
    {
        FedExShippingService client = new FedExShippingService();
        FedExWebServiceRequest request;
        List<Commodity> list = new List<Commodity>();
        List<byte[]> labelList = new List<byte[]>();
        string masterTrackId = "";
        int sequenceNo = 1;
        string payor = shipmentTable.Rows[0]["bill_to"].ToString();

        if (IsInternational())
        {
            list = new List<Commodity>();
            foreach (DataRow dr in packagesTable.Rows)
            {
                if (!string.IsNullOrEmpty(dr["trackno"].ToString())) continue;
                list.Add(FedExHelper.CreateCommodity(Convert.ToDecimal(dr["weight"]), dr["description"].ToString(), Convert.ToDecimal(dr["unit_price"]), dr["partno"].ToString()));
            }
        }

        foreach (DataRow dr in packagesTable.Rows)
        {
            if (!string.IsNullOrEmpty(dr["trackno"].ToString())) continue;

            request = FedExHelper.ProcessRequest(shipmentTable.Rows[0], dr, packagesTable.Rows.Count.ToString(),
                (payor == "sender") ? FedExHelper.PaymentType.SENDER : (payor == "receiver") ? FedExHelper.PaymentType.RECIPIENT : FedExHelper.PaymentType.THIRD_PARTY,
                shipmentTable.Rows[0]["account_no"].ToString());
            request.Commodity = (list.Count > 0) ? list.ToArray() : null;

            request.MasterTrackNo = masterTrackId;
            request.SequenceNumber = sequenceNo.ToString();

            FedExWebServiceResult result = client.GetLabel(request);

            if (result.IsValidated)
            {
                FedExHelper.ShipmentResult label = JsonConvert.DeserializeObject<FedExHelper.ShipmentResult>(result.JsonResult);
                dr["trackno"] = label.TrackNo;
                if (request.Commodity != null)
                {
                    sequenceNo++;
                    if (string.IsNullOrEmpty(masterTrackId))
                        masterTrackId = dr["trackno"].ToString();
                }

                labelList.Add(Convert.FromBase64String(label.Label));
            }
            else
            {
                foreach (string msg in result.ErrorMessages)
                {
                    dr["errMsg"] += msg + " ";
                }
            }
        }

        return labelList;
    }

    protected void gvResult_RowCreated(object sender, EventArgs e)
    {
        gvResult.Columns[3].Visible = multiView.ActiveViewIndex == 1;
    }

    #endregion

    #region Utility Function

    private bool IsInternational()
    {
        return shipmentTable.Rows[0]["country"].ToString() != "US" || (shipmentTable.Rows[0]["country"].ToString() == "US" && shipmentTable.Rows[0]["state"].ToString() == "PR");
    }

    private void BindDataSource()
    {
        dvShipping_from.DataSource = shipmentTable;
        dvShipping_from.DataBind();
        dvShipping_to.DataSource = shipmentTable;
        dvShipping_to.DataBind();
        gvPackages.DataSource = packagesTable;
        gvPackages.DataBind();
        dvShipping_payment.DataSource = shipmentTable;
        dvShipping_payment.DataBind();
        dvConfirm_From.DataSource = shipmentTable;
        dvConfirm_From.DataBind();
        dvConfirm_To.DataSource = shipmentTable;
        dvConfirm_To.DataBind();
        gvReview.DataSource = packagesTable;
        gvReview.DataBind();
        dvConfirm_Payment.DataSource = shipmentTable;
        dvConfirm_Payment.DataBind();
        gvResult.DataSource = packagesTable;
        gvResult.DataBind();
        gvFreight.DataSource = packagesTable;
        gvFreight.DataBind();
    }

    private bool IsRequired(TableCell cell, string field, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            cell.Attributes.Add("class", "required");
            return true;
        }
        else
        {
            shipmentTable.Rows[0][field] = value;
            cell.Attributes.Remove("class");
        }

        return false;
    }

    private void StayOnStep1()
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_4').toggle(false);$('#expcol_5').toggle(false);$('#expcol_1').toggle(true);", true);
    }

    private void StayOnStep2()
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_4').toggle(false);$('#expcol_5').toggle(false);$('#expcol_2').toggle(true);", true);
    }

    private void StayOnStep3()
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_4').toggle(false);$('#expcol_5').toggle(false);$('#expcol_3').toggle(true);", true);
    }

    private void GoToStep4()
    {
        BindDataSource();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_4').toggle(false);$('#expcol_5').toggle(false);$('#expcol_4').toggle(800);", true);
    }

    protected void btnUpdate_Click(Object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "address":
                if (Step1Evaluation()) return;
                break;
            case "package":
                if (gvPackages.EditIndex != -1)
                {
                    StayOnStep2();
                    return;
                }

                if (Step2Evaluation()) return;
                break;
            case "payment":
                if (Step3Evaluation()) return;
                break;
        }

        GoToStep4();
    }

    private void CleanUpCookie()
    {
        HttpCookie cookie = Request.Cookies["created"];
        if (cookie != null)
        {
            cookie.Value = "";
            Response.SetCookie(cookie);
        }
    }

    private void DisplayPayorFields()
    {
        if (multiView.ActiveViewIndex == 1)
        {
            dvShipping_payment.Fields[4].HeaderText = "*Bill To:";
            dvShipping_payment.Fields[7].Visible = true;
            dvShipping_payment.Fields[8].Visible = true;
            dvShipping_payment.Fields[9].Visible = true;
            dvShipping_payment.Fields[10].Visible = true;
        }
        else
        {
            dvShipping_payment.Fields[4].HeaderText = "Bill To:";
            dvShipping_payment.Fields[7].Visible = false;
            dvShipping_payment.Fields[8].Visible = false;
            dvShipping_payment.Fields[9].Visible = false;
            dvShipping_payment.Fields[10].Visible = false;
        }
    }

    #endregion

    protected void btnNew_Click(object sender, EventArgs e)
    {
        foreach (DataRow dr in packagesTable.Rows)
        {
            dr["trackno"] = "";
            dr["pickupno"] = "";
        }

        divStep4.Visible = false;
        div_result.Visible = false;
        BindDataSource();
        StayOnStep1();
        CleanUpCookie();
    }

    protected void btnFake_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["created"];
        if (cookie != null)
        {
            for (var i = 0; i < packagesTable.Rows.Count; i++)
            {
                DataRow dr = packagesTable.Rows[i];
                string[] result = cookie[i.ToString()].Split('^');
                dr["trackno"] = result[0];
                dr["pickupno"] = result[1];
                dr["errMsg"] = result[2];
            }
        }

        div_result.Visible = true;
        BindDataSource();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CollapseExpand", "$('#expcol_1').toggle(false);$('#expcol_2').toggle(false);" +
            "$('#expcol_3').toggle(false);$('#expcol_4').toggle(false);", true);
    }
}