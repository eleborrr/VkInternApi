FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VkInternApi/VkInternApi.csproj", "VkInternApi/"]
RUN dotnet restore "VkInternApi/VkInternApi.csproj"
COPY . .
WORKDIR "/src/VkInternApi"
RUN dotnet build "VkInternApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VkInternApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VkInternApi.dll"]
