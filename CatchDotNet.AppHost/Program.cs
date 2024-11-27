using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<CatchDotNet_WebApi>("catchdotnet-webapi");

builder.AddProject<CatchDotNet_Gateway>("catchdotnet-gateway");

builder.Build().Run();