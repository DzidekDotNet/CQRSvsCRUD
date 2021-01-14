#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CQRS vs CRUD/CQRS vs CRUD.csproj", "CQRS vs CRUD/"]
RUN dotnet restore "CQRS vs CRUD/CQRS vs CRUD.csproj"
COPY . .
WORKDIR "/src/CQRS vs CRUD"
RUN dotnet build "CQRS vs CRUD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRS vs CRUD.csproj" -c Release -o /app/publish

FROM base AS waitForMsSql
RUN apt-get update && apt-get install -y wget
ENV DOCKERIZE_VERSION v0.6.1
RUN wget https://github.com/jwilder/dockerize/releases/download/$DOCKERIZE_VERSION/dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz \
    && tar -C /usr/local/bin -xzvf dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz \
    && rm dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz

FROM waitForMsSql AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRS vs CRUD.dll"]