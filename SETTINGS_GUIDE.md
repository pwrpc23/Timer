# Ayarlar Özelliği Ekleme Rehberi

Şu anda uygulama kullanıcı ayarlarını kaydetmemektedir. Bu özelliği eklemek için aşağıdaki adımları takip edebilirsiniz:

## Önerilen Ayarlar

Kaydedilmesi önerilen ayarlar:
- Son kullanılan dakika değeri
- Son kullanılan saniye değeri
- DisplayWindow pozisyonu (Left, Top)
- DisplayWindow boyutu (Width, Height)
- Ses bildirimi açık/kapalı
- Renk geçiş eşikleri (yeşil, turuncu, kırmızı)

## Uygulama Yöntemleri

### Yöntem 1: JSON Dosyası Kullanımı (Önerilen)

**Avantajları:**
- Okunması kolay
- El ile düzenlenebilir
- Platform bağımsız

**Örnek Kod:**

```csharp
// Settings.cs
public class AppSettings {
    public int LastMinutes { get; set; }
    public int LastSeconds { get; set; }
    public double WindowLeft { get; set; }
    public double WindowTop { get; set; }
    public bool SoundEnabled { get; set; } = true;
}

// Kaydetme
var settings = new AppSettings {
    LastMinutes = Minutes,
    LastSeconds = Seconds,
    WindowLeft = displayWindow.Left,
    WindowTop = displayWindow.Top
};
string json = JsonSerializer.Serialize(settings);
File.WriteAllText("settings.json", json);

// Yükleme
if(File.Exists("settings.json")) {
    string json = File.ReadAllText("settings.json");
    var settings = JsonSerializer.Deserialize<AppSettings>(json);
    MinutesUpDown.Value = settings.LastMinutes;
    SecondsUpDown.Value = settings.LastSeconds;
}
```

### Yöntem 2: User Settings (Visual Studio)

**Avantajları:**
- Visual Studio entegrasyonu
- Tip güvenli
- Otomatik senkronizasyon

**Adımlar:**
1. Proje → Properties → Settings
2. Yeni ayarlar ekle (Scope: User)
3. Kodda kullan:

```csharp
// Kaydetme
Properties.Settings.Default.LastMinutes = Minutes;
Properties.Settings.Default.Save();

// Yükleme
MinutesUpDown.Value = Properties.Settings.Default.LastMinutes;
```

### Yöntem 3: Windows Registry

**Not:** Önerilmez - JSON kullanımı daha modern ve güvenli.

## Dosya Konumu

Ayar dosyasının kaydedileceği önerilen konumlar:

```csharp
// Kullanıcı AppData klasörü (Önerilen)
string settingsPath = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "Timer",
    "settings.json"
);

// Veya uygulama klasörü
string settingsPath = Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory,
    "settings.json"
);
```

## Uygulama Örneği

MainWindow.xaml.cs'e eklenecek metodlar:

```csharp
private void SaveSettings() {
    try {
        var settings = new AppSettings {
            LastMinutes = Minutes,
            LastSeconds = Seconds,
            WindowLeft = displayWindow?.Left ?? 0,
            WindowTop = displayWindow?.Top ?? 0,
            SoundEnabled = true
        };
        
        string settingsDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Timer"
        );
        Directory.CreateDirectory(settingsDir);
        
        string settingsPath = Path.Combine(settingsDir, "settings.json");
        string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { 
            WriteIndented = true 
        });
        File.WriteAllText(settingsPath, json);
    }
    catch(Exception ex) {
        // Hata yönetimi
    }
}

private void LoadSettings() {
    try {
        string settingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Timer",
            "settings.json"
        );
        
        if(File.Exists(settingsPath)) {
            string json = File.ReadAllText(settingsPath);
            var settings = JsonSerializer.Deserialize<AppSettings>(json);
            
            MinutesUpDown.Value = settings.LastMinutes;
            SecondsUpDown.Value = settings.LastSeconds;
            // displayWindow pozisyonunu ayarlama...
        }
    }
    catch(Exception ex) {
        // Hata yönetimi - varsayılan değerler kullanılır
    }
}
```

## Ne Zaman Kaydetmeli?

- Uygulama kapatılırken (Window.Closing event)
- Süre değerleri değiştiğinde (isteğe bağlı)
- "Kaydet" butonu eklenebilir (isteğe bağlı)

## Gerekli NuGet Paketi

JSON serileştirme için:
```
System.Text.Json (zaten .NET 8.0'da dahil)
```

## Test Etme

1. Ayarları kaydedin
2. Uygulamayı kapatın
3. Tekrar açın
4. Ayarların yüklendiğini kontrol edin
