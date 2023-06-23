#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ans.file.worker.api/ans.file.worker.api.csproj", "ans.file.worker.api/"]
RUN dotnet restore "ans.file.worker.api/ans.file.worker.api.csproj"
COPY . .
WORKDIR "/src/ans.file.worker.api"
RUN dotnet build "ans.file.worker.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ans.file.worker.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ans.file.worker.api.dll"]