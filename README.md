# ✈️ IXIGO.com Flight Booking Automation Framework (C# + SpecFlow)

This is a modern, maintainable automation framework built using **Selenium WebDriver**, **C#**, **SpecFlow (BDD)**, and **NUnit**. It automates the **flight booking module** of IXIGO.com, simulating real-world booking scenarios with clean reporting and modular design.

---

## 🚀 Features

- ✅ One-way flight booking  
- ✅ Round-trip flight booking  
- ✅ Multi-passenger scenarios  
- ✅ No flights found validation  
- ✅ Data-driven testing using Excel or JSON  
- ✅ BDD with Gherkin feature files  
- ✅ Screenshots on failure  
- ✅ Page Object Model (POM) structure  

---

## 🧰 Tech Stack

| Tool/Library       | Purpose                             |
|--------------------|-------------------------------------|
| C#                 | Programming language                |
| Selenium WebDriver | UI automation                       |
| SpecFlow           | BDD and feature file support        |
| NUnit              | Test execution and assertions       |
| ExcelDataReader / JSON.NET | Data-driven testing         |
| ExtentReports  | Test reporting with screenshots |
| Visual Studio      | IDE used for development            |

---

## 📊 Reporting

- Reports are generated in the `TestResults/` or `Reports/` folder.
- Screenshots are captured automatically for failed steps.

---

## 🧪 How to Run Tests

### ✅ Prerequisites

- .NET SDK (6.0 or later)
- ChromeDriver in system PATH
- Visual Studio 2022+ with NUnit and SpecFlow extensions

### ▶️ Run via Visual Studio

- Open the solution in Visual Studio
- Build the project
- Right-click on the test project > **Run Tests**

### ▶️ Run via CLI

```bash
dotnet clean
dotnet build
dotnet test
