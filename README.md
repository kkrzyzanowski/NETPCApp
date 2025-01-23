## Technical Specification

### Class and Method Descriptions

#### Application Layer (.NET 8.0)

1. **Controllers**
   - **ContactController**
     - `GetById(int id)`: Returns a user with the specified ID.
     - `GetAll(int id)`: Returns all users.
     - `Create(ContactDto contactDto)`: Creates a new user.
     - `Update(int id, ContactDto contactDto)`: Updates user data for the specified ID.
     - `Delete(int id)`: Deletes a user with the specified ID.
    
   - **AuthorizationController**
     - `Login(UserDTO loginDto)`: Logs in a user with the provided credentials.

2. **Services**
   - **ContactService**
     - `GetContactByIdAsync(int id)`: Retrieves a user from the repository.
     - `GetAllContactsAsync()`: Retrieves all users from the repository.
     - `AddContactAsync(ContactDTO contactDTO)`: Adds a new user to the repository.
     - `UpdateContactAsync(int id, ContactDTO contactDTO)`: Updates user data in the repository.
     - `DeleteContactAsync(int id)`: Deletes a user from the repository.
    
   - **AuthService**
     - `LoginAsync(string email, string password)`: Logs in a user.
     - `HashPassword(string password)`: Encrypts the password.
     - `VerifyPassword(string password, string hashedPassword)`: Verifies the provided password.

3. **Repositories**
   - **ContactRepository**
     - `GetByIdAsync(int id)`: Retrieves a user from the database.
     - `GetAllAsync()`: Retrieves all users from the database.
    
   - **UserRepository**
     - `GetByEmailAsync(string email)`: Retrieves a user's email.

   - **BaseRepository**
     - Performs basic operations like add, update, and delete.

#### Presentation Layer (Angular)

1. **Components**
   - **ContactListComponent**
     - Displays a list of users with an option to add new ones.
   - **ContactFormComponent**
     - A form for editing user details.
   - **ContactDetailsComponent**
     - Displays user details with options to edit or delete the user.

2. **Services**
   - **AuthService**
     - Provides authentication methods like `login()`.
   - **ContactService**
     - Provides CRUD methods for contacts.

### Libraries Used

1. **.NET 8.0**
   - Entity Framework Core
   - ASP.NET Core

2. **Angular**
   - Angular CLI
   - RxJS
   - Angular Forms

### Compilation Instructions

#### Backend (.NET 8.0)

To update the database using migrations in a .NET project with Entity Framework, follow these steps:

### Updating the Database with Migrations

1. **Open the terminal in the backend project directory.**
2. **Apply the database migration:**

   Use the `dotnet ef` command to apply migrations. Ensure you have the Entity Framework CLI tool installed (dotnet-ef). If not, you can install it with the following command:
   ```bash
   dotnet tool install --global dotnet-ef
   ```

3. **Apply the migrations:**

   Execute the following command to apply all available migrations to the database:
   ```bash
   dotnet ef database update
   ```

### Example:

```bash
cd /path/to/your/project/
dotnet ef database update "/path/to/your/project/NETPCApp.Infrastructure/NETPCApp.Infrastructure.csproj" --startup-project "/path/to/your/project/NETPCApp.Server/NETPCApp.Server.csproj"
```

After completing these steps, the database will be updated according to all defined migrations. Now you can run the application.

### Running the Application

#### Backend (.NET 8.0)

```bash
dotnet run
```

#### Frontend (Angular)

```bash
ng serve
```

1. Open the terminal in the backend project directory.
2. Execute the command:
   ```bash
   dotnet build
   ```
3. To run the application, use the command:
   ```bash
   dotnet run
   ```

#### Frontend (Angular)

1. Open the terminal in the frontend project directory.
2. Install dependencies:
   ```bash
   npm install
   ```
3. Compile the application:
   ```bash
   ng build
   ```
4. To run the application in development mode, use the command:
   ```bash
   ng serve
   ```
5. Then, open a browser and navigate to `http://localhost:4200/login` and log in with the following credentials:
   - Email: `test@test.pl`
   - Password: `test`

This should redirect the application to the contacts list.

### Architecture

The application is designed using hexagonal architecture, which separates business logic from infrastructure. This ensures that business logic is encapsulated in services that communicate with repositories responsible for data access.
