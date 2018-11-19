FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["KubeSampleApi/KubeSampleApi.csproj", "KubeSampleApi/"]
RUN dotnet restore "KubeSampleApi/KubeSampleApi.csproj"
COPY . .
WORKDIR "/src/KubeSampleApi"
RUN dotnet build "KubeSampleApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KubeSampleApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KubeSampleApi.dll"]