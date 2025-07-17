var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Web_API>("web-api");

builder.Build().Run();
