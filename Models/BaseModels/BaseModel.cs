using System;

namespace Models.BaseModels
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool ModelState { get; set; } = true;
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
    
    
