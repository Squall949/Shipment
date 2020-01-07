using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.Services.Protocols;
using System.Net;
using FedExShippingWCF;
using FedExShippingWCF.FedExShipService;
using System.Globalization;

/// <summary>
/// FedEx API Utility
/// </summary>
public class FedExHelper
{
    public class ShipmentResult
    {
        public string TrackNo { get; set; }
        public string Label { get; set; }
    }

    public enum PaymentType
    {
        SENDER = 1,
        RECIPIENT = 2,
        THIRD_PARTY = 3
    }

    public FedExHelper()
    {
    }

    #region Shipment

    public static TrackingIdType GetTrackingIdType(ShippingServiceType shippingType)
    {
        switch (shippingType)
        {
            case ShippingServiceType.FEDEX_GROUND:
            case ShippingServiceType.GROUND_HOME_DELIVERY:
                return TrackingIdType.GROUND;
            case ShippingServiceType.FEDEX_EXPRESS_SAVER:
            case ShippingServiceType.STANDARD_OVERNIGHT:
            case ShippingServiceType.PRIORITY_OVERNIGHT:
            case ShippingServiceType.FEDEX_2_DAY:
            case ShippingServiceType.FEDEX_2_DAY_AM:
            case ShippingServiceType.FEDEX_2_DAY_FREIGHT:
            case ShippingServiceType.FEDEX_3_DAY_FREIGHT:
            case ShippingServiceType.FIRST_OVERNIGHT:
            case ShippingServiceType.INTERNATIONAL_ECONOMY:
            case ShippingServiceType.INTERNATIONAL_ECONOMY_FREIGHT:
            case ShippingServiceType.INTERNATIONAL_PRIORITY_FREIGHT:
                return TrackingIdType.EXPRESS;
            default:
                return TrackingIdType.FEDEX;
        }
    }

    public static FedExWebServiceRequest ProcessRequest(DataRow drShipment, DataRow drPackage, string totalQty, PaymentType type, string accNum = "")
    {
        FedExWebServiceRequest request = new FedExWebServiceRequest();

        switch (type)
        {
            case PaymentType.SENDER:
                request.Bill_to = "1";
                request.ShippingAccNum = accNum;
                break;
            case PaymentType.RECIPIENT:
                request.Bill_to = "2";
                request.RecipientAccNum = accNum;
                break;
            case PaymentType.THIRD_PARTY:
                request.Bill_to = "3";
                request.TpAccNum = accNum;
                break;
        }

        FedExWebServiceContact recipient = new FedExWebServiceContact();
        recipient.Address1 = drShipment["address1"].ToString().Trim();
        recipient.Address2 = string.IsNullOrWhiteSpace(drShipment["address2"].ToString()) ? "" : drShipment["address2"].ToString().Trim();
        recipient.City = drShipment["city"].ToString().Trim();
        recipient.Name = drShipment["cname"].ToString().Trim();
        recipient.Company = drShipment["company"].ToString().Trim();
        recipient.CountryCode = drShipment["country"].ToString().Trim();
        recipient.Email = drShipment["email"].ToString().Trim();
        recipient.Postcode = drShipment["postcode"].ToString().Trim();
        recipient.State = drShipment["state"].ToString().Trim();
        recipient.Tel = drShipment["tel"].ToString().Trim();
        request.Recipient = recipient;

        FedExWebServiceContact shipper = new FedExWebServiceContact();
        shipper.Email = drShipment["emailfail"].ToString().Trim();
        shipper.Address1 = drShipment["sf_address1"].ToString().Trim();
        shipper.Address2 = string.IsNullOrWhiteSpace(drShipment["sf_address2"].ToString()) ? "" : drShipment["sf_address2"].ToString().Trim();
        if (drShipment.Table.Columns.Contains("sf_attention"))
            shipper.Name = string.IsNullOrWhiteSpace(drShipment["sf_attention"].ToString()) ? "" : drShipment["sf_attention"].ToString().Trim();
        shipper.City = drShipment["sf_city"].ToString().Trim();
        shipper.Company = drShipment["sf_cname"].ToString().Trim();
        shipper.CountryCode = drShipment["sf_country"].ToString().Trim();
        shipper.Postcode = drShipment["sf_postcode"].ToString().Trim();
        shipper.State = drShipment["sf_state"].ToString().Trim();
        shipper.Tel = drShipment["sf_tel"].ToString().Trim();
        request.Shipper = shipper;

        request.Length = drPackage["length"].ToString().Trim();
        request.Width = drPackage["width"].ToString().Trim();
        request.Height = drPackage["height"].ToString().Trim();
        request.Weight = Convert.ToDecimal(drPackage["weight"]);
        request.Qty = drPackage["qty"].ToString().Trim();
        request.TotalQty = totalQty;
        request.ServiceType = (ShippingServiceType)Convert.ToInt32(drPackage["service_type_fx"]);
        if (drShipment.Table.Columns.Contains("reference"))
            request.Reference = drShipment["reference"].ToString().Trim();
        if (drShipment.Table.Columns.Contains("pono"))
            request.PoNo = drShipment["pono"].ToString().Trim();
        request.IsEmail = Convert.ToBoolean(drShipment["isemail"]);

        return request;
    }

    public static Commodity CreateCommodity(decimal weight, string description, decimal unit_price, string partno)
    {
        Commodity cmd = new Commodity();
        cmd.NumberOfPieces = "1";
        cmd.CountryOfManufacture = "TW";
        cmd.Weight = new Weight();
        cmd.Weight.Value = weight;
        cmd.Weight.Units = WeightUnits.LB;
        cmd.Description = description;
        cmd.QuantityUnits = "EA";
        cmd.Quantity = 1;
        cmd.QuantitySpecified = true;
        cmd.UnitPrice = new Money();
        cmd.UnitPrice.Currency = "USD";
        cmd.UnitPrice.Amount = unit_price;
        cmd.Purpose = CommodityPurposeType.CONSUMER;
        cmd.PartNumber = partno;

        return cmd;
    }

    public static void WriteFileToResponse(HttpContext context, byte[] bytes, string fileName)
    {

        var bytesLength = bytes.Length.ToString(CultureInfo.InvariantCulture);
        var response = context.Response;
        response.Clear();
        response.Buffer = true;
        response.AddHeader("Content-Length", bytesLength);
        response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
        response.ContentType = "application/pdf";
        response.BinaryWrite(bytes);
        response.Flush();
        response.End();
    }

    #endregion
}