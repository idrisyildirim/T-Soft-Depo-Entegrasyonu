using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Soft.T_Soft
{
    public class Rootobject
    {
        public bool success { get; set; }
        public Datum[] data { get; set; }
        public Message[] message { get; set; }
        public Summary summary { get; set; }
    }

    public class Summary
    {
        public string totalRecordCount { get; set; }
        public string primaryKey { get; set; }
    }

    public class Datum
    {
        //public string OrderId { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
       // public string OrderDateTimeStamp { get; set; }
       // public DateTime UpdateDate { get; set; }
       // public string UpdateDateTimeStamp { get; set; }
       // public string OrderStatusId { get; set; }
       // public string OrderTotalPrice { get; set; }
       // public string OrderSubtotal { get; set; }
       // public string DiscountTotal { get; set; }
       // public string TaxTotal { get; set; }
       // public string Currency { get; set; }
       // public string SiteDefaultCurrency { get; set; }
        //public string Language { get; set; }
        //public string ExchangeRate { get; set; }
        //public string CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerUsername { get; set; }
        // public string CustomerGroupId { get; set; }
        //public string PaymentTypeId { get; set; }
        // public string PaymentType { get; set; }
        // public string Bank { get; set; }
        //public string BankTransactionVendor { get; set; }
        //public string CCBank { get; set; }
        // public string Installment { get; set; }
        //public string PaymentInfo { get; set; }
        // public string CargoTrackingCode { get; set; }
        //public string CargoId { get; set; }
        //public string CargoCode { get; set; }
        //public string Cargo { get; set; }
        //public string CargoPaymentMethod { get; set; }
        public string CustomerName { get; set; }
        //public string CustomerPhone { get; set; }
        //public string ServiceName { get; set; }
        //public int ServiceChargeWithoutVat { get; set; }
        //public int ServiceChargeWithVat { get; set; }
        //public string ServiceVatPercent { get; set; }
        //public object CargoChargeWithoutVat { get; set; }
        //public object CargoChargeWithVat { get; set; }
        //public object CargoChargeWithoutDiscount { get; set; }
        //public string CargoVatPercent { get; set; }
        //public string RepresentativeCode { get; set; }
        //public string RepresentativeName { get; set; }
        //public string Application { get; set; }
        //public string WsOrderNumber { get; set; }
        //public string CampaignIds { get; set; }
        //public string CampaignDetail { get; set; }
        //public string ApproveType { get; set; }
        //public string CustomerIp { get; set; }
        //public string NonMemberShopping { get; set; }
        //public string HopiCoin { get; set; }
        //public string IsTransferred { get; set; }
        //public string TransactionId { get; set; }
        //public string ShipmentTime { get; set; }
        //public string ShipmentDeliveryTime { get; set; }
        //public string DutyServiceRate { get; set; }
        //public string DutyServiceTotal { get; set; }
        //public string GeneralOrderNote { get; set; }
        //public string VoucherCode { get; set; }
        //public string VoucherDiscountType { get; set; }
        //public string VoucherDiscountValue { get; set; }
        public string OrderStatus { get; set; }
        //public string OrderStatusTranslated { get; set; }
        //public string InvoiceAddressId { get; set; }
        //public string CustomerInvoiceAdressId { get; set; }
        //public int InvoiceType { get; set; }
        //public string InvoiceName { get; set; }
        public string InvoiceCompany { get; set; }
        public string InvoiceTaxdep { get; set; }
        public string InvoiceTaxno { get; set; }
        public string InvoiceMobile { get; set; }
        public string InvoiceTel { get; set; }
        // public string InvoiceOtherPhone { get; set; }
        public string InvoiceAddress { get; set; }
        public string InvoiceCity { get; set; }
        //public string InvoiceCityCode { get; set; }
        public string InvoiceTown { get; set; }
        //public string InvoiceTownCode { get; set; }
        //public string InvoiceNeighbourhood { get; set; }
        public string Invoice_country { get; set; }
        //public string InvoiceCountryCode { get; set; }
        //public string InvoiceZipcode { get; set; }
        //public bool HasEInvoice { get; set; }
        // public string DeliveryAddressId { get; set; }
        // public string CustomerDeliveryAdressId { get; set; }
        //public string DeliveryName { get; set; }
        //public string DeliveryMobile { get; set; }
        //public string DeliveryTel { get; set; }
        //public string DeliveryAddress { get; set; }
        //public string DeliveryCity { get; set; }
        //public string DeliveryCityCode { get; set; }
        //public string DeliveryTown { get; set; }
        //public string DeliveryTownCode { get; set; }
        //public string DeliveryNeighbourhood { get; set; }
        //public string DeliveryCountry { get; set; }
        //public string DeliveryCountryCode { get; set; }
        //public string DeliveryZipcode { get; set; }
        //public string HopiProvisionId { get; set; }
        //public int HopiUsed { get; set; }
        //public string CargoServiceName { get; set; }
        public Orderdetail[] OrderDetails { get; set; }
    }

    public class Orderdetail
    {
        public string OrderProductId { get; set; }
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string StockUnit { get; set; }
        public string StockUnitId { get; set; }
        public string BuyingPrice { get; set; }
        public string Vat { get; set; }
        public string SellingCurrency { get; set; }
        public string SellingCartPrice { get; set; }
        public string SellingPriceWithoutDiscount { get; set; }
        public string SellingPriceWithoutVat { get; set; }
        public string SellingPrice { get; set; }
        public string SellingCurrencyExchangeRate { get; set; }
        public string Barcode { get; set; }
        public string Brand { get; set; }
        public string DefaultCategoryId { get; set; }
        public string SubProductId { get; set; }
        public string SubProductCode { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Personalization { get; set; }
        public string OrderNote { get; set; }
        public string ImageUrl { get; set; }
        public string GiftPackage { get; set; }
        public string GiftNote { get; set; }
        public string PostStatus { get; set; }
        public string PostNote { get; set; }
        public string SupplyStatus { get; set; }
        public string SupplyNote { get; set; }
        public string OwnerId { get; set; }
        public string IsPackage { get; set; }
        public string Supplier { get; set; }
        public string SupplierProductCode { get; set; }
        public string RefundCount { get; set; }
        public string ImageUrlBig { get; set; }
        public float DiscountPercent { get; set; }
    }

    public class Message
    {
        public object type { get; set; }
        public object code { get; set; }
        public int index { get; set; }
        public string id { get; set; }
        public string subid { get; set; }
        public object[] text { get; set; }
        public object[] errorField { get; set; }
    }


}

