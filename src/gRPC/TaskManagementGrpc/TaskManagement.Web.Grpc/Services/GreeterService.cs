// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using Grpc.Core;

namespace AnishCeDev.TaskManagement.Web.Grpc.Services
{
    public class GreeterService(ILogger<GreeterService> logger) : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            logger.LogInformation("The message is received from {Name}", request.Name);

            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
