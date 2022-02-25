namespace Models.Products
{
    public class Product:BaseModels.BaseModel
    {
        public string ProductName { get; set; }
        public int UnderCategoryTypeId { get; set; }

    }
}
