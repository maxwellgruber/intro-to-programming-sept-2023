

namespace Banking.Domain;

// Interfaces model functionality abstractly. Classes provide concrete code that implements interfaces.
// A quote from the 90's from Don Box. 
// An interface is a "Job Description"
public interface ICalculateAccountBonuses
{
    decimal GetBonusForDepositOnAccount(decimal balance, decimal amountToDeposit);
}
