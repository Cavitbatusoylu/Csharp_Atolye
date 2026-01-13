# 🚗 Akıllı Araç Kiralama Rezervasyon Sistemi

C# ile geliştirilmiş, konsol tabanlı profesyonel bir araç kiralama yönetim sistemi.

<p align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Console_App-000000?style=for-the-badge&logo=windows-terminal&logoColor=white" />
</p>

## 📋 Proje Hakkında

Bu proje, **C# Atölyesi Bitirme Projesi** kapsamında geliştirilmiş kapsamlı bir araç kiralama rezervasyon sistemidir. Kullanıcı dostu menü arayüzü ile araç filosu yönetimi, rezervasyon işlemleri ve gelir raporlaması yapılabilir.

## ✨ Özellikler

### 🚙 Araç Yönetimi
- Mevcut araç filosunu listeleme
- Belirli tarih aralığında müsait araçları sorgulama
- Araç detayları (marka, model, tip, günlük fiyat)

### 📝 Rezervasyon İşlemleri
- **Yeni rezervasyon oluşturma** (günlük veya saatlik kiralama)
- **Rezervasyon düzenleme** (müşteri adı, tarihler)
- **Rezervasyon iptal etme**
- Müşteri bazlı rezervasyon sorgulama
- Plaka/müşteri adı ile arama

### 📊 Raporlama & Analiz
- Toplam gelir hesaplama
- Saatlik vs günlük kiralama ayrımı
- En çok kiralanan araç istatistiği
- Detaylı rapor çıktısı (TXT & JSON formatında)

### 💾 Veri Yönetimi
- Otomatik veri kaydetme
- Çoklu format desteği (TXT ve JSON)
- Uygulama yeniden başlatıldığında verilerin korunması

## 🗂️ Proje Yapısı

```
csharp-bitirme-projesi/
├── Program.cs           # Ana uygulama ve menü sistemi
├── Arac.cs              # Araç entity sınıfı
├── AracManager.cs       # Araç yönetim işlemleri
├── Rezervasyon.cs       # Rezervasyon entity sınıfı
├── RezervasyonManager.cs # Rezervasyon CRUD ve raporlama
├── DosyaManager.cs      # Dosya okuma/yazma işlemleri
├── rezervasyonlar.txt   # Rezervasyon verileri (TXT)
├── rezervasyonlar.json  # Rezervasyon verileri (JSON)
├── rapor.txt            # Detaylı rapor çıktısı
└── rapor.json           # JSON formatında rapor
```

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler
- .NET Framework 4.7.2 veya üzeri
- Visual Studio 2019+ (önerilen)

### Adımlar

1. **Repoyu klonlayın:**
   ```bash
   git clone https://github.com/Cavitbatusoylu/Csharp_Atolye_Bitirme_Projesi.git
   ```

2. **Projeyi açın:**
   ```bash
   cd Csharp_Atolye_Bitirme_Projesi
   ```

3. **Visual Studio ile açın veya CLI kullanın:**
   ```bash
   dotnet run
   ```

## 📸 Ekran Görüntüleri

### Ana Menü
```
============================================================
       AKILLI ARAC KIRALAMA REZERVASYON SISTEMI            
============================================================
  [1] Tum Araclari Listele                                 
  [2] Musait Araclari Goster                               
  [3] Yeni Rezervasyon Yap                                 
  [4] Rezervasyon Duzenle                                  
  [5] Rezervasyon Iptal Et                                 
  [6] Musteri Rezervasyonlarini Goruntule                  
  [7] Rezervasyon Ara                                      
------------------------------------------------------------
  [8] Toplam Geliri Goster                                 
  [9] En Cok Kiralanan Arac                                
 [10] Raporu Dosyaya Yazdir                                
------------------------------------------------------------
  [0] Cikis                                                
============================================================
```

## 🛠️ Kullanılan Teknolojiler

- **Dil:** C# 8.0
- **Framework:** .NET Framework 4.7.2
- **IDE:** Visual Studio 2022
- **Mimari:** Katmanlı mimari (Manager pattern)

## 📖 Öğrenilen Kavramlar

Bu proje sürecinde aşağıdaki C# kavramları uygulanmıştır:

- ✅ Object-Oriented Programming (OOP)
- ✅ LINQ (Language Integrated Query)
- ✅ Static class ve static method kullanımı
- ✅ Property ve auto-property
- ✅ Expression-bodied members
- ✅ Nullable reference types
- ✅ File I/O işlemleri
- ✅ Exception handling
- ✅ String manipulation ve formatting
- ✅ DateTime işlemleri

## 🔮 Gelecek Geliştirmeler

- [ ] Veritabanı entegrasyonu (SQLite/SQL Server)
- [ ] Windows Forms veya WPF arayüzü
- [ ] Kullanıcı kimlik doğrulama
- [ ] E-posta bildirimleri
- [ ] PDF rapor çıktısı

## 👨‍💻 Geliştirici

**Cavit Batu Soylu**

- GitHub: [@Cavitbatusoylu](https://github.com/Cavitbatusoylu)
- LinkedIn: [Cavit Batu Soylu](https://www.linkedin.com/in/cavit-batu-soylu/)

---

<p align="center">
  ⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!
</p>
