using System.Collections.Generic;

public class Category
{
    public Category()
    {
        ComponentTypeCategory = new List<ComponentTypeCategory>();
    }

    public long CategoryId { get; set; }
    public string Name {get; set;}
    public ICollection<ComponentTypeCategory> ComponentTypeCategory { get; protected set; }

}