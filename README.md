## Specyfikacja Techniczna

### Opis Klas i Metod

#### Warstwa Aplikacji (.NET 8.0)

1. **Controllers**
   - **UserController**
     - `GetUser(int id)`: Zwraca użytkownika o podanym ID.
     - `CreateUser(UserDto userDto)`: Tworzy nowego użytkownika.
     - `UpdateUser(int id, UserDto userDto)`: Aktualizuje dane użytkownika o podanym ID.
     - `DeleteUser(int id)`: Usuwa użytkownika o podanym ID.

2. **Services**
   - **UserService**
     - `GetUser(int id)`: Pobiera użytkownika z repozytorium.
     - `CreateUser(UserDto userDto)`: Dodaje nowego użytkownika do repozytorium.
     - `UpdateUser(int id, UserDto userDto)`: Aktualizuje dane użytkownika w repozytorium.
     - `DeleteUser(int id)`: Usuwa użytkownika z repozytorium.

3. **Repositories**
   - **UserRepository**
     - `GetById(int id)`: Pobiera użytkownika z bazy danych.
     - `Add(User user)`: Dodaje nowego użytkownika do bazy danych.
     - `Update(User user)`: Aktualizuje dane użytkownika w bazie danych.
     - `Delete(int id)`: Usuwa użytkownika z bazy danych.

#### Warstwa Prezentacji (Angular)

1. **Components**
   - **UserComponent**
     - `ngOnInit()`: Inicjalizuje dane użytkownika.
     - `createUser()`: Wywołuje serwis do stworzenia nowego użytkownika.
     - `updateUser()`: Wywołuje serwis do aktualizacji danych użytkownika.
     - `deleteUser()`: Wywołuje serwis do usunięcia użytkownika.

2. **Services**
   - **UserService**
     - `getUser(id: number)`: Pobiera dane użytkownika z API.
     - `createUser(user: User)`: Wysyła żądanie do API w celu stworzenia nowego użytkownika.
     - `updateUser(id: number, user: User)`: Wysyła żądanie do API w celu aktualizacji danych użytkownika.
     - `deleteUser(id: number)`: Wysyła żądanie do API w celu usunięcia użytkownika.

### Wykorzystane Biblioteki

1. **.NET 8.0**
   - Entity Framework Core
   - ASP.NET Core

2. **Angular**
   - Angular CLI
   - RxJS
   - Angular Forms

### Sposób Kompilacji Aplikacji

#### Backend (.NET 8.0)

Aby zaktualizować bazę danych za pomocą migracji w projekcie .NET z Entity Framework, wykonaj następujące kroki:

### Aktualizacja bazy danych migracją

1. **Otwórz terminal w katalogu projektu backendowego.**
2. **Wykonaj migrację bazy danych:**

   Użyj polecenia `dotnet ef` do zastosowania migracji. Upewnij się, że masz zainstalowane narzędzie Entity Framework CLI (dotnet-ef). Jeśli nie, możesz je zainstalować za pomocą polecenia:
   ```bash
   dotnet tool install --global dotnet-ef
   ```

3. **Zastosuj migracje:**

   Wykonaj poniższe polecenie, aby zastosować wszystkie dostępne migracje do bazy danych:
   ```bash
   dotnet ef database update
   ```

### Przykład:

```bash
cd /path/to/your/project
dotnet ef database update
```

Po wykonaniu tych kroków baza danych zostanie zaktualizowana zgodnie z wszystkimi zdefiniowanymi migracjami. Teraz możesz uruchomić aplikację.

### Uruchomienie aplikacji

#### Backend (.NET 8.0)

```bash
dotnet run
```

#### Frontend (Angular)

```bash
ng serve
```

1. Otwórz terminal w katalogu projektu backendowego.
2. Wykonaj polecenie:
   ```bash
   dotnet build
   ```
3. Aby uruchomić aplikację, użyj polecenia:
   ```bash
   dotnet run
   ```

#### Frontend (Angular)

1. Otwórz terminal w katalogu projektu frontendowego.
2. Zainstaluj zależności:
   ```bash
   npm install
   ```
3. Skompiluj aplikację:
   ```bash
   ng build
   ```
4. Aby uruchomić aplikację w trybie deweloperskim, użyj polecenia:
   ```bash
   ng serve
   ```

### Architektura

Aplikacja została zaprojektowana w stylu architektury heksagonalnej, co pozwala na rozdzielenie logiki biznesowej od infrastruktury. Dzięki temu logika biznesowa jest zamknięta w serwisach, które komunikują się z repozytoriami odpowiedzialnymi za dostęp do danych.
