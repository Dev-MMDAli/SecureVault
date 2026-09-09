<div align="center">

# 🔐 SecureVault

**A secure backend API built with ASP.NET Core 8 (LTS) for password management.**

[![.NET 8](https://img.shields.io/badge/.NET-8-512bd4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite)](https://www.sqlite.org/)
[![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=jsonwebtokens)](https://jwt.io/)
</div>
<br />

## 📖 What it does

SecureVault is designed to be a safe place for sensitive data. The main goal was to build a system where passwords are never stored in plain text and users are completely isolated from one another.

The API handles everything from user registration and login (via JWT) to the full CRUD cycle of password entries. 

**Key capabilities:**
- Secure login and session management using JWT.
- Encryption of stored passwords using AES.
- User account protection with BCrypt hashing.
- Strict ownership checks so users only see their own data.
- Interactive API testing through Swagger.

<br />

## 🛠️ Tech Stack

<div align="center">

| Component | Technology |
| :--- | :--- |
| **Framework** | `ASP.NET Core 8 Web API` |
| **Database** | `SQLite` |
| **ORM** | `Entity Framework Core` |
| **Auth** | `JWT Bearer Tokens` |
| **Encryption** | `AES & BCrypt` |

</div>

<br />

## 🏗️ Project Layout

<details>
<summary><b>📂 Click to expand project structure</b></summary>

```SecureVault/
├── Controllers/          # API Endpoints
├── Services/             # Business logic & Security helpers
├── Repositories/         # Database queries
├── Models/               # DB Entities
├── DTOs/                 # Request/Response objects
├── Interfaces/           # Contracts for services/repos
├── Data/                 # DbContext & Migrations
└── Program.cs            # App configuration
```

</details>

<br />

## 📚 API Endpoints

### 🔑 Auth
- `POST /api/auth/register` &rarr; Create an account.
- `POST /api/auth/login` &rarr; Get a JWT token.

### 🔐 Passwords (Requires Auth)
- `GET /api/password` &rarr; List all your passwords.
- `GET /api/password/{id}` &rarr; Get one specific entry.
- `POST /api/password` &rarr; Save a new password.
- `PATCH /api/password/{id}` &rarr; Update an entry.
- `DELETE /api/password/{id}` &rarr; Remove an entry.

<br />

## 🚀 Getting Started

### Requirements
- .NET 8 SDK
- Git

### Setup

1. **Clone the repo:**

   ```
   git clone https://github.com/Dev-MMDAli/SecureVault.git
   cd SecureVault
2. **Restore and configure:**

   ```
   dotnet restore
   copy appsettings.example.json appsettings.json
3. **Set your keys in appsettings.json:**

   ```
   JwtSettings:Secret (min 32 chars)
   Encryption:Key (32 chars)
   Encryption:IV (16 chars)
4. **Start the app:**

   ```
   dotnet ef database update
   dotnet run

Then open `http://localhost:5000/swagger` in your browser.

🛡️ How security is handled
I implemented a layered security approach to make sure the data stays safe. For user accounts, I used BCrypt to hash passwords before they hit the database, which means the original passwords can't be recovered even if the database is leaked.

For the actual passwords that users save in the vault, I used AES encryption. The data is encrypted before being saved and only decrypted when the authorized user requests it. To prevent unauthorized access, every request is filtered by the `UserId` extracted from the JWT token, ensuring no one can access or modify another user's passwords.



<hr>
<div align="center">
<pre>
👤 Author
<b>Mohammad Ali Amiri</b>

[![GitHub](https://img.shields.io/badge/GitHub-Dev--MMDAli-black?logo=github)](https://github.com/Dev-MMDAli)
</pre>
</div>


