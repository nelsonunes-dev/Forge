var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Forge_Api>("API");

builder.Build().Run();
