FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY dist /app

COPY node_modules/wait-for-it.sh/bin/wait-for-it /app/wait-for-it.sh

RUN chmod +x /app/wait-for-it.sh

RUN sed -i 's/TLSv1.2/TLSv1.0/g' /etc/ssl/openssl.cnf

WORKDIR /app

EXPOSE 80

ENV ASPNETCORE_URLS http://+:80

ENV WAITHOST=mysql WAITPORT=3306

ENTRYPOINT ./wait-for-it.sh $WAITHOST:$WAITPORT --timeout=0 \
    && exec dotnet ExampleApp.dll