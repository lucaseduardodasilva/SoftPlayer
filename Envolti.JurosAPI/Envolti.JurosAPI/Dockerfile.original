#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY Envolti.JurosAPI/Envolti.JurosAPI.csproj Envolti.JurosAPI/
COPY Envolti.IoC/Envolti.IoC.csproj Envolti.IoC/
COPY Envolti.Servicos/Envolti.Servicos.csproj Envolti.Servicos/
COPY Envolti.Interfaces/Envolti.Interfaces.csproj Envolti.Interfaces/
RUN dotnet restore Envolti.JurosAPI/Envolti.JurosAPI.csproj
COPY . .
WORKDIR /src/Envolti.JurosAPI
RUN dotnet build Envolti.JurosAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Envolti.JurosAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Envolti.JurosAPI.dll"]
