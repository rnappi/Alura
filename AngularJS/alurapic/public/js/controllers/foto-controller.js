angular.module('alurapic').controller('FotoController', function($scope, cadastroDeFotos, $routeParams){
	$scope.foto = {};
	$scope.mensagem = '';

	/*
	// $routeParams nos dá acesso aos parâmetros passados na url através da rota
	if ($routeParams.fotoId) {
		$http.get('v1/fotos/' + $routeParams.fotoId)
		.success(function(foto){
			$scope.foto = foto;
		})
		.error(function(erro){
			console.log(erro);
			$scope.menssagem = 'Não foi possível obetr a foto';
		});
	}

	$scope.submeter = function(){
		if ($scope.formulario.$valid) {
			// se a foto possui um id, estamos alterando a foto
			// caso não tenha, estamos incluindo uma nova foto
			if ($scope.foto._id) {
				$http.put('v1/fotos/' + $scope.foto._id, $scope.foto)
				.success(function(){
					$scope.mensagem = 'Foto ' + $scope.foto.titulo + ' foi alterada com sucesso!';
				})
				.error(function(erro){
					$scope.mensagem = 'Não foi possível editar a foto ' + $scope.foto.titulo;
					console.log(error);					
				});
			} else{
				$http.post('v1/fotos', $scope.foto)
				.success(function(){
					$scope.foto = {};
					$scope.mensagem = 'Foto incluída com sucesso!';
				})
				.error(function(erro){
					$scope.mensagem = 'Não foi possível incluir a foto';
					console.log(error);
				});					
			}		
		}
	};
	*/

	// $routeParams nos dá acesso aos parâmetros passados na url através da rota
	if ($routeParams.fotoId) {
		recursoFoto.get({fotoId: $routeParams.fotoId}, function(foto){
			$scope.foto = foto;
		}, function(erro){
			console.log(erro);
			$scope.menssagem = 'Não foi possível obetr a foto';			
		});
	}

	$scope.submeter = function(){
		if ($scope.formulario.$valid) {
			cadastroDeFotos.cadastrar($scope.foto)
			.then(function(dados){
				$scope.mensagem = dados.mensagem;
				if (dados.inclusao) $scope.foto = {};
				$scope.focado = true;
			})
			.catch(function(dados){
				$scope.mensagem = dados.mensagem;
			});		
		}
	};
});