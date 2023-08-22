FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Копирование проектов и восстановление зависимостей
COPY ./BookStore.Application/BookStore.Application.csproj ./BookStore.Application/
COPY ./BookStore.Domain/BookStore.Domain.csproj ./BookStore.Domain/
COPY ./BookStore.Infrastructure/BookStore.Infrastructure.csproj ./BookStore.Infrastructure/
COPY ./BookStore.Persistence/BookStore.Persistence.csproj ./BookStore.Persistence/
COPY ./BookStore.API/BookStore.API.csproj ./BookStore.API/
RUN dotnet restore "./BookStore.API/BookStore.API.csproj"

# Копирование всех файлов и сборка приложения
COPY . .
WORKDIR /app/BookStore.API
RUN dotnet build -c Release -o /app/build

# Публикация приложения
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish --verbosity normal

# Окончательный образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "BookStore.API.dll" ]