# DesafioTrayCorp

 - Objetivo: Desenvolva uma API e um Web App para realizar um CRUD de Produtos.

 - Arquitetura do Projeto:
 A solution está dividida em camadas (projetos) cada qual com sua responsabilidade e função.

- ProdutoCrud.Dados: Contém todo conteúdo que se refere aos dados da aplicação, entidades, modelos e repositórios.
- ProdutoCrud.Database: Contém conteúdo referente ao banco de dados da aplicação, mapeamento de entidades, migrations, a classe de DbContext da aplicação e uma classe responsável por conter as informações do banco de dados em sí, como host, user e password.
- ProdutoCrud.IoC: É a camada que contém os registros de injeção de dependência.
- ProdutoCrud.Services: Camada onde está a regra de negócio da aplicação, responsável por intermediar as informações recebidas da request, trazer informações do banco de dados e tratar o retorno.
- ProdutoCrud.Utils: Camada responsável por conter classes com métodos utilitários para a aplicação.
- ProdutoCrud.WebApi: Camada que é o entrypoint da aplicação, onde está os controllers. 