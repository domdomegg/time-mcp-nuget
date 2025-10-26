# Time MCP Server

A minimal Model Context Protocol (MCP) server built with .NET.

The server provides one simple tool:
- `GetCurrentUtcTime` - Gets the current UTC date and time in RFC 3339 format

## Quick start

Prerequisites:
- .NET 9.0 or later
- Claude Desktop or another MCP-compatible client

Run with:

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

## Publishing New Versions

To publish a new version of the package:

1. **Tag the release** with a version number prefixed with 'v':
   ```bash
   git tag v1.0.1
   ```

2. **Push the tag** to trigger the publishing pipeline:
   ```bash
   git push --tags
   ```

The CI/CD pipeline will automatically:
- Publish the NuGet package to nuget.org
- Publish the server to the MCP Registry
- Create a GitHub release

### CI/CD
The project includes GitHub Actions workflows for:
- **Build & Test** - Builds and tests on multiple platforms (Windows, macOS, Linux)
- **Publish** - Automatically publishes to NuGet, MCP Registry, and creates GitHub releases on version tags

### MCP Registry

This server is published to the [Model Context Protocol Registry](https://modelcontextprotocol.io/servers). The publishing process uses the `server.json` configuration file which follows the [MCP Registry specification](https://github.com/modelcontextprotocol/registry).

<!-- mcp-name: io.github.domdomegg/time-mcp-server -->
