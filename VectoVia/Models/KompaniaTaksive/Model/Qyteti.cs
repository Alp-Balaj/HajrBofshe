﻿

using VectoVia.Models.KompaniaTaksive.Model;

public class Qyteti
{
    public int QytetiId { get; set; } 
    public string Name { get; set; }

    public ICollection<KompaniaTaxi> KompaniaTaxis { get; set; } // Navigation property

}
