using System;
using System.Collections.Generic;

namespace Prova_Rubrica.Models;

public partial class ContattiPersonali : ClasseBase
{

    public int? IdPersona { get; set; }

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Persone? IdPersonaNavigation { get; set; }
}
