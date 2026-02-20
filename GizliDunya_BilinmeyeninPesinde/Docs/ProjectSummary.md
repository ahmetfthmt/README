# Gizli Dünya: Bilinmeyenin Peşinde - Proje Özeti

## Proje Tanımı
"Gizli Dünya: Bilinmeyenin Peşinde" 10 bölümlük bir macera-bulmaca oyunudur. Oyuncu, dünyayı saran gizemli yerleri keşfeder ve efsanelerde geçen sırları çözmeye çalışır.

## Geliştirme Durumu

### Tamamlananlar
- [x] Ana oyun yöneticisi (GameManager)
- [x] Oyuncu kontrol sistemi (PlayerController)
- [x] Etkileşim sistemi (Interactable)
- [x] Bitki tanıma bulmacası (Amazon seviyesi)
- [x] Yerli dil bulmacası (Amazon seviyesi)
- [x] Köprü onarımı bulmacası (Amazon seviyesi)
- [x] Işık oyunu bulmacası (Atlantis seviyesi)
- [x] Atlantis alfabesi bulmacası (Atlantis seviyesi)
- [x] Seviye 1 yöneticisi
- [x] Ses yönetimi sistemi
- [x] Ana menü sistemi
- [x] Unity sahne dosyaları (Level1 ve Level2)
- [x] Derleme betiği

### Devam Edenler
- [ ] Mısır seviyesi (Ses yankıları ve hiyeroglif bulmacaları)
- [ ] Maya seviyesi (Güneş gölgeleri ve matematik bulmacaları)
- [ ] Himalayalar seviyesi (Buz heykelleri ve meditasyon bulmacaları)
- [ ] Nazca seviyesi (Çizgiler ve sembol bulmacaları)
- [ ] Stonehenge seviyesi (Astronomik ve Kelt dili bulmacaları)
- [ ] Paskalya Adası seviyesi (Uzaylı sembolleri ve manyetik alan bulmacaları)
- [ ] Antarktika seviyesi (Ses dalgaları ve harita bulmacaları)
- [ ] Bermuda seviyesi (Manyetik fırtınalar ve uzaylı dil bulmacaları)

## Teknik Özellikler

### Oyuncu Kontrolleri
- WASD: Hareket
- Fare: Bakış yönü
- Sol tık: Etkileşim
- Boşluk: Zıplama

### Oyun Mekanikleri
- 3D keşif ve macera
- Kültürler arası bulmacalar
- Tarihi ve mistik konumlar
- Gerçek tarih ve efsanelerden esinlenme

### Geliştirme Ortamı
- Unity 3D (tercihen 2021.3 LTS veya daha yeni)
- C# programlama dili
- Blender (3D modelleme)
- Audacity (ses düzenlemesi)

## Kullanılan Scriptler

### Temel Sistemler
1. **GameManager.cs** - Oyun genelini yönetir
2. **PlayerController.cs** - Oyuncu hareket ve kontrolünü sağlar
3. **Interactable.cs** - Etkileşim nesneleri için temel sınıf
4. **AudioManager.cs** - Ses yönetimi
5. **MainMenu.cs** - Menü sistemi

### Bulmaca Sistemleri
1. **PuzzlePlantIdentifier.cs** - Bitki tanıma bulmacası
2. **NativeLanguagePuzzle.cs** - Yerli dil bulmacası
3. **BridgeRepairPuzzle.cs** - Köprü onarımı bulmacası
4. **UnderwaterLightPuzzle.cs** - Işık oyunu bulmacası
5. **AtlantisAlphabetPuzzle.cs** - Atlantis alfabesi bulmacası

### Seviye Yönetimi
1. **Level1Manager.cs** - İlk seviyenin ilerlemesini yönetir
2. **BuildScript.cs** - Oyun derleme betiği

## Gereksinimler
- .NET Framework 4.7.1 veya üzeri
- OpenGL 3.3 veya üzeri
- Minimum 8GB RAM
- 10GB boş disk alanı

## Geliştirme Planı

### 1. Bölüm: Amazon'un Kaybolmuş Şehri
- [x] 3D yağmur ormanı sahnesi
- [x] Karakter animasyonları
- [x] Bulmaca mekanikleri
- [x] Gerçekçi orman ses efektleri
- [x] Beta testi prototipi

### 2. Bölüm: Atlantis'in Son Mirası
- [x] Su altı sahnesi ve 3D Atlantis kalıntıları
- [x] Işık ve gölge efektleri
- [x] Şifre çözme mekaniği
- [x] Su altı ses efektleri
- [x] Beta testi prototipi

### 3. Bölüm: Mısır'ın Gizli Odası
- [ ] Piramit içi 3D sahnesi
- [ ] Ses yankısı mekaniği
- [ ] Hiyeroglif çözme bulmacası
- [ ] Mısır temalı müzik ve ses efektleri
- [ ] Beta testi prototipi

### 4. Bölüm: Maya Takvimi ve Kıyamet Kehaneti
- [ ] Maya tapınağı ve çevresi 3D modeli
- [ ] Güneş gölgesi mekaniği
- [ ] Maya matematik bulmacası
- [ ] Meksika temalı müzik ve ses efektleri
- [ ] Beta testi prototipi

### 5. Bölüm: Himalayalar'daki Gizli Manastır
- [ ] Himalaya dağları ve manastır sahnesi
- [ ] Buz heykeli bulmacası
- [ ] Meditasyon mekaniği
- [ ] Tibet temalı müzik ve ses efektleri
- [ ] Beta testi prototipi

### 6. Bölüm: Nazca Çizgilerinin Sırrı
- [ ] Nazca çizgileri 3D modeli
- [ ] Uzaydan görüntüleme mekaniği
- [ ] Sembol bulmacası
- [ ] Peru temalı müzik ve ses efektleri
- [ ] Beta testi prototipi

### 7. Bölüm: Stonehenge'in Astronomik Şifresi
- [ ] Stonehenge sahnesi 3D modeli
- [ ] Güneş doğumu mekaniği
- [ ] Kelt dili bulmacası
- [ ] İngiltere temalı müzik ve ses efektleri
- [ ] Beta testi prototipi

### 8. Bölüm: Pasifik'teki Uzaylı İzi
- [ ] Paskalya Adası ve heykelleri 3D modeli
- [ ] Sembol çözme mekaniği
- [ ] Manyetik alan bulmacası
- [ ] Pasifik temalı müzik ve ses efektleri
- [ ] Beta testi prototipi

### 9. Bölüm: Antarktika'daki Gizli Üs
- [ ] Antarktika buzulları ve gizli üs sahnesi
- [ ] Ses dalgası mekaniği
- [ ] Harita çözme bulmacası
- [ ] Antarktika temalı müzik ve ses efektleri
- [ ] Beta testi prototipi

### 10. Bölüm: Bermuda Şeytan Üçgeni ve Son Sır
- [ ] Bermuda Şeytan Üçgeni sahnesi 3D modeli
- [ ] Manyetik fırtına mekaniği
- [ ] Uzaylı dil bulmacası
- [ ] Gizemli müzik ve ses efektleri
- [ ] Beta testi prototipi

## Lisans
Bu proje açık kaynaklıdır ve eğitim amaçlı kullanılabilir.