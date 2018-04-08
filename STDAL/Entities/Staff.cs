using System;
using System.Collections.Generic;

namespace STDAL.Entities
{
    public partial class Staff
    {
        public Staff()
        {
            SubmissionRelationsChief = new HashSet<SubmissionRelations>();
            SubmissionRelationsSubordinate = new HashSet<SubmissionRelations>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long DateWork { get; set; }
        public long EmployeeGroupId { get; set; }
        public double? BasicSalary { get; set; }

        public EmployeeGroup EmployeeGroup { get; set; }
        public ICollection<SubmissionRelations> SubmissionRelationsChief { get; set; }
        public ICollection<SubmissionRelations> SubmissionRelationsSubordinate { get; set; }
    }
}
