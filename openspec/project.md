# Project Context

## Purpose
ModProtocols is a multi-protocol communication middleware designed for game mod ecosystems. It provides standardized and extensible interaction capabilities between different mods. The current implementation includes the core **ModHttpV1** protocol, with plans to support additional protocol types in the future.

## Tech Stack
- **C#** with .NET Standard 2.1
- **Unity** game engine integration
- **UniTask** for async operations
- **Ducky.Sdk** v0.1.7-dev.2 for mod framework

## Project Conventions

### Code Style
- Use C# naming conventions (PascalCase for types, camelCase for members)
- Enable nullable reference types
- Use preview language features
- Include XML documentation for public APIs

### Architecture Patterns
- **Modular Design**: Each protocol is self-contained
- **Async/Await Pattern**: All I/O operations use UniTask
- **Message Hub Pattern**: Central message routing system
- **Protocol Abstraction**: Common interface for all protocols

### Testing Strategy
- Unit tests for protocol implementations
- Integration tests for cross-mod communication
- Performance tests for high-frequency messaging

### Git Workflow
- **main** branch for stable releases
- Feature branches for new protocols
- Commit format: `type: description` (e.g., `feat: add binary protocol support`)
- PR reviews required for protocol changes

## Domain Context

### Mod Communication Basics
- **Mods**: Self-contained game modifications that can extend or modify game behavior
- **Message Hub**: Central broker for inter-mod communication
- **Protocol**: Standardized communication format (e.g., ModHttpV1 for text-based communication)
- **Client**: Mod instance registered with the communication system

### Core Protocols
- **ModHttpV1**: Text-based point-to-point full-duplex communication
  - Max queue size: 200 messages per client
  - Async message processing
  - Thread-safe operations

### Use Cases
- Cross-mod terminal operations (e.g., Mod A querying Mod B's data)
- Resource sharing between mods
- Coordinated mod features
- Event broadcasting across mod ecosystem

## Important Constraints

### Performance Constraints
- Never block the game's main thread
- Message processing should be < 16ms per batch
- Max 200 messages per queue to prevent memory issues
- Async operations must use UniTask for Unity integration

### Compatibility Constraints
- .NET Standard 2.1 compliance
- Unity compatibility
- Ducky.Sdk dependency requirements
- Backward compatibility with existing protocols

### Security Constraints
- Validate all incoming messages
- Prevent message flooding (queue limits)
- Sandbox mod interactions
- No direct memory access between mods

## External Dependencies

### Ducky.Sdk
- Provides mod framework foundation
- Handles mod lifecycle events
- Supplies message hub infrastructure
- Version: 0.1.7-dev.2

### UniTask
- Async/await for Unity
- Performance-optimized task scheduling
- Integration with Unity's main thread

## File Organization

```
Ducky.ModProtocols/
├── ModBehaviour.cs           # Main mod entry point
├── Protocols/                # Protocol implementations
│   ├── ModHttpV1/           # HTTP V1 text protocol
│   └── [Future Protocols]   # Placeholder for new protocols
├── Core/                    # Shared infrastructure
│   ├── MessageHub/         # Message routing
│   └── Interfaces/         # Protocol abstractions
└── Assets/                  # Mod metadata
    ├── description/         # Mod descriptions
    └── title/              # Mod titles
```

## Development Guidelines

### Adding New Protocols
1. Create protocol folder under `Protocols/`
2. Implement `IProtocol` interface
3. Register in `ModBehaviour.ModEnabled()`
4. Update documentation

### Modifying Existing Protocols
- Maintain backward compatibility
- Version breaking changes
- Update protocol specifications
- Test with existing integrations
