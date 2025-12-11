using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Timer {
	/// <summary>
	/// Ana pencere sınıfı - sayaç kontrollerini içerir
	/// </summary>
	public partial class MainWindow : Window {
		/// <summary>
		/// Dakika değerini saklar
		/// </summary>
		public int Minutes { get; set; }
		
		/// <summary>
		/// Saniye değerini saklar
		/// </summary>
		public int Seconds { get; set; }
		
		/// <summary>
		/// Toplam saniye cinsinden süreyi hesaplar ve ayarlar
		/// </summary>
		public int TotalSeconds {
			get => (Minutes * 60) + Seconds;
			set {
				Minutes = value / 60;
				Seconds = value % 60;
			}
		}
		private DispatcherTimer timer;
		private DisplayWindow displayWindow;

		/// <summary>
		/// MainWindow constructor - timer ve event handler'ları başlatır
		/// </summary>
		public MainWindow() {
			InitializeComponent();
			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += Timer_Tick;

			this.Loaded += MainWindow_Loaded;
			this.KeyDown += MainWindow_KeyDown;
			MinutesUpDown.ValueChanged += UpDown_ValueChanged;
			SecondsUpDown.ValueChanged += UpDown_ValueChanged;
		}

		/// <summary>
		/// Pencere yüklendiğinde çalışır - DisplayWindow'u başlatır
		/// </summary>
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

		/// <summary>
		/// Dakika veya saniye değiştiğinde tetiklenir
		/// </summary>
		private void UpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
			if(displayWindow != null && displayWindow.IsLoaded) {
				Minutes = MinutesUpDown.Value ?? 0;
				Seconds = SecondsUpDown.Value ?? 0;

				UpdateDisplay();
			}
		}

		/// <summary>
		/// Başlat butonuna tıklandığında - sayacı başlatır
		/// </summary>
		private void Start_Click(object sender, RoutedEventArgs e) {
			StartTimer();
		}

		/// <summary>
		/// DisplayWindow kapatıldığında tetiklenir
		/// </summary>
		private void DisplayWindow_DisplayWindowClosed(object? sender, EventArgs e) {
			StopTimer();
		}

		/// <summary>
		/// Durdur butonuna tıklandığında - sayacı duraklatır
		/// </summary>
		private void Pause_Click(object sender, RoutedEventArgs e) {
			PauseTimer();
		}

		/// <summary>
		/// Devam butonuna tıklandığında - duraklatılan sayacı devam ettirir
		/// </summary>
		private void Resume_Click(object sender, RoutedEventArgs e) {
			ResumeTimer();
		}

		/// <summary>
		/// Sıfırla butonuna tıklandığında - sayacı başlangıç değerlerine döndürür
		/// </summary>
		private void Reset_Click(object sender, RoutedEventArgs e) {
			ResetTimer();
		}

		/// <summary>
		/// Kapat butonuna tıklandığında - DisplayWindow'u kapatır
		/// </summary>
		private void CloseDisplay_Click(object sender, RoutedEventArgs e) {
			CloseDisplayWindow();
		}

		// Timer işlemleri için ayrı metodlar
		
		/// <summary>
		/// Sayacı başlatır
		/// </summary>
		private void StartTimer() {
			int minutes = MinutesUpDown.Value ?? 0;
			int seconds = SecondsUpDown.Value ?? 0;

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

		/// <summary>
		/// Sayacı durdurur
		/// </summary>
		private void StopTimer() {
			timer.Stop();
		}

		/// <summary>
		/// Sayacı duraklatır
		/// </summary>
		private void PauseTimer() {
			timer.Stop();
		}

		/// <summary>
		/// Duraklatılan sayacı devam ettirir
		/// </summary>
		private void ResumeTimer() {
			timer.Start();
		}

		/// <summary>
		/// Sayacı sıfırlar
		/// </summary>
		private void ResetTimer() {
			timer.Stop();
			TotalSeconds = 0;

			MinutesUpDown.Value = 0;
			SecondsUpDown.Value = 0;

			UpdateDisplay();
		}

		/// <summary>
		/// DisplayWindow'u kapatır
		/// </summary>
		private void CloseDisplayWindow() {
			if(displayWindow != null && displayWindow.IsLoaded) {
				displayWindow.Close();
			}
			timer.Stop();
		}

		/// <summary>
		/// Her saniye tetiklenir - sayacı bir azaltır
		/// </summary>
		private void Timer_Tick(object sender, EventArgs e) {
			TotalSeconds--;
			UpdateDisplay();
		}

		/// <summary>
		/// DisplayWindow'daki zamanı günceller
		/// </summary>
		private void UpdateDisplay() {
			int mins = TotalSeconds / 60;
			int secs = Math.Abs(TotalSeconds % 60); // negatifte de pozitif gösterim
			string sign = TotalSeconds < 0 ? "-" : "";
			string timeStr = $"{sign}{Math.Abs(mins):D2}:{secs:D2}";

			if(displayWindow != null && displayWindow.IsLoaded)
				displayWindow.UpdateTime(timeStr, TotalSeconds);
		}

		/// <summary>
		/// Klavye kısayollarını işler
		/// </summary>
		private void MainWindow_KeyDown(object sender, KeyEventArgs e) {
			switch(e.Key) {
				case Key.Space:
					StartTimer();
					e.Handled = true;
					break;
				case Key.P:
					PauseTimer();
					e.Handled = true;
					break;
				case Key.R:
					ResumeTimer();
					e.Handled = true;
					break;
				case Key.Escape:
					ResetTimer();
					e.Handled = true;
					break;
			}
		}
	}
}