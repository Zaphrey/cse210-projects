using System;

public class SaveManager
{
    private List<string> _saveData;

    public SaveManager()
    {
        _saveData = new List<string>();
    }

    public SaveManager(List<string> saveData)
    {
        _saveData = saveData;
    }

    public void AddData(string data)
    {
        _saveData.Add(data);
    }

    public void Save()
    {
        Console.Write("Please input the file name: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (string line in _saveData)
                {
                    Console.WriteLine($"Saving {line}");
                    outputFile.WriteLine(line);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unable to save file! {e.Message}");
        }
    }

    public void Load()
    {
        Console.Write("Please input the file name: ");
        string fileName = Console.ReadLine();
        try 
        {
            string [] lines = File.ReadAllLines(fileName);

            _saveData = new List<string>();

            foreach (string line in lines)
            {
                _saveData.Add(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unable to load save file! {e.Message}");
        }
    }

    public List<string> GetData()
    {
        return _saveData;
    }
}