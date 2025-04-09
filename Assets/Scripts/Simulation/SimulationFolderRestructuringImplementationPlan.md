# Simulation Folder Restructuring Implementation Plan

## Overview

This document provides a detailed implementation plan for restructuring the Simulation folder as outlined in the SimulationFolderRestructuringProposal.md. The plan is designed to minimize disruption while achieving a cleaner, more maintainable folder structure.

## Step 1: Create New Folder Structure

Create the following folder structure:

```
Simulation/
├── Core/
│   ├── MatchData/
│   └── Constants/
├── AI/
│   ├── Decision/
│   ├── Evaluation/
│   └── Positioning/
├── Physics/
├── Events/
└── Utils/
```

## Step 2: File Migration Plan

### Core Folder

- Move from `MatchData/` → `Core/MatchData/`
  - MatchState.cs
  - MatchSimulationData.cs
- Move from `Constants/` → `Core/Constants/`
  - ActionResolverConstants.cs
- Move from root → `Core/`
  - MatchSimulator.cs
  - SimulationUtils.cs

### AI Folder

- Move from `AI/DecisionMakers/` → `AI/Decision/`
  - IPassingDecisionMaker.cs
  - IShootingDecisionMaker.cs
  - IDribblingDecisionMaker.cs
  - IDefensiveDecisionMaker.cs
- Move from `AI/Evaluators/` → `AI/Evaluation/`
  - IGameStateEvaluator.cs
  - IPersonalityEvaluator.cs
  - ITacticalEvaluator.cs
- Keep `AI/Positioning/` as is
  - IGoalkeeperPositioner.cs
- Move from `Engines/` → `AI/`
  - PlayerAIController.cs
  - TacticPositioner.cs

### Physics Folder

- Move from `Engines/` → `Physics/`
  - MovementSimulator.cs
- Move from `Interfaces/` → `Physics/`
  - IBallPhysicsCalculator.cs
- Move from `Services/` → `Physics/`
  - DefaultBallPhysicsCalculator.cs

### Events Folder

- Move from `Engines/` → `Events/`
  - ActionResolver.cs
  - MatchEventHandler.cs
- Move from `Engines/Calculators/` → `Events/Calculators/`
  - ActionCalculatorsUtils.cs
  - FoulCalculator.cs
  - InterceptionCalculator.cs
  - PassCalculator.cs
  - ShotCalculator.cs
  - TackleCalculator.cs
- Move from `Services/` → `Events/`
  - DefaultEventDetector.cs
  - DefaultMatchEventHandler.cs
  - DefaultMatchFinalizer.cs

### Utils Folder

- Move from `Utils/` → `Utils/`
  - PlayerPositionHelper.cs
- Move from `Common/` → `Utils/`
  - IGeometryProvider.cs
- Move from `Services/` → `Utils/`
  - PitchGeometryProvider.cs
  - DefaultPhaseManager.cs
  - DefaultPlayerSetupHandler.cs
  - DefaultSimulationTimer.cs

## Step 3: Interface Consolidation

### Phase 1: Move Interfaces

Move interfaces next to their implementations:

- `IActionResolver.cs` → `Events/`
- `IMovementSimulator.cs` → `Physics/`
- `IPlayerAIController.cs` → `AI/`
- `ITacticPositioner.cs` → `AI/`
- `IEventDetector.cs` → `Events/`
- `IMatchEventHandler.cs` → `Events/`
- `IMatchFinalizer.cs` → `Events/`
- `IPhaseManager.cs` → `Utils/`
- `IPlayerSetupHandler.cs` → `Utils/`
- `ISimulationTimer.cs` → `Utils/`

### Phase 2: Consider Interface Consolidation

After moving interfaces, consider these consolidations:

1. Offensive Decision Making:
   - Combine `IPassingDecisionMaker`, `IShootingDecisionMaker`, and `IDribblingDecisionMaker` into a single `IOffensiveDecisionMaker` interface

2. Evaluation:
   - Consider combining `ITacticalEvaluator`, `IPersonalityEvaluator`, and `IGameStateEvaluator` into a more cohesive evaluation system

3. Event Handling:
   - Evaluate if `IEventDetector` and `IMatchEventHandler` can be consolidated

## Step 4: Namespace Updates

Update namespaces to match the new folder structure:

```csharp
// Core
namespace HandballManager.Simulation.Core
namespace HandballManager.Simulation.Core.MatchData
namespace HandballManager.Simulation.Core.Constants

// AI
namespace HandballManager.Simulation.AI
namespace HandballManager.Simulation.AI.Decision
namespace HandballManager.Simulation.AI.Evaluation
namespace HandballManager.Simulation.AI.Positioning

// Physics
namespace HandballManager.Simulation.Physics

// Events
namespace HandballManager.Simulation.Events
namespace HandballManager.Simulation.Events.Calculators

// Utils
namespace HandballManager.Simulation.Utils
```

## Step 5: Update Import Statements

After moving files and updating namespaces, update all import statements throughout the codebase. This includes:

1. Update `using` statements in all files
2. Update any fully qualified type names
3. Update any reflection-based code that might reference the old namespaces

## Step 6: Factory Updates

Update the `MatchSimulatorFactory` and `IMatchSimulatorFactory` to reflect the new structure and namespaces.

## Step 7: Testing

1. Compile the codebase to identify any missed references
2. Run unit tests to ensure functionality is preserved
3. Perform manual testing of the simulation system

## Implementation Timeline

1. Create new folder structure (1 day)
2. Move files to new locations (1-2 days)
3. Update namespaces and imports (2-3 days)
4. Interface consolidation (2-3 days)
5. Testing and fixes (2-3 days)

Total estimated time: 8-12 days

## Rollback Plan

In case of significant issues:

1. Keep a backup of the original folder structure
2. Document all changes made during restructuring
3. Prepare scripts to revert changes if necessary

## Conclusion

This implementation plan provides a structured approach to reorganizing the Simulation folder. By following these steps, the codebase will be transformed into a more maintainable and intuitive structure while preserving all functionality.