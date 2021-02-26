# Notes Api

This project is written with .Net Core 5.

To build and run the project, execute the command `dotnet run` from within the /NotesApi folder. Notes will be written/updated/deleted from the included notes.json file.

Navigate to https://localhost:5001/swagger to use Swagger to explore the API. Endpoints may also be called via HTTP methods, with the following endpoints available

- GET /Notes - Get all Notes  
- GET /Notes/{id} - Get a specific Note
- POST /Notes - Create a new Note
- PUT /Notes/{id} - Edit an existing Note    
- DELETE /Notes/{id} - Delete an existing Note

Tests can be run to confirm functionality of each of the above endpoints using the `dotnet test` command within the /NotesApi folder.