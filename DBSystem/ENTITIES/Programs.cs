using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DBSystem.ENTITIES;

namespace DBSystem.ENTITIES
{
    [Table("Programs")]
    public class Programs
    {
        [Key]
        public int ProgramID { get; set; }
        public string ProgramName { get; set; }       
        public string DiplomaName { get; set; }
        public string SchoolCode { get; set; }
        public decimal Tuition { get; set; }
        public decimal InternationalTuition { get; set; }
    }
}
