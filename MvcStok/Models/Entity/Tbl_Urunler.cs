//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Urunler()
        {
            this.Tbl_Satis = new HashSet<Tbl_Satis>();
        }
    
        public int URUNID { get; set; }
    
        public string URUNAD { get; set; }
        
        public string MARKA { get; set; }
        public Nullable<short> URUNKATEGORI { get; set; }
        public Nullable<decimal> FİYAT { get; set; }
        public Nullable<byte> STOK { get; set; }
    
        public virtual Tbl_Kategoriler Tbl_Kategoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Satis> Tbl_Satis { get; set; }
    }
}
