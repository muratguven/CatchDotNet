var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CatchDotNet_WebApi>("catchdotnet-webapi");

builder.Build().Run();
