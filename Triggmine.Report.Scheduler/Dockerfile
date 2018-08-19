FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 65468
EXPOSE 44375

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Triggmine.Report.Scheduler/Triggmine.Report.Scheduler.csproj Triggmine.Report.Scheduler/
RUN dotnet restore Triggmine.Report.Scheduler/Triggmine.Report.Scheduler.csproj
COPY . .
WORKDIR /src/Triggmine.Report.Scheduler
RUN dotnet build Triggmine.Report.Scheduler.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Triggmine.Report.Scheduler.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Triggmine.Report.Scheduler.dll"]
