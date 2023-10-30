using System.ComponentModel.DataAnnotations;

namespace ChatGptAPI.Model;

public class Image
{
    [Required]
    public string Prompt { get; set; } 
    public int Piece { get; set; } 
    public int Size { get; set; }
}
