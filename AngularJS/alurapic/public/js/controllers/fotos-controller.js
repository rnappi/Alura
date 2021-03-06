// cria o controller e injeto o $scope (POJO) no controle
// $scope serve para disponibilizar dados do controller para view
// $http é a serviço do angular responsável por realizar chamadas ajax
angular.module('alurapic').controller('FotosController', function($scope, recursoFoto){

	// lista de fotos
	// o $scope é utilizado para que a view tenha acesso a essa lista
	$scope.fotos = [];
	$scope.filtro = '';
	$scope.menssagem = '';

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
	/*
	$http.get('v1/fotos')
	.success(function(retorno){
		$scope.fotos = retorno;
	})
	.error(function(error){
		console.log(error);
	});

	$scope.remover = function(foto){
		$http.delete('v1/fotos/' + foto._id)
		.success(function(){
			var indiceFoto = $scope.fotos.indexOf(foto);
			$scope.fotos.splice(indiceFoto, 1);
			$scope.menssagem = 'Foto ' + foto.titulo + ' foi removida com sucesso';
		})
		.error(function(erro){
			console.log(erro);
			$scope.menssagem = 'Não foi possível remover a foto ' + foto.titulo;
		});
	};
	*/

	// o método query do ngResource executa automaticamente o método get (API REST),
	// utilizando a url informada na linha a cima sem considerar o coringa :fotoId 
	// o primeiro parametro é executado no sucesso da requisição
	// o segundo parametro é executado em caso de erro
	recursoFoto.query(function(fotos){
		$scope.fotos = fotos;
	}, function(erro){
		console.log(erro);
	});
	
	$scope.remover = function(foto){
		// executa o método delete da API REST preenchendo o coringa fotoId com o valor que desejamos
		// o segundo parametro é executado no sucesso
		// o terceiro parametro é executado nem caso de erro
		recursoFoto.delete({fotoId: foto._id}, function(){
			var indiceFoto = $scope.fotos.indexOf(foto);
			$scope.fotos.splice(indiceFoto, 1);
			$scope.menssagem = 'Foto ' + foto.titulo + ' foi removida com sucesso';
		}, function(erro){
			console.log(erro);
			$scope.menssagem = 'Não foi possível remover a foto ' + foto.titulo;		
		});
	};
});