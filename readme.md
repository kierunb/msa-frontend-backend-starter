# Frontend + Backend microservices starter

#### CLI

```shell
dotnet add .\WebApiBackend\ package Microsoft.Tye.Extensions.Configuration --prerelease

tye run --logs console
tye run --dtrace zipkin=http://localhost:9411 --logs seq=http://localhost:5341
```
