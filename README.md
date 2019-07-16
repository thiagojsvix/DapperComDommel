![Middleware](~/../Content/Velocity.jpg)
# Dapper - Acesse seu Banco de Dados com mais velocidade
No desenvolvimento de Software é comum termos que fazer acesso a `Banco de Dados - BD`, porém quando temos que fazer esse tipo de acesso começamos a encontrar alguns problemas. A maioria dos `BDs` utilizados em aplicação [LoB](https://en.wikipedia.org/wiki/Line_of_business) hoje em dia, são relacionais, e como podemos fazer a traduzação de um ambiente relacional para um estrutural? a Resposta é: Frameworks [ORM](https://en.wikipedia.org/wiki/Object-relational_mapping).

Na plataforma .Net temos com `ORMs` mais populares o [Entity Framework](https://docs.microsoft.com/en-us/ef/core/) e [NHibernate](https://nhibernate.info/doc/nh/en/index.html) embora funcione muito bem para solucionar o problema que sem propoem a resolver, em alguns cenários podem não ter uma perfomance muito boa e ser uma ferramenta muito complexa para resolver um pequeno problema.

Imagine uma aplicação na qual você está utilizando o [Pattern CQRS](https://martinfowler.com/bliki/CQRS.html), e precisa criar mais uma consulta para entregar a sua API ou para servir uma necessidade do seu negócio. Porém o seu CTO recomendou que você faça essa consulta da forma mais rapida e performatica o possível.

Nesse momento se você utiliza um ORMs como `Entity Framework` ou `NHibernate` você já sabe que tem muitas coisa para configurar até que consiga fazer essa simples consulta, sem falar que para você testar essa consulta é bem complicado, já que há a necessidade de integrar o ambiente com o `BD` para que a consulta funcione corretamente. É claro que é possível mockar o contexto do seu ORM, mas mesmo assim sabemos que dá trabalho e você não pode esquecer que o seu CTO pediu agilidade no processo. Como alternativa você deve ter pensando: vou usar o básico, ADO.NET com instruções SQL. Você até estar correto no que tange a velocidade de execução, mas será que você terá a velocidade de construção que lhe foi solicitado?

## Apresentamos o Dapper

O [Micro ORM Dapper](https://github.com/StackExchange/Dapper) é uma ferramenta formidável, porém a palavra de ordem é **Micro**. Ele não se propõem a resolver todos os problemas que um ORM como o `Entity` e `NH` resolvem. A pegada dele é ter agilidade no uso e perfomance na execução. E para tal, ele fornece uma série de extensão do ADO.Net que garante a compatibilidade com diversos BDs, entre eles: Postgres, Sql Server, MySql entre outros.

Para usar o Dapper é muito simples. Primeiro você tem que instalar o pacote nuget do Dapper, criar a conexão com o seu banco de dados e Pronto. Só executar o código

```
Install-Package Dapper
```

Abaixo é apresentado um exemplo onde é executado uma consulta no banco de dados e o resultado é associado ao seu objeto .Net. Lembrando que essa é uma facilidade que você não teria utilizando acesso nativo com o ADO.Net.


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
Um outro ponto que me chama muito a atenção é a capacidade de fazer o bind com o seu objeto .Net. Lembrando que essa é uma facilidade que você não teria utilizando acesso nativo com o ADO.Net.

Se você ainda não está convencido que esse krinha é bom, vou listar algumas das funcionalidade que ele tem:

* Mapeamento para objetos fortemente tipado
* Mapeamento para objetos dinâmico
* Executar comandos como: Select, Insert, Delete, Update entre outros
* Te dá suporte a Listas
* Substituição literal
* Executar Multiplas Consultas
* Manipular Stored Procedures

## Nem tudo são flores, problemas das instruções SQL
Em construção ...

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
* Realiza integração do Dapper com o Dommel
* Realizar Teste de Integração
