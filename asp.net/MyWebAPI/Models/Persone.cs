using System;
using System.Collections.Generic;

namespace Prova_Rubrica.Models;

public partial class Persone : ClasseBase
{

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public virtual ICollection<ContattiPersonali> ContattiPersonalis { get; set; } = new List<ContattiPersonali>();
}
