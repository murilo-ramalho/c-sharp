FROM mcr.microsoft.com/dotnet/sdk:10.0

WORKDIR /src

ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet tool install --global dotnet-ef --version 10.0.10

COPY docker-entrypoint.sh /usr/local/bin/docker-entrypoint.sh
RUN chmod +x /usr/local/bin/docker-entrypoint.sh

EXPOSE 8080

ENTRYPOINT ["/usr/local/bin/docker-entrypoint.sh"]
