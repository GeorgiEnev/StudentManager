# 🎓 StudentManager AI-Powered Web App

A full-featured ASP.NET MVC application designed to manage Students, Exams, and Results — supercharged with **local AI integration** using [Ollama](https://ollama.com/). This solution combines a structured MVC architecture, SQL-backed persistence, and advanced AI features to deliver a modern educational administration tool.

---

## ✨ Overview

StudentManager is a web-based system that allows users (e.g., teachers or admins) to:

- Create and manage student records.
- Schedule and assign exams.
- Record and visualize exam results.
- Generate AI-powered insights or suggestions using local large language models (LLMs).
- Choose between **SQLite** for lightweight local testing or **SQL Server** for production-scale reliability.

Whether you're a developer, teacher, or institution exploring hybrid data+AI platforms — this app offers both utility and flexibility.

---

## ⚙️ Core Technologies

| Layer              | Stack                               |
|-------------------|--------------------------------------|
| **Backend**        | ASP.NET Core MVC (C#)               |
| **Frontend**       | Razor Views, HTML5, Bootstrap CSS   |
| **AI Engine**      | Ollama (Local LLMs: DeepSeek, LLaMA, etc.) |
| **Database**       | SQLite (Dev), SQL Server (Prod)     |
| **Tooling**        | Entity Framework Core, LINQ         |
| **Others**         | Identity, Model Validation, Logging |

---

## 📚 Key Features

### 🧑 Student Management
- Add/edit/delete student profiles
- View searchable lists
- Connect students to exams

### 📝 Exam & Result Management
- Create exams
- Record scores by student
- Display results in table views

### 🤖 AI Integration via Ollama
- Connects to a local Ollama instance (no external API required)
- Generates contextual suggestions (e.g. feedback based on scores)
- Model-agnostic: use DeepSeek, LLaMA, or others

### 🧩 Modular Architecture
- Fully separated MVC layers
- Razor layout system with custom styling (`exam-index.css`)
- Dynamic rendering with `ViewBag`, sections, and partials

### ⚒️ Configurable Database Support
- Easily swap between SQLite and SQL Server via `appsettings.json`
- Database migrations supported via EF Core

---

## 🛠️ Getting Started

### ✅ Prerequisites

- [.NET 6+ SDK](https://dotnet.microsoft.com/)
- [Ollama](https://ollama.com/)
- Visual Studio 2022+ or VS Code
- SQL Server (for production use)
- SQLite (optional for local development)

---

### 🔧 Setup Instructions

#### 1. Clone the Repository

```bash
git clone https://github.com/GeorgiEnev/StudentManager.git
cd StudentManager
