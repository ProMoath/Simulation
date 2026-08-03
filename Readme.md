# 🚀 Single-Channel Queue Simulation System (C# WinForms)

![.NET Version](https://img.shields.io/badge/.NET-6.0%2B-blue)
![Platform](https://img.shields.io/badge/Platform-Windows--Forms-green)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

A Windows Forms application built in **C#** to simulate a **single-channel, single-server queueing system** using the **Inverse Transform Technique** for random variable generation.

## 📚 Overview (Academic Context)
This project is a practical implementation of **"Manual Simulation"** concepts. It applies mathematical models and builds stochastic simulation frameworks without relying on built-in search or replace functions. This demonstrates a deep understanding of how random engines operate within simulation software.

The project strictly follows the step-by-step simulation methodology outlined in standard academic curricula (such as the single-server queue examples found in simulation textbooks).

## ✨ Key Features

*   **Advanced Setup Interface (Form2):**
    *   Create probability distribution tables for **Interarrival Time** and **Service Time**.
    *   Input field for the maximum number of time intervals with strict input validation (`int.TryParse`).
    *   **Automated Random Probability Generation:** Generates random numbers and applies a custom **Normalization algorithm** to ensure the total sum of all probabilities equals exactly **1.0**.
    *   Automatic calculation of **Cumulative Probability** and the **Random Number Assignment (RNA)** range using a custom `StringBuilder` logic.
    *   Dynamic, editable DataGridView with smart warnings (if the sum exceeds 1.0, or locks further input if the sum reaches 1.0 early).

*   **Simulation and Statistics Interface (Form1):**
    *   Generates separate random numbers for each customer's arrival and service.
    *   A custom logic function (`LookupValueByRandomNumber`) that maps the generated random number to the correct time interval based on the cumulative probability, **without using any built-in search functions** (like `IndexOf`, `Find`, or `Replace`).
    *   A detailed results table displaying (Arrival Time, Start of Service, End of Service, Time in Queue, Time in System, and Server Idle Time).
    *   **Performance Metrics:** Statistical results (e.g., Average Wait Time, Server Utilization) are displayed dynamically in a dedicated `Label`.
    *   **Smart Summary Rows:** Automatically appends `Total` and `Average` rows at the end of the results table with customized background coloring and bold fonts for improved readability.

## 🛠️ Technologies & Libraries Used
*   **Language:** C# (.NET 6+)
*   **UI Framework:** Windows Forms (WinForms)
*   **Data Management:** `System.Data.DataTable` and `System.Data.DataRow` (Enforcing a clear separation between data logic and UI).
*   **Data Visualization:** `DataGridView` with dynamic data binding.
*   **Data Structures:** `System.Collections.Generic.List<T>` for storing random numbers before normalization.
*   **Mathematical Logic:** LINQ (`Sum`, `AsEnumerable`) and `Math.Abs` for robust floating-point precision checks.

## 📖 User Guide (How to Use)
1.  **Run the Application:** The main window (`Form1`) will appear.
2.  **Open Settings:** Click the `Set Up Form` button to open the configuration window (`Form2`).
3.  **Configure Probabilities (Form2):**
    *   Under the `Time Between Arrival` tab, enter the maximum number of time intervals (e.g., 8) and click `Input`.
    *   Fill in the `Probability` column manually, or click `Generate Probability` to get a valid normalized set of random numbers.
    *   Repeat the exact same steps for the `Service Time` tab.
    *   *Note: You cannot input further values in remaining probability rows if the cumulative sum has already reached 1.0.*
4.  **Run Simulation (Form1):**
    *   Enter the desired number of customers in the `Number Of Customers` textbox.
    *   Click the `Simulate` button.
5.  **Read the Results:**
    *   A detailed simulation table will appear in the `DataGridView`.
    *   Scroll down to see the colored `Total` and `Average` summary rows.
    *   The performance metrics (e.g., `Server Utilization` and `Average Time in Queue`) will be displayed in the `Label` located above the table.

## 📊 Implemented Mathematical Algorithms
The simulation relies on a custom probability distribution. The following algorithms are implemented entirely from scratch:
1.  **Normalization of Random Numbers:**
    *   `Sum = Σ RandomNumbers[i]`
    *   `NormalizationFactor = 1.0 / Sum`
    *   `FinalProbability = RandomNumbers[i] * NormalizationFactor`
    *(Ensures the sum of all probabilities exactly equals 1.0).*
2.  **Cumulative Probability Calculation:**
    *   `Cumulative[i] = Cumulative[i-1] + Probability[i]`
3.  **Inverse Transform Technique (Value Mapping):**
    *   Check if the generated random number `RN` falls within the range: `Cumulative[i-1] < RN <= Cumulative[i]`.
    *   Return the corresponding `Time[i]`.

## ⚙️ Installation & Local Setup
1.  Clone the repository to your local machine.
    ```bash
    git clone https://github.com/ProMoath/Single-Channel-Queue-Simulation.git
    ```
2.  Open the solution file `Simulation.sln` using **Microsoft Visual Studio 2022** (or newer).
3.  Ensure `Simulation` is set as the Startup Project.
4.  Press `F5` or click the `Run` button to launch the application.

## 📂 Project Structure
*   `Form1.cs` / `Form1.Designer.cs`: Main window, simulation logic, and results table.
*   `Form2.cs` / `Form2.Designer.cs`: Setup window for configuring probabilities, cumulative sums, and random generation.
*   `Program.cs`: The application's main entry point.

## 🤝 License
This project is licensed under the **MIT License**. You are free to use, modify, and distribute it for academic or personal purposes.

## 🤝 Contributing

Contributions are welcome! To get started:

```bash
# 1. Fork the repository on GitHub

# 2. Create a feature branch
git checkout -b feature/your-feature-name

# 3. Make your changes and commit
git commit -m "feat: describe your change"

# 4. Push your branch
git push origin feature/your-feature-name

# 5. Open a Pull Request on GitHub
```

## 📞 Contact

| Channel | Details |
|---------|---------|
| 👨‍💻 **Developer** | Moath Alshahari |
| 📧 **Email** | [moathalshah2023@gmail.com](mailto:moathalshah2023@gmail.com) |
| 🐙 **GitHub** | [@ProMoath](https://github.com/ProMoath) |

---

<div align="center">

<br />

### ⭐ Support the Project

If you find this project useful, please give it a star on GitHub and share it with others!

[![GitHub stars](https://img.shields.io/github/stars/ProMoath/Single-Channel-Queue-Simulation?style=social)](https://github.com/ProMoath/Single-Channel-Queue-Simulation)