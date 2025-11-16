# ModProtocols - Mod Interoperability Protocol Framework
## Core Positioning
ModProtocols is a **multi-protocol communication middleware** designed for game mod ecosystems, aiming to provide standardized and extensible interaction capabilities for different mods. The **ModHttpV1** core protocol has been implemented, with more protocol types to be supported in the future to build a complete mod communication ecosystem.
## Current Core Protocol: ModHttpV1
### Protocol Features
- **Peer-to-peer full-duplex communication**: Supports bidirectional text data transmission between any two mods without communication direction restrictions
- **Asynchronous non-blocking design**: Implements asynchronous message processing based on UniTask to avoid blocking the game's main thread
- **Text-based protocol**: Uses strings as message carriers, compatible with various text formats (such as JSON, command strings, etc.)
- **Concurrent safety mechanism**: Ensures stability of simultaneous communication between multiple mods through thread-safe queues and dictionaries
### Core Functions
- **Mod Registration/Unregistration**: Supports dynamic access (**RegisterClient**) and exit (**UnregisterClient**) of mods from the communication system
- **Message Queue Management**: Maintains independent message queues for each mod, automatically handling message backlogs (maximum queue capacity 200)
- **Reliable Message Delivery**: Messages are processed in sending order, with logging on failure to ensure communication continuity
- **Full-duplex Interaction**: Any mod can act as both sender and receiver for bidirectional real-time communication
### Implemented Scenario: Terminal Cross-Mod Interoperability
Based on the **ModHttpV1** protocol, **terminal interoperability** between mods has been realized:
- Allows mods to call terminal functions of other mods via text commands
- Implements cross-mod command forwarding, result return, and status synchronization
- Example: Mod A can query resource data of Mod B through terminal commands, and Mod B returns result text after processing
## Future Expansion Plans
ModProtocols will continue to expand protocol types, with planned support for:
- Binary efficient transmission protocol (suitable for large data volume scenarios)
- Broadcast/multicast protocol (supporting one-to-many batch communication)
- Event subscription protocol (topic-based message push mechanism)
All protocols will maintain a unified access layer, ensuring mod developers can adapt to multiple communication methods without modifying core logic.
## Technical Advantages
- **Lightweight integration**: Developed based on Unity, requiring only a small amount of code to integrate into existing mods
- **Non-intrusive design**: Does not affect the original functions of mods, only realizes communication capabilities through registration interfaces
- **Comprehensive logging**: Built-in detailed logging system for debugging cross-mod communication issues
- **Dynamic extensibility**: New protocols can be seamlessly integrated into the framework while maintaining compatibility with old protocols
With ModProtocols, mod developers can focus on function implementation without worrying about the underlying details of cross-mod communication, easily building a tightly collaborative mod ecosystem.
# ModProtocols - 模组间多协议通信框架
## 核心定位
ModProtocols 是一套为游戏模组生态打造的**多协议通信中间件**，旨在为不同模组提供标准化、可扩展的交互能力。当前已实现 **ModHttpV1** 核心协议，后续将支持更多协议类型，构建完整的模组通信生态。
## 现有核心协议：ModHttpV1
### 协议特性
- **点对点全双工通信**：支持任意两个模组间双向文本数据传输，无通信方向限制
- **异步非阻塞设计**：基于 UniTask 实现异步消息处理，避免阻塞游戏主线程
- **文本协议基础**：以字符串为消息载体，兼容各类文本格式（如JSON、命令串等）
- **并发安全机制**：通过线程安全队列与字典，保障多模组同时通信的稳定性
### 核心功能
- **模组注册/注销**：支持模组动态接入（**RegisterClient**）与退出（**UnregisterClient**）通信系统
- **消息队列管理**：为每个模组维护独立消息队列，自动处理消息积压（最大队列容量200）
- **可靠消息传递**：消息按发送顺序处理，失败时记录日志并继续执行，保障通信连续性
- **全双工交互**：任意模组可同时作为发送方与接收方，实现双向实时通信
### 已落地场景：Terminal 跨模组互操作
基于 **ModHttpV1** 协议，已实现模组间的 **Terminal（终端）互操作功能**：
- 支持模组通过文本命令调用其他模组的终端功能
- 实现跨模组的指令转发、结果返回与状态同步
- 举例：A模组可通过终端命令查询B模组的资源数据，B模组处理后返回结果文本
## 未来扩展计划
ModProtocols 将持续扩展协议类型，计划支持：
- 二进制高效传输协议（适用于大数据量场景）
- 广播/组播协议（支持一对多批量通信）
- 事件订阅协议（基于主题的消息推送机制）
所有协议将保持统一接入层，确保模组开发者无需修改核心逻辑即可适配多种通信方式。
## 技术优势
- **轻量集成**：基于Unity开发，仅需少量代码即可接入现有模组
- **无侵入设计**：不影响模组原有功能，仅通过注册接口实现通信能力
- **完善日志**：内置详细日志系统，便于调试跨模组通信问题
- **动态扩展**：新协议可无缝接入框架，保持对旧协议的兼容性
通过 ModProtocols，模组开发者可专注于功能实现，无需关心跨模组通信的底层细节，轻松构建协作紧密的模组生态。

