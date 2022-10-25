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
    
    public partial class Food
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Food()
        {
            this.AnimalFoods = new HashSet<AnimalFood>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> AnimalCategoryId { get; set; }
        public Nullable<int> Remaind { get; set; }
        public Nullable<int> FoodTypeId { get; set; }
        public Nullable<int> ManufacturerId { get; set; }
        public byte[] Image { get; set; }
    
        public virtual AnimalCategory AnimalCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }
        public virtual FoodType FoodType { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}