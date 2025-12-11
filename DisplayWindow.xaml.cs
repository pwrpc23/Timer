using System;
using System.Media;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;


namespace Timer {
	/// <summary>
	/// Sayaç gösterim penceresi - her zaman üstte, taşınabilir, şeffaf tasarım
	/// </summary>
	public partial class DisplayWindow : Window {
		/// <summary>
		/// Pencere kapatıldığında tetiklenir
		/// </summary>
		public event EventHandler DisplayWindowClosed;
		
		private bool showTimeText = true; // metin mi gösteriliyor, yoksa "SÜRE DOLDU" mu
		private bool soundPlayed = false; // ses çalındı mı kontrolü

		/// <summary>
		/// DisplayWindow constructor - pencere ayarlarını başlatır
		/// </summary>
		public DisplayWindow() {
			InitializeComponent();
			this.LocationChanged += DisplayWindow_LocationChanged;
			this.Closed += DisplayWindow_Closed; // pencere kapandığında çalışır
		}

		private void DisplayWindow_Closed(object sender, EventArgs e) {
			DisplayWindowClosed?.Invoke(this, EventArgs.Empty);  // MainWindow’a haber gönder
		}

		public void UpdateTime(string time, int remainingSeconds) {
			if(remainingSeconds >= 0) {
				TimeLabel.Text = time;
				soundPlayed = false; // Pozitif süreye dönüldüğünde ses tekrar çalabilir

				if(remainingSeconds <= 120) // kırmızı
					TimeLabel.Foreground = new SolidColorBrush(Colors.Red);
				else if(remainingSeconds <= 180) // turuncu
					TimeLabel.Foreground = new SolidColorBrush(Colors.Orange);
				else
					TimeLabel.Foreground = new SolidColorBrush(Colors.Green);
			}
			else {
				// Süre dolduğunda ses çal (sadece bir kez)
				if(!soundPlayed) {
					try {
						SystemSounds.Beep.Play();
						soundPlayed = true;
					}
					catch {
						// Ses çalınamazsa sessizce devam et
					}
				}

				// Süre dolduktan sonra: yanıp sönen davranış
				if(showTimeText) {
					TimeLabel.Text = time;  // süreyi göster
				}
				else {
					TimeLabel.Text = "SÜRE DOLDU";  // uyarı metni
				}

				TimeLabel.Foreground = new SolidColorBrush(Colors.Red);  // kırmızı
				showTimeText = !showTimeText;  // her tick'te değiştir
			}
		}

		/// <summary>
		/// Pencere pozisyonunu ekran sınırları içinde tutar
		/// </summary>
		private void DisplayWindow_LocationChanged(object? sender, EventArgs e) {
			var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
			var screen = Screen.FromHandle(hwnd);

			var workingArea = screen.WorkingArea;  // bu ekranın kullanılabilir alanı (taskbar hariç)

			double maxLeft = workingArea.Right - this.Width;
			double maxTop = workingArea.Bottom - this.Height;

			if(this.Left < workingArea.Left)
				this.Left = workingArea.Left;
			else if(this.Left > maxLeft)
				this.Left = maxLeft;

			if(this.Top < workingArea.Top)
				this.Top = workingArea.Top;
			else if(this.Top > maxTop)
				this.Top = maxTop;
		}

		/// <summary>
		/// Fare sol tık ile pencere sürükleme
		/// </summary>
		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
			this.DragMove();
		}
	}

}
