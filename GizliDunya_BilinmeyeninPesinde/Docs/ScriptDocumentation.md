# Gizli Dünya: Bilinmeyenin Peşinde - Script Dokümantasyonu

## Genel Oyun Scriptleri

### GameManager.cs
- Oyun genelini yönetir
- Seviye ilerlemesini takip eder
- Oyuncu canını yönetir
- Oyun durumunu korur

### PlayerController.cs
- Oyuncu hareketini yönetir
- Kamera kontrolünü sağlar
- Etkileşim sistemini içerir
- Yürüme, zıplama, bakış gibi temel kontrolleri sağlar

### Interactable.cs
- Tüm etkileşim nesneleri için temel sınıf
- Soyut bir sınıftır
- Etkileşim mekaniklerini içerir

## Bulmaca Scriptleri

### PuzzlePlantIdentifier.cs
- Amazon ormanı seviyesindeki bitki tanıma bulmacası
- Zehirli ve güvenli bitkileri ayırt etmeyi sağlar
- Oyuncu doğru bitkiyi seçtiğinde ilerleme sağlar

### ClickablePlant.cs
- Bitkiye tıklanabilirlik özelliği ekler
- PuzzlePlantIdentifier ile birlikte çalışır

### NativeLanguagePuzzle.cs
- Yerli dil bulmacası
- Yerli kabilelerin dilini öğrenme mekaniği
- Doğru çeviri yaparak ilerleme sağlar

### BridgeRepairPuzzle.cs
- Köprü onarımı bulmacası
- Parçaları doğru konumlara yerleştirme mekaniği
- Drag and drop sistemi

### BridgePart.cs
- Köprü parçalarına tıklanabilirlik ve sürükle-bırak özelliği ekler
- BridgeRepairPuzzle ile birlikte çalışır

### UnderwaterLightPuzzle.cs
- Atlantis seviyesindeki ışık bulmacası
- Işıkların renklerini doğru sıraya koyma
- Işık kombinasyonlarını çözme

### LightPuzzlePiece.cs
- Işıklara tıklanabilirlik özelliği ekler
- UnderwaterLightPuzzle ile birlikte çalışır

### AtlantisAlphabetPuzzle.cs
- Atlantis alfabesi bulmacası
- Sembolleri doğru anlamlarıyla eşleştirme
- Şifre çözme mekaniği

## Seviye Yönetimi

### Level1Manager.cs
- İlk seviyenin ilerlemesini yönetir
- Tüm bulmacaların tamamlanıp tamamlanmadığını kontrol eder
- Seviye tamamlama sistemini içerir

## Menü ve Sistem Scriptleri

### MainMenu.cs
- Ana menü sistemini yönetir
- Seviye seçimi, ayarlar ve çıkış fonksiyonlarını içerir

### AudioManager.cs
- Oyun müziklerini ve ses efektlerini yönetir
- Her seviye için uygun müzikleri çalar
- SFX sistemini içerir

## Geliştirme Planı

### 1. Bölüm: Amazon Ormanları
- [x] Bitki tanıma bulmacası
- [x] Yerli dil bulmacası
- [x] Köprü onarımı bulmacası
- [x] Seviye yöneticisi

### 2. Bölüm: Atlantis
- [x] Işık oyunu bulmacası
- [x] Atlantis alfabesi bulmacası

### Diğer Bölümler
- [ ] Mısır: Ses yankıları ve hiyeroglif bulmacaları
- [ ] Maya: Güneş gölgeleri ve matematik bulmacaları
- [ ] Himalayalar: Buz heykelleri ve meditasyon bulmacaları
- [ ] Nazca: Çizgiler ve sembol bulmacaları
- [ ] Stonehenge: Astronomik ve Kelt dili bulmacaları
- [ ] Paskalya Adası: Uzaylı sembolleri ve manyetik alan bulmacaları
- [ ] Antarktika: Ses dalgaları ve harita bulmacaları
- [ ] Bermuda: Manyetik fırtınalar ve uzaylı dil bulmacaları