using STDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Staff> Staffs { get; }
        IRepository<EmployeeGroup> EmployeeGroups { get; }
        IRepository<SubmissionRelations> SubmissionRelations { get; }
        void Save();
    }
}
