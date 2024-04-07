namespace TemporaryProject;

public class Dog
{
    public string? name { get; set; }
    public int? age { get; set; }


    public void PrintDogsAges()
    {
        Dictionary<string, int> dogs = new Dictionary<string, int>()
        {
            { "mom", 20 },
            { "dad", 23 },
            { "me", 55 }
        };

        foreach (KeyValuePair<string, int> item in dogs)
        {
            Console.WriteLine($"Name: {item.Key}, Age: {item.Value}");
        }
    }
    

}