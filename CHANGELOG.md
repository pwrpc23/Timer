# Changelog

Tüm önemli değişiklikler bu dosyada belgelenecektir.

Format [Keep a Changelog](https://keepachangelog.com/en/1.0.0/) standardını takip eder.

## [Unreleased]

### Eklenenler
- Kapsamlı README.md - proje açıklaması, özellikler, kurulum talimatları
- XML dokümantasyon yorumları - tüm public sınıf ve metodlar için
- Global exception handler - beklenmeyen hataları yakalamak için
- Ses bildirimi - süre dolduğunda sistem sesi çalar
- Klavye kısayolları:
  - Space: Başlat
  - P: Durdur
  - R: Devam
  - Esc: Sıfırla
- CONTRIBUTING.md - katkıda bulunma rehberi
- ICON_README.md - uygulama ikonu ekleme talimatları
- SETTINGS_GUIDE.md - ayarlar özelliği ekleme rehberi
- GitHub Actions CI/CD workflow - otomatik build ve test
- Uygulama meta bilgileri (version, product, company)

### Değiştirilenler
- Kullanılmayan using direktifleri temizlendi
- Yorum satırları kaldırıldı veya iyileştirildi
- Kod dokümantasyonu iyileştirildi
- Buton metinleri güncellendi (klavye kısayollarını gösterir)

### Düzeltilenler
- Ses bildirimi için null kontrol eklendi
- DisplayWindow kapatma durumu için daha iyi hata yönetimi

## [1.0.0] - İlk Sürüm

### Özellikler
- Dakika ve saniye bazlı geri sayım
- Görsel geri bildirim (yeşil → turuncu → kırmızı renk geçişi)
- Taşınabilir sayaç penceresi
- Süre doldu uyarısı (yanıp sönen)
- Başlat, Durdur, Devam, Sıfırla, Kapat butonları
- Her zaman üstte kalma özelliği
- Şeffaf ve modern tasarım
- Ekran sınırları içinde kalma
