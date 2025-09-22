﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Shop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog")
            {
                Scopes = {"CatalogFullPermission","CatalogReadPermission"}
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes = { "DiscountFullPermission"}
            },
            new ApiResource("ResourceOrder")
            {
                Scopes = { "OrderFullPermission"}
            },
            new ApiResource("ResourceCargo")
            {
                Scopes = { "CargoFullPermission"}
            },
            new ApiResource("ResourceBasket")
            {
                Scopes = { "BasketFullPermission"},
            },
            new ApiResource("ResourceReview")
            {
                Scopes = { "ReviewFullPermission"}
            },
            new ApiResource("ResourcePayment")
            {
                Scopes = { "PaymentFullPermission"}
            },
            new ApiResource("ResourceImages")
            {
                Scopes = { "ImagesFullPermission" }
            },
            new ApiResource("ResourceMessage")
            {
                Scopes = { "MessageFullPermission"}
            },
            new ApiResource("ResourceOcelot")
            {
                Scopes = { "OcelotFullPermission"}
            },

            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope("BasketFullPermission","Full authority for basket operations"),
            new ApiScope("ReviewFullPermission","Full authority for review operations"),
            new ApiScope("PaymentFullPermission","Full authority for payment operations"),
            new ApiScope("ImagesFullPermission","Full authority for images operations"),
            new ApiScope("MessageFullPermission","Full authority for message operations"),
            new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId = "ShopVisitorID",
                ClientName="Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("shopsecret".Sha256())},
                AllowedScopes={"CatalogReadPermission", "CatalogFullPermission", "ReviewFullPermission", "BasketFullPermission","DiscountFullPermission", "CargoFullPermission", "OcelotFullPermission" },
                AllowAccessTokensViaBrowser=true
            }, 

            //Manager
            new Client
            {
                ClientId = "ShopManagerID",
                ClientName="Shop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("shopsecret".Sha256())},
                AllowedScopes={"CatalogFullPermission","CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission", "CargoFullPermission", "BasketFullPermission", "ReviewFullPermission", "PaymentFullPermission", "ImagesFullPermission", "MessageFullPermission", "OcelotFullPermission" ,
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile },
                AllowOfflineAccess = true,  // Refresh token için gerekli
                AccessTokenLifetime = 600,
                AbsoluteRefreshTokenLifetime = 2592000,   // 30 gün
                SlidingRefreshTokenLifetime = 1296000     // 15 gün
            },

            //Admin
            new Client
            {
                ClientId = "ShopAdminID",
                ClientName="Shop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("shopsecret".Sha256())},
                AllowedScopes={"CatalogFullPermission","CatalogReadPermission","DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission","ReviewFullPermission","PaymentFullPermission","ImagesFullPermission","MessageFullPermission","OcelotFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,

                IdentityServerConstants.StandardScopes.Profile
                },
                AllowOfflineAccess = true,  // Refresh token için gerekli
                AccessTokenLifetime = 600,
                AbsoluteRefreshTokenLifetime = 2592000,   // 30 gün
                SlidingRefreshTokenLifetime = 1296000     // 15 gün
            }
        };
    }
}
