# Planning Pocker - CHALLENGE BACKEND
## Planning poker
O planejamento do poker, também chamado de scrum poker, é uma técnica de estimativa baseada em consenso e gamificada, usada principalmente para estimar o esforço ou o tamanho relativo dos objetivos de desenvolvimento no desenvolvimento de software.

[Saiba Mais](https://www.culturaagil.com.br/planning-poker-tecnica-baseada-consenso/)

## API RESTFul 
A API está documentada utilizando Swagger, utiliza banco de dados SQLLite com ORM Entity Framework Core + Migrations
- Usuário (Autenticação usando JWT + .NET Core Identity)
  User (GetUser, Register e Login)
- Carta (CRUD)
- Historia (CRUD)
- Voto  
  - Após persistir os dados, o voto é enviado no HUB SignalR, Use a página hubs/Teste.html para testar o consumo da mensagem.
  - Após confirmar o voto é publicado uma mensagem no RabbitMQ exchange ALLVotos (Conta criada em https://www.cloudamqp.com/)

  ## Ferramentas e tecnologias utilizadas

 - [.Net Core 3](https://docs.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-core-3-0)
 - [Flunt](https://balta.io/blog/flunt)
 - [Swagger](https://swagger.io/)
 - [SQLite](https://www.sqlite.org/index.html)
 - [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/)
 - [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
 - [RabbitMQ](https://www.rabbitmq.com/)
  

