using EmployeeBenefits.Data;
using EmployeeBenefits.Data.Model;
using EmployeeBenifits.Shared;
using System;

namespace EmployeeBenefits.Services
{
    public class BenefitDeductionService : IBenefitDeductionService
    {
        private readonly IAppSettings appSettings;
        private readonly IEmployeeRepository employeeRepository;

        public BenefitDeductionService(IAppSettings appSettings, IEmployeeRepository employeeRepository)
        {
            this.appSettings = appSettings;
            this.employeeRepository = employeeRepository;
        }

        public BenefitDeductionDetailModel CalculateBenefitDeduction(int employeeId)
        {

            Employee employeeDetails = employeeRepository.GetEmployee(employeeId);

            if (employeeDetails == null)
                return new BenefitDeductionDetailModel();

            BenefitDeductionDetailModel benefitDetails = new BenefitDeductionDetailModel();

            benefitDetails.TotalSalaryPerPayCheckBeforeBenifit = Math.Round(employeeDetails.Salary / appSettings.PayChecksPerYear, 2);

            benefitDetails.EmployeeBenifitPerPaycheck = CalculateEmployeeBenifit(employeeDetails);
            benefitDetails.EmployeeBenifitPerYear = Math.Round(benefitDetails.EmployeeBenifitPerPaycheck * appSettings.PayChecksPerYear, 2);

            foreach (Dependent dependent in employeeDetails.Dependent)
            {
                benefitDetails.TotalDependentsBenifitPerPayCheck += CalculateDependentBenifit(dependent);
            }
            benefitDetails.TotalDependentsBenifitPerYear = Math.Round(benefitDetails.TotalDependentsBenifitPerPayCheck * appSettings.PayChecksPerYear, 2);

            benefitDetails.TotalSalaryPerPayCheckAfterBenifit = benefitDetails.TotalSalaryPerPayCheckBeforeBenifit - (benefitDetails.EmployeeBenifitPerPaycheck + benefitDetails.TotalDependentsBenifitPerPayCheck);
            benefitDetails.TotalSalaryPerYearAfterBenifit = Math.Round(benefitDetails.TotalSalaryPerPayCheckAfterBenifit * appSettings.PayChecksPerYear, 2);

            return benefitDetails;
        }

        private decimal CalculateEmployeeBenifit(Employee employeeDetails)
        {

            if (employeeDetails.FirstName.ToLower().StartsWith("a"))
                return Math.Round(((appSettings.EmployeeBenifitPerYear - (appSettings.NameDiscountPercentage * appSettings.EmployeeBenifitPerYear)) / appSettings.PayChecksPerYear), 2);
            else
                return Math.Round(appSettings.EmployeeBenifitPerYear / appSettings.PayChecksPerYear, 2);
        }

        private decimal CalculateDependentBenifit(Dependent dependentDetails)
        {
            if (dependentDetails.FirstName.ToLower().StartsWith("a"))
                return Math.Round(((appSettings.DependentBenifitPerYear - (appSettings.NameDiscountPercentage * appSettings.DependentBenifitPerYear)) / appSettings.PayChecksPerYear), 2);
            else
                return Math.Round(appSettings.DependentBenifitPerYear / appSettings.PayChecksPerYear, 2);
        }

    }
}
