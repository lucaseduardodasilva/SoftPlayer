## Pontos importantes para o funcionamento da aplicação:

Ler a seção Docker.

Como a API CalculaJuros consome a API TaxaJuros por meio do Ip do docker, na máquina que estiver utilizando a aplicação será necessário configurar a Url na classe: `Urls` ex: `public const string ConsultaJurosDockerIp = "http://xxx.xx.xxx.xxx/api/taxaJuros"`;

Na API CalculaJuros, disponilizei uma controller adicional chamada `TesteCalculoController`, que faz o cálculo com a taxa de juros mocada, apenas para caso queiram testar de maneira mais rápida sem ter que rodar o docker.

## Swagger

As APIs estão documentadas utilizando [Swagger](https://swagger.io/), é possível consumir os métodos das controllers utilizando as páginas do swagger, que disponibilizam cada método das controllers, o verbo e os parâmetros.

## Docker

A aplicação está configurada e pronta para ser utilizada com utilização do comando: docker-compose up. 

Para utilização do docker, utilizar o comando: `docker-compose up` pelo prompt ou Powershell dentro do seguinte diretório : `../Envolti/Envolti.JurosAPI`.

Caso os Ip's das aplicações não sejam disponibilizados na janela de comando após rodar o `docker-compose up`, será necessário seguir os próximos passos para verificar os ips que as aplicações estão rodando.

1 - No command prompt executar o comando: `docker ps -a` 
este irá disponibilizar os containeres existentes na máquina.

2 - Deverá existir dois containeres chamados `envoltijurosapi` e 	`envolticalculajurosapi`, verificar o id dos containeres ex: 5c9ee331be07 e 6fbb5d3b5dab 

3 - Com os ids dos containeres em mãos, vamos executar o seguinte comando para descobrir o ip de cada um: 
`docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" 5c9ee331be07`

4 - Copiar o Ip, colocar no navegador e adicionar um /swagger no final, 
ex: `http://172.29.197.94/swagger/`

## Testes 

Para testes foi utilizado TDD pirâmide de testes, os testes unitários estão no 	projeto Envolti.Dominio.Testes e os testes de integração estão no projeto 	Envolti.Integracao.Testes

Para um cenário mais realístico, criei uma entidade para utilizar nos testes unitários.

## Ferramentas e arquitetura utilizadas para realização dos testes:

[XUnit .Netcore](https://xunit.net/)

[Bogus](https://github.com/bchavez/Bogus)

[ExpectedObjects](https://github.com/derekgreer/expectedObjects) 

[FluentAssertions](https://fluentassertions.com/)

[TDD](https://docs.microsoft.com/en-us/visualstudio/test/quick-start-test-driven-development-with-test-explorer?view=vs-2019) 

[Builder](https://www.dofactory.com/net/builder-design-pattern)
