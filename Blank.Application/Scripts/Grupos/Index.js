head(function () {
    
    $(".accordion").accordion();
    $(".button").button();

    $(".filtraGrupos").click(function () {

        var form = $("#formGrupo");

        $.pjax({
            url: form.attr('action'),
            type : 'GET',
            data : form.serialize(),
            container: '#resultado'
        });

    });

});