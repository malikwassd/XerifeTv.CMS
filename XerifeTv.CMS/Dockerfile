# Etapa 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia os arquivos .csproj e restaura dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o resto dos arquivos e faz o build da aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Configuração do ambiente de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expõe a porta 80 para o container
EXPOSE 88

# Comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "XerifeTv.CMS.dll"]