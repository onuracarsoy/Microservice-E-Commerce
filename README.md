# Shop — Microservice E‑Commerce

A modular e‑commerce platform implemented with a microservice architecture. This solution demonstrates Clean Architecture, Domain‑Driven Design, and a production‑oriented service landscape (datastores, cache, API Gateway, identity server, real‑time notifications and admin/frontends).

[![.NET](https://img.shields.io/badge/.NET-6%2F8-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![Docker](https://img.shields.io/badge/Docker-Containers-blue?style=flat&logo=docker)](https://www.docker.com/)
[![Microservices](https://img.shields.io/badge/Microservices-Architecture-orange?style=flat)]()

---

## Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Microservices & Frontends](#microservices--frontends)
- [Technologies](#technologies)
- [Prerequisites](#prerequisites)
- [Quick Start (Aspire)](#quick-start-aspire)
- [Manual Run](#manual-run)
- [Configuration](#configuration)
- [Project Structure](#project-structure)

---

## Overview

This repository contains a sample e‑commerce platform composed of multiple services and frontends intended to illustrate:

- Microservice decomposition (Catalog, Order, Basket, Payment, etc.)
- Polyglot persistence (MongoDB, PostgreSQL, SQL Server, Redis)
- API Gateway (Ocelot) and service orchestration (Aspire)
- Real‑time notifications via SignalR
- Admin UI built with Blazor Server and customer UI with ASP.NET MVC
- Docker support for local integration and deployment

The project is suitable as a learning/demo platform or as a starting point for production projects (requires hardening for production use).

---

## Architecture

The solution follows Clean Architecture and DDD principles:

- Domain Layer — core business entities and rules
- Application Layer — use cases / application services
- Infrastructure Layer — data access, messaging, adapters
- Presentation Layer — Web APIs, frontends, and administrative tools

An API Gateway (Ocelot) routes requests to internal services. Aspire is used for local orchestration and service lifecycle management. IdentityServer (or similar) handles authentication/authorization.

---

## Microservices & Frontends

### Backend Services
- Catalog — product management (MongoDB)
- Order — order processing (Clean Architecture + PostgreSQL)
- Basket — shopping cart (Redis)
- Payment — payment processing
- Cargo — shipping / tracking
- Discount — promotions & discount rules (SQL Server)
- Review — product reviews
- Message — messaging service (PostgreSQL)
- Images — image storage/processing
- SignalR — real‑time notifications/hubs

### Frontends
- Shop.WebUI — customer storefront (ASP.NET Core MVC)
- Shop.AdminUI — admin panel (Blazor Server)
- Aspire Web — orchestration dashboard
- ServiceDistribute / ServiceDefaults — distribution helpers and templates

### Infrastructure
- IdentityServer — identity & access management
- Ocelot API Gateway — routing & aggregation
- Aspire — service orchestration & local app host
- Docker / Compose — optional containerization for services

---

## Technologies

| Area | Technologies |
|---|---|
| Runtime / Framework | .NET 6 / .NET 8, ASP.NET Core |
| API / Gateway | ASP.NET Core Web API, Ocelot |
| Frontend | Blazor Server (Admin), ASP.NET MVC (WebUI), HTML/JS templates |
| Datastores | MongoDB, PostgreSQL, SQL Server, Redis |
| Real-time | SignalR |
| Dev / Infra | Docker, Docker Compose, Aspire |
| Other | Swagger / OpenAPI, AutoMapper, EF Core |

---

## Prerequisites

- .NET 6 SDK or .NET 8 SDK (depending on the service target)
- Docker & Docker Compose (recommended)
- MongoDB (for Catalog) — can run as container
- PostgreSQL (for Order, Message services) — can run as container
- SQL Server (for Identity/Discount) — optional
- Redis (for Basket) — optional

---

## Quick Start (Aspire — recommended for integrated run)

This solution includes an Aspire orchestration layer to start many services together.

1. Open a terminal and navigate to the Aspire host folder:
   ```bash
   cd Aspire/Shop.Aspire.AppHost
   ```

2. Run the Aspire host:
   ```bash
   dotnet run
   ```

3. Start frontends and clients (AdminUI / WebUI) as needed. Aspire hosts and orchestrates services in the recommended order.

Note: Aspire configuration and service discovery details are in the Aspire folder. Check logs for ports and endpoints.

---

## Manual Run

If you prefer manual startup:

1. Start infrastructure (containers):
   - MongoDB
   - PostgreSQL
   - Redis
   - SQL Server (if required)

   Example (using Docker Compose if available):
   ```bash
   docker-compose -f docker/docker-compose.yml up -d
   ```

2. Start IdentityServer:
   ```bash
   cd IdentityServer
   dotnet run
   ```

3. Start backend services (in a recommended order):
   - Services/Images/Shop.Images
   - Services/Catalog/Shop.Catalog.WebApi
   - Services/Order/Shop.Order.WebApi
   - Services/Basket/Shop.Basket.WebApi
   - Services/Payment/Shop.Payment.WebApi
   - Services/SignalR/Shop.SignalR
   (...and others)

   For each service:
   ```bash
   cd Services/<ServiceName>/<Project>
   dotnet run
   ```

4. Start API Gateway:
   ```bash
   cd ApiGateway
   dotnet run
   ```

5. Start frontends:
   - Frontends/Shop.AdminUI
   - Frontends/Shop.WebUI

Open the configured URLs (printed in console logs) to access UIs.

---

## Configuration

Each service has its own configuration file (appsettings.json). Key settings:

- Connection strings (MongoDB/Postgres/SQL Server)
- Redis endpoints
- Identity/Authentication settings (IdentityServer)
- External provider keys (payment gateways, object storage)
- Environment variables override local appsettings

Example connection strings (replace with your values):
```json
"ConnectionStrings": {
  "PostgresConnection": "Host=localhost;Port=5432;Database=shopdb;Username=postgres;Password=yourpass",
  "SqlServerConnection": "Server=localhost;Database=DiscountDb;User Id=sa;Password=yourpass",
  "MongoConnection": "mongodb://localhost:27017",
  "Redis": "localhost:6379"
}
```

Security: Do not commit secrets. Use environment variables, Docker secrets or a secret manager for production.

---

## Project Structure (high level)

```
.
├── Aspire/                        # Aspire orchestration
├── ApiGateway/                    # Ocelot Gateway
├── IdentityServer/                # Authentication server
├── Services/
│   ├── Catalog/
│   ├── Order/
│   ├── Basket/
│   ├── Payment/
│   ├── Cargo/
│   ├── Discount/
│   ├── Review/
│   ├── Message/
│   ├── Images/
│   └── SignalR/
├── Frontends/
│   ├── Shop.WebUI/                # Customer UI (MVC)
│   ├── Shop.AdminUI/              # Admin UI (Blazor)
│   └── ServiceDistribute/
├── docker/                        # Docker compose files (optional)
└── README.md
```

Each service contains its own README and startup instructions. Look inside the relevant service folder for service‑specific run/migration commands.

---

Made with ❤️ — microservices, .NET and open web technologies.
