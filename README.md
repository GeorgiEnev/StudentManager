# StudentManager

An **ASP.NET Core MVC** application for managing school data—teachers, subjects, and exams—complete with user authentication and an optional AI‑powered study assistant.

# Table of Contents
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Prerequisites and Setup](#prerequisites-and-setup)
- [Configure the Environment](#configure-the-environment)
- [Database Setup & Migrations](#database-setup--migrations)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)
- [.gitignore Quick Reference](#gitignore-quick-reference)

# Features
- 🗝 **Authentication & Authorization** with ASP.NET Identity  
- 👩‍🏫 **Teachers** – full CRUD  
- 📚 **Subjects** – linked to teachers  
- 📝 **Exams** – schedule date, time, location, status  
- ✨ Modern **glassmorphic UI** with animated background & cards  
- 📱 Fully **responsive** (desktop → mobile)  
- 🤖 Optional **AI Study Assistant** (OpenAI ChatGPT)  

# Tech Stack

| Layer     | Technology                           |
|-----------|--------------------------------------|
| Backend   | ASP.NET Core MVC (.NET 8)            |
| Database  | SQLite via Entity Framework Core     |
| Auth      | ASP.NET Core Identity                |
| Front‑end | Razor, HTML, CSS, jQuery             |
| Styling   | Custom CSS, Font Awesome             |
| AI (opt.) | OpenAI Chat Completion API           |

# Prerequisites and Setup

| Tool                | Version  | Purpose                        |
|---------------------|----------|--------------------------------|
| .NET SDK            | 8.0+     | Build & run the application    |
| Git                 | Latest   | Version control                |
| Visual Studio       | 2022+    | IDE (with ASP.NET workload)    |
| Node.js (optional)  | 16+      | Front‑end tooling              |
| SQLite CLI / GUI    | Optional | Inspect `studentmanager.db`    |

### Clone the Repository
```bash
git clone https://github.com/<GeorgiEnenv>/StudentManager.git
cd StudentManager/StudentManager
```
# Configure the Environment
## Connection String
appsettings.json is pre‑configured for:
SQLite: "ConnectionStrings": {  
"DefaultConnection": "Data Source=studentmanager.db"
}  

To use another database provider (e.g., SQL Server), update this string and install the corresponding EF Core package.
## OpenAI API Key (Optional)
Using User Secrets (recommended for development)
- dotnet user-secrets init
- dotnet user-secrets set "OpenAI:ApiKey" "sk-xxxxxxxxxxxxxxxx"

# Database Setup & Migrations 
```bash
# Install EF Core CLI (once per machine)
dotnet tool install --global dotnet-ef
# Restore NuGet packages
dotnet restore
# Create the initial migration (if not already present)
dotnet ef migrations add InitialCreate
# Apply migrations to generate/update the SQLite database
dotnet ef database update
```
# Project Structure
```text
StudentManager/
├── Controllers/
│   ├── AccountController.cs
│   ├── TeachersController.cs
│   ├── SubjectsController.cs
│   ├── ExamsController.cs
│   └── AiController.cs
│
├── Models/
│   ├── AppDbContext.cs
│   ├── Teacher.cs
│   ├── Subject.cs
│   └── Exam.cs
│
├── Views/
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── Teachers/
│   ├── Subjects/
│   ├── Exams/
│   │   └── Index.cshtml
│   └── Ai/
│
├── wwwroot/
│   ├── css/
│   │   └── exam-index.css
│   └── lib/
│       ├── jquery/
│       └── fontawesome/
│
├── Program.cs
├── appsettings.json
└── studentmanager.db
```

# Contributing
1. Fork the repository
2. Clone your fork locally
3. Create a feature branch:
```bash
git checkout -b feature/my-feature
```
4. Make your changes and commit:
```bash
git add .
git commit -m "feat: describe your change"
```
5. Push to GitHub:
```bash
git push origin feature/my-feature
```
6. Open a Pull Request against the main branch

# License
<details> <summary>Show MIT License</summary>
MIT License  
  
Copyright (c) 2025 Georgi Enev

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
</details>

# .gitignore Quick Reference

Below is a summary of the most important ignore rules for this project.  Copy these into your **.gitignore** file at the repo root.

```gitignore
# =====================================
# Build & published output
# =====================================
bin/
obj/
publish/

# =====================================
# User‐specific / IDE files
# =====================================
.vs/                 # Visual Studio settings
*.user               # .NET user profiles
*.suo                # Solution user options
.idea/               # Rider / IntelliJ
.vscode/             # VS Code

# =====================================
# OS‐generated files
# =====================================
.DS_Store            # macOS Finder
Thumbs.db            # Windows Explorer

# =====================================
# Logs & temporary files
# =====================================
*.log
*.tmp
*.temp

# =====================================
# Database files
# =====================================
*.db
*.sqlite

# =====================================
# Secrets & credentials
# =====================================
secrets.json
appsettings.Development.json

# =====================================
# Front‑end dependencies
# =====================================
node_modules/

# =====================================
# Coverage & test results
# =====================================
coverage/
TestResults/
```




