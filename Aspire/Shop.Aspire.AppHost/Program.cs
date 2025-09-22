using Projects;

var builder = DistributedApplication.CreateBuilder(args);


var catalog = builder.AddProject<Projects.Shop_Catalog>("shop-catalog");
      
var review = builder.AddProject<Projects.Shop_Review>("shop-review");
var ocelot = builder.AddProject<Projects.Shop_OcelotGateway>("ocelot");
var identity = builder.AddProject<Projects.Shop_IdentityServer>("shop-identityserver");
var basket = builder.AddProject<Projects.Shop_Basket>("shop-basket");
var discount = builder.AddProject<Projects.Shop_Discount>("shop-discount");
var order = builder.AddProject<Projects.Shop_Order_WebApi>("shop-order-webapi");
var message = builder.AddProject<Projects.Shop_Message>("shop-message");
var cargo = builder.AddProject<Projects.Shop_Cargo_WebApi>("shop-cargo-webapi");

var signalr = builder.AddProject<Projects.Shop_SignalR>("shop-signalr");

builder.AddProject<Projects.Shop_AdminUI>("shop-adminui")
    .WithExternalHttpEndpoints()
    .WithReference(catalog)
    .WaitFor(catalog)
    .WithReference(review)
    .WaitFor(review)
    .WithReference(discount)
    .WaitFor(discount)
    .WithReference(order)
    .WaitFor(order)
    .WithReference(cargo)
    .WaitFor(cargo)

    .WithReference(ocelot)
    .WaitFor(ocelot)
    .WithReference(identity)
    .WaitFor(identity);


builder.AddProject<Projects.Shop_WebUI>("shop-webui")
    .WithExternalHttpEndpoints()
    .WithReference(catalog)
    .WaitFor(catalog)
    .WithReference(review)
    .WaitFor(review)
    .WithReference(basket)
    .WaitFor(basket)
    .WithReference(discount)
    .WaitFor(discount)
    .WithReference(order)
    .WaitFor(order)
    .WithReference(cargo)
    .WaitFor(cargo)

    .WithReference(ocelot)
    .WaitFor(ocelot)
    .WithReference(identity)
    .WaitFor(identity);



builder.Build().Run();
