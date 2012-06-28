$(function(){
	$("body").append('<div id="confirmPadrao" style="display: none;" title="Atenção"></div>');
});

function confirm(data){
	confirmCustomizado(data['message'], data['yesCallback'], data['noCallback']);
}

function confirmCustomizado(message, yesCallback, noCallback){
	$("#confirmPadrao").html(message);
	$("#confirmPadrao").dialog({
				resizable: false,
				modal: true,
				buttons: {
				    "Não": function () {
						$(this).dialog("close");
						if (noCallback != null && $.isFunction(noCallback)) {
							noCallback.apply();
						}
					},
					Sim: function() {
						$(this).dialog("close");
						if ($.isFunction(yesCallback)) {
							yesCallback.apply();
						}
					}
				}}).position({ my: "center", at: "center", of: window });
}