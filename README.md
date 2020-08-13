# Teste Auvo
## Introdução
Olá, conforme foi solicitado, eu implementei uma API simples, e apesar de ter sido solicitado um 'approach' DDD, o escopo da aplicação é muito simples para expor muita coisa, então busquei usar um abordagem mais exagerada, fazendo as coisas de formas menos eficientes, mas que pudessem expor mais do funcionamento e do meu conhecimento da linguagem e das metodologias.

#### Arquitetura
Para implementar o projeto, decidi usar o template de WebApi padrão, com as integrações e facilidades oferecidas pela IDE Rider, da JetBrains. Além disso, como eu já tinha o SQL Server na minha maquina, fui usando ele mesmo, mas testei no Oracle também, e funcionou sem problemas

## Commit Inicial
Conforme conversei, esta é uma versão incompleta, que fiz em paralelo com minhas outras atividades, por isso não tem todos os testes, não tem a camada de serviço, e tem um monte de "TODO"...

Dependendo do feedback de vocês, posso terminar, ou deixar como está.

## Utilidades
#### Regerar migrations:
Rodar na pasta raiz da solução:
```
dotnet ef database update 0 --project Infra\Data\Persistence\Persistence.csproj --context MsSqlContext &&  dotnet ef migrations remove --project Infra\Data\Persistence\Persistence.csproj --context MsSqlContext && dotnet ef migrations add InitialCreate --project Infra\Data\Persistence\Persistence.csproj --context MsSqlContext --output-dir Migrations/SqlServerMigrations && dotnet ef database update --project Infra\Data\Persistence\Persistence.csproj --context MsSqlContext
```