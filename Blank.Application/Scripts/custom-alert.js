$(function(){
	$("body").append("<div id='alertPadrao' style='display: none;' title='Atenção'></div>");
});

function alert(message){
	alertCustomizado(message);
}

function alertCustomizado(message){
	$("#alertPadrao").html(message);
	$("#alertPadrao").dialog({ modal: true, resizable : false }).position({ my: "center", at: "center", of: window });
}