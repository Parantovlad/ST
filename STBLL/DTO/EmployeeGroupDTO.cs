using System;
using System.Collections.Generic;
using System.Text;

namespace STBLL.DTO
{
    public class EmployeeGroupDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<StaffDTO> Staff { get; set; }
    }
}
