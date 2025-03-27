<h1 align="center"> Gerenciador de Gastos API .Net</h1>

# Resumo do projeto
O serviço é um organizador de gastos que utiliza SQL Server como database para salvar transações e pessoas. Como usuário, você podera salvar pessoas e vincular a elas transações, sendo do tipo Income (1) para receita e Expense (0) para despesas, também é possível ver o total de despesas, de gastos e o total final. Ao utilizar a aplicação, você poderá checar as rotas com a documentação gerada pelo Swagger. (Mais informações na área de utilização).

# Endpoints


## Entenda os Endpoints
- ``/api/v1/person: Endpoint de tipo Post onde é feita a criação de uma pessoa``
- ``/api/v1/person: Endpoint de tipo GET onde é feita o retorno de todas as pessoas paginadas``
- ``/api/v1/person/{idPerson}: Endpoint de tipo GET onde é feita o retorno de uma pessoa especifica com base no seu id``
- ``/api/v1/person/{idPerson}: Endpoint de tipo PUT onde é feita a atualização de uma pessoa com base no seu ID``
- ``/api/v1/person/{idPerson}: Endpoint de tipo DELETE onde é feita a exclusão de uma pessoa``
- ``/api/v1/transaction: Endpoint de tipo POST onde é feita a criação de uma transação``
- ``/api/v1/transaction: Endpoint de tipo GET onde é feito o retorno de todas transações paginadas``
- ``/api/v1/transaction/{idTransaction}: Endpoint de tipo GET onde é feito o retorno de uma transação com base no ID``
- ``/api/v1/transaction/total: Endpoint de tipo GET onde é feito o retorno do valor total das transações``

![image](https://github.com/user-attachments/assets/6521cd48-4c26-4c4f-82cf-355bb7830b10)


## ✔️ Bibliotecas e tecnologias utilizadas

- ``C# 12.0``
- ``.Net 8``
- ``FrameWork Core``
- ``Framework Core Design``
- ``Framework Core Sql Server``
- ``Framework Core Sql Tools``
- ``Swagger``

# Features 
1. Operação de Crud de pessoas.
2. Operação de Crud do transações.
3. Vincular uma transação a pessoa.
6. Get de valores totais das suas transações.

# Instalação
1. Faça a clonagem do projeto
2. Abra o projeto na sua IDE e faça a instalação das dependências
3. Adicione a configuração do seu Banco de Dados SQL Server no appSerttings.hsib, lá você deve colocar o seu servidor e configuações do Sql Server
4. Rode o projeto e as migrations, lá será feita as criações de tabelas e valores iniciais
5. Acesse https://localhost:7092/swagger/index.html para ver a documentação

