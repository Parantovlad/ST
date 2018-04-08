using System;
using System.Collections.Generic;

namespace STDAL.Entities
{
    public partial class EmployeeGroup
    {
        public EmployeeGroup()
        {
            Staff = new HashSet<Staff>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Staff> Staff { get; set; }
    }
}
