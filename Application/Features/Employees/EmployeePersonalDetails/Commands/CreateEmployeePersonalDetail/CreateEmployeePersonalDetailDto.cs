﻿using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Application.Features.Employees.EmployeeAddresses.Commands.CreateEmployeeAddress;
using ApwPayroll_Application.Features.Employees.EmployeeBankDetails.Commands.CreateEmployeeBankDetails;
using ApwPayroll_Application.Features.Employees.EmployeeLanguages.Commands.CreateEmployeeLanguage;
using ApwPayroll_Domain.common.Enums.BloodGroup;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.MarriedStatus;
using ApwPayroll_Domain.Entities.Employees.EmergencyContacts;
using ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeePersonalDetails.Commands.CreateEmployeePersonalDetail
{
    public class CreateEmployeePersonalDetailDto
    {
        public string Name { get; set; } = "Ram";
        public GenderEnum Gender { get; set; }
        public DateTime DOB { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? Religion { get; set; }
        public BloodGroupEnum BloodGroup { get; set; }
   
        public string FatherName { get; set; }
        public DateTime? FatherDOB { get; set; }
        public string? MotherName { get; set; }
        public DateTime? MotherDOB { get; set; }
        public string? SpouseName { get; set; }
        public DateTime? SpouseDOB { get; set; }
        public GenderEnum SpouseGender { get; set; }
        public MarriedStatusEnum MarriedStatus { get; set; }
        public DateTime? DateOfWedding { get; set; }
        public EmergencyContact? Emergency { get; set; }
        public CreateEmployeeAddressCommand? ResidentialAddress { get; set; }
        public CreateEmployeeAddressCommand? PermanentAddress { get; set; }

        //public CreateEmployeeLanguageCommand? CreateEmployeeLanguage { get; set; }
        public CreateEmployeeBankDetailCommand CreateEmployeeBank {  get; set; }
    }
}
