using STBLL.DTO;
using System;

namespace STBLL.BusinessModels
{
    public class Salary
    {
        private StaffDTO staff;
        private double bonus;
        private double maxBonus;
        private double subordinateBonus;
        private double basicSalary => staff?.BasicSalary ?? 0;
        private int yearWork => GetYearWork(onDate);
        private DateTime onDate;

        public Salary(StaffDTO staff, DateTime onDate)
        {
            this.staff = staff;
            this.onDate = onDate;
        }

        public double GetFullSalary()
        {
            if (staff.DateWork > onDate)
                return 0;
            if (basicSalary != 0)
            {
                if (staff.EmployeeGroupId == 1)
                {
                    bonus = basicSalary * 0.03 * yearWork;
                    maxBonus = basicSalary * 0.3;

                    return basicSalary + (bonus > maxBonus ? maxBonus : bonus);
                }
                if (staff.EmployeeGroupId == 2)
                {
                    bonus = basicSalary * 0.05 * yearWork;
                    maxBonus = basicSalary * 0.4;

                    foreach(var subordinate in staff.SubmissionRelationsSubordinate)
                    {
                        if(subordinate.ChiefId != staff.Id)
                        {
                            subordinateBonus += new Salary(subordinate.Chief, onDate).GetFullSalary() * 0.005;
                        }
                    }
                    return basicSalary + (bonus > maxBonus ? maxBonus : bonus) + subordinateBonus;
                }
                if (staff.EmployeeGroupId == 3)
                {
                    bonus = basicSalary * 0.01 * yearWork;
                    maxBonus = basicSalary * 0.35;

                    foreach (var subordinate in staff.SubmissionRelationsSubordinate)
                    {
                        if (subordinate.ChiefId != staff.Id)
                        {
                            foreach (var subsubordinate in subordinate.Chief.SubmissionRelationsSubordinate)
                            {
                                subordinateBonus += new Salary(subordinate.Chief, onDate).GetFullSalary() * 0.003;
                            }
                            subordinateBonus += new Salary(subordinate.Chief, onDate).GetFullSalary() * 0.003;
                        }
                    }
                    return basicSalary + (bonus > maxBonus ? maxBonus : bonus) + subordinateBonus;
                }
            }
            return 0;
        }

        private int GetYearWork(DateTime date)
        {
            int yearWork = (date - staff.DateWork).Days / 365;

            return yearWork > 0 ? yearWork : 0;
        }
    }
}
