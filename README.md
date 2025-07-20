# StudentManager

An **ASP.NET Core MVC** application for managing school data—teachers, subjects, and exams—complete with user authentication and an optional AI‑powered study assistant.

## Table of Contents
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Prerequisites and Setup](#prerequisites-and-setup)
- [Configure the Environment](#configure-the-environment)
- [Database Setup & Migrations](#database-setup--migrations)
- [Running the App](#running-the-app)
- [AI Tutor Setup (Optional)](#ai-tutor-setup-optional)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)
- [.gitignore Quick Reference](#gitignore-quick-reference)

## Features
- 🗝 **Authentication & Authorization** with ASP.NET Identity  
- 👩‍🏫 **Teachers** – full CRUD  
- 📚 **Subjects** – linked to teachers  
- 📝 **Exams** – schedule date, time, location, status  
- ✨ Modern **glassmorphic UI** with animated background & cards  
- 📱 Fully **responsive** (desktop → mobile)  
- 🤖 Optional **AI Study Assistant** (OpenAI ChatGPT)  

## Tech Stack

| Layer     | Technology                           |
|-----------|--------------------------------------|
| Backend   | ASP.NET Core MVC (.NET 8)            |
| Database  | SQLite via Entity Framework Core     |
| Auth      | ASP.NET Core Identity                |
| Front‑end | Razor, HTML, CSS, jQuery             |
| Styling   | Custom CSS, Font Awesome             |
| AI (opt.) | OpenAI Chat Completion API           |

## Prerequisites and Setup

| Tool                | Version  | Purpose                        |
|---------------------|----------|--------------------------------|
| .NET SDK            | 8.0+     | Build & run the application    |
| Git                 | Latest   | Version control                |
| Visual Studio       | 2022+    | IDE (with ASP.NET workload)    |
| Node.js (optional)  | 16+      | Front‑end tooling              |
| SQLite CLI / GUI    | Optional | Inspect `studentmanager.db`     |


