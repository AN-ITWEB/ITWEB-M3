using System.Collections.Generic;

namespace ITWEB_M3.Models
{
    public class ComponentTypeViewModel2
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
        public ICollection<Category> Category { get; protected set; }

        public ComponentTypeViewModel2()
        {
            Components = new List<Component>();
        }


        public static ComponentTypeViewModel2 ParseToComponent(ComponentTypeViewModel componentTypeViewModel, List<Category> category)
        {
            return new ComponentTypeViewModel2
            {
                ComponentTypeId = componentTypeViewModel.ComponentTypeId,
                Components = componentTypeViewModel.Components,
                Status = componentTypeViewModel.Status,
                ComponentName = componentTypeViewModel.ComponentName,
                AdminComment = componentTypeViewModel.AdminComment,
                Category = category,
                ComponentInfo = componentTypeViewModel.ComponentInfo,
                Datasheet = componentTypeViewModel.Datasheet,
                Image = componentTypeViewModel.Image,
                ImageUrl = componentTypeViewModel.ImageUrl,
                Location = componentTypeViewModel.Location,
                Manufacturer = componentTypeViewModel.Manufacturer,
                WikiLink = componentTypeViewModel.WikiLink

            };
        }
    }
}
