#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Microservices/VacanciesMS/VacanciesMS.WebApi/VacanciesMS.WebApi.csproj", "src/Microservices/VacanciesMS/VacanciesMS.WebApi/"]
RUN dotnet restore "src/Microservices/VacanciesMS/VacanciesMS.WebApi/VacanciesMS.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Microservices/VacanciesMS/VacanciesMS.WebApi"
RUN dotnet build "VacanciesMS.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VacanciesMS.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VacanciesMS.WebApi.dll"]