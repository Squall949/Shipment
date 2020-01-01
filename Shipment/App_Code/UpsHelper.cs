using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class UpsHelper
{
    public enum PaymentType
    {
        SENDER = 1,
        RECIPIENT = 2,
        THIRD_PARTY = 3
    }

    public class labelRequest
    {
        public int id_num { get; set; }
        public int? itemno { get; set; }
        public string country { get; set; }
        public string podate { get; set; }
        public string paydate { get; set; }
        public string cname { get; set; }
        public int? cname_id { get; set; }
        public string filename { get; set; }
        public int? filename_id { get; set; }
        public string description { get; set; }
        public string ebayno { get; set; }
        public string buyid { get; set; }
        public string address { get; set; }
        public string address1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public int qty { get; set; }
        public int? qtyInv { get; set; }
        public int? qtyExt { get; set; }
        public int? qtyOn { get; set; }
        public int? qtyShp { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string upsservice { get; set; }
        public decimal? weight { get; set; }
        public int? length { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public string package { get; set; }
        public int? valuess { get; set; }
        public string shipper { get; set; }
        public string paymethod { get; set; }
        public string billingopt { get; set; }
        public string upsdate { get; set; }
        public string qvnoption { get; set; }
        public string qvnsubline { get; set; }
        public string qvnfailede { get; set; }
        public string qvnfore { get; set; }
        public string auction { get; set; }
        public string shipperTel { get; set; }
        public string PickslipID { get; set; }
        public string loc { get; set; }
        public string imgFormat { get; set; }
        public byte[] shpLbl { get; set; }
        public string Reasons { get; set; }
        public string DateShipped { get; set; }
        public string operator1 { get; set; }
        public string op_date { get; set; }
        public string notes { get; set; }
        public string dropship { get; set; }
        public string combo { get; set; }
        public string transfer_flag { get; set; }
        public Int64 batch_num { get; set; }
        public string shipping_carrier { get; set; }
        public string WarehouseCode { get; set; }
        public int? WarehouseID { get; set; }
        public string Send { get; set; }
        public string sfName { get; set; }
        public string sfAttention { get; set; }
        public string sfAddressLine { get; set; }
        public string sfAddressLine1 { get; set; }
        public string sfCity { get; set; }
        public string sfState { get; set; }
        public string sfPostalCode { get; set; }
        public string sfCountryCode { get; set; }
        public string contactName { get; set; }
        public string serviceCode { get; set; }
        public string reference { get; set; }
        public string recipientAccount { get; set; }
        public string tpAccount { get; set; }
        public string tpPostalCode { get; set; }
        public string tpCountryCode { get; set; }
        public string PayorCity { get; set; }
        public string PayorName { get; set; }
        public string PayorAddress1 { get; set; }
        public string PayorAddress2 { get; set; }
        public string PayorState { get; set; }
        public bool isNotify { get; set; }
        public string notifyEmail { get; set; }
        public string OriginCountryCode { get; set; }
        public package[] packages { get; set; }
        public Product[] products { get; set; }
    }

    public class Product
    {
        public string Description { get; set; }
        public string productCode { get; set; }
        public string CommodityCode { get; set; }
        public string OriginCountryCode { get; set; }
        public string unitNumber { get; set; }
        public string unitValue { get; set; }
        public string uomCode { get; set; }
        public string uomDesc { get; set; }
        public string Weight { get; set; }
        public string uomWeightCode { get; set; }
        public string uomWeightDesc { get; set; }
        public string billingopt { get; set; }
    }

    public class package
    {
        public string uom { get; set; }
        public string Weight { get; set; }
        public string labelHeight { get; set; }
        public string labelWidth { get; set; }
        public string labelImageFormat { get; set; }
        public string insuranceValue { get; set; }
        public string otherValue { get; set; }
        public string otherDesc { get; set; }
        public string packType { get; set; }
        public string ShipmentIdentificationNumber { get; set; }
        public byte[] shippingLabelImg { get; set; }
        public byte[] shippingLabelHtml { get; set; }
        public Dimensions dimensions { get; set; }
        public string FreightPckType { get; set; }
        public string pickupDate { get; set; }
        public string startHour { get; set; }
        public string startMinute { get; set; }
        public string endHour { get; set; }
        public string endMinute { get; set; }

        public package()
        {
            dimensions = new Dimensions();
        }
    }

    public class Dimensions
    {
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string UnitOfMeasurement { get; set; }
    }

    public UpsHelper()
    {
        
    }

    public static string GetUpsServiceTypeDisplayName(string type)
    {
        switch (type)
        {
            case "2DA":
                return "2nd Day Air";
            case "2DM":
                return "2nd Day Air AM";
            case "3DS":
                return "3 Day Select";
            case "1DA":
                return "Next Day Air";
            case "1DM":
                return "Next Day Air Early AM";
            case "1DP":
                return "Next Day Air Saver";
            case "ST":
                return "Standard";
            case "EX":
                return "Worldwide Expedited";
            case "ES":
                return "Worldwide Express";
            case "EP":
                return "Worldwide Express Plus";
            case "SV":
                return "Worldwide Saver (Express)";
            default:
                return "Ground";
        }
    }

    public static labelRequest ProcessRequest(DataRow dr, PaymentType type, string accnum = "")
    {
        labelRequest request = new labelRequest();

        request.sfName = !string.IsNullOrWhiteSpace(dr["sf_cname"].ToString()) ? dr["sf_cname"].ToString().Trim() : string.Empty;
        request.sfAttention = !string.IsNullOrWhiteSpace(dr["sf_attention"].ToString()) ? dr["sf_attention"].ToString().Trim() : "";
        request.shipperTel = !string.IsNullOrWhiteSpace(dr["sf_tel"].ToString()) ? dr["sf_tel"].ToString().Trim() : string.Empty;
        request.shipper = "";
        request.sfAddressLine = dr["sf_address1"].ToString().Trim();
        request.sfAddressLine1 = !string.IsNullOrWhiteSpace(dr["sf_address2"].ToString()) ? dr["sf_address2"].ToString().Trim() : string.Empty;
        request.sfCity = dr["sf_city"].ToString().Trim();
        request.sfState = dr["sf_state"].ToString().Trim();
        request.sfPostalCode = dr["sf_postcode"].ToString().Trim();
        request.sfCountryCode = GetCountryCode(dr["sf_country"].ToString().Trim());
        request.email = dr["emailfail"].ToString().Trim();

        switch (type)
        {
            case PaymentType.SENDER:
                break;
            case PaymentType.RECIPIENT:
                request.recipientAccount = accnum;
                break;
            case PaymentType.THIRD_PARTY:
                request.tpAccount = accnum;
                break;
        }
        
        if (dr.Table.Columns.Contains("tp_postcode"))
            request.tpPostalCode = dr["tp_postcode"].ToString().Trim();
        if (dr.Table.Columns.Contains("tp_country"))
            request.tpCountryCode = GetCountryCode(dr["tp_country"].ToString().Trim());
        if (dr.Table.Columns.Contains("payorCity"))
            request.PayorCity = dr["payorCity"].ToString().Trim();
        if (dr.Table.Columns.Contains("payorName"))
            request.PayorName = dr["payorName"].ToString().Trim();
        if (dr.Table.Columns.Contains("payorAddress1"))
            request.PayorAddress1 = dr["payorAddress1"].ToString().Trim();
        if (dr.Table.Columns.Contains("payorAddress2"))
            request.PayorAddress2 = !string.IsNullOrWhiteSpace(dr["payorAddress2"].ToString()) ? dr["payorAddress2"].ToString().Trim() : string.Empty;
        if (dr.Table.Columns.Contains("payorState"))
            request.PayorState = dr["payorState"].ToString().Trim();

        request.cname = !string.IsNullOrWhiteSpace(dr["company"].ToString()) ? dr["company"].ToString().Trim() :
            !string.IsNullOrWhiteSpace(dr["cname"].ToString()) ? dr["cname"].ToString().Trim() : string.Empty;
        request.contactName = dr["cname"].ToString().Trim();
        request.tel = !string.IsNullOrWhiteSpace(dr["tel"].ToString()) ? dr["tel"].ToString().Trim() : string.Empty;
        request.notifyEmail = !string.IsNullOrWhiteSpace(dr["email"].ToString()) ? dr["email"].ToString().Trim() : string.Empty;
        request.isNotify = Convert.ToBoolean(dr["isemail"]);
        request.address = dr["address1"].ToString().Trim();
        request.address1 = !string.IsNullOrWhiteSpace(dr["address2"].ToString()) ? dr["address2"].ToString().Trim() : string.Empty;
        request.city = dr["city"].ToString().Trim();
        request.state = dr["state"].ToString().Trim();
        request.postcode = dr["postcode"].ToString().Trim();
        request.country = dr["country"].ToString().Trim();
        request.podate = DateTime.Today.ToString("MM/dd/yyyy");
        request.ebayno = !string.IsNullOrWhiteSpace(dr["pono"].ToString()) ? dr["pono"].ToString().Trim() : string.Empty;

        request.WarehouseID = 1;
        request.reference = dr["reference"].ToString();
        request.PickslipID = request.reference;

        return request;
    }

    public static string GetCountryCode(string country)
    {
        if (string.IsNullOrWhiteSpace(country)) return "";

        switch (country.ToUpper())
        {
            case "UNITED STATES":
                return "US";
            case "CANADA":
                return "CA";
            default:
                return country;
        }
    }

    public static string GetServiceCode(string code)
    {
        switch (code)
        {
            case "2DA":
                return "02";
            case "2DM":
                return "59";
            case "3DS":
                return "12";
            case "1DA":
                return "01";
            case "1DM":
                return "14";
            case "1DP":
                return "13";
            case "ST":
                return "11";
            case "EX":
                return "08";
            case "ES":
                return "07";
            case "EP":
                return "54";
            case "SV":
                return "65";
            default:
                return "03";
        }
    }

    public static Product CreateProduct(DataRow dtRow)
    {
        Product prd = new Product();
        prd.productCode = !string.IsNullOrWhiteSpace(dtRow["partno"].ToString()) ? dtRow["partno"].ToString().Trim() : string.Empty;
        prd.CommodityCode = DateTime.Today.ToString("MMddyyyy") + "UPSAPI";
        prd.Description = !string.IsNullOrWhiteSpace(dtRow["description"].ToString()) ? dtRow["description"].ToString().Trim() : string.Empty;
        prd.OriginCountryCode = "TW";
        prd.uomCode = "Box";
        prd.uomDesc = "Box";
        prd.unitNumber = "1";
        prd.unitValue = string.IsNullOrWhiteSpace(dtRow["unit_price"].ToString()) ? "99" : dtRow["unit_price"].ToString();
        prd.uomWeightCode = "LBS";
        prd.uomWeightDesc = "LBS";
        prd.Weight = dtRow["weight"].ToString();
        if (dtRow.Table.Columns.Contains("FreightBilling"))
            prd.billingopt = dtRow["FreightBilling"].ToString().Trim();

        return prd;
    }

    public static package CreatePackage(DataRow dtRow)
    {
        package pck = new package();
        pck.insuranceValue = "99";
        pck.Weight = dtRow["weight"].ToString();
        pck.packType = "02";
        pck.labelImageFormat = "PNG";
        pck.otherDesc = dtRow["partno"].ToString();
        pck.otherValue = "0";
        pck.ShipmentIdentificationNumber = dtRow["id_num"].ToString(); ;
        pck.uom = "LBS";
        pck.labelWidth = "4";
        pck.labelHeight = "6";
        Dimensions dim = new Dimensions();
        dim.Length = dtRow["length"].ToString();
        dim.Width = dtRow["width"].ToString();
        dim.Height = dtRow["height"].ToString();
        dim.UnitOfMeasurement = "IN";
        pck.dimensions = dim;
        if (dtRow.Table.Columns.Contains("FreightPckType"))
            pck.FreightPckType = dtRow["FreightPckType"].ToString();
        if (dtRow.Table.Columns.Contains("pickupDate"))
            pck.pickupDate = Convert.ToDateTime(dtRow["pickupDate"]).ToString("yyyyMMdd");
        if (dtRow.Table.Columns.Contains("startHour"))
            pck.startHour = dtRow["startHour"].ToString();
        if (dtRow.Table.Columns.Contains("startMinute"))
            pck.startMinute = dtRow["startMinute"].ToString();
        if (dtRow.Table.Columns.Contains("endHour"))
            pck.endHour = dtRow["endHour"].ToString();
        if (dtRow.Table.Columns.Contains("endMinute"))
            pck.endMinute = dtRow["endMinute"].ToString();

        return pck;
    }

    public static string GetBillingOptionText(string value)
    {
        switch (value)
        {
            case "10":
                return "Prepaid";
            case "30":
                return "Bill to Third Party";
            case "40":
                return "Collect";
        }

        return value;
    }

    public static string GetPackagingTypeText(string value)
    {
        switch (value)
        {
            case "CRT":
                return "Crate";
            case "BAG":
                return "Bag";
            case "BAL":
                return "Bale";
            case "BAR":
                return "Barrel";
            case "BDL":
                return "Bundle";
            case "BIN":
                return "Bin";
            case "BOX":
                return "Box";
            case "BSK":
                return "Basket";
            case "BUN":
                return "Bunch";
            case "CAB":
                return "Cabinet";
            case "CAN":
                return "Can";
            case "CAR":
                return "Carrier";
            case "CAS":
                return "Case";
            case "CBY":
                return "Carboy";
            case "CON":
                return "Container";
            case "CSK":
                return "Cask";
            case "CTN":
                return "Carton";
            case "CYL":
                return "Cylinder";
            case "DRM":
                return "Drum";
            case "LOO":
                return "Loose";
            case "OTH":
                return "Other";
            case "PAL":
                return "Pail";
            case "PCS":
                return "Pieces";
            case "PKG":
                return "Package";
            case "PLN":
                return "Pipe Line";
            case "PLT":
                return "Pallet";
            case "RCK":
                return "Rack";
            case "REL":
                return "Reel";
            case "ROL":
                return "Roll";
            case "SKD":
                return "Skid";
            case "SPL":
                return "Spool";
            case "TBE":
                return "Tube";
            case "TNK":
                return "Tank";
            case "UNT":
                return "Unit";
            case "VPK":
                return "Van Pack";
            case "WRP":
                return "Wrapped";
        }

        return value;
    }
}