
using Banking.Domain;

namespace Banking.UnitTests;
public class GoldAccountsGetBonus
{
    [Fact]
    public void GoldAccountGetsBonusOnDeposit()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;
        account.AccountType = AccountLoyaltyLevel.Gold;

        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());
    }
}
