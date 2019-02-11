// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Add keyup-event handler to input box that triggers the form's submit event handler
//Results in search for every key-press
$(document).on("keyup", "#searchString", function (evt) {
    $("form[data-ajax=true]").trigger("submit");
});
