namespace EmployeeBenifits.Shared
{
    public interface IAppSettings
    {
        /// <summary>
        /// Number of pay checks per year
        /// </summary>
        int PayChecksPerYear { get; set; }

        /// <summary>
        /// Employee benifit per year
        /// </summary>
        decimal EmployeeBenifitPerYear { get; set; }

        /// <summary>
        /// Dependent benifit per year
        /// </summary>
        decimal DependentBenifitPerYear { get; set; }

        /// <summary>
        /// Discount percentage on name
        /// </summary>
        decimal NameDiscountPercentage { get; set; }

        /// <summary>
        /// Number of dependents
        /// </summary>
        int DependentsCount { get; set;  }
    }
}
