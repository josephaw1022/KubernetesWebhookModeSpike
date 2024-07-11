var builder = DistributedApplication.CreateBuilder(args);


var api = builder.AddProject<Projects.WebhookApi>("webhook-api");





builder.Build().Run();
