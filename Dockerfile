FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
COPY ["API/API.xml", "/app/"]
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["API/API.csproj", "API/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["TestLibrary/TestLibrary.csproj", "TestLibrary/"]
RUN dotnet restore "API/API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "API.dll"]
