using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace reminderApp
	{
	/// <summary>
	/// Interaction logic for remindWindow.xaml
	/// </summary>
	public partial class remindWindow : Window
		{
		private ReminderContext context;
		public bool FilterDateTime { get; set; }

		
		public remindWindow(bool filterDateTime=false,bool edit=false)
		{
			this.FilterDateTime = filterDateTime;
			InitializeComponent();
			context = new ReminderContext();
		    //dgRemindSet.IsReadOnly=true;
			dgRemindSet.DataContext = context;
			var dayNow = DateTime.Now;
			var dayNext = dayNow.AddDays(1);

			 var alarmList = from alarms in context.AlarmSet
							join pacients in context.PacientSet
								on alarms.PacientPacientId
								equals pacients.PacientId
							where alarms.Time >= dayNow
							select new { alarms.Time, pacients.Surname, pacients.Name, pacients.SecondName };

			if(this.FilterDateTime && !edit)
				{
				alarmList = from alarms in context.AlarmSet
								join pacients in context.PacientSet
									on alarms.PacientPacientId
									equals pacients.PacientId
								where alarms.Time >= dayNow && alarms.Time < dayNext
								select new { alarms.Time, pacients.Surname, pacients.Name, pacients.SecondName }; 
				}

            if (!this.FilterDateTime && edit)
            {
                dgRemindSet.IsReadOnly = false;
            }
			
			dgRemindSet.ItemsSource = alarmList.ToList();
			}
		}
	}
