# 🧠 Quiz Platform – C# .NET + Oracle DB

A Windows Forms-based quiz application developed using **C# (.NET Framework)** and connected to an **Oracle Database**. Students can register, log in, attempt quizzes with a countdown timer, and view previous results.

---

## 📌 Features

- 🔐 **Student Registration & Login**
- 📚 **Category-wise Quiz Selection**
- ⏱️ **Quiz Timer (Countdown from 10 mins)**
- ✅ **Multiple Choice Questions (MCQs) with 4 options**
- 📊 **Score Tracking**
- 🗂️ **Previous Results View**
- 🧠 **Correct Answer Evaluation**
- 📅 **Date & Time of Attempt Recorded**
- 🔙 **Back Navigation for User Convenience**

---

## 🏗️ Technology Stack

| Component      | Tech Used                     |
|----------------|-------------------------------|
| Frontend       | Windows Forms (WinForms)      |
| Backend        | C# (.NET Framework)           |
| Database       | Oracle XE                     |
| Database Access| Oracle.ManagedDataAccess (ODP.NET) |
| IDE            | Visual Studio                 |

---

## 📁 Project Structure
Quiz_Plateform/
├── Forms/
│ ├── LoginForm.cs
│ ├── RegisterForm.cs
│ ├── Dashboard.cs
│ ├── quizForm.cs
│ ├── ResultForm.cs
│ └── PreviousResults.cs
├── DatabaseConfig.cs ← Global connection string
├── Program.cs
├── README.md
└── .sln

