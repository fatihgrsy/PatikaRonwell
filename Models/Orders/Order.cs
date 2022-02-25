namespace Models.Orders
{
    public class Order
    {
        public int Id { get; set; } // update delete select
        public int CustomerId { get; set; }
        public int PriceTagId { get; set; }
        public int ProductId { get; set; }
       
        // 1 10 20 2 3 1 
    }
}
