using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Prova_Rubrica.Models;

public partial class Persone : ClasseBase
{

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<ContattiPersonali> ContattiPersonalis { get; set; } = new List<ContattiPersonali>();
    //proprietà creata dallo scaffolding per garantire l'integrità referenziale del db, per gestire la foreignkey

}  //Aggiungendo l'attributo [JsonIgnore] alla proprietà ContattiPersonalis, questa proprietà non verrà inclusa
   //nella serializzazione JSON e quindi non sarà visibile nel frontend.
   //Tuttavia, la proprietà sarà ancora disponibile nel backend per tutte le operazioni necessarie.
