//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABCD_Mall.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gallery
    {
        public int imageId { get; set; }
        public string imagePath { get; set; }
        public string objectType { get; set; }
        public int objectId { get; set; }
    
        public virtual Movy Movy { get; set; }
        public virtual Product Product { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
