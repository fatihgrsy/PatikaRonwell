using System;

namespace Models.CustomerCarts
{
    public class CustomerCart
    {
        public int Id { get; set; }
        public int UnderCategoryId { get; set; }
        public DateTime InsertDate { get; set; }// 30 dakika boyunca rezerve ettik
        
        // sepetimizi şua an ki zaman - eklenme zamanı = 30 dakikadan büyükse ürünü serbest bırak 
    }
}
