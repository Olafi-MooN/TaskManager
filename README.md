# Gerenciador de Tarefas - API
## Descrição
Este projeto tem como objetivo desenvolver uma API para um sistema Gerenciador de Tarefas utilizando C# e .NET. O sistema permite que os usuários criem, visualizem, editem e excluam tarefas.

## Requisitos
- Arquitetura em Camadas
- A aplicação segue a prática recomendada de dividir o projeto em camadas. O projeto contém as seguintes camadas:
- Camada de Comunicação: Responsável pelo gerenciamento das interações com a API.
 - Camada de Regras de Negócios: Responsável pela lógica de negócios da aplicação.

## Dados e Campos Sugeridos
Cada tarefa possui os seguintes campos:

* id (int): Identificador único da tarefa.
* nome (string): Nome da tarefa.
* descricao (string): Descrição detalhada da tarefa.
* prioridade (string): Prioridade da tarefa (ex.: alta, média, baixa).
* dataLimite (DateTime): Data limite para a tarefa ser realizada.
* status (string): Status da tarefa (ex.: concluída, em andamento, aguardando).

## Endpoints Necessários
A API deve fornecer os seguintes endpoints:

POST /tarefas: Cria uma nova tarefa.
GET /tarefas: Retorna todas as tarefas.
GET /tarefas/{id}: Retorna uma tarefa específica pelo seu ID.
PUT /tarefas/{id}: Atualiza as informações de uma tarefa existente.
DELETE /tarefas/{id}: Exclui uma tarefa existente.

## Status Codes
200 OK: Solicitação bem-sucedida.
201 Created: Tarefa criada com sucesso.
400 Bad Request: Solicitação inválida.
404 Not Found: Tarefa não encontrada.
500 Internal Server Error: Erro no servidor.
