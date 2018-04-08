using Microsoft.EntityFrameworkCore;
using STDAL.EF;
using STDAL.Entities;
using STDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDAL.Repositories
{
    public class EmployeeGroupRepository : BaseRepository<EmployeeGroup>, IRepository<EmployeeGroup>
    {
        public EmployeeGroupRepository(STDBContext context)
        {
            Context = context;
            Table = Context.EmployeeGroup;
        }

        public IEnumerable<EmployeeGroup> Find(Func<EmployeeGroup, bool> predicate)
            => Context.EmployeeGroup.Where(predicate).ToList();
    }
}
