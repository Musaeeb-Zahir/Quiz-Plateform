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
├── DatabaseConfig.cs ← Global    connection string   
├── Program.cs       
├── README.md   
└── .sln   

---

## 🧑‍💻 How to Run

1. 🔧 **Set up Oracle Database**  
   - Install [Oracle XE](https://www.oracle.com/database/technologies/xe-downloads.html)
   - Create required tables (`STUDENT`, `QUESTIONS`, `QUIZZES`, `RESULTS` etc.) OR just execute dataInsertion script and tableScript in Table folder on Oracle sql command line and COMMIT
   - Insert sample data.

2. ⚙️ **Configure Connection**  
   - Update the connection string in `DatabaseConfig.cs`:
     ```csharp
     public static readonly string ConnectionString =
         "User Id=system;Password=yourPassword;Data Source=localhost:1521/XE;";
     ```

3. 🛠️ **Build the Solution**  
   - Open the project in Visual Studio.
   - Build the solution (Ctrl + Shift + B).

4. ▶️ **Run the Application**  
   - Start the app.
   - Register a new student and begin the quiz.

---

## 🗃️ Database Tables Overview

| Table       | Description                         |
|-------------|-------------------------------------|
| STUDENT     | Stores student information          |
| QUIZZES     | Stores quiz titles & categories     |
| QUESTIONS   | Stores MCQs for each quiz           |
| RESULTS     | Stores result data for each student |

---

## 📌 Notes

- `btnNext` is disabled until an option is selected.
- Timer is shown in MM:SS format and turns red in the last minute.
- Results are saved with date, time, quiz title, duration, and score.

---

## 💡 Future Improvements

- Admin Panel for managing questions/quizzes
- Leaderboard of top scores
- Export result to PDF
- Dark mode UI

---

## 👨‍💻 Developed By

**Name:** [Musaeeb Zahir]  
**Department:** BS Computer Science  
**Tools:** C#, Oracle XE, Visual Studio

---

## 📜 License

This project is for educational purposes. Feel free to use or modify it as per your need.


