#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Casino.Slot/Casino.Slot.csproj", "Casino.Slot/"]
COPY ["Casino.Common/Casino.Common.csproj", "Casino.Common/"]
RUN dotnet restore "Casino.Slot/Casino.Slot.csproj"
COPY . .
WORKDIR "/src/Casino.Slot"
RUN dotnet build "Casino.Slot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Casino.Slot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Casino.Slot.dll"]