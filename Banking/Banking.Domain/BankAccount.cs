namespace Banking.Domain;

public enum AccountLoyaltyLevel  {  Standard, Gold}
public class BankAccount
{

    private decimal _balance = 5000M; //JFHCI
    public AccountLoyaltyLevel AccountType { get; set; } = AccountLoyaltyLevel.Standard;
    public void Deposit(decimal amountToDeposit)
    {
        decimal bonus = GetBonusForDeposit(amountToDeposit);
        _balance += amountToDeposit + bonus;
    }

    private decimal GetBonusForDeposit(decimal amountToDeposit)
    {
        decimal bonus = 0;
        if (AccountType == AccountLoyaltyLevel.Gold)
        {
            bonus = amountToDeposit * .10M;
        }

        return bonus;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (AccountHasAvailableFunds(amountToWithdraw))
        {
            _balance -= amountToWithdraw;
        }
        else
        {
            throw new OverdraftException();
        }
    }

    private bool AccountHasAvailableFunds(decimal amountToWithdraw)
    {
        return amountToWithdraw <= _balance;
    }
}