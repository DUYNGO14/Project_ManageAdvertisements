var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.API>("apiservice"); 

builder.AddProject<Projects.Presentation>("webfrontend") 
.WithExternalHttpEndpoints()
.WithReference(apiService);

builder.Build().Run();
