repro for https://gitlab.winehq.org/wine/wine/-/merge_requests/678

1. install .net sdk 6.0
2. `cd ./CoreclrWineCrash/`
3. `dotnet publish -f net6.0 -r win-x86 --self-contained`
4. `wine bin/Debug/net6.0/win-x86/CoreclrWineCrash.exe`
5. coreclr crashes
