# StudentManager

An **ASP.NET Core MVC** application for managing school data — teachers, subjects, and exams — complete with user authentication and an optional AI‑powered study assistant.

## Table of Contents
1. [Features](#1-features)  
2. [Tech Stack](#2-tech-stack)  
3. [Prerequisites & Setup](#3-prerequisites--setup)  
4. [Configure the Environment](#4-configure-the-environment)  
5. [Database Setup & Migrations](#5-database-setup--migrations)  
6. [Running the App](#6-running-the-app)  
7. [AI Tutor Setup (Optional)](#7-ai-tutor-setup-optional)  
8. [Project Structure](#8-project-structure)  
9. [Contributing](#9-contributing)  
10. [License](#10-license)  
11. [.gitignore Quick Reference](#11-gitignore-quick-reference)  

## 1. Features
- 🗝 **Authentication & Authorization** with ASP.NET Identity  
- 👩‍🏫 **Teachers** – create / read / update / delete  
- 📚 **Subjects** – linked to teachers  
- 📝 **Exams** – scheduled with date, time, location, status badges  
- ✨ Modern **glassmorphic UI** (animated background, floating cards)  
- 📱 Fully **responsive** (desktop → mobile)  
- 🤖 Optional **AI Study Assistant** (OpenAI ChatGPT)  

## 2. Tech Stack

| Layer     | Technology |
|-----------|------------|
| Backend   | **ASP.NET Core MVC** (.NET 8) |
| Database  | **SQLite** via Entity Framework Core |
| Auth      | **ASP.NET Identity** |
| Front‑end | Razor • HTML • CSS • jQuery |
| Styling   | Custom CSS, Font Awesome |
| AI (opt.) | OpenAI Chat Completion API |

## 3. Prerequisites & Setup

| Tool                | Min Version | Purpose |
|---------------------|-------------|---------|
| .NET SDK            | **8.0**     | Build & run the app |
| Visual Studio 2022  | 17.4+       | Full IDE (ASP.NET workload) |
| Git                 | Latest      | Version control |
| Node.js (optional)  | 16+         | Front‑end tooling (if desired) |
| SQLite CLI / GUI    | optional    | Inspect `studentmanager.db` |

### Clone the Repository
```bash
git clone https://github.com/<your‑username>/StudentManager.git
cd StudentManager/StudentManager
