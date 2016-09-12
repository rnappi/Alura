// cria o controller e injeto o $scope (POJO) no controle
// $scope serve para disponibilizar dados do controller para view
// $http é a serviço do angular responsável por realizar chamadas ajax
angular.module('alurapic').controller('FotosController', function($scope, $http){

	// lista de fotos
	// o $scope é utilizado para que a view tenha acesso a essa lista
	$scope.fotos = [];

	// faz uma requisição assíncrona utilizando o método .get para carregar dados do servidor
	// $http devolve uma promisse 
	// vai executar a função de callback passada no then quando tiver sucesso na requisição
	// vai executar a função de callback passada no catch quando acontecer algum erro na requisição
	/*
	var promisse = $http.get('v1/fotos');
	promisse.then(function(retorno){
		$scope.fotos = retorno.data;
	}).catch(function(error){
		console.log(error);
	});
	*/

	// forma abreviada de fazer a mesma requisição
	// por baixo dos panos, o angular utiliza a promisse
	// neste caso não precisamos utilizar retorno.data, apenas o retorno já vai nos devolver os dados que foram carregados
	$http.get('v1/fotos')
	.success(function(retorno){
		$scope.fotos = retorno;
	})
	.error(function(error){
		console.log(error);
	});
});