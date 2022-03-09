using EmployeeBenifits.Shared;

namespace EmployeeBenefits.Services
{
    public interface IBenefitDeductionService
    {
        /// <summary>
        /// Calculate employee benifit deduction
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>Benifit deduction details</returns>
        BenefitDeductionDetailModel CalculateBenefitDeduction(int employeeId);

    }
}
