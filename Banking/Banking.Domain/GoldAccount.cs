using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain;
public class GoldAccount : BankAccount
{
    public override void Deposit(decimal amountToDeposit)
    {
      
        base.Deposit(amountToDeposit * 1.10M);
    }

  

    public void SendToaster()
    {

    }
}

public class PlatinumAccount : BankAccount
{
    public override void Deposit(decimal amountToDeposit)
    {
        base.Deposit(amountToDeposit * 1.25M);
    }
}
