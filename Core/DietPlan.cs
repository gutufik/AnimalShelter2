//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class DietPlan
    {
        public int Id { get; set; }
        public Nullable<int> AnimalFoodId { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public Nullable<int> Weight { get; set; }
    
        public virtual AnimalFood AnimalFood { get; set; }
    }
}