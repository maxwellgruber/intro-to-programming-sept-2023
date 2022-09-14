
namespace CSharpSyntaxStuff;
public class AccountHolderTests
{
    [Fact]
    public void AccountHolderStuff()
    {
		AccountHolder ah1;
		try
		{

			ah1 = AccountHolder.Create("joe", "8989");
		}
		catch (ArgumentException)
		{

			throw;
		}

		Assert.Equal("JOE", ah1.Name);

		var updatedAh1 = ah1.ChangeName(ah1, "bill");

		Assert.Equal("BILL", updatedAh1.Name);
		Assert.Equal("JOE", ah1.Name);
    }
}
