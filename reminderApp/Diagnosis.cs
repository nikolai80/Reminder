//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace reminderApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            this.Alarm = new HashSet<Alarm>();
        }
    
        public int DiagnosisId { get; set; }
    
        public virtual ICollection<Alarm> Alarm { get; set; }
    }
}
