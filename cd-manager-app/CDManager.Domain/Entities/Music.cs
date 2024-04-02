using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDManager.Domain.Entities
{
    public class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int CDId { get; set; }
        public CDMusic CD { get; set; }
    }
}
