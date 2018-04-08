using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STWEB.Models
{
    public class StaffViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateWork { get; set; }
        public long EmployeeGroupId { get; set; }
        public double? BasicSalary { get; set; }
        public double? FullSalary { get; set; }
    }
}
