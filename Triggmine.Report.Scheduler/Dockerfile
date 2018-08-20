FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
#EXPOSE 65468
#EXPOSE 44375

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY NuGet.config  ./

COPY Triggmine.Report.Scheduler/Triggmine.Report.Scheduler.csproj Triggmine.Report.Scheduler/
COPY Triggmine.Report.Scheduler.Shared/Triggmine.Report.Scheduler.Shared.csproj Triggmine.Report.Scheduler.Shared/
COPY docker-compose.dcproj ./

RUN dotnet restore Triggmine.Report.Scheduler.sln --configfile NuGet.config

COPY . .
WORKDIR /src/Triggmine.Report.Scheduler
RUN dotnet build Triggmine.Report.Scheduler.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Triggmine.Report.Scheduler.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Triggmine.Report.Scheduler.dll"]
