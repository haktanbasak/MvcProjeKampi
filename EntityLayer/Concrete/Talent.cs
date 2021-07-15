using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Talent
    {
        [Key]
        public int TalentID { get; set; }
        public int AdminID { get; set; }

        [StringLength(100)]
        public string TalentName { get; set; }
        public int TalentPercent { get; set; }
    }
}
