using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECDL_Megoldas.Models
{
    public class Vizsgazo
    {
        public int Id { get; set; }
        public string? Nev { get; set; }
        public int VizsgatipusId { get; set; }
        public Vizsgatipus? Vizsgatipus { get; set; }
        public int? Eredmeny { get; set; }
    }
}
