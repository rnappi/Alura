// cria o controller e injeto o $scope (POJO) no controle
// o $scope serve para disponibilizar dados do controller para view
angular.module('alurapic').controller('FotosController', function($scope){
	$scope.foto = {
		titulo: 'Leão',
		url: 'http://www.fundosanimais.com/Minis/leoes.jpg'	
	};
});