using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Model;

public class Book
{
    
    public int? BookId { get; set; }
    
    public string? Author { get; set; }

    public override string ToString()
    {
        return $"Book id {BookId} and Author: {Author}";
    }
    
}
    
