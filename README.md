# Teste-LG

No docs estão os códigos SQL do exercício número 3, e também uma imagem com as respostas do teste de lógica.
Confesso que me falta mais treinamento na linguagem SQL, não tive tempo de fazer correções.

https://docs.google.com/document/d/1MukY3KiY80i6XSeEmyCucq39Lu1NU3a_m4fByxmAXZ4/edit?usp=sharing


Exercício 01

Foi criado um projeto Web API em ASP.NET Core 6 utilizando o EntityFrameWork.
Banco de dados relacional Sqlite.

O projeto foi implementado utilizando o padrão Repository para desacoplar
o modelo de domínio do código de acesso a dados, em conjunto também foram
implementados o padrão Unit Of Work, Dependency Injection, o conceito de
contratos através de interfaces e funções assíncronas.

Basicamente o código está dividido em quatro camadas, cada uma com sua responsabilidade.
São elas: Domain, Data, Services e Controllers.

![Diagrama Padrão Repository](https://user-images.githubusercontent.com/62609759/179336459-5c43cf9d-7cb7-4e24-a2fe-86fb2e3a8692.jpeg)

Na camada de Domain estão as entidades, enumeradores, interfaces, DTOs e viewmodels,
que fazem parte do dominio da aplicação.
Na camada de Data está a conexão com o banco de dados através da classe
DataContext, os repositórios de cada entidade e os Types Fluent Mapping 
que ajudam a modelar o banco de dados com base nas entidades
sem criar dependência.
Na camada de Services estão as regras de negócio da aplicação.
Na camada de Controllers estão os endpoints de cada entidade, foram utilizados
os conceitos de DTOs para retornar dados e as ViewModels para receber dados.

No que poderia melhorar?

Adicionar os pacotes FluentValidation e AutoMapper.

Exercício 02

Foi criado um projeto Console Application em ASP.NET Core 6.

O projeto foi implementado utilizando o padrão Repository para desacoplar
o modelo de domínio do código de acesso a dados, em conjunto também foram utilizados os conceitos de
contratos através de interfaces e herança e abstração para maximizar a reutilização de código.
