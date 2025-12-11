# Timer - Geri Sayım Uygulaması

## Proje Hakkında

Timer, Windows için geliştirilmiş modern bir geri sayım (countdown) uygulamasıdır. WPF (Windows Presentation Foundation) kullanılarak geliştirilmiştir ve kullanıcı dostu bir arayüz sunar.

## Özellikler

- ⏱️ **Dakika ve saniye bazlı geri sayım**: Esnek zaman ayarlama
- 🎨 **Görsel geri bildirim**: Süreye göre renk değişimi (Yeşil → Turuncu → Kırmızı)
- 🪟 **Taşınabilir ekran**: Ekranda istediğiniz yere sürükleyebileceğiniz sayaç penceresi
- 🔔 **Süre doldu uyarısı**: Yanıp sönen görsel uyarı
- ⏯️ **Tam kontrol**: Başlat, Durdur, Devam, Sıfırla butonları
- 🎯 **Her zaman üstte**: Sayaç penceresi diğer pencerelerin üzerinde kalır
- 🖼️ **Şeffaf tasarım**: Modern ve minimal görünüm

## Gereksinimler

- Windows 10 veya üzeri
- .NET 8.0 Runtime
- Visual Studio 2022 (geliştirme için)

## Kurulum

### Kullanıcılar İçin
1. [Releases](../../releases) sayfasından en son sürümü indirin
2. ZIP dosyasını çıkartın
3. `Timer.exe` dosyasını çalıştırın

### Geliştiriciler İçin
```bash
# Repository'yi klonlayın
git clone https://github.com/pwrpc23/Timer.git
cd Timer

# Projeyi Visual Studio 2022 ile açın
start Timer.sln

# Veya komut satırından derleyin (sadece Windows'ta)
dotnet build
dotnet run
```

## Kullanım

1. **Süre Ayarlama**: Ana pencereden dakika ve saniye değerlerini ayarlayın
2. **Başlatma**: "Başlat" butonuna tıklayarak geri sayımı başlatın
3. **Sayaç Penceresi**: Ekranda belirecek sayaç penceresini istediğiniz yere sürükleyin
4. **Kontrol**: 
   - **Durdur**: Geri sayımı duraklatır
   - **Devam**: Duraklatılan geri sayımı devam ettirir
   - **Sıfırla**: Sayacı sıfırlar ve başlangıç değerlerine döner
   - **Kapat**: Sayaç penceresini kapatır

## Renk Göstergeleri

- 🟢 **Yeşil**: 3 dakikadan fazla süre kaldı
- 🟠 **Turuncu**: 2-3 dakika arası süre kaldı  
- 🔴 **Kırmızı**: 2 dakikadan az süre kaldı
- 🔴 **Yanıp sönen**: Süre doldu!

## Teknolojiler

- **Platform**: .NET 8.0
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Dil**: C# 12
- **Paketler**: 
  - Extended.Wpf.Toolkit 4.7.25104.5739

## Katkıda Bulunma

Katkılarınızı bekliyoruz! Lütfen aşağıdaki adımları izleyin:

1. Projeyi fork edin
2. Yeni bir branch oluşturun (`git checkout -b feature/yeniOzellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/yeniOzellik`)
5. Pull Request oluşturun

## Lisans

Bu proje GPL-3.0 lisansı altında lisanslanmıştır. Detaylar için [LICENSE.txt](LICENSE.txt) dosyasına bakın.

## İletişim

Sorularınız veya önerileriniz için [issue](../../issues) açabilirsiniz.

## Teşekkürler

Bu projeyi kullandığınız için teşekkür ederiz! ⭐ vermeyi unutmayın.