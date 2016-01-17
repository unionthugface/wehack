var WeHack = { Layout: {}, Services: {}, Page: {}, Utilities: {} };

WeHack.Ajax = function (inputModel) {
    if (!inputModel.URL) {
        console.log("diversitech.Ajax requires a URL");
        return;
    }

    var AjaxSettings = {
        headers: {
            Accept: "application/json; charset=utf-8",
        },
        url: inputModel.URL,
        type: inputModel.Method || "GET",
        data: inputModel.Data,
        success: inputModel.Success || WeHack.Handlers.Success,
        error: inputModel.Error || WeHack.Handlers.Error,
        cache: false,
        WeHackModel: inputModel
    };

    if (inputModel.AjaxSettings) {
        jQuery.extend(true, AjaxSettings, inputModel.AjaxSettings);
    }

    $.ajax(AjaxSettings);
};

WeHack.Handlers.Error = function (jqXHR, textStatus, errorThrow) {
    if (WeHack.Page.ErrorHandler) {
        WeHack.Page.ErrorHandler(jqXHR, textStatus, errorThrow);
    }
    else if (WeHack.Layout.ErrorHandler) {
        WeHack.Layout.ErrorHandler(jqXHR, textStatus, errorThrow);
    }
    else if (console) {
        console.log("not ok");
        console.log(textStatus);
    }
};

WeHack.Handlers.Success = function (data) {
    console.log("all ok");
    console.log(data);
};