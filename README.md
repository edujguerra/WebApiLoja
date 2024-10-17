INSTRU��ES

1. Ap�s clonar ou copiar o reposit�rio do git, executar na raiz da solu��o os seguintes comandos: 
					
	dotnet publish --os linux --arch x64 /t:PublishContainer -c Release
    docker run --name webapiloja -d -p 8080:8080 webapiloja:latest

2. A porta para rodar pelo docker ser� a 8080, tendo apenas dois end-points na solu��o, ambas POST

	http://localhost:8080/api/login	   (POST)
	http://localhost:8080/api/pedido   (POST) 

3. O endpoint de pedido dever� ter autoriza��o (JWT com Bearer token). Qualquer que for email e password 
ir� gerar um token que expira a cada 2 horas.

4. O bearer token dever� ser copiado no "cabe�alho" da requi��o de pedidos, caso contr�rio acusar� erro
	401 de n�o-autorizado.

5. No algoritmo de empacotamento, levei em considera��o o volume das caixas, n�o procurei fazer algo
	mais complexo, justamente por esse problema ser um caso conhecido de pesquisa cient�fica.

6. Tentei ao m�ximo utilizar os conceitos de clean arch, por�m, mesmo pela solu��o n�o precisar 
    de um banco de dados, ficou mais simples.

