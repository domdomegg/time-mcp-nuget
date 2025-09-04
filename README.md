# Time MCP Server

A Model Context Protocol (MCP) server built with .NET that provides time-related tools.

## Features

The server provides one simple tool:
- `GetCurrentUtcTime` - Gets the current UTC date and time in RFC 3339 format

## Prerequisites

- .NET 9.0 or later
- Claude Desktop or another MCP-compatible client

## Installation

1. Build the project:
   ```bash
   dotnet build
   ```

2. Run the server:
   ```bash
   dotnet run
   ```

## Configuration

To use this server with Claude Desktop, add the following to your MCP configuration file:

### Windows
Add to `%APPDATA%\Claude\claude_desktop_config.json`:

```json
{
  "mcpServers": {
    "time-server": {
      "command": "dotnet",
      "args": [
        "run", 
        "--project", 
        "C:\\path\\to\\TimeMcpServer.csproj"
      ]
    }
  }
}
```

### macOS
Add to `~/Library/Application Support/Claude/claude_desktop_config.json`:

```json
{
  "mcpServers": {
    "time-server": {
      "command": "dotnet",
      "args": [
        "run", 
        "--project", 
        "/path/to/TimeMcpServer.csproj"
      ]
    }
  }
}
```

## Usage

Once configured, you can use the time tool in Claude Desktop:
- "What's the current UTC time?"
- "Give me an RFC 3339 timestamp"

## Publishing

### Publishing as a Self-Contained Executable

To publish the server as a self-contained executable that doesn't require .NET runtime to be installed:

```bash
# Windows x64
dotnet publish -c Release -r win-x64 --self-contained

# macOS arm64 (Apple Silicon)
dotnet publish -c Release -r osx-arm64 --self-contained

# macOS x64 (Intel)
dotnet publish -c Release -r osx-x64 --self-contained

# Linux x64
dotnet publish -c Release -r linux-x64 --self-contained
```

The published executable will be in `bin/Release/net9.0/{runtime}/publish/`

### Publishing as Framework-Dependent

For smaller size when .NET runtime is available:

```bash
dotnet publish -c Release
```

### NuGet Package

To package as a .NET tool:

1. Add these properties to `TimeMcpServer.csproj`:
```xml
<PropertyGroup>
  <PackAsTool>true</PackAsTool>
  <ToolCommandName>time-mcp-server</ToolCommandName>
  <PackageId>TimeMcpServer</PackageId>
  <Version>1.0.0</Version>
  <Authors>Your Name</Authors>
  <Description>Time MCP Server</Description>
</PropertyGroup>
```

2. Pack and publish:
```bash
dotnet pack -c Release
dotnet nuget push bin/Release/TimeMcpServer.1.0.0.nupkg --source https://api.nuget.org/v3/index.json --api-key YOUR_API_KEY
```

3. Install globally:
```bash
dotnet tool install -g TimeMcpServer
```

## Development

### Building
```bash
dotnet build
```

### Running
```bash
dotnet run
```

### CI/CD
The project includes GitHub Actions workflow that builds and tests on multiple platforms (Windows, macOS, Linux).

## Dependencies

- ModelContextProtocol (0.3.0-preview.4)
- Microsoft.Extensions.Hosting (9.0.8)