using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Veam.EMS.Application;

namespace Veam.EMS.EmpBasic
{
    public class EmployeeRegisterVM: Profile
    {
        public EmployeeRegisterVM()
        {
            CreateMap<EmployeeRegisterVM, RegisterNewEmployeeCommand>()
            .ForMember(d => d.Gender, o => o.MapFrom(s => s.gender.ToString()))
                           ;
        }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender gender { get; set; }
        public DateTime BirthDate { get; set; }
        public enum Gender
        {
            Male,
            Female,
            Other,
        }

        public string user { get; set; }
    }
}
