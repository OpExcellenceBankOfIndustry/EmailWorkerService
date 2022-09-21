#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BOI_WorkerService/BOI_WorkerService.csproj", "BOI_WorkerService/"]
RUN dotnet restore "BOI_WorkerService/BOI_WorkerService.csproj"
COPY . .
WORKDIR "/src/BOI_WorkerService"
RUN dotnet build "BOI_WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BOI_WorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BOI_WorkerService.dll"]