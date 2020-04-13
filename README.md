# Team Project

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/eeca594b496b4013aff89f060d51ca2b)](https://www.codacy.com/manual/liannoi/team-project?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=liannoi/team-project&amp;utm_campaign=Badge_Grade)
[![CodeFactor](https://www.codefactor.io/repository/github/liannoi/team-project/badge)](https://www.codefactor.io/repository/github/liannoi/team-project)
[![BCH compliance](https://bettercodehub.com/edge/badge/liannoi/team-project?branch=master)](https://bettercodehub.com/)

### Short description

The prototype of a multi-tier application on ASP.NET Core, providing a voting
system for the best film from the nomination.

There are two sides to working with the system - the user side and the
administrator side. The administrator has the opportunity to conduct CRUD
operations on films, genres and actors. The actors and the film have photos
that can be added / removed directly when editing the "parent".

SQL Server database, accessed through the Entity Framework Core (Code First).

There are Web APIs that clients access and receive JSON in response, then
everything is drawn directly to them. Web API and Application layer -
implemented using the Repository pattern and projection of `Entities` on business
types (DTOs).

Authentication, in turn, is implemented at the Web API level through JWT tokens
with integration on the MVC client.

In the idea of architecture, we tried to adhere to the methodology of Clean
Architecture, first announced by [Robert Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
and explained in detail by Jason Taylor [sample](https://github.com/jasontaylordev/NorthwindTraders).

## Technologies

- .NET Core 3.1
- Entity Framework Core 3.1
- Bootstrap 4.3.1
- **[Dependence]** jQuery 3.3 (with plugins)

