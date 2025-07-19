# 📝 Full Stack Todo App

This is a full-stack Todo application built with:

- **Backend:** ASP.NET Core Web API, Entity Framework Core, MySQL, Repository Pattern
- **Frontend:** React, Vite, Bootstrap, Fetch API

---

## 📁 Project Structure

todo-fullstack/
│
├── Todo-Backend/ # ASP.NET Core Web API backend
├── frontend/ # React + Vite frontend
└── README.md

---

## 🚀 Features

### ✅ Backend
- Built with **ASP.NET Core Web API**
- Uses **EF Core** with **Pomelo.EntityFrameworkCore.MySql**
- Follows **Repository Pattern** for clean separation of concerns
- Connected to **MySQL database**
- Includes CRUD API endpoints:
  - `GET /api/todo`
  - `POST /api/todo`
  - `PUT /api/todo`
  - `DELETE /api/todo/{id}`

### ✅ Frontend
- Built using **React** with **Vite** as the build tool
- UI built using **Bootstrap**
- Uses native **Fetch API** to communicate with backend
- Features:
  - Add new task
  - Delete task
  - View task list (with timestamps)

---

## ⚙️ Getting Started

### 🔧 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- [Node.js](https://nodejs.org/) (for frontend)
- Git

---

## 🖥️ Backend Setup

```bash
cd Todo-Backend

# Install dependencies
dotnet restore

# Apply database migrations
dotnet ef database update

# Run the backend
dotnet run
Make sure to configure your appsettings.json:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=todo_db;User=root;Password=your_password;"
}
🌐 Frontend Setup
bash
Copy
Edit
cd frontend

# Install dependencies
npm install

# Run the Vite dev server
npm run dev
The frontend runs at:
📍 http://localhost:5173
