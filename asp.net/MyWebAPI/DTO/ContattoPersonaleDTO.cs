using System.ComponentModel.DataAnnotations;

namespace Prova_Rubrica.DTO;

public class ContattoPersonaleDTO
{
    [Required]
    public string? Name {  get; set; }

    [Required]
    public string? Surname { get; set; }

    [Required]
    public string? Telefono { get; set; }

    [Required]
    public string? Email { get; set; }
    
    
}
