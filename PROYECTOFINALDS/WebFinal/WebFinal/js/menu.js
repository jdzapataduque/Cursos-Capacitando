	$(document).ready(main);
	function main () {

		$('.menu_bar').click(efecto);
		$('#login').click(mostarFormulario);
		$('#inicio').click(mostrar);
		$('#contact').click(okidoki);
	}
	function efecto()
	{
		$('nav').slideToggle();
	}
	function mostarFormulario()
	{
		$('#formulario').slideToggle();
	}
	function mostrar () {
		alertify.error('Error Inesperado');
	}
	function okidoki () {
		alertify.success("Contacto");
	}
