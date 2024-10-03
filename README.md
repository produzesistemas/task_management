# task_management
Desafio técnico Eclipseworks

* Projeto criado a partir do template "Clean Lean Architecture Solution Template" disponível em https://github.com/rimaz523/Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template
* Comando para criação do projeto: dotnet new cla-sln --name TaskManagement
* Inicializando o docker no projeto e criando os arquivos necessários para executar o container: docker init
* Create image docker with uma tag: docker image build -t eclipseWorks/task-management -t eclipseWorks/task-management:8.0.0 .
* Execute: docker run -d -p 8000:8080 eclipseWorks/task-management
* Como o swagger está configurado no projeto acesse através da url: http://localhost:8000/swagger/index.html


  
