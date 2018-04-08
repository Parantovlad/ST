using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using STBLL.BusinessModels;
using STBLL.DTO;
using STBLL.Infrastructure;
using STBLL.Interfaces;
using STWEB.Models;

namespace STWEB.Controllers
{
    public class HomeController : Controller
    {
        IStaffService staffService;
        public HomeController(IStaffService service)
        {
            staffService = service;
        }

        public IActionResult Index()
        {
            return Index(DateTime.Now);
        }

        [HttpPost]
        public IActionResult Index(DateTime date)
        {
            IEnumerable<StaffDTO> staffDTOs = staffService.GetStaffs(date);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StaffDTO, StaffViewModel>()
                .ForMember(dest => dest.FullSalary, opt => opt.MapFrom(staffDTO => new Salary(staffDTO, date).GetFullSalary())));
            var mapper = config.CreateMapper();
            var staffs = mapper.Map<IEnumerable<StaffDTO>, List<StaffViewModel>>(staffDTOs);

            double totalSalary = 0;
            foreach(var staff in staffs)
            {
                totalSalary += staff.FullSalary ?? 0;
            }
            ViewData["TotalSalary"] = totalSalary;

            return View(staffs);
        }

        public IActionResult AddStaff()
        {
            //Данный список неоходимо брать из базы данных
            IEnumerable<EmployeeGroupViewModel> employeeGroups = new List<EmployeeGroupViewModel>
            {
                new EmployeeGroupViewModel {Id=1,Name="Employee"},
                new EmployeeGroupViewModel {Id=2,Name="Manager"},
                new EmployeeGroupViewModel {Id=3,Name="Salesman"}
            };
            ViewData["EmployeeGroup"] = new SelectList(employeeGroups, "Id", "Name");

            StaffViewModel staff = new StaffViewModel();
            return View(staff);
        }

        [HttpPost]
        public IActionResult AddStaff(StaffViewModel staff)
        {
            try
            {
                var staffDTO = new StaffDTO
                {
                    Name = staff.Name,
                    DateWork = staff.DateWork,
                    EmployeeGroupId = staff.EmployeeGroupId,
                    BasicSalary = staff.BasicSalary
                };
                staffService.AddStaff(staffDTO);
                return RedirectToAction("Index");
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(staff);
        }

        protected override void Dispose(bool disposing)
        {
            staffService.Dispose();
            base.Dispose(disposing);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
