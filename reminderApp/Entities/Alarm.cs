using System;

namespace reminderApp.Entities
{
    public class Alarm
    {
    #region Properties

        public int AlarmId { get; set; }
        public DateTime AlarmDate { get; set; }
        public Pacient Pacient { get; set; }
        public Diagnostic Diagnostic { get; set; }

    #endregion 
    }
}