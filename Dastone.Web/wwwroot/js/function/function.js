var handleFunction =
{
    DropDowlist: function (parameters, pElement, pTextOptionOne) {
        if (parameters.length == 0) return;

        var vOption = "";
        vOption += "<option value='0'>" + pTextOptionOne + "</option>"

        for (var i = 0; i < parameters.length; i++)
            vOption += "<option value='" + parameters[i].Value + "'>" + parameters[i].Text + "</option>"

        $("#" + pElement).html(vOption);
    },
    GetFilterProperty: function (arrayObj, pElement, ptype) {
        if (arrayObj.length == 0) return;

        var vElement = "";

        for (var i = 0; i < arrayObj.length; i++) {
            vElement += '<label class="containerhny-checkbox">';
            vElement += arrayObj[i].Text;

            vElement += '<input id="' + arrayObj[i].Value + '" type="checkbox" value="' + arrayObj[i].Value + '" data-value="' + arrayObj[i].Value + '" data-text="' + arrayObj[i].Text + '" data-type="' + ptype + '" class="filterType">';

            vElement += '<span class="checkmark"></span>';

            vElement += '</label>';
        }

        $("#" + pElement).html(vElement);
    },
    CreateCookies: function (nome, valor) {
        // Cria uma data 01/01/2020
        var data = new Date(2020, 0, 01);
        // Converte a data para GMT
        data = data.toGMTString();
        // Codifica o valor do cookie para evitar problemas
        valor = encodeURI(valor);
        // Cria o novo cookie
        document.cookie = nome + '=' + valor + '; expires=' + data + '; path=/';
    },
    DeleteCookies: function (nome) {
        // Cria uma data no passado 01/01/2010
        var data = new Date(2010, 0, 01);
        // Converte a data para GMT
        data = data.toGMTString();
        // Tenta modificar o valor do cookie para a data expirada
        // Assim ele será apagado
        document.cookie = nome + '=; expires=' + data + '; path=/';
    },
    FormatBrazilianDate: function () {
        var today = new Date();
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        var yyyy = today.getFullYear();

        today = dd + '/' + mm + '/' + yyyy;
        return today;
    }
}
