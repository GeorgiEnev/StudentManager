# StudentManager

An **ASP.NET Core MVC** application for managing school data—teachers, subjects, and exams—complete with user authentication and an experimental AI‑powered study helper.

---

## Table of Contents

1. [Features](#features)  
2. [Tech Stack](#tech-stack)  
3. [Prerequisites & Setup](#prerequisites--setup)  
4. [Configure the Environment](#configure-the-environment)  
5. [Database Setup & Migrations](#database-setup--migrations)  
6. [Running the App](#running-the-app)  
7. [AI Tutor Setup (Optional)](#ai-tutor-setup-optional)  
8. [Project Structure](#project-structure)  
9. [Contributing](#contributing)  
10. [License](#license)  

---

## Features

- ✅ User registration, login, and authentication using ASP.NET Core Identity  
- ✅ CRUD functionality for:
  - Teachers  
  - Subjects (linked to teachers)  
  - Exams (linked to subjects with schedule, location, and status)  
- ✅ Modern, animated **glassmorphic UI** with dynamic exam cards  
- ✅ Animated background and floating particle effects  
- ✅ Mobile-friendly and responsive layout  
- ✅ Optional **AI-powered chat assistant** for study help (uses OpenAI API)

---

## Tech Stack

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core (with SQLite)
- ASP.NET Identity (for user authentication)
- Custom CSS with animations and gradients
- Font Awesome (icons)
- jQuery (form validation & tooltips)
- Optional OpenAI integration via `HttpClient`

---

## Prerequisites & Setup

### Required

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Git
- SQLite (or just use the `.db` file included)
- Visual Studio 2022 or VS Code + C# extension

### Recommended

- Node.js (if you want frontend tooling like minification or bundling)
- SQLite Browser (for inspecting the database)

### Clone the Repository

```bash
git clone https://github.com/<your-username>/StudentManager.git
cd StudentManager/StudentManager

##Configure the Environment
The app is preconfigured to use SQLite and local appsettings.json:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Data Source=studentmanager.db"
}
If you want to store secrets (e.g., OpenAI API key), use either:

Option 1: Environment Variables
bash
Copy
Edit
# Windows
setx OPENAI_API_KEY "sk-..."
setx ASPNETCORE_ENVIRONMENT "Development"

# macOS/Linux
export OPENAI_API_KEY="sk-..."
export ASPNETCORE_ENVIRONMENT=Development
Option 2: User Secrets
bash
Copy
Edit
dotnet user-secrets init
dotnet user-secrets set "OpenAI:ApiKey" "sk-..."
Then retrieve via Configuration["OpenAI:ApiKey"] in Program.cs.

Database Setup & Migrations
Install EF Core CLI (if needed)

bash
Copy
Edit
dotnet tool install --global dotnet-ef
Restore packages

bash
Copy
Edit
dotnet restore
Create and apply migrations

bash
Copy
Edit
dotnet ef migrations add InitialCreate
dotnet ef database update
This will generate and apply the schema to studentmanager.db.

Running the App
Via CLI
bash
Copy
Edit
dotnet run
Then visit: https://localhost:5001

Via Visual Studio
Open StudentManager.sln

Set as Startup Project

Hit F5 or Ctrl+F5 to build and launch

AI Tutor Setup (Optional)
If you want to enable the AI chat feature (available at /Ai/Chat):

Set your OpenAI API key via secrets or env variable.

In Program.cs, register the OpenAI client:

csharp
Copy
Edit
builder.Services.AddHttpClient("openai", c =>
{
    c.BaseAddress = new Uri("https://api.openai.com/v1/");
    c.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", Configuration["OpenAI:ApiKey"]);
});
Launch the app and navigate to /Ai/Chat

Project Structure
graphql
Copy
Edit
StudentManager/
├── Controllers/
│   ├── AccountController.cs        # Login/Register
│   ├── HomeController.cs           # Landing pages
│   ├── TeachersController.cs       # CRUD for teachers
│   ├── SubjectsController.cs       # CRUD for subjects
│   ├── ExamsController.cs          # CRUD for exams
│   └── AiController.cs             # AI chat endpoint
│
├── Models/
│   ├── AppDbContext.cs             # EF Core context
│   ├── Teacher.cs
│   ├── Subject.cs
│   └── Exam.cs
│
├── Views/
│   ├── Shared/                     # _Layout, _ValidationScripts, etc.
│   ├── Account/
│   ├── Home/
│   ├── Teachers/
│   ├── Subjects/
│   ├── Exams/
│   └── Ai/
│
├── wwwroot/
│   ├── css/
│   │   └── exam-index.css          # Custom glassmorphic styling
│   ├── lib/                        # Static libraries (jQuery, FontAwesome)
│   └── js/
│
├── studentmanager.db               # SQLite database file (created at runtime)
├── appsettings.json
├── Program.cs
└── README.md
Contributing
We welcome contributions! To contribute:

Fork the repo

Create a new branch:

bash
Copy
Edit
git checkout -b feature/my-feature
Commit your changes:

bash
Copy
Edit
git add .
git commit -m "Add: your description"
git push origin feature/my-feature
Open a Pull Request on GitHub

License
This project is licensed under the MIT License. See LICENSE for details.
