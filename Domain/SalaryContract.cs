using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.ValueObject;

namespace Domain
{
    public abstract  class SalaryContract
    {
        public abstract Money CalculatedAnnualSalary();
    }
}
