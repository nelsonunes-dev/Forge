# Forge ⚒️

*A modular actor-based architecture for distributed fantasy event simulations.*

---

## 🧭 Overview

**Forge** is a pluggable game engine and simulation framework designed for real-time, distributed processing of fantasy battle or event-driven systems. It serves as a back-end foundation for event broadcasting, state tracking, persistence, and replays using an actor-model approach powered by **Akka.NET**.

---

## 🛠️ Tech Stack

- **.NET 8**
- **FastEndpoints** – Ultra-performant minimal API framework
- **Akka.NET** – Actor-based concurrency and fault tolerance
- **EF Core** – Relational persistence (e.g., SQLite/SQL Server)
- **Serilog** – Structured, extensible logging
- **Swagger/OpenAPI** – Developer-friendly API docs

---

## 🏗️ Architecture Overview

Forge is built using a **Hybrid Modular Clean Architecture**, structured to be:

- 📦 Modular: Easily extensible across APIs, domains, persistence strategies
- ♻️ Reusable: Core components and service registration usable across projects
- ⚡️ Fast: Plug-and-play FastEndpoints, Akka.NET actor orchestration
- 🚪 API Gateway-ready: via Ocelot or similar reverse proxies

```plaintext
                     +--------------------------+
                     |      API Gateway         |
                     |        (Ocelot)          |
                     +-----------+--------------+
                                 |
                 +---------------+----------------+
                 |                                |
      +----------v---------------+         +-----------v----------+
      | Forge.Api                |         | Forge.OtherApi       |
      | (Modular FastEndpoints)  |         | (Optional verticals) |
      +----------+---------------+         +------------+---------+
                 |                                      |
        +--------v--------------+             +---------v------------+
        | Forge.Core            |<----------->| Forge.Infrastructure |
        | - Domain              |             | - Persistence        |
        | - Contracts           |             | - Akka persistence   |
        | - Logging (Serilog)   |             | - EF Core (SQLite)   |
        +-----------------------+             +----------------------+

---

## 📁 Project Structure

```text
src/
├── Api
    ├── Forge.Api               → .NET Core API project
├── Aspire
    ├── Forge.AppHost           → Host for running APIs/modules
    ├── Forge.ServiceDefaults   → Common API configs shared across all APIs
├── Core
    ├── Forge.Core              → Domain, Abstractions, Logging, Endpoints
    ├── Forge.Infrastructure    → EF Core, Persistence (Akka, SQLite), Services
