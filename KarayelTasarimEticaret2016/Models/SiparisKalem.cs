//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KarayelTasarimEticaret2016.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SiparisKalem
    {
        public int SiparisKalemID { get; set; }
        public int RefSiparisID { get; set; }
        public int RefUrunID { get; set; }
        public int Adet { get; set; }
        public int ToplamTutar { get; set; }
    
        public virtual Sipari Sipari { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
