INSTRUÇÕES

1. Após clonar ou copiar o repositório do git, executar na raiz da solução os seguintes comandos: 
					
	dotnet publish --os linux --arch x64 /t:PublishContainer -c Release
    docker run --name webapiloja -d -p 8080:8080 webapiloja:latest

2. A porta para rodar pelo docker será a 8080, tendo apenas dois end-points na solução, ambas POST

	http://localhost:8080/api/login	   (POST)
	http://localhost:8080/api/pedido   (POST) 

3. O endpoint de pedido deverá ter autorização (JWT com Bearer token). Qualquer que for email e password 
irá gerar um token que expira a cada 2 horas.

4. O bearer token deverá ser copiado no "cabeçalho" da requição de pedidos, caso contrário acusará erro
	401 de não-autorizado.

5. No algoritmo de empacotamento, levei em consideração o volume das caixas, não procurei fazer algo
	mais complexo, justamente por esse problema ser um caso conhecido de pesquisa científica.

6. Tentei ao máximo utilizar os conceitos de clean arch, porém, mesmo pela solução não precisar 
    de um banco de dados, ficou mais simples.

