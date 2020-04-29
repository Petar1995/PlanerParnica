$(document).ready(function () {
    var i = 1;
    $("#AddAdvokat").click(function () {
        var div = $("<div />");
        var value = "";

        var Advokat = $("<input />").attr("type", "textbox").attr("name", "ParnicaAdvokati");

        Advokat.val(value);
        div.append(Advokat);

        var button = $("<input />").attr("type", "button").attr("value", "remove");
        button.attr("onclick", "RemoveTextBox(this)");
        div.append(button);
        $("#AdvokatiTbxContainer").append(div);
        i++;
    });
});
function RemoveTextBox(button) {
    $(button).parent().remove();
};
$(function () {
    $("#PripadaKompaniji").click(function () {
        if ($(this).is(':checked')) {
            $("#KompanijaNaziv").show();
            $("#KompanijaAdresa").show();
        }
        else {
            $("#KompanijaNaziv").hide();
            $("#KompanijaAdresa").hide();
        }
    });
});
