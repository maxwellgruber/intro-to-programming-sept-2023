using Banking.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests;
public class BankAccountBonusCalculationInteractionTests
{
    [Fact]
    public void UsesBonusCalculator()
    {
        // Given
        var stubbedBonusCalculator = new Mock<ICalculateAccountBonuses>();
        
        var account = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = account.GetBalance();
        var amountToDeposit =420M;

        stubbedBonusCalculator.Setup(c => c.GetBonusForDepositOnAccount(
            openingBalance, amountToDeposit)
        ).Returns(69.41M);


        // When
        account.Deposit(amountToDeposit);

        // Then
        Assert.Equal(openingBalance + amountToDeposit + 69.41M, account.GetBalance());
    }
}
