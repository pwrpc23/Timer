using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Timer {
	/// <summary>
	/// Interaction logic for DisplayWindow.xaml
	/// </summary>
	public partial class DisplayWindow : Window {
		public event EventHandler DisplayWindowClosed;
		private bool showTimeText = true; // metin mi gösteriliyor, yoksa "SÜRE DOLDU" mu

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

				if(remainingSeconds <= 120) // kırmızı
					TimeLabel.Foreground = new SolidColorBrush(Colors.Red);
				else if(remainingSeconds <= 180) // turuncu
					TimeLabel.Foreground = new SolidColorBrush(Colors.Orange);
				else
					TimeLabel.Foreground = new SolidColorBrush(Colors.Green);
			}
			else {
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

		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
			this.DragMove();
		}
	}

}
