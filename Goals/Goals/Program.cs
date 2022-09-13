Console.BackgroundColor = ConsoleColor.Magenta;
Console.ForegroundColor = ConsoleColor.White;
Console.Clear();
Console.WriteLine("Enter Your Goal For Today");

var goal = Console.ReadLine()!;

if(goal.Length> 256)
{
    goal = goal.Substring(0, 256);
}

var today = DateTime.Now;
var NL = Environment.NewLine;
var message = $"[For {today:D} Your Goal Is:]{NL}{NL}{goal}";
Console.WriteLine(message);


Console.Write("Save your Changes? [Y/n]?");
var save = Console.ReadLine()!;

if(save == "n")
{
    Console.WriteLine("Ok, run me again!");
} else
{
    Console.WriteLine("Ok, Saving Your Stuff");
    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "goals", "goals.txt");
  
    if(!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
    if(!File.Exists(path))
    {
        File.Create(path);
    }

    File.AppendAllText(path, Environment.NewLine + message);
}