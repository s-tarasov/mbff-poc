wt.exe -w 1 nt --title WebGateway --startingDirectory platform\WebGateway -commandline dotnet watch run --no-hot-reload
set NODE_TLS_REJECT_UNAUTHORIZED=0
wt.exe -w 1 nt --title FrontendPlatform --startingDirectory platform\FrontendPlatform -commandline node --watch --inspect server.mjs
wt.exe -w 1 nt --title IdentityServer --startingDirectory platform\IdentityServer -commandline dotnet run -c Release

wt.exe -w 1 nt --title ProductMs --startingDirectory team-red\ProductMs -commandline dotnet watch run --no-hot-reload
wt.exe -w 1 nt --title ProductPageBFF --startingDirectory team-red\ProductPageBFF -commandline dotnet watch run --no-hot-reload

wt.exe -w 1 nt --title InspireMs --startingDirectory team-green\InspireMs -commandline dotnet watch run --no-hot-reload
wt.exe -w 1 nt --title InspireBFF --startingDirectory team-green\InspireBFF -commandline node --watch server.mjs

wt.exe -w 1 nt --title BasketMs --startingDirectory team-blue\BasketMs -commandline dotnet watch run --no-hot-reload
