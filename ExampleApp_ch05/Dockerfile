FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

RUN sed -i 's/TLSv1.2/TLSv1.0/g' /etc/ssl/openssl.cnf
 
COPY dist /app

WORKDIR /app

EXPOSE 80

ENV ASPNETCORE_URLS http://+:80

ENTRYPOINT ["dotnet", "ExampleApp.dll"]