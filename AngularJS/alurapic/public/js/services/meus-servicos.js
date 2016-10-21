// O serviço deve ser criado quando queremos compartilhar elementos entre vários controllers
// O serviço é injetado no controller igual fazemos com o $http, $resource e etc
// Vale lembrar que o serviço guarda estado. Ou seja, pode ser utilizado para compartilhar informações entre controllers
angular.module('meusServicos', ['ngResource'])
// o primeiro parametro é o nome do serviço
// o segundo parametro é uma função que sempre deve retornar um objeto
.factory('recursoFoto', function($resource){
	// null é utilizado para passar parametro via queryString
	// o resource não suporta o verbo HTTP PUT, por isso precisamos implementá-lo
	return recursoFoto = $resource('v1/fotos/:fotoId', null, {
		update:{
			method: 'PUT'
		}
	});
})
// $q nos permite criar nossas próprias promisses
.factory('cadastroDeFotos', function(recursoFoto, $q, $rootScope){
	var servico = {};
	var evento = 'fotoCadastrada';
	servico.cadastrar = function(foto){
		// o parametro resolve é uma função que será executada quando a promisse for resolvida com sucesso
		// o parametro reject é uma funcção que será executada em caso de erro
		// estas funções estão implementadas pelo controller que utilizar o serviço cadastroDeFotos através do .then e do .catch
		return $q(function(resolve, reject){
			// caso a foto possua id, estamos alterando
			// se não, estamos cadastrando uma foto nova
			if (foto._id) {
				recursoFoto.update({fotoId: foto._id}, foto, function(foto){
					// quando uma foto for cadastrada, disparamos o evento chamado fotoCadastrada
					// não podemos utilizar $scope na diretiva, pois não temos acesso (e nem devemos ter) a ele
					// por isso, devemos utilizar o $rootScope que é o scope pai de todos os controllers no Angular
					$rootScope.$broadcast(evento);
					resolve({
						mensagem: 'Foto ' + foto.titulo + ' foi alterada com sucesso!',
						inclusao: false
					});
				}, function(erro){
					console.log(erro);
					reject({
						mensagem: 'Não foi possível editar a foto ' + foto.titulo
					});
				});
			} else{
				recursoFoto.save(foto, function(foto){
					$rootScope.$broadcast(evento);
					resolve({
						mensagem: 'Foto ' + foto.titulo + ' incluída com sucesso!',
						inclusao: true
					});
				}, function(erro){
					console.log(erro);
					reject({
						mensagem: 'Não foi possível incluir a foto ' + foto.titulo
					});
				});
			}
		});
	};
	return servico
});