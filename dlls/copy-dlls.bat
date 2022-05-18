@echo off
cls
xcopy /y "D:\Projects\RabbitMqDotNetDockerDemo\MessageBroker.Core\bin\Debug\net6.0\MessageBroker.Core.dll" "D:\Projects\RabbitMqDotNetDockerDemo\dlls"
xcopy /y "D:\Projects\RabbitMqDotNetDockerDemo\MessageBroker.Core\bin\Debug\net6.0\MessageBroker.Core.dll" "D:\Projects\MapEntitiesSystem\Microservices"

xcopy /y "D:\Projects\RabbitMqDotNetDockerDemo\MessageBroker.Infrastructure\bin\Debug\net6.0\MessageBroker.Infrastructure.dll" "D:\Projects\RabbitMqDotNetDockerDemo\dlls"
xcopy /y "D:\Projects\RabbitMqDotNetDockerDemo\MessageBroker.Infrastructure\bin\Debug\net6.0\MessageBroker.Infrastructure.dll" "D:\Projects\MapEntitiesSystem\Microservices"

pause