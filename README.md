![Middleware](~/../Content/Velocity.jpg)
# Dapper - Acesse seu Banco de Dados com mais velocidade
No desenvolvimento de Software � comum termos que fazer acesso a `Banco de Dados - BD`, por�m quando temos que fazer esse tipo de acesso come�amos a encontrar alguns problemas. A maioria dos `BDs` utilizados em aplica��o [LoB](https://en.wikipedia.org/wiki/Line_of_business) hoje em dia, s�o relacionais, e como podemos fazer a traduza��o de um ambiente relacional para um estrutural? a Resposta �: Frameworks [ORM](https://en.wikipedia.org/wiki/Object-relational_mapping).

Na plataforma .Net temos com `ORMs` mais populares o [Entity Framework](https://docs.microsoft.com/en-us/ef/core/) e [NHibernate](https://nhibernate.info/doc/nh/en/index.html) embora funcione muito bem para solucionar o problema que sem propoem a resolver, em alguns cen�rios podem n�o ter uma perfomance muito boa e ser uma ferramenta muito complexa para resolver um pequeno problema.

Imagine uma aplica��o na qual voc� est� utilizando o [Pattern CQRS](https://martinfowler.com/bliki/CQRS.html), e precisa criar mais uma consulta para entregar a sua API ou para servir uma necessidade do seu neg�cio. Por�m o seu CTO recomendou que voc� fa�a essa consulta da forma mais rapida e performatica o poss�vel.

Nesse momento se voc� utiliza um ORMs como `Entity Framework` ou `NHibernate` voc� j� sabe que tem muitas coisa para configurar at� que consiga fazer essa simples consulta, sem falar que para voc� testar essa consulta � bem complicado, j� que h� a necessidade de integrar o ambiente com o `BD` para que a consulta funcione corretamente. � claro que � poss�vel mockar o contexto do seu ORM, mas mesmo assim sabemos que d� trabalho e voc� n�o pode esquecer que o seu CTO pediu agilidade no processo. Como alternativa voc� deve ter pensando: vou usar o b�sico, ADO.NET com instru��es SQL. Voc� at� estar correto no que tange a velocidade de execu��o, mas ser� que voc� ter� a velocidade de constru��o que lhe foi solicitado?

## Apresentamos o Dapper

O [Micro ORM Dapper](https://github.com/StackExchange/Dapper) � uma ferramenta formid�vel, por�m a palavra de ordem � **Micro**. Ele n�o se prop�em a resolver todos os problemas que um ORM como o `Entity` e `NH` resolvem. A pegada dele � ter agilidade no uso e perfomance na execu��o. E para tal, ele fornece uma s�rie de extens�o do ADO.Net que garante a compatibilidade com diversos BDs, entre eles: Postgres, Sql Server, MySql entre outros.

Para usar o Dapper � muito simples. Primeiro voc� tem que instalar o pacote nuget do Dapper, criar a conex�o com o seu banco de dados e Pronto. S� executar o c�digo

```
Install-Package Dapper
```

Abaixo � apresentado um exemplo onde � executado uma consulta no banco de dados e o resultado � associado ao seu objeto .Net. Lembrando que essa � uma facilidade que voc� n�o teria utilizando acesso nativo com o ADO.Net.


```csharp
public class Dog
{
    public int? Age { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public float? Weight { get; set; }

    public int IgnoredProperty { get { return 1; } }
}

var guid = Guid.NewGuid();
var dog = connection.Query<Dog>("select Age = @Age, Id = @Id", new { Age = (int?)null, Id = guid });

Assert.Equal(1,dog.Count());
Assert.Null(dog.First().Age);
Assert.Equal(guid, dog.First().Id);
```
Um outro ponto que me chama muito a aten��o � a capacidade de fazer o bind com o seu objeto .Net. Lembrando que essa � uma facilidade que voc� n�o teria utilizando acesso nativo com o ADO.Net.

Se voc� ainda n�o est� convencido que esse krinha � bom, vou listar algumas das funcionalidade que ele tem:

* Mapeamento para objetos fortemente tipado
* Mapeamento para objetos din�mico
* Executar comandos como: Select, Insert, Delete, Update entre outros
* Te d� suporte a Listas
* Substitui��o literal
* Executar Multiplas Consultas
* Manipular Stored Procedures

## Nem tudo s�o flores, problemas das instru��es SQL
Em constru��o ...

## Referencia
* [Object-relational_mapping](https://en.wikipedia.org/wiki/Object-relational_mapping)  
* [Line of Business](https://en.wikipedia.org/wiki/Line_of_business)
* [Entity Framework](https://docs.microsoft.com/en-us/ef/core/) 
* [NHibernate](https://nhibernate.info/doc/nh/en/index.html)
* [Pattern CQRS](https://martinfowler.com/bliki/CQRS.html)
* [Micro ORM Dapper](https://github.com/StackExchange/Dapper)

## Roadmap
* Criar consultas linq
* Testar consultas linq
* Criar banco de dados SQL Server
* Realizar consultas com Micro ORM Dapper
* Realiza integra��o do Dapper com o Dommel
* Realizar Teste de Integra��o
