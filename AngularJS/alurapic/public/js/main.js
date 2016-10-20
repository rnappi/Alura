// é necessário passar o parametro '[]' para criar um módulo
// este array '[]' serve para informar ao Angular quais são as dependências deste módulo
// essas dependências são outros módulos que são utilizados pelo 'alurapic'
angular.module("alurapic", ['minhasDiretivas', 'ngAnimate', 'ngRoute', 'meusServicos'])
.config(function($routeProvider, $locationProvider){
	
	// configura o Angular para retirar o # das rotas e utilizar o history API do HTML5
	// o backend deve estar preparado para que este recurso funcione
	// o browser também de ter suporte a esta API do HTML5
	$locationProvider.html5Mode(true);

	// routeProvider é um objeto injeta pelo ngRoute
	// é com ele que conseguimos configurar as rotas
	$routeProvider.when('/fotos', {
		templateUrl: 'partials/principal.html',
		controller: 'FotosController'
	});

	$routeProvider.when('/fotos/new', {
		templateUrl: 'partials/foto.html',
		controller: 'FotoController'
	});

	$routeProvider.when('/fotos/edit/:fotoId', {
		templateUrl: 'partials/foto.html',
		controller: 'FotoController'
	});

	// rota padrão da aplicação
	// caso o usuário tente acessar um rota que não existe, ele vai ser redirecionado para essa
	$routeProvider.otherwise({ redirectTo: '/fotos' });

});