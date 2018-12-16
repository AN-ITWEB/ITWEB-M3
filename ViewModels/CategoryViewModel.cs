using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITWEB_M3.Models;

namespace ITWEB_M3.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            ComponentTypes = new List<ComponentTypeViewModel>();
        }
        public Int64 Id { get; set; }

        public string Name { get; set; }
        public ICollection<ComponentTypeViewModel> ComponentTypes { get; protected set; }
    }
}
