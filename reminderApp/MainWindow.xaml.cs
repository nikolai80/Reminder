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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace reminderApp
	{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
		{
		ReminderContext context;
		public MainWindow()
			{
			InitializeComponent();
			context = new ReminderContext();
			}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
			{
			string surname, name, secondName;
			DateTime date, time;
			int hours = 0, minutes = 0;
			surname = txbSurname.Text;
			name = txbName.Text;
			secondName = txbSecondName.Text;
			date = dpData.DisplayDate;

			try
				{
				hours = Int32.Parse(txbHours.Text);
				minutes = Int32.Parse(txbMinutes.Text);
				time = new DateTime(date.Year, date.Month, date.Day, hours, minutes, 0);
				var pacient = new Pacient() { Name = name, SecondName = secondName, Surname = surname };
				context.PacientSet.Add(pacient);
				var alarm = new Alarm() { Time = time, Pacient = pacient };
				context.AlarmSet.Add(alarm);
				context.SaveChanges();
				}
			catch(FormatException ex)
				{
				Console.WriteLine(ex.Message);
				}
			catch(Exception ex) { Console.WriteLine("Что то не так--> {0}",ex.Message); }

			}
		}
	}
