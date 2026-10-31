<!-- OPENSPEC:START -->
# OpenSpec Instructions

These instructions are for AI assistants working in this project.

Always open `@/openspec/AGENTS.md` when the request:
- Mentions planning or proposals (words like proposal, spec, change, plan)
- Introduces new capabilities, breaking changes, architecture shifts, or big performance/security work
- Sounds ambiguous and you need the authoritative spec before coding

Use `@/openspec/AGENTS.md` to learn:
- How to create and apply change proposals
- Spec format and conventions
- Project structure and guidelines

Keep this managed block so 'openspec update' can refresh the instructions.

<!-- OPENSPEC:END -->

# Dukcy.ModProtocols

## 项目概述

`Ducky.ModProtocols` 是《逃离鸭科夫》（Escape from Duckov）的一个模组，面向其他模组开发者，定位为"模组间多协议通信框架"（README 称核心协议为 ModHttpV1，场景包括 Terminal 跨模组互操作）。它是一个基于 Ducky.Sdk 的 C# 模组项目：`netstandard2.1`，`Nullable` 开启，`LangVersion` 为 preview。README 为中文（`README.md`）并附英文版（`README_en.md`）；本文件使用中文。

## 目录结构

- `Ducky.ModProtocols.slnx` - 解决方案（仅包含一个项目，另列 `Directory.Build.props`、`nuget.config`）。
- `Ducky.ModProtocols/Ducky.ModProtocols.csproj` - 项目文件，`ModName` 为 `Ducky.ModProtocols`，唯一包引用 `Ducky.Sdk` `0.1.7-dev.2`（`PrivateAssets=all`）；若存在 `..\Local.props` 会被导入（该文件被 gitignore，用于本机路径等本地设置）。
- `Ducky.ModProtocols/ModBehaviour.cs` - 唯一的源文件，共 14 行：继承 `ModBehaviourBase`，设置 `EnableMessageHubHost = true`，`ModEnabled`/`ModDisabled` 为空。
- `Ducky.ModProtocols/assets/` - 模组元数据与发布素材：`info.ini`（`name`、`displayName`、`description`、`tags`、`publishedFileId`）、`preview.png`、`description/{en,zh}.md`、`title/{en,zh}.md`。目录布局符合 `ducky7go/dukcy-package-spec`。
- `openspec/AGENTS.md`、`openspec/project.md` - OpenSpec 流程与项目背景（没有 `specs/`、`changes/` 子目录）。
- `.editorconfig` - UTF-8、LF、4 空格缩进（json/yaml/sh 为 2 空格、csproj/props 缩进 2）、ReSharper 规则（`if/for/foreach/while` 必须带大括号）。

## 构建 / 测试 / 运行

- 工具链：`global.json` 要求 .NET SDK `10.0.0`（`rollForward: latestMajor`，`allowPrerelease: true`）。
- `nuget.config`：`Ducky.Sdk` 只从 MyGet（`https://www.myget.org/F/ducky/api/v3/index.json`）解析，其余包来自 nuget.org（`packageSourceMapping`）。
- 使用 `dotnet` CLI 对 `.slnx` 构建；仓库内没有构建脚本、测试项目或 `.github/workflows`，因此没有可验证的专用命令（本次未执行构建）。
- 模组发布走 ducky-cli / action-ducky-nuget（见下），本仓库自身没有 CI。

## 约定

- `Ducky.ModProtocols/assets/info.ini` 的 `name` 必须与产出 DLL 文件名一致（规范要求），当前均为 `Ducky.ModProtocols`；修改模组名要同时改 `info.ini` 与 csproj 的 `ModName`。
- `info.ini` 里没有 `version` 字段（规范中 `version` 为可选，打包工具默认 `1.0.0`）；发布前如需版本号，需要显式添加。
- 提交信息：`git log` 仅有 `feat: Introduces OpenSpec for spec-driven development (#4)`（浅克隆）；`openspec/project.md` 声明格式为 `type: description`，主分支 `main`。
- 变更提案走 OpenSpec（见上方受管块）。

## 注意事项

- README、`description/*.md` 与 `openspec/project.md` 描述了 ModHttpV1 协议、`RegisterClient`/`UnregisterClient`、UniTask、队列容量 200 等，但本仓库源码里没有这些实现（全仓库 grep `UniTask|ModHttp|RegisterClient` 无 `.cs`/`.csproj` 命中）。实际的消息中枢能力应来自 `Ducky.Sdk`（`ModBehaviourBase.EnableMessageHubHost`）；改动前先确认逻辑所在位置，不要假设这里有协议代码。
- `openspec/project.md` 中"单元/集成/性能测试"的测试策略在仓库中没有对应项目，属于愿景描述。
- `Local.props`、`bin/`、`obj/` 被 gitignore，不要提交。

## 相关仓库

- `Ducky.Sdk`（NuGet 包，`0.1.7-dev.2`）- 提供 `ModBehaviourBase` 等；README 致谢。
- `ducky7go/dukcy-package-spec` - 模组文件夹与 NuGet 打包规范。
- `ducky7go/ducky-cli`、`ducky7go/action-ducky-nuget` - 打包并发布模组到 NuGet / Steam 创意工坊的工具。
