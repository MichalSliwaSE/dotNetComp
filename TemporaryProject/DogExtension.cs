namespace TemporaryProject;

public static class DogExtension
{
    public static string GetAgeAndName(this Dog dog)
    {
        return $"{dog.age} and name is {dog.name}";
    }
}