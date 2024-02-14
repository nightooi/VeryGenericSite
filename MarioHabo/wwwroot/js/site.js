﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    var reloadId;
    $(window).load(
        function(){
            $("a").each(
                (i, t) => {
                    $(t).attr("data-ajax", "false");
                }
            )
        }
    )
        
    $(window).on("resize", () => {
        clearTimeout(reloadId);
        reloadId = setTimeout(() => {
            window.location.href = window.location.href;
        },250);
    })
   
})
