echo @off

start dotnet ./Task1Processor/bin/Debug/netcoreapp2.1/Task1Processor.Console.dll -baseAddress http://192.168.137.93:8080
start dotnet ./Task4Processor.Console/bin/Debug/netcoreapp2.1/Task4Processor.Console.dll -baseAddress http://192.168.137.93:8080
start dotnet ./Task5Processor.Console/bin/Debug/netcoreapp2.1/Task5Processor.Console.dll -baseAddress http://192.168.137.93:8080
start dotnet ./Task6Processor.Console/bin/Debug/netcoreapp2.1/Task6Processor.Console.dll -baseAddress http://192.168.137.93:8080
start dotnet ./TaskProcessor10.Console/bin/Debug/netcoreapp2.1/TaskProcessor10.Console.dll -baseAddress http://192.168.137.93:8080
start dotnet ./TaskProcessor11.Console/bin/Debug/netcoreapp2.1/TaskProcessor11.Console.dll -baseAddress http://192.168.137.93:8080
start dotnet ./TaskProcessor30.Console/bin/Debug/netcoreapp2.1/TaskProcessor30.Console.dll -baseAddress http://192.168.137.93:8080