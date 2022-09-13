

using System.Collections; // This is illegal. Don't use this namespace in your apps.

namespace CSharpSyntaxStuff;

public class CreatingInstancesOfTypes
{
    [Fact]
    public void DeterminingType()
    {
        // Explicit Variable declaration
        Int32 x = 12;
        int y = 12;

       

        string myName = "Jeff";
        String yourName = "Ringo";
        char middleInital = 'M'; 

    }
    [Fact]
    public void ImplicitVariableDeclaration()
    {
        var x = 12;

        var y = "Monkey";

        string yourName;

        yourName = "Paul";

        Assert.Equal("Paul", yourName);

        var bob = new Employee();

        var myPay = new PayCheck();

        var manager = new Manager();

        manager.SaveThis(bob);
        manager.SaveThis(myPay);
        manager.SaveThis("Tacos");
        manager.SaveThis(42);

    }

    [Fact]
    public void OldSchoolCollections()
    {
        var favoriteNumbers = new ArrayList();
        favoriteNumbers.Add(9);
        favoriteNumbers.Add(42);
        favoriteNumbers.Add(20);

        Assert.Equal(9, favoriteNumbers[0]);

        favoriteNumbers.Add("Pizza");

        // favoriteNumbers[0] = "Three";
        var sumOfFirstTwo = ((int)favoriteNumbers[0]) + ((int)favoriteNumbers[1]);

        Assert.Equal(51, sumOfFirstTwo);
    }

    [Fact]
    public void NewSchoolCollections()
    {
        // Parametric Polymorphism
        var favoriteNumbers = new List<int>();

        favoriteNumbers.Add(9);
        favoriteNumbers.Add(42);
        favoriteNumbers.Add(20);

        var sumOfFirstTwo = favoriteNumbers[0] + favoriteNumbers[1];
        Assert.Equal(51, sumOfFirstTwo);
    }
    
}


public class Employee { }

public struct PayCheck {
    public decimal Amount;
    public string Currency;
}

public class Manager
{
    public void SaveThis(Object o)
    {
        
    }
}