
namespace CSharpSyntaxStuff;
public record AccountHolder {


    private AccountHolder() { }

    // backing field
    public string Name { get; private init; } = string.Empty;

    // "Auto Property"
    public string Email { get; private init; } = string.Empty;

    public string AccountNumber { get; private init; } = string.Empty;

    public string GetInfo()
    {
        return $"This Account Holder is {Name} and reach them at {Email}";
    }

    public static AccountHolder Create(string name, string acountNumber)
    {
        if (name == "jeff") throw new ArgumentException("That dude sucks!");

        return new AccountHolder { Name = name.ToUpper(), AccountNumber = acountNumber };
    }

    public  AccountHolder ChangeName(AccountHolder account, string newName)
    {
        return account with { Name = newName.ToUpper() };

    }
}


public class Dog
{
    public string Name { get; init; }
    public string Breed { get; init; }
    public void RollOver()
    {

    }
}