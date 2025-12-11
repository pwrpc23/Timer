# Uygulama İkonu Ekleme Rehberi

Şu anda proje bir uygulama ikonu içermemektedir. İkon eklemek için aşağıdaki adımları izleyin:

## İkon Oluşturma

### Seçenek 1: Online İkon Oluşturucu
1. [favicon.io](https://favicon.io/) veya [icon-icons.com](https://icon-icons.com/) gibi siteleri kullanın
2. 256x256 boyutunda bir ikon oluşturun
3. `.ico` formatında indirin

### Seçenek 2: Photoshop/GIMP ile Oluşturma
1. 256x256 piksel boyutunda yeni bir dosya oluşturun
2. Tasarımınızı yapın (zamanlayıcı, saat simgesi önerilir)
3. `.ico` formatında kaydedin

### Seçenek 3: Görsel'den İkon Oluşturma
1. PNG veya JPG formatında bir görseliniz varsa
2. [ConvertICO](https://converticon.com/) gibi online araçlarla `.ico` formatına çevirin

## İkonu Projeye Ekleme

1. Oluşturduğunuz `.ico` dosyasını `timer.ico` olarak adlandırın
2. Dosyayı proje kök dizinine (Timer.csproj ile aynı klasöre) kopyalayın
3. Visual Studio'da projeye sağ tıklayın → "Add" → "Existing Item"
4. `timer.ico` dosyasını seçin

## Önerilen İkon Tasarımı

Timer uygulaması için önerilen tasarım elementleri:
- ⏱️ Kronometre veya zamanlayıcı simgesi
- 🕐 Saat veya zaman göstergesi
- ⏳ Kum saati
- Renkler: Yeşil, Turuncu veya Kırmızı (uygulamanın renk temasına uygun)

## Doğrulama

İkon başarıyla eklendikten sonra:
1. Projeyi build edin: `dotnet build`
2. `bin/Release/net8.0-windows/Timer.exe` dosyasına bakın
3. İkonun göründüğünden emin olun
4. Masaüstünde veya görev çubuğunda test edin

## Not

`Timer.csproj` dosyası zaten ikon kullanacak şekilde yapılandırılmıştır:
```xml
<ApplicationIcon>timer.ico</ApplicationIcon>
```

Sadece `timer.ico` dosyasını eklemeniz yeterlidir!
