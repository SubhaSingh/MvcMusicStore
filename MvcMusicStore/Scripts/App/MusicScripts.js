/// <reference path="jquery-1.10.2.js" />
/// <reference path="jquery-ui-1.10.3.js" />

$("input[data-autocomplete-source]").each(function () {
    var target = $(this);
    target.autocomplete({ source: target.attr("data-autocomplete-source") });
});

$("#artistSearch").submit(function (event) {
    event.preventDefault();
    var form = $(this);
    $.ajax({
        url: form.attr("action"),
        data: form.serialize(),
        beforeSend: function () {
            $("#ajx-loader").show();
        },
        complete: function () {
            $("#ajax-loader").hide();
        },
        error: searchFailed,
        success: function (data) {
            var html = Mustache.to_html($("#artistTemplate").html(),
                { artists: data });
            $("#searchresults").empty().append(html);
        }
});
});