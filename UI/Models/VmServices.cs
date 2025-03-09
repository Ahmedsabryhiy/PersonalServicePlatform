using Application.Dots;

namespace UI.Models
{
    public class VmServices
    {
        public List<TbServiceDTO> Services { get; set; }= new List<TbServiceDTO>();
        private List<TbCategoryDTO> Categories { get; set; }= new List<TbCategoryDTO>();
    }
}
