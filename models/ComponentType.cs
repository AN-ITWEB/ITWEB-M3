using System.Collections.Generic;

namespace ITWEB_M3.Models
{
    public class ComponentType
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
        public ICollection<CategoryToComponentType> CategoryToComponentTypes { get; set; }

        public ComponentType()
        {
            Components = new List<Component>();
            CategoryToComponentTypes = new List<CategoryToComponentType>();
        }


        public static ComponentType ParseToComponent(ComponentTypeViewModel componentTypeViewModel, List<CategoryToComponentType> category)
        {
            return new ComponentType
            {
                ComponentTypeId = componentTypeViewModel.ComponentTypeId,
                Components = componentTypeViewModel.Components,
                Status = componentTypeViewModel.Status,
                ComponentName = componentTypeViewModel.ComponentName,
                AdminComment = componentTypeViewModel.AdminComment,
                CategoryToComponentTypes = category,
                ComponentInfo = componentTypeViewModel.ComponentInfo,
                Datasheet = componentTypeViewModel.Datasheet,
                Image = componentTypeViewModel.Image,
                ImageUrl = componentTypeViewModel.ImageUrl,
                Location = componentTypeViewModel.Location,
                Manufacturer = componentTypeViewModel.Manufacturer,
                WikiLink = componentTypeViewModel.WikiLink

            };
        }

        public static void OverWrite(ComponentType componentTypeEF, ComponentType componentType)
        {
            componentTypeEF.ComponentTypeId = componentType.ComponentTypeId;
            componentTypeEF.Components = componentType.Components;
            componentTypeEF.Status = componentType.Status;
            componentTypeEF.ComponentName = componentType.ComponentName;
            componentTypeEF.AdminComment = componentType.AdminComment;
            componentTypeEF.CategoryToComponentTypes = componentType.CategoryToComponentTypes;
            componentTypeEF.ComponentInfo = componentType.ComponentInfo;
            componentTypeEF.Datasheet = componentType.Datasheet;
            componentTypeEF.Image = componentType.Image;
            componentTypeEF.ImageUrl = componentType.ImageUrl;
            componentTypeEF.Location = componentType.Location;
            componentTypeEF.Manufacturer = componentType.Manufacturer;
            componentTypeEF.WikiLink = componentType.WikiLink;
        }
    }
}
