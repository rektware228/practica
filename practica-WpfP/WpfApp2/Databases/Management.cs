//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2.Databases
{
    using System;
    using System.Collections.Generic;
    
    public partial class Management
    {
        public int ID_management { get; set; }
        public Nullable<int> ID_discipline { get; set; }
        public Nullable<int> ID_speciality { get; set; }
    
        public virtual Discipline Discipline { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
