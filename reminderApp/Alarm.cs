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
    
    public partial class Alarm
    {
        public int AlarmId { get; set; }
        public System.DateTime Time { get; set; }
    
        public virtual Pacient Pacient { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
    }
}
