//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BonusMvcStok.Models.entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLSATISLAR
    {
        public int id { get; set; }
        public Nullable<int> urun { get; set; }
        public Nullable<int> personel { get; set; }
        public Nullable<int> musterı { get; set; }
        public Nullable<decimal> fıyat { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
    
        public virtual TBLMUSTERILER TBLMUSTERILER { get; set; }
        public virtual TBLPERSONEL TBLPERSONEL { get; set; }
        public virtual TBLURUNLER TBLURUNLER { get; set; }
    }
}
