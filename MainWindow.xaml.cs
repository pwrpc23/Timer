using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System;
using System.Windows.Threading;
using Timer;

namespace Timer {
	public partial class MainWindow : Window {
		public int Minutes { get; set; }
		public int Seconds { get; set; }
		public int TotalSeconds {
			get => (Minutes * 60) + Seconds;
			set {
				Minutes = value / 60;
				Seconds = value % 60;
			}
		}
		private DispatcherTimer timer;
		private DisplayWindow displayWindow;

		public MainWindow() {
			InitializeComponent();
			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += Timer_Tick;

			this.Loaded += MainWindow_Loaded;
			MinutesUpDown.ValueChanged += UpDown_ValueChanged;
			SecondsUpDown.ValueChanged += UpDown_ValueChanged;
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
			displayWindow = new DisplayWindow();
			displayWindow.Owner = this;
			displayWindow.Left = 0;
			displayWindow.Top = 0;
			displayWindow.Show();
			displayWindow.DisplayWindowClosed += DisplayWindow_DisplayWindowClosed;

			Minutes = MinutesUpDown.Value ?? 0;
			Seconds = SecondsUpDown.Value ?? 0;
			UpdateDisplay();
		}

		private void UpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
			if(displayWindow != null && displayWindow.IsLoaded) {
				Minutes = MinutesUpDown.Value ?? 0;
				Seconds = SecondsUpDown.Value ?? 0;

				UpdateDisplay();
			}
		}

		private void Start_Click(object sender, RoutedEventArgs e) {
			int minutes = MinutesUpDown.Value ?? 0;
			int seconds = SecondsUpDown.Value ?? 0;

			//TotalSeconds = minutes * 60 + seconds;

			if(displayWindow == null || !displayWindow.IsLoaded) {
				displayWindow = new DisplayWindow();
				displayWindow.Owner = this;
				displayWindow.Left = 0;
				displayWindow.Top = 0;
				displayWindow.Show();
				displayWindow.DisplayWindowClosed += DisplayWindow_DisplayWindowClosed;
			}

			UpdateDisplay();
			timer.Start();
		}

		private void DisplayWindow_DisplayWindowClosed(object? sender, EventArgs e) {
			timer.Stop();  // DisplayWindow kapatıldığında timer da dursun
		}

		private void Pause_Click(object sender, RoutedEventArgs e) {
			timer.Stop();
		}

		private void Resume_Click(object sender, RoutedEventArgs e) {
			timer.Start();
		}

		private void Reset_Click(object sender, RoutedEventArgs e) {
			timer.Stop();
			TotalSeconds = 0;

			MinutesUpDown.Value = 0;
			SecondsUpDown.Value = 0;

			UpdateDisplay();
		}

		private void CloseDisplay_Click(object sender, RoutedEventArgs e) {
			if(displayWindow != null && displayWindow.IsLoaded) {
				displayWindow.Close();
			}
			timer.Stop();
		}

		private void Timer_Tick(object sender, EventArgs e) {
			TotalSeconds--;
			UpdateDisplay();
		}

		private void UpdateDisplay() {
			int mins = TotalSeconds / 60;
			int secs = Math.Abs(TotalSeconds % 60); // negatifte de pozitif gösterim
			string sign = TotalSeconds < 0 ? "-" : "";
			string timeStr = $"{sign}{Math.Abs(mins):D2}:{secs:D2}";

			if(displayWindow != null && displayWindow.IsLoaded)
				displayWindow.UpdateTime(timeStr, TotalSeconds);
		}
	}
}