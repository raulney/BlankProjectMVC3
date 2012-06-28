head(function () {
    $(".accordion").accordion('activate', 1);

    $(".inativar").click(function () {

        var link = $(this);

        confirm({ message: "Deseja realmente inativar este grupo de acesso?", yesCallback: function () {

            $.post($(this).attr('action'), {}, function (resultado) {

                $(link).hide();
                $(link).siblings('.ativar').show();
                alert('<label class="msgSucesso">Grupo de acesso inativado com sucesso</label>');

            });

        }
        });

        return false;

    });

    $(".ativar").click(function () {

        var link = $(this);

        confirm({ message: "Deseja realmente reativar este grupo de acesso?", yesCallback: function () {

            $.post($(this).attr('action'), {}, function (resultado) {

                $(link).hide();
                $(link).siblings('.ativar').show();
                alert('<label class="msgSucesso">Grupo de acesso reativado com sucesso</label>');

            });

        }
        });

        return false;

    });

});