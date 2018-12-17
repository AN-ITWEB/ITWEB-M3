using System;
using System.Collections.Generic;
using System.Linq;

namespace ITWEB_M3.Models
{
    public class ComponentTypeViewModel
    {
        public long ComponentTypeId { get; set; }
        public string ComponentName { get; set; }
        public string ComponentInfo { get; set; }
        public string Location { get; set; }
        public ComponentTypeStatus Status { get; set; }
        public string Datasheet { get; set; }
        public string ImageUrl { get; set; }
        public string Manufacturer { get; set; }
        public string WikiLink { get; set; }
        public string AdminComment { get; set; }
        public virtual ESImage Image { get; set; }
        public ICollection<Component> Components { get; protected set; }
        public IEnumerable<long> CategoryIds { get; protected set; }

        public ComponentTypeViewModel()
        {
            Components = new List<Component>();
            CategoryIds = new List<long>();
        }

        public static ComponentTypeViewModel ParseToComponentViewModel(ComponentType componentType, List<Category> category)
        {
            return new ComponentTypeViewModel
            {
                ComponentTypeId = componentType.ComponentTypeId,
                Components = componentType.Components,
                Status = componentType.Status,
                ComponentName = componentType.ComponentName,
                AdminComment = componentType.AdminComment,
                CategoryIds = category.Select(x => x.CategoryId).ToList(),
                ComponentInfo = componentType.ComponentInfo,
                Datasheet = componentType.Datasheet,
                Image = componentType.Image,
                ImageUrl = componentType.ImageUrl,
                Location = componentType.Location,
                Manufacturer = componentType.Manufacturer,
                WikiLink = componentType.WikiLink

            };
        }
    }
}
