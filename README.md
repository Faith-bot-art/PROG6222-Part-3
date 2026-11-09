# PROG6212 - RaceDay Platform (Part 1, 2 & 3)

## Description

RaceDay is a full-stack web-based event management system designed for the South African road running, walking, and cycling community. The platform allows Event Organisers to create and manage events, categories, and participant results, while Participants can browse upcoming events, enter events, track their personal performance history, and prepare for race day.

This project is built progressively across three parts:
- **Part 1:** System Planning and Database (ERD, API Plan, SQL Script)
- **Part 2:** RESTful API Development (ASP.NET Core Web API, EF Core, JWT)
- **Part 3:** Automation of Web Application (ASP.NET Core MVC, Azure Blob Integration, Docker)

---

## User Roles

### 1. Event Organiser
- Create, update, and delete events
- Add, update, and delete categories for events
- View enrolments for their own events
- Upload, update, and delete race results
- Upload event banner images (stored via Azure Blob Storage / Local emulation)

### 2. Participant
- Browse and search upcoming events (public)
- Enrol in events by selecting a category
- View personal enrolment history
- View personal race results
- Update their own profile

---

## Architecture & Technology Stack

| Layer | Technology |
|-------|------------|
| **Frontend (Part 3)** | ASP.NET Core MVC (.NET 8), Bootstrap 5, Session Management |
| **Backend (Part 2)** | ASP.NET Core Web API (.NET 8), RESTful endpoints |
| **Database** | SQL Server, Entity Framework Core (Code-First) |
| **Authentication** | JWT Bearer Tokens (API) / Sessions (MVC) |
| **File Storage** | Azure Blob Storage API (Configured for local file emulation) |
| **Testing** | xUnit, EF Core InMemory |
| **Containerization** | Docker, Docker Compose |
| **CI/CD** | GitHub Actions |

---

## Project Structure

```text
PROG6212-Part2/ (or PROG6212-Part1/)
├── .github/workflows/       # GitHub Actions CI/CD
├── docs/                    # Part 1 ERD and Documentation
├── RaceDay.API/             # Part 2 Backend API
├── RaceDay.Tests/           # Part 2 Unit Tests
├── RaceDay.MVC/             # Part 3 Frontend Web App
├── docker-compose.yml       # Docker configuration
└── README.md
