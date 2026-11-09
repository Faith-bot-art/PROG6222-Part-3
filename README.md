# PROG6212 Part 3 - RaceDay MVC Web Application

## Description

This is the final part of the RaceDay platform. It consists of an ASP.NET Core MVC web application that consumes the RESTful API built in Part 2. The application provides a clean, role-aware interface for Event Organisers and Participants. It includes session-based authentication, image uploading (integrated with Azure Blob Storage via the API), and is fully containerized using Docker.

---

## User Roles

### 1. Event Organiser
- Dashboard showing a summary of created events.
- Create, edit, and delete events.
- Upload an event banner image when creating an event.
- View participant enrolments for their events.
- Upload and publish race results.

### 2. Participant
- Browse upcoming events with filtering options.
- View full event details and available categories.
- Enrol in events.
- View personal enrolment history and statuses.
- View personal race results.

---

## Technology Stack (Part 3 Additions)

| Component | Technology |
|-----------|------------|
| **Frontend Framework** | ASP.NET Core MVC (.NET 8) |
| **UI & Styling** | Bootstrap 5, Custom CSS |
| **Authentication** | Session Management (Stores JWT securely) |
| **File Handling** | API-mediated Azure Blob Storage integration |
| **Containerization** | Docker & Docker Compose |

---

## Docker Setup & Instructions

The application is fully containerized. The `docker-compose.yml` file is configured to build and run both the Part 2 API and the Part 3 MVC frontend simultaneously.

### Prerequisites
- Docker Desktop installed and running.

### Docker Run Command
To build and start the application, open your terminal in the root directory (where the `docker-compose.yml` is located) and run the following single command:

```bash
docker compose up --build
