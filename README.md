# 🎵 Sound Vault App

**A Blazor-based application for managing musical genres, artists, and albums. A complete CRUD solution with .NET and SQL.**

---

## 📅 Changelog

<<<<<<< HEAD
- **2025-03-31**: Initial commit. Added backend architecture (Onion + patterns), frontend login module, and appointment request feature.
- **2025-05-09**: Added Login module. Add Artits module. Add entities: Users, Artits and nationalities.


---

## 🎯 Objective

This project was created to practice key technologies including:

- **.NET (C#)** and **SQL Server**
- **Blazor (Razor Components)**
- **Dapper** for database access
- **Design Patterns & Layered Architecture**

---

## 🚀 Features

### 🛠️ Backend

- **.NET Core 9.0.0 (Visual Studio Community 2022)**
- **C#**
- **Dapper 2.1.66**
- **Design Patterns**:
  - Base Entity
  - Data Transfer Objects (DTOs)
- **Key Libraries**:
  - 🔐 **Encryption**:
    - `BCrypt.Net-Next`
    - `System.Security.Cryptography` (AES-256)
  - 🧾 **Logging**:
    - `Serilog`
    - `Serilog.Extensions.Logging`
    - `Serilog.Sinks.File`
  - 🧩 **Database Access**:
    - `Dapper`
    - `Microsoft.Data.SqlClient`

---

### 💻 Frontend

- Built with **Blazor Server**
- Developed in **.NET Core 9.0.0**
- UI Framework: **Bootstrap 5**
- Data Visualization: **Chart.js** via `ChartJs.Blazor 1.1.0`

**Features**:
- 🔒 Authentication with `ProtectedLocalStorage`
- 🔁 Session persistence and restoration
- 🚪 Logout and layout components
- 📊 Charts via JavaScript interop

---

### 🗃️ Database

- **SQL Server** (using **SQL Express**)
- Includes:
  - 🧬 Entity-Relationship Diagram (ERD)
  - 🧾 DDL Scripts for table creation
  - 📥 DML Scripts for inserting sample data

---

## 🧪 Installation

### ✅ Prerequisites

Make sure you have the following installed:

- [.NET SDK 9.0.200](https://dotnet.microsoft.com/)
- [SQL Server Express 2022](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- [SQL Server Management Studio 20.2.30.0](https://learn.microsoft.com/es-es/ssms/download-sql-server-management-studio-ssms)
- [Postman 11.44.3](https://www.postman.com/downloads/)

---

### ⚙️ Setup Steps

1. Clone the repository:

   ```bash
   git clone https://github.com/waltermillan/SoundVault.git
