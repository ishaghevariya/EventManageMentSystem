// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function(){
    var placeholderelement = $('placeholder');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url')
        $.get(url).done(function (data) {
            placeholderelement.html(data);
            placeholderelement.find('.modal').modal('show');
        })
    })
})