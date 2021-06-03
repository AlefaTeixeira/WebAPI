# Curso Pragmatico de Csharp
🛠️ Ferramentas: .NET - VSCODE - GIT - GITHUB DESKTOP

# Tarefa 1 - O chamado da aventura 
Crie um repositório no Github com a sua conta pessoal
Adicione um arquivo .gitignore para projetos em .NET
Adicione um projeto .NET 5 do tipo webapi
Execute o projeto e tente encontrar a página da sua documentação URL padrão: https://localhost:5001/swagger/index.html
Modifique o método do Controller para ver a diferença que isso causa na API

# Resolução 
Criar Respositório WebAPI no Github, ja no github desktop voce deve vincular sua conta no menu File -> options, inserir em Accounts e em GIT, para que o mesmo seja vinculado corretamente a conta e e-mail.

Criar o projeto webapi usando comando:

dotnet new webapi

Executar o projeto com o comando:

dotnet run

O mesmo nos retorna:
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Repos\WebAPI
       Application started. Press Ctrl+C to shut down.

O link acima abrira com erro, pois a pagina nao contem Html, e sim uma api apenas, link do mesmo: https://localhost:[porta]/swagger/index.html

Em caso de dúvidas sempre consultar em:

1 - Documentação .NET:https://docs.microsoft.com/pt-br/dotnet/

2 - Projetos já existentes no Github: https://github.com/

3 - Fóruns no StackOverFlow: https://stackoverflow.com/

4 - Faça sua pesquisa direto no Google.



