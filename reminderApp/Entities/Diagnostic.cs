using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reminderApp.Entities
    {
    public class Diagnostic
        {
        #region Properties

        public int DiagnosticId
            {
            get;
            set;
            }

        public string Title { get; set; }
        #endregion
        #region Constructor

        public Diagnostic(int diagnosticId,string title)
        {
            DiagnosticId = diagnosticId;
            Title = title;
        }
        #endregion
        }
    }
