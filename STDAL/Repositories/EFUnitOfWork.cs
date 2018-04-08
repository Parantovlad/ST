using STDAL.EF;
using STDAL.Entities;
using STDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace STDAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private STDBContext context;
        private StaffRepository staffRepository;
        private EmployeeGroupRepository employeeGroupRepository;
        private SubmissionRelationsRepository submissionRelationsRepository;

        public EFUnitOfWork()
        {
            context = new STDBContext();
        }

        public IRepository<Staff> Staffs
        {
            get
            {
                if (staffRepository == null)
                    staffRepository = new StaffRepository(context);
                return staffRepository;
            }
        }

        public IRepository<EmployeeGroup> EmployeeGroups
        {
            get
            {
                if (employeeGroupRepository == null)
                    employeeGroupRepository = new EmployeeGroupRepository(context);
                return employeeGroupRepository;
            }
        }

        public IRepository<SubmissionRelations> SubmissionRelations
        {
            get
            {
                if (submissionRelationsRepository == null)
                    submissionRelationsRepository = new SubmissionRelationsRepository(context);
                return submissionRelationsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }
    }
}
