using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
using System.Windows.Threading;

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
			this.DisplayReminder();
			}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
			{
			string surname, name, secondName;
			DateTime date, time;
			int hours = 0, minutes = 0;
			surname = txbSurname.Text;
			name = txbName.Text;
			secondName = txbSecondName.Text;
			date = dpData.SelectedDate.Value;

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
				MessageBox.Show("Напоминание добавлено успешно");
				//обнуляем все поля
				txbSurname.Text = "";
				txbName.Text = "";
				txbSecondName.Text = "";
				txbHours.Text = "";
				txbMinutes.Text = "";
				dpData.Text = "";
				}
			catch(FormatException ex)
				{
				MessageBox.Show(ex.Message);
				}
			catch(Exception ex) { MessageBox.Show("Что то не так--> {0}", ex.Message); }

			}

		private void txbAnyEmptyText_MouseUp(object sender, MouseEventArgs e)
			{
			TextBox txbAny = sender as TextBox;
			txbAny.Text = "";
			}

		private void txbAnyEmpty_onGotFocus(object sender, RoutedEventArgs e)
			{
			TextBox txbAny = sender as TextBox;
			txbAny.Text = "";
			}

		private void Button_Click(object sender, RoutedEventArgs e)
			{
			remindWindow allReminders = new remindWindow();
			allReminders.Show();
			}

		//Отображение окна с уведомление по таймеру
		private void DisplayReminder()
			{
			DispatcherTimer timer = new DispatcherTimer();
			timer.Tick += new EventHandler(dispatcherTimer_Tick);
			timer.Interval = new TimeSpan(0, 0, 5);
			if(IsRemind())
				{
				timer.Start(); 
				}

			}

		//Событие происходящее при срабатывании таймера
		private void dispatcherTimer_Tick(object sender, EventArgs e)
			{
			remindWindow allReminders = new remindWindow();
			allReminders.Show();
			}

		//метод определяющий есть ли в ближайшее время напоминания
		private bool IsRemind()
			{
			bool isRemind = false;
			var timeNow = DateTime.Now.TimeOfDay;
			var dayNow = DateTime.Now;
			var dayNext = dayNow.AddDays(1);
			var alarmsOnDay = context.AlarmSet.Where(a => a.Time>= dayNow&&a.Time<dayNext).Count();
			
			if(alarmsOnDay > 0)
				{
				isRemind = true;
				}
			return isRemind;
			}

		private void btnViewToday_Click(object sender, RoutedEventArgs e)
			{
			remindWindow allReminders = new remindWindow(true);
			allReminders.Owner = this;
			allReminders.Show(); 
			}

		}
	}
