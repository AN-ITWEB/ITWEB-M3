using System;
using System.Collections.Generic;


namespace ITWEB_M3.ViewModels
{
    public class ComponentTypeCreateVM : ComponentTypeViewModel
    {
        public ComponentTypeCreateVM() : base()
        {
            CategoryIDs = new List<Int64>();
        }

        public IEnumerable<Int64> CategoryIDs { get; set; }
    }
}
