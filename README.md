# Example Web Service

A simple ASP.NET Core Web API that stores a list of words in memory with:
- GET `/api/words` – get all words
- POST `/api/words?value=some-word` – add a new word
- Swagger UI available at `/swagger`

## Prerequisites

- .NET 8 SDK

## Setup

Install .NET SDK:
```bash
sudo apt install -y dotnet-sdk-8.0
```

## Build

```bash
dotnet publish -c Release -r linux-x64 --self-contained false
```

## Run

HTTP:
```bash
dotnet publish/ExampleWebService.dll --urls "http://0.0.0.0:5000"
```

HTTPS:
```bash
dotnet publish/ExampleWebService.dll --urls "https://0.0.0.0:5001"
```

> For HTTPS, ensure the development certificate is trusted:
> ```bash
> dotnet dev-certs https --trust
> ```

## Access

- API: `http://localhost:5000/api/words`
- Swagger UI: `http://localhost:5000/swagger`