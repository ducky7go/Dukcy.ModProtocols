Language: [English](README_en.md) | [中文](README.md)

# ModProtocols - Mod Interoperability Protocol Framework

## Core Positioning

ModProtocols is a multi-protocol communication middleware designed for game mod ecosystems, aiming to provide standardized and extensible interaction capabilities for different mods. The **ModHttpV1** core protocol has been implemented, with more protocol types to be supported in the future to build a complete mod communication ecosystem.

## Current Core Protocol: ModHttpV1

### Protocol Features

- Peer-to-peer full-duplex communication: Supports bidirectional text data transmission between any two mods without communication direction restrictions
- Asynchronous non-blocking design: Implements asynchronous message processing based on **UniTask** to avoid blocking the game's main thread
- Text-based protocol: Uses strings as message carriers, compatible with various text formats (such as JSON, command strings, etc.)
- Concurrent safety mechanism: Ensures stability of simultaneous communication between multiple mods through thread-safe queues and dictionaries

### Core Functions

- Mod registration and unregistration: Supports dynamic access (**RegisterClient**) and exit (**UnregisterClient**) of mods from the communication system
- Message queue management: Maintains independent message queues for each mod, automatically handling message backlogs (maximum queue capacity 200)
- Reliable message delivery: Messages are processed in sending order, with logging on failure to ensure communication continuity
- Full-duplex interaction: Any mod can act as both sender and receiver for bidirectional real-time communication

### Implemented Scenario: Terminal Cross-Mod Interoperability

Based on the **ModHttpV1** protocol, terminal interoperability between mods has been realized:

- Allows mods to call terminal functions of other mods via text commands
- Implements cross-mod command forwarding, result return, and status synchronization
- Example: Mod A can query resource data of Mod B through terminal commands, and Mod B returns result text after processing

## Future Expansion Plans

- Binary efficient transmission protocol (suitable for large data volume scenarios)
- Broadcast or multicast protocol (supporting one-to-many batch communication)
- Event subscription protocol (topic-based message push mechanism)

All protocols will maintain a unified access layer, ensuring mod developers can adapt to multiple communication methods without modifying core logic.

## Technical Advantages

- Lightweight integration: Developed based on **Unity**, requiring only a small amount of code to integrate into existing mods
- Non-intrusive design: Does not affect the original functions of mods, only realizes communication capabilities through registration interfaces
- Comprehensive logging: Built-in detailed logging system for debugging cross-mod communication issues
- Dynamic extensibility: New protocols can be seamlessly integrated into the framework while maintaining compatibility with old protocols

## License

This project is open-sourced under the MIT license. See the **LICENSE** file for details.

## Acknowledgments

- Thanks to **Ducky.Sdk** for support

