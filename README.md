# Jokenpo API - Rock, Paper, Scissors, Lizard, Spock

A REST API to manage rounds of the Jokenpo game (Rock-Paper-Scissors-Lizard-Spock), allowing player registration, move submission, round status querying, and round finalization with winner determination.

---

## Table of Contents

- [Technologies](#technologies)  
- [Setup and Running](#setup-and-running)  
- [Project Structure](#project-structure)  
- [Available Endpoints](#available-endpoints)  
- [Usage Examples](#usage-examples)  
- [Architectural Decisions](#architectural-decisions)  

---

## Technologies

- .NET 8  
- C#  
- MediatR (CQRS pattern)  
- FluentValidation  
- Swagger UI  
- xUnit + Moq (for unit testing)

---

## Setup and Running

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed  
- IDE such as Visual Studio, Visual Studio Code, or Rider

### Steps to run

1. Clone the repository:  
   ```bash
   git clone https://github.com/Skyerv/Jokenpo.git
   cd Jokenpo2
   ```
   
2. Restore dependencies:

```bash
dotnet restore
```

3. Run the application:
```bash
dotnet run --project Jokenpo2.Api
```

4. Open Swagger UI to explore endpoints:

```bash
https://localhost:7232/index.html
```

## Project Structure
```graphql
Jokenpo
├── Application
│   ├── Commands        # Commands for actions (e.g. register player, submit move, end round)
│   ├── Handlers        # Handlers for Commands and Queries
│   ├── Queries         # Queries for data retrieval (e.g. get round status)
│   ├── Services        # Core business logic (JokenpoService)
│   └── Validators      # FluentValidation validators
├── Controllers         # Web API Controllers (JokenpoController)
├── Domain
│   ├── DTO             # Data Transfer Objects
│   └── Enums           # Enums (e.g. Move)
├── Program.cs          # App configuration and Dependency Injection
```

## Available Endpoints
### 1. Register a player
```
POST /jokenpo/players
```
Request body JSON:

```json
{
  "name": "Carlos"
}
```

### 2. Remove a player
```
DELETE /jokenpo/players/{id}
```

### 3. Submit a move
```
POST /jokenpo/move
```
Request body JSON:
```json
{
  "playerId": "player-guid",
  "move": 0  // Options: 0 - Rock, 1 - Paper, 2 - Scissors, 3 - Lizard, 4 - Spock
}
```
### 4. Get current round status  
`GET /jokenpo/round`  
Returns the current round status with three arrays:

- `players`: list of all registered players (id and name)
- `played`: list of players who have already played
- `notPlayed`: list of players who still need to play

Example response:

```json
{
  "players": [
    { "playerId": "id-carlos", "name": "Carlos" },
    { "playerId": "id-joao", "name": "João" }
  ],
  "played": [
    { "playerId": "id-carlos", "name": "Carlos" }
  ],
  "notPlayed": [
    { "playerId": "id-joao", "name": "João" }
  ]
}
```
### 5. End the current round
```
POST /jokenpo/round/end
```
No request body. Returns the winner or error if not all players have played.

## Usage Examples
### Example game flow
Register player Carlos
```
POST /jokenpo/players
```
```json
{ "name": "Carlos" }
```
Carlos submits "Rock" move
```
POST /jokenpo/move
```
```json
{ "playerId": "carlos-id", "move": 0 }
```
Register player João
```
POST /jokenpo/players
```
```json
{ "name": "João" }
```
João submits "Scissors" move
```
POST /jokenpo/moves
```
```json
{ "playerId": "joao-id", "move": 2 }
```
Get current round status
```
GET /jokenpo/round
```
Response:
```json
{
  "players": [
    { "playerId": "carlos-id", "name": "Carlos" },
    { "playerId": "joao-id", "name": "João" }
  ],
  "played": [
    { "playerId": "carlos-id", "name": "Carlos" },
    { "playerId": "joao-id", "name": "João" }
  ],
  "notPlayed": []
}
```
End the round
```
POST /jokenpo/round/end
```
Response:

```json
{
  "winnerId": "carlos-id",
  "winnerName": "Carlos"
}
```
## Architectural Decisions
**CQRS with MediatR**: Clear separation of commands (state changes) and queries (data retrieval) for maintainability and extensibility. \
**Central Service (JokenpoService)**: Core round logic, players and moves state kept in-memory singleton service to simplify design. \
**FluentValidation**: Validates commands to ensure data integrity on input. \
**No Database**: As per requirements, state is kept in-memory, focusing on game logic. \
**Swagger**: Automatic and interactive API documentation for easy testing and integration. \
**Unit Tests**: Handlers and core logic are covered by unit tests to ensure reliability. 
