using System;
using System.Collections.Generic;
using ITWEB_M3.Models;

namespace ITWEB_M3.ViewModels
{
    public class ComponentTypeViewModel
    {
        public ComponentTypeViewModel()
        {
            Components = new List<ComponentViewModel>();
            Categories = new List<CategoryViewModel>();
        }

        public Int64 Id { get; set; }

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
        
        public ICollection<ComponentViewModel> Components { get; set; }
        public ICollection<CategoryViewModel> Categories{ get; set; }
    }
}
