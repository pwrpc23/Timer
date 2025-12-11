using System.Configuration;
using System.Data;
using System.Windows;

namespace Timer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application {
        /// <summary>
        /// Application constructor - global exception handler'ı ayarlar
        /// </summary>
        public App() {
            // Global exception handler
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        /// <summary>
        /// UI thread'inde yakalananamayan exception'ları ele alır
        /// </summary>
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            MessageBox.Show(
                $"Beklenmeyen bir hata oluştu:\n\n{e.Exception.Message}\n\nUygulama kapatılacak.",
                "Hata",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
            e.Handled = true;
            this.Shutdown();
        }

        /// <summary>
        /// Domain level exception'ları ele alır
        /// </summary>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            var exception = e.ExceptionObject as Exception;
            MessageBox.Show(
                $"Kritik hata oluştu:\n\n{exception?.Message ?? "Bilinmeyen hata"}\n\nUygulama kapatılacak.",
                "Kritik Hata",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

}
