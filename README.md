# Shop Microservice E-Commerce Projesi

Modern mikroservis mimarisi ile geliştirilmiş e-ticaret platformu.

## 🏗️ Mimari

Bu proje **Clean Architecture** ve **Domain Driven Design** prensiplerine uygun olarak tasarlanmış mikroservis tabanlı bir e-ticaret sistemidir.

### Teknolojiler
- **.NET 6/8** - Backend ve Frontend
- **ASP.NET Core Web API** - Mikroservis API'leri
- **Blazor Server** - Modern web arayüzü (AdminUI)
- **ASP.NET Core MVC** - WebUI frontend
- **IdentityServer4** - Kimlik doğrulama ve yetkilendirme
- **Ocelot** - API Gateway
- **.NET Aspire** - Servis orkestrasyonu
- **SignalR** - Gerçek zamanlı iletişim
- **PostgreSQL** - İlişkisel veritabanı (Message, Order servisleri)
- **SQL Server** - İlişkisel veritabanı (IdentityServer, Discount servisleri)
- **MongoDB** - NoSQL veritabanı (Catalog servisi)
- **Redis** - Cache ve sepet yönetimi

## 📦 Mikroservisler

### Backend Servisleri
- **Catalog** - Ürün kataloğu yönetimi (MongoDB)
- **Order** - Sipariş işlemleri (Clean Architecture + PostgreSQL)
- **Basket** - Sepet yönetimi (Redis)
- **Payment** - Ödeme işlemleri
- **Cargo** - Kargo takibi
- **Discount** - İndirim sistemi (SQL Server)
- **Review** - Ürün değerlendirmeleri
- **Message** - Mesajlaşma sistemi (PostgreSQL)
- **Images** - Resim yönetimi
- **SignalR** - Gerçek zamanlı bildirimler

### Frontend Uygulamaları
- **WebUI** - Müşteri arayüzü (ASP.NET Core MVC)
- **AdminUI** - Yönetici paneli (Blazor Server)
- **ServiceDistribute** - Servis dağıtım katmanı
- **Aspire Web** - Aspire dashboard (Blazor Server)

### Altyapı Servisleri
- **IdentityServer** - Kimlik doğrulama ve yetkilendirme
- **OcelotGateway** - API Gateway
- **Aspire** - Servis orkestrasyonu

## 🚀 Çalıştırma

### Gereksinimler
- .NET 6/8 SDK
- Visual Studio 2022 veya VS Code
- **Veritabanları:**
  - MongoDB (Catalog servisi için)
  - PostgreSQL (Message, Order servisleri için)
  - SQL Server (IdentityServer, Discount servisleri için)
  - Redis (Sepet yönetimi için)

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
- ✅ **Blazor Server** ile modern admin paneli
- ✅ **ASP.NET Core MVC** ile müşteri arayüzü
- ✅ JWT tabanlı kimlik doğrulama
- ✅ API Gateway ile yönlendirme
- ✅ **Redis** ile hızlı sepet yönetimi
- ✅ **PostgreSQL** ile güvenilir veri depolama
- ✅ **MongoDB** ile esnek ürün kataloğu
- ✅ Gerçek zamanlı bildirimler (SignalR)
- ✅ Clean Architecture
- ✅ Docker desteği (Aspire ile)
- ✅ Swagger API dokümantasyonu

## 📁 Proje Yapısı

```
├── Services/          # Mikroservisler
│   ├── Catalog/       # Ürün kataloğu (MongoDB)
│   ├── Order/         # Sipariş (Clean Architecture + PostgreSQL)
│   ├── Basket/        # Sepet (Redis)
│   ├── Payment/       # Ödeme
│   ├── Cargo/         # Kargo
│   ├── Discount/      # İndirim (SQL Server)
│   ├── Review/        # Değerlendirme
│   ├── Message/       # Mesajlaşma (PostgreSQL)
│   ├── Images/        # Resim yönetimi
│   └── SignalR/       # Gerçek zamanlı bildirimler
├── Frontends/         # Frontend uygulamaları
│   ├── Shop.WebUI/    # Müşteri arayüzü (MVC)
│   ├── Shop.AdminUI/  # Admin paneli (Blazor Server)
│   └── ServiceDistribute/ # Servis katmanı
├── IdentityServer/    # Kimlik doğrulama servisi
├── ApiGateway/        # Ocelot Gateway
└── Aspire/           # Servis orkestrasyonu
    ├── AppHost/       # Ana orkestratör
    ├── Web/           # Aspire dashboard (Blazor)
    └── ServiceDefaults/ # Varsayılan servisler
