# 🎮 GameZone - Video Game Catalog App

**GameZone** is a web application for managing a video game catalog, developed as a university course project for the "Web Applications" (ASP.NET Core) discipline.

The project represents a complete system for browsing, adding, and rating games, utilizing modern technologies and design patterns.

---

## ✨ Key Features

The project covers all assignment requirements and includes additional bonus features:

### 1. 🗄️ Database & Structure
* **5 Relational Tables:** `Games`, `Developers`, `Genres`, `Platforms`, `Reviews`.
* **Relationships:** Implemented *One-to-Many* relationships.
* **Code First:** Entity Framework Core was used for database creation.

### 2. 🔐 Users & Security (Identity)
* **Login & Registration:** Full functionality using `ASP.NET Core Identity`.
* **Role Model:**
    * **Guests:** Can browse the catalog and read reviews.
    * **Users:** Can add games, edit, delete entries, and write comments.
* **Security:** The backend is protected via `[Authorize]`, and UI buttons/forms are hidden for unauthorized users.

### 3. ⚙️ Data Management (CRUD)
* Full capability for **Creating, Reading, Editing, and Deleting** Games, Genres, Platforms, and Studios.
* **Master-Detail:** The game details page displays specific game information + a list of all user reviews associated with it.

### 4. 🔍 Search & Filtering
* **Search:** By game title.
* **Filtering:** Dropdown menu for selecting a Genre.
* **Sorting:** Dynamic sorting by Title, Release Date, and Price (Ascending/Descending).
* **Pagination:** Results are paginated (5 items per page).

### 5. 🎨 Design & UI
* **Dark Mode Elements:** Custom dark-themed navigation menu and footer.
* **Responsive:** Built with **Bootstrap 5** for mobile compatibility.
* **UX:** Dynamic cards, Google Fonts (Poppins), and emoji icons.
* **Dashboard:** A home page featuring real-time statistics (count of games, reviews, studios) and latest activity.

### 🚀 Bonus: Automatic Data Seeding
Upon the first launch, the application automatically:
1. Creates the database (if it is missing).
2. Applies pending migrations.
3. Populates tables with initial data (10 games, 16 reviews, genres, and platforms).

---

## 🛠️ Tech Stack

* **Framework:** ASP.NET Core 8 (Razor Pages)
* **Language:** C#
* **ORM:** Entity Framework Core
* **Database:** MS SQL Server (LocalDB)
* **Frontend:** HTML5, CSS3, Bootstrap 5
* **IDE:** Visual Studio 2022

---

## 📥 How to Run the Project

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/stoyantsiparov/GameZone-App.git](https://github.com/stoyantsiparov/GameZone-App.git)
    ```
2.  **Open the project:**
    Open `GameZone.sln` in Visual Studio 2022.
3.  **Configuration:**
    Ensure `appsettings.json` points to your local SQL instance.
4.  **Run:**
    Press `F5` or the green "Play" button.
    *Note: You do not need to run database commands manually. The application handles database creation and seeding automatically on startup.*

---
