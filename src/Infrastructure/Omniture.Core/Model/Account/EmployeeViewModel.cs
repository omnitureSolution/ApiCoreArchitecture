using FluentValidation;
using System;
using System.Collections.Generic;
using Omniture.Db.Abstractions.Enums;

namespace Omniture.Core.Model.Account
{
    public class EmployeeViewModel : ViewModel
    {
        public int EmployeeId { get; set; }
        public int ReferenceId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }        
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string DirectDial { get; set; }
         
        public int UserId { get; set; }        
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public class FlatResident
    {
        public int? FlatId { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string FlatNo { get; set; }
        public string FlatSearch { get; set; }
    }

    public class PersonList
    {
        public int PersonId { get; set; }
        public String Name { get; set; }
        public string FlatNo { get; set; }
        public string FlatSearch { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
