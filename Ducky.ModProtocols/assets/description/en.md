# ModProtocols - Mod Communication Framework

Provides standardized communication capabilities for game mods.

## Core Protocol: ModHttpV1

- **Peer-to-Peer Communication**: Bidirectional text transmission between mods
- **Async Processing**: Based on UniTask, non-blocking main thread
- **Message Queue**: Independent queue per mod (max 200 messages)
- **Thread Safety**: Support for concurrent multi-mod communication

## Application Scenarios

- **Cross-Mod Terminal Operations**: Mod A commands calling Mod B functionality
- **Resource Data Sharing**: Query and exchange data between mods
- **Coordination Features**: Multi-mod linkage for complex functionality

## Future Extensions

- Binary transmission protocol
- Broadcast/Multicast protocol
- Event subscription mechanism

## Features

- Lightweight integration, non-invasive design
- Comprehensive logging for easy debugging
- Dynamic extension while maintaining compatibility

## Important Notice

This feature has now been integrated into Ducky.Sdk, making every mod capable of being a host. Therefore, unless you have special needs, such as mods not opened with Ducky.Sdk that require communication protocols, installation is not necessary. Otherwise, installation is not required.