//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class AnimalComment
    {
        public int Id { get; set; }
        public Nullable<int> AnimalId { get; set; }
        public Nullable<int> CommentId { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Animal Animal { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
