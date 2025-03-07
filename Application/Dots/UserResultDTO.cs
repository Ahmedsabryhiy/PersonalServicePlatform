using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dots
{
    public  class UserResultDTO
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public IEnumerable <string> Errors { get; set; }
    }
}
