namespace EmployeeBenifits.Shared
{
    public class AppSettings : IAppSettings
    {
        public int PayChecksPerYear { get; set; }
        public decimal EmployeeBenifitPerYear { get; set; }
        public decimal DependentBenifitPerYear { get; set; }
        public decimal NameDiscountPercentage { get; set; }
        public int DependentsCount { get; set; }
    }
}
