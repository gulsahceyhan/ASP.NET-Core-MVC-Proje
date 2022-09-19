

using EntityLayer.Abstract;

namespace EntityLayer.DTOs
{
    public class ProductDetailDto:IDto
    {
        public int ProductID { get; set; }
        
        public int CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public Int16 UnitsInStock { get; set; }
     
    }


}
