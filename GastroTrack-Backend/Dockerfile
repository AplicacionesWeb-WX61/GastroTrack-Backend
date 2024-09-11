FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copia todos los archivos del proyecto al contenedor
COPY . ./

# Restaura dependencias
RUN dotnet restore

# Compila y publica el proyecto
RUN dotnet publish -c Release -o out

# Construye la imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

# Copia los archivos compilados desde la imagen de construcción
COPY --from=build-env /App/out .

# Expone el puerto en el que la aplicación escuchará
EXPOSE 80

# Comando para ejecutar la aplicación
CMD ["dotnet", "GastroTrack-Backend.dll"]