using System.Collections.Generic;

namespace ITWEB_M3.Models
{
    public class Category
    {
        public long CategoryId {get; set;}
        public string Name {get; set;}
        public ICollection<CategoryToComponentType> CategoryToComponentTypes {get; protected set;}

        public Category() 
        {
            CategoryToComponentTypes = new List<CategoryToComponentType>();
        }
    }
}