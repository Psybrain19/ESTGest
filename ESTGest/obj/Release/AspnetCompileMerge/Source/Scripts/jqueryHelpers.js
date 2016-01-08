(function ($) {
    $.fn.liveDelayedKeyup = function (selector, opts) {
        var defaults = {
            handler: $.noop(),
            delay: 1000
        };
        return this.each(function (index, elem) {
            $(elem).on("keyup", selector, function (e) {
                var options = $.extend({}, defaults, opts);
                var self = this;
                if (typeof (window['inputTimeout']) != "undefined") {
                    window.clearTimeout(inputTimeout);
                }
                window['inputTimeout'] = window.setTimeout(function () {
                    options.handler.call(self, e);
                }, options.delay);
            });
        });
    };

    $.fn.liveSortable = function (selector, opts) {
        return this.each(function (index, elem) {
            $(elem).on("mousemove", selector, function () {
                $(this).sortable(opts);
            });
        });
    };

    $.fn.liveDraggable = function (selector, opts) {
        return this.each(function (index, elem) {
            $(elem).on("mousemove", selector, function () {
                $(this).draggable(opts);
            });
        });
    };

    $.fn.liveDroppable = function (selector, opts) {
        return this.each(function (index, elem) {
            $(elem).on("mousemove", selector, function () {
                $(this).droppable(opts);
            });
        });
    };

    $.fn.liveAutoComplete = function (selector, opts) {
        return this.each(function (index, elem) {
            $(elem).on("mousemove", selector, function () {
                $(this).autocomplete(opts);
            });
        });
    };

    $.fn.liveHover = function (selector, callbackHoverIn, timeHoverIn, callbackHoverOut, timeHoverOut) {
        return this.each(function (index, elem) {
            $(elem).on("mousemove", selector, function () {
                $(this).hover(function () {
                    clearTimeout($(elem).data('liveHoverIn'));
                    $(elem).data('liveHoverIn', setTimeout(callbackHoverIn, timeHoverIn, $(this)));
                }, function () {
                    clearTimeout($(elem).data('liveHoverOut'));
                    $(elem).data('liveHoverOut', setTimeout(callbackHoverOut, timeHoverOut, $(this)));
                })
            })
        });
    };

    $.fn.selectRange = function (start, end) {
        return this.each(function () {
            if (this.setSelectionRange) {
                this.focus();
                this.setSelectionRange(start, end);
            } else if (this.createTextRange) {
                var range = this.createTextRange();
                range.collapse(true);
                range.moveEnd('character', end);
                range.moveStart('character', start);
                range.select();
            }
        });
    };

    $.fn.liveMyContextPopup = function (selector) {
        return this.each(function (index, elem) {
            $(elem).on("mouseenter", selector, function () {
                $(this).myContextPopup();
            });
        });
    };


    $.fn.SubmitAjaxWindowForm = function (additionalCondition, onSuccess, onFailure) {
        var selector = "input[type='submit']";
        if (additionalCondition) selector = additionalCondition + " input[type='submit']";
        return this.on("click", selector, function (e) {
            e.preventDefault();
            var eventButton = $(this);
            var window = $("#" + eventButton.closest('.k-window-content').attr("id")).data("kendoWindow");
            if (IsDisable(eventButton) == false) {
                var form = eventButton.closest('form');
                var validator = form.kendoValidator({ validateOnBlur: false }).data("kendoValidator");
                if (validator.validate()) {
                    $.ajax({
                        type: "POST", dataType: "JSON", url: form.attr("action"), data: serializeAll(form),
                        success: function (data, textStatus, jqXHR) {
                            Enable(eventButton);
                            MostrarMensagemErro(data);
                            if (data.RenderPatialViews != null) {
                                $.each(data.RenderPatialViews, function (k, v) {
                                    $(v.Selector).html(v.Html);
                                });
                            }
                            if (data.Success) {
                                if (onSuccess && typeof (onSuccess) === "function") {
                                    Disable(eventButton);
                                    onSuccess(eventButton, data);
                                }
                                if (window) window.close();
                            }
                            else {
                                if (onFailure && typeof (onFailure) === "function") {
                                    Disable(eventButton);
                                    onFailure(eventButton, data);
                                }
                            }
                        }
                    })
                }
                else Enable(eventButton);
            }
        });
    };

}(jQuery));

//function KendoForceValidation() {
//    $("form").off("submit").on("submit", function (e) {
//        var validator = $(this).kendoValidator().data("kendoValidator");
//        return validator.validate();
//    });

//    $(".k-combobox input, .k-dropdown input, .k-multiselect input").off("focusout").on("focusout", function (e) {
//        var kwidget = $(this).closest(".k-widget"), input;
//        if (kwidget.hasClass("k-multiselect")) input = $(kwidget).children("select");
//        else input = $(kwidget).children("input");
//        var form = $(this).closest('form');
//        var validator = form.kendoValidator().data("kendoValidator");
//        validator.validateInput($(input));
//    });
//}

function IsDisable(select) {
    if (select.hasClass("k-state-disabled")) return true;
    else {
        Disable(select);
        return false;
    }
}

