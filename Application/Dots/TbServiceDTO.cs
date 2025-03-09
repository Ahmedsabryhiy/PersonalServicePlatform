using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dots
{
    public class TbServiceDTO : BaseTableDTO
    {

        public int ProviderId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string? Location { get; set; }



       
    }
}
