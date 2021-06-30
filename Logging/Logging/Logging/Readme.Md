## Logging
Apply logging according to
https://docs.microsoft.com/en-us/dotnet/core/extensions/logging?tabs=command-line 

## LogLevels
Trace = 0, 
Debug = 1, 
Information = 2, 
Warning = 3, 
Error = 4, 
Critical = 5, 
None = 6.

When a LogLevel is specified, logging is enabled for messages at the specified level and higher.


.Net Core Logging https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-5.0

Logging providers store logs, except for the Console provider which displays logs.
To override the default set of logging providers added by Host.CreateDefaultBuilder, call ClearProviders and add the required logging providers.

MS officially recommends to use 3rd party file loggers. You can use serilog or nlog third party dlls.

## Configuration
How to create an application in the Spring ecosystem that can be freely configured? Let's assume our application displays the name "CodeCool" on the `/about` page. However, it turned out that we have a requirement from the client to have a second instance
display "CodeCool B2B" on this page.

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0

Using the configured values:
```Configuration["Position:Title"]```

set env for upcoming process:
set ASPNETCORE_ENVIRONMENT=Staging
dotnet run --no-launch-profile
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0#windows