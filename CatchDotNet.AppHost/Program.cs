var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CatchDotNet_WebApi>("catchdotnet-webapi");

builder.AddProject<Projects.CatchDotNet_Gateway>("catchdotnet-gateway");

builder.Build().Run();
