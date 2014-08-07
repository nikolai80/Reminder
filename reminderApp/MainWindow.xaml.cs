using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
			dpDataNow.Text = DateTime.Now.ToString("D");
			for(int i = 1; i < 13; i++)
				{
				cbPeriodicity.Items.Add(i);
				}
			this.DisplayReminder();

			}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
			{
			string surname, name, secondName;
			surname = txbSurname.Text;
			name = txbName.Text;
			secondName = txbSecondName.Text;
			

			try
				{
				var pacient = new Pacient() { Name = name, SecondName = secondName, Surname = surname };
				context.PacientSet.Add(pacient);
				var alarm = new Alarm() { Time = dpDataNextVisit.DisplayDate, Pacient = pacient };
				context.AlarmSet.Add(alarm);
				context.SaveChanges();
				MessageBox.Show("Напоминание добавлено успешно");
				//обнуляем все поля
				txbSurname.Text = "Фамилия";
				txbName.Text = "Имя";
				txbSecondName.Text = "Отчество";
				dpDataNow.Text = "";
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
			txbAny.Text = String.Empty;
			}

		private void txbAnyEmpty_onGotFocus(object sender, RoutedEventArgs e)
			{
			TextBox txbAny = sender as TextBox;
			txbAny.Text = String.Empty;
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
			var dayNow = DateTime.Now;
			var dayNext = dayNow.AddDays(1);
			var alarmsOnDay = context.AlarmSet.Where(a => a.Time >= dayNow && a.Time < dayNext).Count();

			if(alarmsOnDay > 0)
				{
				isRemind = true;
				}
			return isRemind;
			}
		//Вычисление даты следующего визита к врачу
		private DateTime DateOfNextVisit(DateTime dateNow, int interval = 12)
			{
			int afterMonth = Constants.monthInYear / interval;
			DateTime dateNextVisit = dateNow.AddMonths(afterMonth);
			return dateNextVisit;
			}
		private void btnViewToday_Click(object sender, RoutedEventArgs e)
			{
			remindWindow allReminders = new remindWindow(true);
			allReminders.Owner = this;
			allReminders.Show();
			}

		private void cbPeriodicity_SelectionChanged(object sender, SelectionChangedEventArgs e)
			{
			DateTime dateNow = dpDataNow.DisplayDate;
			int interval;
			try
				{
				interval = Int32.Parse(cbPeriodicity.SelectedValue.ToString());
				}
			catch(ArgumentNullException)
				{
				throw;
				}

			DateTime dateNextVisit = DateOfNextVisit(dateNow, interval);
			dpDataNextVisit.DisplayDate = dateNextVisit;
			dpDataNextVisit.Text = dpDataNextVisit.DisplayDate.ToString("D");
			}

		}
	}
