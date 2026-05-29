# Beauty Salon Explorer
A full-stack web application designed to explore beauty salons, filter them by district, view details, and manage salon information.
### Database Schema
<img width="777" height="262" alt="BeautySalons-2026-05-29_01-44" src="https://github.com/user-attachments/assets/74593e27-8a55-4eb1-98f2-8a37a8377efc" />


## 🚀 How to Run the Application
I used **Docker** and **Docker Compose** to containerize this application. 

**Why Docker?**

It is incredibly easy to run — it requires just one command in the terminal.

The project uses a PostgreSQL database. Without Docker, you would need to install PostgreSQL locally, configure it, and update the connection strings in appsettings.json. Docker handles all of this automatically in an isolated environment.

### Prerequisites
* You must have [Docker](https://www.docker.com/products/docker-desktop/) installed on your machine.

## Installation Steps:
  ## Installation Steps:
1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/ANDRONNES/Beauty-Salon-Explorer.git
2. Navigate to the project directory:
   ```bash
   cd Beauty-Salon-Explorer
  
3. Build and run the containers in detached mode:
   ```bash
   docker compose up -d
   
Once the build is complete and the containers are running, open your browser and navigate to:

👉 http://localhost:3000/

(The backend API will be running on http://localhost:8080)

## 🛠 Technical Solution and Frameworks Used
This project is built using .NET 9 for the backend and React (Vite) for the frontend.

For the backend architecture, I chose a Layered Architecture (N-Tier). Given the relatively small scope and tight timeframe, this approach is the most efficient. However, I deliberately split the layers into separate Class Libraries (API, BLL, DAL) to ensure the code remains modular, maintainable, and highly testable in the future.

### Backend (.NET)
Core Libraries:
 - Microsoft.EntityFrameworkCore.Design & Microsoft.EntityFrameworkCore.PostgreSQL: Used for database access using the Code-First approach with PostgreSQL.
 - Microsoft.AspNetCore.OpenApi: For API documentation.

Additional Tools:
 - EFCore.NamingConventions: Ensures seamless mapping between C# PascalCase conventions and PostgreSQL snake_case conventions.
 - FluentValidation.AspNetCore: Used to extract validation logic out of the SalonService into separate, dedicated validator classes. This keeps the business logic clean and gets rid of massive if-else blocks.

#### (Note: Test libraries are included in the solution architecture, ready for future implementation).

### Frontend (React + Vite)
Core Libraries:
 - React & Vite: For a fast, modern development environment.
 - react-router-dom: For seamless client-side routing.
 - axios: For handling HTTP requests to the .NET API.

Additional Tools:
 - react-hook-form: Used to build the "Update Salon" form efficiently, ensuring readable code and robust client-side validation.
 - react-select: Implemented to create a smart, searchable multi-select dropdown for salon categories.

## 🔮 What I Would Improve with More Time
If I had more time to expand this MVP, I would focus on the following improvements:
 1. Unit Testing: I would write comprehensive unit tests (using xUnit/Moq) to cover the core business logic inside the BLL services and validators.
 2. Web Scraping / Data Enrichment: I would try to find a way (or integrate a third-party API) to extract actual services and detailed price lists for every beauty salon to make the platform more valuable for users. The database schema already includes the necessary entities for this feature, but they currently remain unpopulated.
 3. Server-Side Pagination and Filtering: Currently, filtering and pagination are handled on the frontend for speed of initial development. While this works for a small dataset, the correct architectural approach is to handle this on the backend. If the application scales to thousands of salons, sending the entire database to the client would be too slow and ruin the user experience. I would implement offset-based or cursor-based pagination directly in the API and SQL queries.
