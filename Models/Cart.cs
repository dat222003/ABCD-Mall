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
    
    public partial class Cart
    {
        public int cartId { get; set; }
        public int customerId { get; set; }
        public int ticketId { get; set; }
        public int quantity { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
