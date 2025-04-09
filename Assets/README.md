# Handball Manager Simulation Framework

## Overview
Event-driven sports simulation framework built with Unity, implementing core handball match mechanics through modular, DI-based architecture. Inspired by Football Manager.

## Project Structure
```
Assets/
└── Scripts/
    ├── Simulation/
    │   ├── Engines/       # Match simulation engines (MatchEngine)
    │   ├── Factories/     # Object creation patterns (MatchSimulatorFactory)
    │   ├── Physics/       # Ball trajectory calculations
    │   ├── AI/            # Player decision-making
    │   └── Events/        # Event handling system
    ├── Core/             # Framework infrastructure
    ├── Data/             # Game data structures
    └── Gameplay/         # Match rules & mechanics
```

## Key Components

### MatchSimulatorFactory
```csharp
// DI constructor example
public MatchSimulatorFactory(
    ILogger logger,
    IPhaseManager phaseManager,
    ISimulationTimer simulationTimer,
    /*...12+ injected dependencies...*/)
{
    // Validation and dependency storage
}
```

### Event-Driven Architecture
```csharp
// IMatchEventHandler interface
public interface IMatchEventHandler {
    void HandleActionResult(ActionResult result, MatchState state);
    void HandlePossessionChange(MatchState state, int newPossessionTeamId);
    void LogEvent(MatchState state, string description);
}
```

## Setup
1. Install Unity 2022.3+ LTS
2. Clone repository
3. Open project in Unity Hub
4. Navigate to **Assets/Scenes/MatchSimulation**

## Simulation Flow
1. MatchEngine initializes simulation parameters
2. MatchSimulatorFactory creates configured simulator
3. Physics/AI systems process match state
4. Event handlers manage game state transitions

[//]: # (Add sequence diagram placeholder)

## Dependency Management
Framework components are connected through constructor injection:
```csharp
var simulator = new MatchSimulator(
    matchState,
    _phaseManager,
    _simulationTimer,
    _ballPhysicsCalculator,
    //...10+ injected dependencies
);
```
