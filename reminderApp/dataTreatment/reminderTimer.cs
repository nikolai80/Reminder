﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using reminderApp.Entities;

namespace reminderApp.dataTreatment
	{
	class ReminderTimer
		{
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }
		public int Hour { get; set; }
		public int Minute { get; set; }
		public int Second { get; set; }

		public ReminderTimer(int year, int month, int day, int hour, int minute, int second)
			{
			this.Year = year;
			this.Month = month;
			this.Day = day;
			this.Hour = hour;
			this.Minute = minute;
			this.Second = second;
			}
		Alarm alarm = new Alarm();
		//Метод возвращает список напоминаний
		public List<Alarm> FilterListOfAlarmsByTime(List<Alarm> alarms)
			{
			return alarms.Where(oneAlarm => oneAlarm.AlarmDate.TimeOfDay == DateTime.Now.TimeOfDay).ToList();
			}
		}
	}
