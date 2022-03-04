FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
EXPOSE 80

COPY bin/Debug/net6.0 .

ENTRYPOINT ["dotnet", "RootNamesoace.Api.dll"]