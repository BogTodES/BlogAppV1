using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.Entities.DTOs
{
    public class PosterDto
    {
        public int PosterId { get; set; }
        public string PosterUsername { get; set; }
        public long PostId { get; set; }
    }
}
