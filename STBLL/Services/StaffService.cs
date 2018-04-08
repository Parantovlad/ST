using AutoMapper;
using STBLL.DTO;
using STBLL.Infrastructure;
using STBLL.Interfaces;
using STDAL.Entities;
using STDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace STBLL.Services
{
    public class StaffService : IStaffService
    {
        IUnitOfWork Database { get; set; }

        public StaffService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddStaff(StaffDTO staffDTO)
        {
            Staff staff = new Staff
            {
                Name = staffDTO.Name,
                DateWork = (long)ConvertToUnixTimestamp(DateTime.Now),
                EmployeeGroupId = staffDTO.EmployeeGroupId,
                BasicSalary = staffDTO.BasicSalary
            };
            Database.Staffs.Create(staff);
            Database.Save();
        }

        public IEnumerable<StaffDTO> GetStaffs(DateTime date)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Staff, StaffDTO>()
                .ForMember(dest => dest.DateWork, opt => opt.MapFrom(staff => ConvertFromUnixTimestamp(staff.DateWork))));
            var mapper = config.CreateMapper();
            var staffs = Database.Staffs.Find(staff => staff.DateWork <= ConvertToUnixTimestamp(date));

            return mapper.Map<IEnumerable<Staff>, List<StaffDTO>>(staffs);
        }

        public StaffDTO GetStaff(int? id)
        {
            if(id == null)
                throw new ValidationException("Не установлено id сотрудника", "");

            var staff = Database.Staffs.Get(id.Value);
            if(staff == null)
                throw new ValidationException("Сотрудник не найден", "");

            return new StaffDTO
            {
                Name = staff.Name,
                DateWork = ConvertFromUnixTimestamp(staff.DateWork),
                EmployeeGroupId = staff.EmployeeGroupId,
                BasicSalary = staff.BasicSalary
            };
        }

        private DateTime ConvertFromUnixTimestamp(double date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(date);
        }
        private double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
