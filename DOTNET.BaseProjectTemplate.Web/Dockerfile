FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["DOTNET.BaseProjectTemplate.Web/DOTNET.BaseProjectTemplate.Web.csproj", "DOTNET.BaseProjectTemplate.Web/"]
RUN dotnet restore "DOTNET.BaseProjectTemplate.Web/DOTNET.BaseProjectTemplate.Web.csproj"
COPY . .
WORKDIR "/src/DOTNET.BaseProjectTemplate.Web"
RUN dotnet build "DOTNET.BaseProjectTemplate.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DOTNET.BaseProjectTemplate.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DOTNET.BaseProjectTemplate.Web.dll"]