using STBLL.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace STBLL.DTO
{
    public class StaffDTO
    {
        private double? salary => new Salary(this, DateTime.Now).GetFullSalary();

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateWork { get; set; }        
        public long EmployeeGroupId { get; set; }
        public double? BasicSalary { get; set; }
        public double? FullSalary
        {
            get
            {
                return salary;
            }
        }

        public EmployeeGroupDTO EmployeeGroup { get; set; }
        public ICollection<SubmissionRelationsDTO> SubmissionRelationsChief { get; set; }
        public ICollection<SubmissionRelationsDTO> SubmissionRelationsSubordinate { get; set; }

        
    }
}
