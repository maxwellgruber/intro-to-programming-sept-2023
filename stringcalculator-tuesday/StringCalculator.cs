
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers) => numbers switch
    {
        "" => 0,
        var nums when numbers.StartsWith("//") => AddWithDelimeters(nums.Remove(0,4), new char[] { ',', '\n', nums.Substring(2, 1).ToCharArray()[0] }),
        _ => AddWithDelimeters(numbers, ',', '\n')
    };

    private int AddWithDelimeters(string numbers, params char[] delimeters) => numbers.Split(delimeters).Select(int.Parse).Sum();
    
}

