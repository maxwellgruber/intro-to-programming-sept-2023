namespace Banking.Domain;

public class TimeBasedBonusCalculator : ICalculateAccountBonuses
{

    private readonly IProvideTheBusinessClock _businessClock;

    public TimeBasedBonusCalculator(IProvideTheBusinessClock businessClock)
    {
        _businessClock = businessClock;
    }

    public decimal GetBonusForDepositOnAccount(decimal balance, decimal amountToDeposit)
    {
        if(_businessClock.DuringBusinessHours() && balance >= 5000)
        {
            return amountToDeposit * .10M;
        } else
        {
            return 0;
        }
    }

   
}