function Disable(select) {
    if (select) select.addClass("k-state-disabled");
}

function Enable(select) {
    if (select) select.removeClass("k-state-disabled");
}

function ChecksCondition(select) {
    return $(select).length > 0;
}

function MostrarMensagemErro(data) {
    var JqMessageBox = data.JqMessageBox;
    if (JqMessageBox != null && data.JqMessageBoxFaturaConfirm) {
        showJqueryFaturaConfirmConfirm();
    }
    else if (JqMessageBox != null) {
        showJqueryConfirmDialog(JqMessageBox.Message, JqMessageBox.Title)
    }
    else if (data.JqMessageBoxRegistarOrcamentoConfirm) {
        showJqueryOrcamentoConfirmConfirm();
    }
    else if (data.JqMessageBoxLoadSaftAlert) {
        showJqMessageBoxLoadSaftAlert();
    }
}

function showJqueryConfirmDialog(message, title) {
    var msg = message.replace().replace(/\n/g, '<br />');
    $.dialog({
        animation: 'none',
        title: title,
        icon: "fa fa-info",
        content: msg,
    });
}

function WindowClose(windowElement) {
    if (windowElement.data('kendoWindow'))
        windowElement.data('kendoWindow').close();
}

function CreateWindow(id, title, buttons, model, draggable, resizable) {
    var windowElement = $("#" + id)
    WindowClose(windowElement);
    windowElement = $("<div></div>").attr('id', id).appendTo('body');
    windowElement.kendoWindow({
        title: title,
        actions: buttons,
        modal: model,
        draggable: draggable,
        resizable: resizable,
    });
    return windowElement.data('kendoWindow');
}

function OpenWindow(eventButton, id, title, buttons, model, draggable, resizable, url, data, onSuccess, onFailure, onClose) {
    $.ajax({
        type: 'POST', dataType: "JSON", url: url, data: data, traditional: true,
        success: function (data) {
            Enable(eventButton);
            if (data.Success) {
                var window = CreateWindow(id, title, buttons, model, draggable, resizable);
                window.content(data.WindowPartialViewHtml);
                window.center().open();
                window.bind('close', function (e) {
                    e.preventDefault();
                    if (onClose && typeof (onClose) === "function") {
                        Disable(eventButton);
                        onClose(eventButton, data);
                    }
                    window.destroy();
                });
                if (onSuccess && typeof (onSuccess) === "function") {
                    Disable(eventButton);
                    onSuccess(eventButton, data);
                }
            }
            else {
                MostrarMensagemErro(data);
                if (onFailure && typeof (onFailure) === "function") {
                    Disable(eventButton);
                    onFailure(eventButton, data);
                }
            }
        }
    });
}

function DownloadFiles(eventButton, url, dataToSend, onSuccess, onFailure) {
    $.ajax({
        type: 'POST', dataType: "JSON", url: url, data: dataToSend,
        success: function (data) {
            Enable(eventButton);
            MostrarMensagemErro(data);
            if (data.Success) {
                if (data.DonwloadFiles != null) {
                    $.each(data.DonwloadFiles, function (k, url) {
                        window.open(url, '_blank');
                    });
                }
                if (onSuccess && typeof (onSuccess) === "function") {
                    Disable(eventButton);
                    onSuccess(eventButton, data);
                }
            }
            else {
                if (onFailure && typeof (onFailure) === "function") {
                    Disable(eventButton);
                    onFailure(eventButton, data);
                }
            }
        }
    });
}

function ActualizaPartialViews(eventButton, url, data, onSuccess) {
    $.ajax({
        type: "POST", dataType: "JSON", url: url, data: data, traditional: true,
        success: function (data, textStatus, jqXHR) {
            Enable(eventButton);
            MostrarMensagemErro(data);
            if (data.Success) {
                if (data.RenderPatialViews != null) {
                    $.each(data.RenderPatialViews, function (k, v) {
                        $(v.Selector).html(v.Html);
                    });
                }
                if (onSuccess && typeof (onSuccess) === "function") {
                    Disable(eventButton);
                    onSuccess(eventButton, data);
                }
            }
        }
    });
}

function AjaxPost(eventButton, url, data, onSuccess, onFailure) {
    $.ajax({
        type: "POST", dataType: "JSON", url: url, data: data,
        success: function (data, textStatus, jqXHR) {
            Enable(eventButton);
            if (data.Success) {
                if (onSuccess && typeof (onSuccess) === "function") {
                    Disable(eventButton);
                    onSuccess(eventButton, data);
                }
            }
            else {
                if (onFailure && typeof (onFailure) === "function") {
                    Disable(eventButton);
                    onFailure(eventButton, data);
                }
            }
        }
    });
}

