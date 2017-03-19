namespace Checkout.Model
{
    public class ItemPrice
    {
        public string SKU { get; set; }

        public decimal UnitPrice { get; set; }

        #region Multiple Price Deal
        public int? Threshold { get; set; }

        public decimal GroupPrice { get; set; }

        #endregion

    }
}