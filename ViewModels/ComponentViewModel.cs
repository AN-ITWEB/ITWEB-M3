using System;
using ITWEB_M3.Models;

namespace ITWEB_M3.ViewModels
{
    public class ComponentViewModel
    {
        public Int64 Id { get; set; }

        public Int64 ComponentTypeId { get; set; }
        public ComponentTypeViewModel ComponentType { get; set; }

        public int ComponentNumber { get; set; }
        public string SerialNo { get; set; }
        public ComponentTypeStatus Status { get; set; }
        public string AdminComment { get; set; }
        public string UserComment { get; set; }
    }
}
