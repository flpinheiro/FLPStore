# Prompt

Atualize a seguinte api web restless desenvolvida em c# e dotnet 9, disponivel no repositório https://github.com/flpinheiro/FLPStore.git, esta api usará o "Azure Entra Id" como servidor de autenticação e autorização, Sql server como banco de dados, Terraform como infraestrutura como código, seraáhospedada no github e usará o github actions como workflow CI/CD. 

Está api funcionará como único ponto de acesso público, portanto, requisições a outras apis será feita por está api. 

A API dever terá um controller com endpoint de criacao de usuario, login e logout.
Durante o processo de criacao de usuarios será feito uma "copia" local para armazenamento de dados pessoais e regras de negócio, sendo que os endpoints de criação, login, logout entre outros devem se chamar as funcionalidades especificas do azure entra Id.

O sistema de autorização seguirá o padrao RBAC (Role based accesse control) com as seguintes roles predefinidas : Administrador (read and write administrative Access), Contributor (Read only administrative Access), User (Not administrative and personal data) e anônimos (endpoint público), com JWT Token. Ajude a definir as roles e claims necessárias. 

Informações como connection string, client secrets e outras informacoes de configuração sensiveis deveram ser armazenadas em azure vault e obtidas pela aplicação em tempo de execução ou inicialização.

Na aplicação serà usada as bibliotecas MediatR, Automapper, Entity framework core, Fluent Validation, entre outras seguindo os padrões de projeto CQRS Pattern, Entity Migration, clean code e SOLID. Recomende qualquer outra biblioteca nuget necessária.

Configure o Program.cs para garantir as funcionalidades necessárias.

Crie os scripts Terraform da estrutura, configurando todos os serviços necessários, tais como "Azure Entra Id", "Sql Server DataBase", "Public Ip", "Azure Web app", "Azure Vault", "Virtual network" entre outras estruturas

Crie os scripts github actions do workflow de implantacao CI/CD.

