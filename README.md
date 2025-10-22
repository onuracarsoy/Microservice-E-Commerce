# Shop Microservice E-Commerce Projesi

Modern mikroservis mimarisi ile geliştirilmiş e-ticaret platformu.

## 🏗️ Mimari

Bu proje **Clean Architecture** ve **Domain Driven Design** prensiplerine uygun olarak tasarlanmış mikroservis tabanlı bir e-ticaret sistemidir.

### Teknolojiler
- **.NET 6**
- **ASP.NET Core Web API**
- **IdentityServer4** (Kimlik doğrulama)
- **Ocelot** (API Gateway)
- **.NET Aspire** (Orkestrasyon)
- **SignalR** (Gerçek zamanlı iletişim)
- **MongoDB** (Veri depolama)

## 📦 Mikroservisler

### Backend Servisleri
- **Catalog** - Ürün kataloğu yönetimi
- **Order** - Sipariş işlemleri (Clean Architecture)
- **Basket** - Sepet yönetimi
- **Payment** - Ödeme işlemleri
- **Cargo** - Kargo takibi
- **Discount** - İndirim sistemi
- **Review** - Ürün değerlendirmeleri
- **Message** - Mesajlaşma sistemi
- **Images** - Resim yönetimi
- **SignalR** - Gerçek zamanlı bildirimler

### Frontend Uygulamaları
- **WebUI** - Müşteri arayüzü
- **AdminUI** - Yönetici paneli
- **ServiceDistribute** - Servis dağıtım katmanı

### Altyapı Servisleri
- **IdentityServer** - Kimlik doğrulama ve yetkilendirme
- **OcelotGateway** - API Gateway
- **Aspire** - Servis orkestrasyonu

## 🚀 Çalıştırma

### Gereksinimler
- .NET 6 SDK
- Visual Studio 2022 veya VS Code
- MongoDB

### Aspire ile Çalıştırma (Önerilen)
```bash
cd Aspire/Shop.Aspire.AppHost
dotnet run
```

### Manuel Çalıştırma
1. IdentityServer'ı başlatın
2. Diğer mikroservisleri sırasıyla çalıştırın
3. Frontend uygulamalarını başlatın

## 🔧 Geliştirme

Proje **Clean Architecture** prensiplerine uygun olarak geliştirilmiştir:
- **Domain Layer** - İş mantığı
- **Application Layer** - Uygulama servisleri
- **Infrastructure Layer** - Veri erişimi
- **Presentation Layer** - API katmanı

## 📝 Özellikler

- ✅ Mikroservis mimarisi
- ✅ JWT tabanlı kimlik doğrulama
- ✅ API Gateway ile yönlendirme
- ✅ Gerçek zamanlı bildirimler
- ✅ Clean Architecture
- ✅ Docker desteği (Aspire ile)
- ✅ Swagger API dokümantasyonu

## 📁 Proje Yapısı

```
├── Services/          # Mikroservisler
├── Frontends/         # Frontend uygulamaları
├── IdentityServer/    # Kimlik doğrulama servisi
├── ApiGateway/        # Ocelot Gateway
└── Aspire/           # Servis orkestrasyonu
```


