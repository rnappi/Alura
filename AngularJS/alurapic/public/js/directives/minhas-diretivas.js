// cria o módulo chamado minhasDiretivas
angular.module('minhasDiretivas', ['meusServicos'])
// cria uma diretiva dentro do módulo 'minhasDiretivas'
// Toda diretiva deve retornar um ddo (Directive Definition Object)
// este objeto é o responsável pela configuração da diretiva
.directive('meuPainel', function(){
	
	// Directive Definition Objet
	// define as configurações da diretiva
	var ddo = {};
	
	// restrição de uso da diretiva
	// informamos que está diretiva pode ser utilizada como A = attribute ou E = element
	// attribute = <div meu-painel></div>
	// element = <meu-painel></meu-painel>
	// nome da diretiva em camelcase, quando utilizar no HTML utilizar '-'
	ddo.restrict = "AE";

	// cria um scopo isolado para a diretiva
	// assim, podemos garantir que esta diretiva não influenciará no comportamento de nenhum elemnto da view que ela for inserida
	// assim também, garantimos que nada na view influenciará no comportamento da diretiva
	ddo.scope = {
		//@titulo é o nome do atributo utilizado na tag para se comunicar com o Angular
		//estamos pegando o valor deste atributo (que está na tag) e colocando em uma propriedade interna chama titulo
		//assim, meu código terá acesso ao valor deste atributo
		//o '@' quer dizer que o valor do atributo será passado 'por valor' para dentro do angular, será uma string cópia da original
		//titulo: '@titulo'

		// neste caso, como a propriedade interna e o nome do atributo são iguais (titulo), podemos utilizar apenas o @
		titulo: '@'
	}

	// liga o mecanismo de transclude do angular
	// isso faz com que a diretiva possa incluir dentro do seu template algum elemento filho que está na marcação HML
	// Exemplo: <meu-painel><img src="teste" alt="teste"></meu-painel>
	// a tag 'img' é um elemento filho da diretiva e poderá ser incluído dentro do template graças ao tranclude = true
	ddo.transclude = true;

	// template HTML que será criado na view que utilizar esta diretiva
	/*
	ddo.template = 
			'<div class="panel panel-default">'
		+	'	<div class="panel-heading">'
        +	'		<h3 class="panel-title">{{titulo}}</h3>'
        +	'	</div>'
        //utilizamos a diretiva ng-transclude 
        //... isso informa ao angular que o objeto filho da diretiva 'meu-painel' que está definido no HTML da view
        //... deve ser inserido dentro deste div
        +	'	<div class="panel-body" ng-transclude>'
        +	'	</div>'
        +	'</div>'
    */

    //ao invés de escrever o template aqui e misturar js com HTML
    //vamos isolar o HTML utilizando a propriedade templateUrl
    ddo.templateUrl = 'js/directives/meu-painel.html';

	// retorna a diretiva e suas configurações
	return ddo;
});

angular.module('minhasDiretivas').directive('minhaFoto', function(){
	var ddo = {};
	ddo.restrict = 'E';
	ddo.scope = {
		url: '@',
		titulo: '@'
	};
	ddo.transclude = false;
	ddo.template = '<img class="img-responsive center-block" src="{{url}}" alt="{{titulo}}">';
	return ddo;
});

angular.module('minhasDiretivas').directive('meuBotaoPerigo', function(){
	var ddo = {};
	ddo.restrict = 'E';
	ddo.scope = {
		// & quer dizer que estamos recebendo a referência de uma função que está sendo implementada no controller
		// @ quer dizer que estamos recebendo uma string por valor, não uma referência para uma expressão/função
		acao: '&',
		nome: '@'
	};
	ddo.template = '<button ng-click="acao(foto)" class="btn btn-danger btn-block">{{nome}}</button>'
	return ddo;
});

angular.module('minhasDiretivas').directive('meuFocus', function(){
	var ddo = {};
	ddo.restrict = 'A';
	
	/*
	ddo.scope = {
		// '=' perite que as alterações na propriedade seja refletida tanto no cntroller quanto na diretiva
		// usamos '=' porque se trata de uma propriedade com comunicação bi-direcional
		focado: '='
	};
	*/

	// link é uma fase do angular que é executada logo após a fase de compile
	// nesta fase, temos acesso ao scope da diretiva e o element do DOM em que a diretiva esta sendo aplicada
	// só conseguimos adicionar watchers nas propriedades nesta fase
	ddo.link = function(scope, element){
		/*
		// watch recebe o nome da propriedade do scopo da diretiva que vai ser monitorada
		// e recebe a função que será executada todas as vezes que a propriedade for alterada
		// com o watch, podemos receber o valor atual e o valor antes da mudança como parametro
		// ex: scope.$watch('focado', function(novoValor, valorAntigo){});
		scope.$watch('focado', function(){
			if (scope.focado) {
				// não estamos utilizando o focus do jQuery
				// o Angular utiliza o jqLight que não possui a função focus
				// por isso, estamos aplicando o focus nativo do javascript diretamente no elemento do DOM (element[0])
				element[0].focus();
				scope.focado = false;
			}
		});
		*/

		// fazendo a mesma coisa utilizando o gerenciador de eventos do Angular
		// vamos utilizar o evento fotoCadastrada que está sendo disparado no controller responsável pelo cadastramento da foto
		scope.$on('fotoCadastrada', function(){
			element[0].focus();
		});
	}

	return ddo;
});

angular.module('alurapic').directive('meusTitulos', function(){
	var ddo = {};
	ddo.restrict = 'E';
	ddo.template = '<ul><li ng-repeat="titulo in titulos">{{titulo}}</li></ul>';
	ddo.controller = function($scope, recursoFoto){
		recursoFoto.query(function(fotos){
			$scope.titulos = fotos.map(function(foto){
				return foto.titulo;
			});
		});
	};
	return ddo;
});