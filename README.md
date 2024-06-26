# Create Project

```bash
dotnet new grpc -o <plugin name>
```

# Publish as a Single Executable

```bash
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true
```
