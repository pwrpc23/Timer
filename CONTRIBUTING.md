# Katkıda Bulunma Rehberi

Timer projesine katkıda bulunmayı düşündüğünüz için teşekkür ederiz! 🎉

## Katkı Süreci

### 1. Issue Oluşturma

Yeni bir özellik eklemeden veya hata düzeltmesi yapmadan önce:
- Mevcut issue'ları kontrol edin
- Benzer bir issue yoksa yeni bir issue açın
- Özellik veya hatayı detaylı açıklayın

### 2. Geliştirme Ortamı

**Gereksinimler:**
- Windows 10 veya üzeri
- Visual Studio 2022 (Community, Professional veya Enterprise)
- .NET 8.0 SDK
- Git

**Kurulum:**
```bash
# Repository'yi fork edin ve klonlayın
git clone https://github.com/KULLANICI_ADINIZ/Timer.git
cd Timer

# Yeni bir branch oluşturun
git checkout -b feature/yeni-ozellik
# veya
git checkout -b fix/hata-adi
```

### 3. Kod Standartları

**C# Kodlama Kuralları:**
- Tab yerine 4 boşluk kullanın
- Açıklayıcı değişken isimleri kullanın (Türkçe veya İngilizce)
- Public metodlar ve sınıflar için XML dokümantasyon yorumları ekleyin
- LINQ kullanımını tercih edin
- Null kontrollerini unutmayın

**XAML Kuralları:**
- Girinti için tab kullanın
- Özellikleri alfabetik sıraya göre düzenleyin
- Açıklayıcı x:Name değerleri kullanın

**Örnek Kod:**
```csharp
/// <summary>
/// Zamanlayıcıyı başlatır
/// </summary>
/// <param name="seconds">Toplam saniye</param>
public void StartTimer(int seconds) {
    if(seconds <= 0) {
        throw new ArgumentException("Saniye değeri pozitif olmalı", nameof(seconds));
    }
    
    TotalSeconds = seconds;
    timer.Start();
}
```

### 4. Commit Mesajları

Anlaşılır ve açıklayıcı commit mesajları yazın:

```bash
# İyi örnekler:
git commit -m "Klavye kısayolları eklendi"
git commit -m "Ses bildirimi hatası düzeltildi"
git commit -m "README.md güncellendi - kurulum talimatları eklendi"

# Kötü örnekler:
git commit -m "update"
git commit -m "fix"
git commit -m "değişiklikler"
```

**Commit Mesajı Formatı:**
- İlk satır: Kısa özet (50 karakter veya daha az)
- Boş satır
- Detaylı açıklama (gerekirse)

### 5. Pull Request Oluşturma

**Pull Request öncesi kontrol listesi:**
- [ ] Kod derleniyor mu?
- [ ] Yeni özellikler test edildi mi?
- [ ] Dokümantasyon güncellendi mi?
- [ ] Commit mesajları açıklayıcı mı?
- [ ] Kod standartlarına uygun mu?

**Pull Request açıklaması şunları içermeli:**
- Yapılan değişikliklerin özeti
- İlgili issue numarası (#123 şeklinde)
- Test edilen senaryolar
- Ekran görüntüleri (UI değişiklikleri için)

**Örnek PR Açıklaması:**
```markdown
## Değişiklik Özeti
Klavye kısayolları eklendi (#45)

## Yapılan Değişiklikler
- Space: Başlat
- P: Durdur
- R: Devam
- Esc: Sıfırla

## Test Edildi
- [x] Tüm kısayollar çalışıyor
- [x] Mevcut fonksiyonalite etkilenmedi
- [x] Buton metinleri güncellendi

## Ekran Görüntüsü
![klavye-kisayollari](screenshot.png)
```

### 6. Code Review

- Geri bildirimlere açık olun
- İstenen değişiklikleri zamanında yapın
- Sorularınızı çekinmeden sorun

## Katkı Türleri

### 🐛 Hata Düzeltmeleri
- Rapor edilen hataları düzeltin
- Test senaryoları ekleyin
- Düzeltme detaylarını dokümante edin

### ✨ Yeni Özellikler
- Issue açarak özelliği önerin
- Onay bekleyin
- Küçük adımlarla geliştirin
- Dokümantasyon ekleyin

### 📝 Dokümantasyon
- README.md iyileştirmeleri
- Kod yorumları
- Kullanım örnekleri
- Türkçe dil desteği

### 🎨 UI/UX İyileştirmeleri
- Arayüz tasarımı
- Kullanılabilirlik
- Erişilebilirlik

### 🔧 Altyapı
- Build süreçleri
- CI/CD pipeline
- Test otomasyonu

## Yardım İhtiyacı

Takıldığınız bir yer varsa:
1. Issue açın ve sorunuzu sorun
2. Discussions bölümünü kullanın
3. Mevcut issue'lara yorum yapın

## Davranış Kuralları

- Saygılı olun
- Yapıcı eleştiri yapın
- Yardımsever olun
- Kapsayıcı bir ortam oluşturun

## Lisans

Katkıda bulunarak, kodunuzun projenin GPL-3.0 lisansı altında yayınlanmasını kabul edersiniz.

---

Tekrar teşekkür ederiz! 🙏 Sorularınız için [issue](../../issues) açabilirsiniz.
