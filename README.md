# AnimesProtech
Este Repositório foi utilizado para a prova manter o código resultado da prova prática do Processo Seletivo da ProtechSolutions.

 ## 1. Arquitetura

 Para desenvolver a API, foi utilizada uma arquitetura em camadas, com intuito de dividir as responsabilidades e deixar o código o mais limpo possível. 

 As camadas são, DAL, Repository, Manager e Controllers.

   . DAL: _Data Access Layer_, é reponsável por gerir as funções relacionadas aos dados: entidades, DTO's(Classes de transferência de dados), contexto do banco de dados e as funções de acesso direto ao banco.\
   . Repository: Camada referente a funções mais abstratas de acesso ao banco. Nessa camadas, os dados são tratados e convertidos em entidade, e são chamadas as funções de acesso direto ao banco.\
   . Manager: Responável pela regra de negócio da Api. Recebe os DTO's, realiza validações e funções específicas e chama o Repository para repassar informações válidas. Também executa lógica no caminho inverso, repassando informações mais interessantes para o cliente.\
   . Controller: Camada mais externa da Arquitetura, é reponsável por manter o endpoints. Recebe os dados das requisições _REST_ e repassa para o manager. No caminho inverso, retorna os dados de acordo com o melhor código HTTP.

## 2. Rodando a Aplicação

O projeto foi desenvolvido em .Net 6, e por isso sua máquina deve ser capaz de executar executáveis deste tipo. Para o banco de dados foi utilizado SQLServer de maneira local. Por isso, você deve possuir uma intância do SQLServe emexecução na sua máquina

### 2.1 Configurando o ambiente

A _ConnectionString_ de acesso ao banco de dados foi definida como variável de ambiente do sistema, que a API coleta ao ser iniciada. O nome da variável é:

`ANIMES_PROTECH_CONNECTION_STRING`

O valor dessa variável deve ser definida de acordo com a sua intância do banco de dados, mas no meu caso foi:

`Server=localhost\SQLEXPRESS;Database=AnimesProtechDB;Trusted_Connection=True;`

Com o projeto aberto no Visual Studio, na aba de gerenciamento de soluções, defina o projeto "AnimesProtech.DAL" como projeto de inicialização. Feito isso, use o console de gerenciamento de pacotes do NuGet. Defina como projeto padrão o projeto "AnimesProtech.DAL". Execute:

`Update-Database`

Este passo irá aplicar as _migrations_ no banco de dados.

### 2.2 Executando

No gerenciador de soluções do Visual Studio, defina o projeto "AnimesProtech.WEBAPI" como projeto de inicialização. clique em iniciar na barra superior do VisualStudio. 

A aplicação irá começar a rodar e uma aba com o _Swagger_ se abrirá no seu navegador padrão. Como esta API não tem autenticação, você consiguirá executar os endpoints sem muitos problemas no _Swagger_.

Imagem do _Swagger_ rodando em minha máquina.
![image](https://user-images.githubusercontent.com/76215426/201207723-dc944934-dd13-4c37-a94e-ad3bf1495715.png)

