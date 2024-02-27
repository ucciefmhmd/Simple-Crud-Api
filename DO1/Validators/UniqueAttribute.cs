using DO1.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class UniqueAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        IDepartmentRep deptRep = (IDepartmentRep)validationContext.GetService(typeof(IDepartmentRep));

        string name = value as string;

        if (deptRep.GetByName(name) != null)
        {
            return new ValidationResult($"This {name} is already taken, Try another name.");
        }
        else
        {
            return ValidationResult.Success;
        }
    }

}
