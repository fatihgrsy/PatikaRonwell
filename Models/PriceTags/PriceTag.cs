namespace Models.PriceTags
{
    public class PriceTag
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; } // Kdv Kargo
    }
}
