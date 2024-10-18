# task_management
Desafio técnico Eclipseworks
  
  Comandos Docker
* Inicializando o docker no projeto e criando os arquivos necessários para executar o container: docker init
* Implementando imagem com uma tag: docker image build -t eclipseWorks/task-management -t eclipseWorks/task-management:v1 .
* Rodando o container: docker run -d -p 80:8080 eclipseWorks/task-management

  Pendências para finalizar o desafio
* Implementação de regra de negócio para restrição de remoção de projetos.
* Implementação de regra de negócio para limitar a quantidade de tarefas por projeto.
* Implementação de relatórios.
* Implementação de comentários nas tarefas.
* Implementação de testes unitários.
* Implementação da Fase 2 do desafio.

  Detalhes do projeto
* .Net 8.
* Banco de dados MSSQL será criado na pasta do usuário local(c:\users\nome_usuario).
* Arquitetura Clean Code implementada.
* Injeção de dependências.
* Uso de Entity Framework para persistência de dados com mapeamento.
* FluentValidation para validação de dados.
* Uso do padrão Seed para inserir usuários no banco de dados após criação.


  
