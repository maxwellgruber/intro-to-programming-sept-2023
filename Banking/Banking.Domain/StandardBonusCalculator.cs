namespace Banking.Domain;

public class StandardBonusCalculator : ICalculateAccountBonuses
{
    public decimal GetBonusForDepositOnAccount(decimal balance, decimal amountToDeposit)
    {
        return balance >= 5000 ? amountToDeposit * .10M : 0;
    }

    public string FavoriteIcecreamFlavor()
    {
        return "Chocolate";
    }
}