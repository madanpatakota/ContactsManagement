# Contacts Management API

### Setup
- Clone the repository.
- Restore dependencies:
  ```bash
  dotnet restore
  ```
- Run the application:
  ```bash
  dotnet run
  ```

### Design Decisions
- A JSON file is used for simplicity; however, a database (e.g., SQL Server) would be more suitable for scaling.

### API Endpoints
- `GET /api/contacts`
- `GET /api/contacts/{id}`
- `POST /api/contacts`
- `PUT /api/contacts/{id}`
- `DELETE /api/contacts/{id}`
