//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERestaurant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_group
    {
        public int Id { get; set; }
        public Nullable<int> User_id { get; set; }
        public Nullable<int> Group_id { get; set; }
    
        public virtual Groups Groups { get; set; }
        public virtual User User { get; set; }
    }
}