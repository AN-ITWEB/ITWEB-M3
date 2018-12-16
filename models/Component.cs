
namespace ITWEB_M3.Models
{
    public class Component
    {
        public long ComponentId { get; set; }
        public ComponentType ComponentType { get; set; }
        public int ComponentNumber { get; set; }
        public string SerialNo { get; set; }
        public ComponentTypeStatus Status { get; set; }
        public string AdminComment { get; set; }
        public string UserComment { get; set; }
        public long? CurrentLoanInformationId { get; set; }


        public static Component ParseToComponent(ComponentViewModel componentViewModel, ComponentType componentType)
        {
            return new Component
            {
                ComponentType = componentType,
                ComponentId = componentViewModel.ComponentId,
                AdminComment = componentViewModel.AdminComment,
                ComponentNumber = componentViewModel.ComponentNumber,
                CurrentLoanInformationId = componentViewModel.CurrentLoanInformationId,
                SerialNo = componentViewModel.SerialNo,
                Status = componentViewModel.Status,
                UserComment = componentViewModel.UserComment
            };
        }


    }
}