var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Property_AppModules>("apiservice")
    .WithHttpsHealthCheck("/health");

builder.AddProject<Projects.Property_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpsHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
