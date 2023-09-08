var HelperHttp =
{
    GetAll: function (parameters, success, fail) {
        $.ajax({
            type: 'post',
            url: parameters.Url,
            data: parameters,
            dataType: 'html',
            success: function (data) {
                $(parameters.DivId).html(data);
                success(true);
            },
            beforeSend: function () {
                //$(".se-pre-con").fadeOut("slow");
                //$("#loading").addClass("se-pre-con");
            },
            complete: function () {
                //$(".se-pre-con").fadeOut("hide");
                //$("#loading").removeClass("se-pre-con");
            },
            error: function (request) {
                fail(request.status);
            }
        });
    },
    Add: function (parameters, success, fail) {

        $.ajax({
            url: parameters.Url,
            data:
            {
                Obj: parameters.Obj
                // __RequestVerificationToken: parameters.requestVerificationToken
            },
            type: 'post',
            success: function (data) {
                success(true);
            },
            beforeSend: function () {

            },
            complete: function () {

            },
            error: function (request) {
                fail(request.status);
            }
        });
    },
    GetById: function (parameters, success, fail) {
        $.ajax({
            url: parameters.Url,
            data: { Id: parameters.Obj.Id },
            type: 'post',
            success: function (data) {

                if (typeof data == "object")
                    success(data);
            },
            beforeSend: function () {

            },
            complete: function () {

            },
            error: function (request, textStatus) {
                fail(request.status);
            }
        });
    },
    Update: function (parameters, success, fail) {
        $.ajax({
            url: parameters.Url,
            data: { Obj: parameters.Obj },
            type: 'post',
            success: function (data) {

                if (typeof data == "object")
                    success(data);
            },
            beforeSend: function () {

            },
            complete: function () {
            },
            error: function (request) {
                fail(request.status);
            }
        });
    },
    Delete: function (parameters, success, fail) {
        $.ajax({
            url: parameters.Url,
            data: { Id: parameters.Obj.Id },
            type: 'post',
            success: function (data) {
                if (typeof data == "object")
                    success(data);
            },
            beforeSend: function () {
            },
            complete: function () {
            },
            error: function (request) {
                fail(request.status);
            }
        });
    },
    GetDropDownList: function (parameters, success, fail) {
        $.ajax({
            url: parameters.Url,
            type: 'post',
            success: function (data) {
                if (typeof data == "object")
                    success(data);
            },
            beforeSend: function () {
            },
            complete: function () {
            },
            error: function (request) {
                fail(request.status);
            }
        });
    }
};