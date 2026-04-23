namespace ConsoleApp8;

class Program
{
    static void Main(string[] args)
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        Console.WriteLine(folderPath);
        
        string fileName = "example.txt";
        
        string fullPath = Path.Combine(folderPath, fileName);
        Console.WriteLine(fullPath);
        
        File.Create(fullPath).Close();
        File.WriteAllText(fullPath, "hello" + Environment.NewLine);
        File.AppendAllText(fullPath, "world");
        File.WriteAllText(fullPath, "hi again"); // WriteAllText удаляет старое содержимое
        
        string content = File.ReadAllText(fullPath);
        string[] lines = File.ReadAllLines(fullPath);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        
        string folderPath2 = Path.Combine(folderPath, "test");
        string filePath = Path.Combine(folderPath2, "anothertext");

        if (!Directory.Exists(folderPath2))
        {
            Directory.CreateDirectory(folderPath2);
        }

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        else
        {
            File.WriteAllText(filePath, "");
        }
        
        string folderPath3 = Path.GetDirectoryName(folderPath);
        string filePath = Path.GetFileName(folderPath);
        Console.WriteLine(folderPath3);
        Console.WriteLine(filePath);
    }
}