function SubmitBtn(elem, options) {
    var eventButton = $(elem);
    var form = eventButton.closest('form');
    if (eventButton.data("confirm-enable")) {
        jConfirm(eventButton.data("confirm-message"), eventButton.data("confirm-title"), { okButton: eventButton.data("confirm-okbutton"), cancelButton: eventButton.data("confirm-cancelbutton"), focusOnOK: false }, function (sim) {
            if (sim) {
                if (eventButton.data("submit-action")) form.attr({ action: eventButton.data("submit-action") });
                if (eventButton.data("submit-ajax")) SubmitFormAjax(eventButton, options.onSuccess, options.onFailure);
                else form.submit();
            }
        });
    }
    else {
        if (eventButton.data("submit-action")) form.attr({ action: eventButton.data("submit-action") });
        if (eventButton.data("submit-ajax")) SubmitFormAjax(eventButton, options.onSuccess, options.onFailure);
        else form.submit();
    }
    return false;
}
function SubmitFormAjax(eventButton, onSuccess, onFailure) {
    var window = $("#" + eventButton.closest('.k-window-content').attr("id")).data("kendoWindow");
    if (IsDisable(eventButton) == false) {
        var form = eventButton.closest('form');
        var validator = form.kendoValidator({ validateOnBlur: false }).data("kendoValidator");
        if (validator.validate()) {
            $.ajax({
                type: "POST", dataType: "JSON", url: form.attr("action"), data: serializeAll(form),
                success: function (data, textStatus, jqXHR) {
                    Enable(eventButton);
                    MostrarMensagemErro(data);
                    if (data.RenderPatialViews != null) {
                        $.each(data.RenderPatialViews, function (k, v) {
                            $(v.Selector).html(v.Html);
                        });
                    }
                    ////if (data.ActivatePooling) {
                    ////    poolingToCheckSAFT();
                    ////}
                    if (data.hideDIV) {
                        $(".divProdutoServicoDetalheBack").remove();
                        $(".divEncomendaContinuarBack").remove();
                    }
                    if (data.DisableForm) {
                        var values = {};
                        $.each(form.serializeArray(), function (i, field) {
                            $("input[name=" + field.name + "]").attr('disabled', true);
                        });
                        $("#btnGravar").attr('disabled', true);
                    }
                    if (data.Success) {
                        if (onSuccess && typeof (onSuccess) === "function") {
                            Disable(eventButton);
                            onSuccess(eventButton, data);
                        }
                        if (window && data.windowClose) {
                            window.close();
                        }
                    }
                    else {
                        if (onFailure && typeof (onFailure) === "function") {
                            Disable(eventButton);
                            onFailure(eventButton, data);
                        }
                        if (data.ClearForm) {
                            $.each(form.serializeArray(), function (i, field) {
                                $("input[name=" + field.name + "]").val('');
                            });
                        }
                    }
                }
            })
        }
        else Enable(eventButton);
    }
}

//Serialize form data to json
function serializeObject(form) {
    var o = {};
    var a = form.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

function serializeAll(form) {
    // Find disabled elements, and remove the "disabled" attribute
    var disabled = form.find('input:disabled, textarea:disabled, select:disabled').removeAttr('disabled');

    // serialize the form
    var serialized = form.serialize();

    // re-disabled the set of elements that you previously enabled
    disabled.attr('disabled', 'disabled');

    return serialized;
}

function ValidateUploadExtensions(e) {
    var arrExtensions = $("#" + e.sender.name).attr("Extensions").split(',');
    $.each(e.files, function () {
        var extension = this.extension.toLowerCase();
        if ($.inArray(extension, arrExtensions) == -1) {
            showJqueryConfirmDialog("The extension" + extension + " is not suported.", "Information");
            e.preventDefault();
            return false;
        }
    });
}

function Truncate(str, maxLength, suffix) {
    if (str.length > maxLength) {
        str = str.substring(0, maxLength + 1);
        str = str.substring(0, Math.min(str.length, str.lastIndexOf(" ")));
        str = str + suffix;
    }
    return str;
}

function kendoFormatDate(str) {
    return kendo.toString(str, "d");
}

// applyFilter function accepts the Field Name and the new value to use for filter.
function applyFilter(gridData, filterField, filterValue) {

    // get currently applied filters from the Grid.
    var currFilterObj = gridData.dataSource.filter();

    // get current set of filters, which is supposed to be array.
    // if the oject we obtained above is null/undefined, set this to an empty array
    var currentFilters = currFilterObj ? currFilterObj.filters : [];

    // iterate over current filters array. if a filter for "filterField" is already
    // defined, remove it from the array
    // once an entry is removed, we stop looking at the rest of the array.
    if (currentFilters && currentFilters.length > 0) {
        for (var i = 0; i < currentFilters.length; i++) {
            if (currentFilters[i].field == filterField) {
                currentFilters.splice(i, 1);
                break;
            }
        }
    }

    // if "filterValue" is "0", meaning "-- select --" option is selected, we don't 
    // do any further processing. That will be equivalent of removing the filter.
    // if a filterValue is selected, we add a new object to the currentFilters array.
    if (filterValue != "0") {
        currentFilters.push({ field: filterField, operator: "eq", value: filterValue });
    }

    // finally, the currentFilters array is applied back to the Grid, using "and" logic.
    gridData.dataSource.filter({ logic: "and", filters: currentFilters });
}

//function replaceNewLines(str) {
//    return str.replace(new RegExp('\r?\n', 'g'), "<br />");
//}

