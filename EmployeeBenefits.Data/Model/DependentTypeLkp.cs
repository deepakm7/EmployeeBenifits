using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeBenefits.Data.Model
{
    public partial class DependentTypeLkp
    {
        public DependentTypeLkp()
        {
            Dependent = new HashSet<Dependent>();
        }

        public int DependentTypeId { get; set; }
        public string DependentTypeName { get; set; }
        public bool Obsolete { get; set; }

        public virtual ICollection<Dependent> Dependent { get; set; }
    }
}
