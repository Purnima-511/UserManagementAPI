# User Management API

An ASP.NET Core Web API demo implementing user CRUD endpoints, DataAnnotations validation, and request/response logging middleware.

## Requirements
- .NET 8 SDK

## Run
```bash
dotnet restore
dotnet run
```
Open the Swagger URL printed in the terminal (typically `/swagger` in Development).

## Endpoints
| Method | Route | Purpose |
|---|---|---|
| GET | `/api/users` | List users |
| GET | `/api/users/{id}` | Get one user |
| POST | `/api/users` | Create user |
| PUT | `/api/users/{id}` | Update user |
| DELETE | `/api/users/{id}` | Delete user |

Example request body:
```json
{
  "name": "Purnima",
  "email": "purnima@example.com",
  "age": 21
}
```

## Validation
`[ApiController]` enables automatic HTTP 400 responses for invalid model state. Name, email, and age use DataAnnotations.

## Middleware
`LoggingMiddleware` logs request method/path and response status.

## Note
This sample uses an in-memory static list for demonstration. Data does not persist after restarting the app. Review and adapt it to your previous coursework before submission.
