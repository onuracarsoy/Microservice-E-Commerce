📌 Proje Özeti (TR)

Microservice-E-Commerce, mikroservis mimarisi kullanılarak geliştirilmiş tam özellikli bir e-ticaret platformudur. .Net Ekosistem bilgilerimin tümünü kullanmaya çalıştığım birnevi benim için final projemdir. Admin kısmını özellikle blazor ile entegre ederek geliştirmek istedim. O yüzden benim için farklı ve özel projedir.

1. ApiGateway/

  Amaç: API Gateway olarak görev yapar, yani istemciden gelen istekleri ilgili mikroservislere yönlendirir.

  İçerik: Shop.OcelotGateway klasörü altında yapılandırma dosyaları ve yönlendirme ayarları bulunur.

2. Aspire/

  Amaç: Uygulamanın ve servislerin daha kolay tek bir yerden kontrolünü ve izlemini kolaylaştırır.


3. Frontends/

  Amaç: Kullanıcı arayüzü (UI) bileşenlerini içerir.


4. IdentityServer/

  Amaç: Kimlik doğrulama ve yetkilendirme işlemlerini yönetir.

  İçerik: Shop.IdentityServer klasörü altında kullanıcı yönetimi, JWT token üretimi ve OAuth2/OpenID Connect yapılandırmaları bulunur.

5. Services/

  Amaç: Mikroservislerin ana işlevselliğini barındırır.

  İçerik: E-ticaret platformunun farklı iş alanlarına hizmet eden mikroservisler burada yer alır. Örneğin:

    ProductService: Ürün yönetimi

    OrderService: Sipariş yönetimi

    InventoryService: Stok yönetimi

    PaymentService: Ödeme işlemleri

    ShippingService: Kargo ve teslimat işlemleri

🛠️ Kullanılan Teknolojiler

• .Net Blazor 8.0

•  .Net Aspire

• Redis

• Dapper

• Docker

• MongoDB

• PostgreSQL

• MSSQL

• SQLLite

• Google Drive Entegreli Fotoğraf Yükleme

• Identity Server

• Api Gateway

• Ocelot Gateway

• Postman

• Swagger

• Onion Architecture

• CQRS Design Pattern

• Mediator Design Pattern

• Repository Design Pattern

• AspNet Core Api

• Api Consume

• Rapid Api

• Authentication

• Authorization

• Json Web Token

• JWT Bearer

• SignalR

• Ajax
