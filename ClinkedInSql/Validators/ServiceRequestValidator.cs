using ClinkedInSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedInSql.Validators
{
    public class ServiceRequestValidator
    {
        public bool Validate(CreateServiceRequest requestToValidate)
        {
            return !(string.IsNullOrEmpty(requestToValidate.Name));
        }
    }
}