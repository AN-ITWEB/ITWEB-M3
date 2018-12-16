
namespace ITWEB_M3.Models
{
    public class CategoryToComponentType
    {
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public long ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }
    }
}