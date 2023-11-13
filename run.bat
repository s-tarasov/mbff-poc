wt.exe -w 1 nt --title ProductMs --startingDirectory ProductMs -commandline dotnet watch run --no-hot-reload
wt.exe -w 1 nt --title ProductPageBFF --startingDirectory ProductPageBFF -commandline dotnet watch run --no-hot-reload
wt.exe -w 1 nt --title WebGateway --startingDirectory WebGateway -commandline dotnet watch run --no-hot-reload
wt.exe -w 1 nt --title FrontendPlatform --startingDirectory FrontendPlatform -commandline node --watch server.mjs
