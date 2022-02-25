

using Models.BaseModels;

namespace Models.Customers
{

    public class Customer: BaseModel
    {
        public string NameSurname { get; set; }
        public int Age { get; set; }
        public long GSMNumber { get; set; }
        public string EMail { get; set; }

        public string City { get; set; }
        public string Distirict { get; set; }

        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
    }
}
