# Simulation Folder Restructuring Proposal

## Current Structure Analysis

The current Simulation folder structure is highly fragmented with many specialized subfolders:

```
Simulation/
├── AI/
│   ├── DecisionMakers/
│   ├── Evaluators/
│   └── Positioning/
├── Common/
├── Constants/
├── Engines/
│   └── Calculators/
├── Factories/
├── Interfaces/
├── MatchData/
├── Services/
└── Utils/
```

This structure creates unnecessary complexity and makes it harder to navigate the codebase.

## Proposed Structure

I propose consolidating the folder structure as follows:

```
Simulation/
├── Core/           # Core simulation components and data structures
│   ├── MatchData/  # Match state and simulation data
│   └── Constants/  # Simulation constants
├── AI/             # All AI-related components
│   ├── Decision/   # Combined decision makers (passing, shooting, etc.)
│   ├── Evaluation/ # Evaluators (tactical, personality, game state)
│   └── Positioning/ # Positioning logic
├── Physics/        # Physics calculations and movement simulation
├── Events/         # Event detection and handling
└── Utils/          # Utility classes and helpers
```

## Namespace Restructuring

The current namespaces are also fragmented and should be consolidated to match the new folder structure:

```csharp
// Current namespaces:
HandballManager.Simulation.AI.DecisionMakers
HandballManager.Simulation.AI.Evaluators
HandballManager.Simulation.AI.Positioning
HandballManager.Simulation.Common
HandballManager.Simulation.Constants
HandballManager.Simulation.Engines
HandballManager.Simulation.Engines.Calculators
HandballManager.Simulation.Factories
HandballManager.Simulation.Interfaces
HandballManager.Simulation.MatchData
HandballManager.Simulation.Physics
HandballManager.Simulation.Services
HandballManager.Simulation.Utils

// Proposed namespaces:
HandballManager.Simulation.Core          // Core simulation components
HandballManager.Simulation.Core.Data     // Match state and data structures
HandballManager.Simulation.AI.Decision   // Decision makers
HandballManager.Simulation.AI.Evaluation // Evaluators
HandballManager.Simulation.AI.Positioning // Positioning logic
HandballManager.Simulation.Physics       // Physics and movement
HandballManager.Simulation.Events        // Event detection and handling
HandballManager.Simulation.Utils         // Utilities
```

## Interface Consolidation

The current design has many small interfaces in the `Interfaces` folder. I propose:

1. Move interfaces next to their implementations
2. Consolidate related interfaces where appropriate

For example:

```csharp
// Instead of separate interfaces:
IPassingDecisionMaker
IShootingDecisionMaker
IDribblingDecisionMaker

// Consider a more consolidated approach:
IOffensiveDecisionMaker with methods for passing, shooting, and dribbling
```

## Implementation Plan

1. Create the new folder structure
2. Move files to their new locations
3. Update namespaces in all files
4. Consolidate interfaces where appropriate
5. Update import statements throughout the codebase

## Benefits

- Reduced folder depth and complexity
- More intuitive organization by functionality
- Easier navigation and maintenance
- Better separation of concerns
- Reduced coupling between components

## Potential Challenges

- Requires updating import statements throughout the codebase
- May require refactoring some interfaces and implementations
- Temporary disruption during the restructuring process

## Conclusion

This restructuring will significantly simplify the Simulation folder structure while maintaining clean separation of concerns. The consolidated structure will make the codebase easier to navigate and maintain.