$(function() {
        $("body").css("transition-duration", "2s");
    xvar = 175;
    yvar = 25;
    var xmove = xvar;
    var ymove = yvar;
    var border = 2;
    $(".widepaneimgcont").each((index, element) => {
        var xres = xmove * Math.random();
        var yres = ymove * Math.random()

        if ((index % 2) == 1) {
            $(element).css("transform", `translate(${xres}px, -${yres}px)`);
            $(element).children("img").css("height", "300px");
            $(element).children("img").css("width", "200px");
            
            $(element).children("img").css("border-radius", `${border}%`);
        } else if ((index % 2 == 0)) {
            $(element).css("transform", `translate(-${xres}px, -${yres}px)`);
            $(element).children("img").css("border-radius", `2%`);
            $(element).children("img").css("height", "300px");
            $(element).children("img").css("width", "200px");

        }

    })

  
    $("[data-article-number]").each((index, element) => {
        $(element).css("height", "20%");

        $(element).on("mouseover", () => {
            console.log("mouseover triggered");

            $("body").css("height", "150%");
            $("body").css("transition-duration", "2s");
            $(element).parent().parent().css("transition-duration", "2s");
            $(element).parent().parent().css("height", "100%");
            $(element).parent().parent().css("overflow", "initial");
            $(element).css("height", "100%");
            $(element).css("transition-duration", "1s");
            $(".wideinfopanetext").css("height", "1200px");
        });
        $(element).on("mouseleave", () => {
            console.log("mouseleave triggered")
            $("body").css("height", "75%");
            $("body").css("transition-duration", "2s");
            $(element).css("height", "20%");
            $(element).css("overflow", "hidden");
            $(element).css("transition-duration", "1s");
            $(element).parent().parent().css("height", "50%");
            $(element).parent().parent().css("transition-duration", "2s");
            $(".wideinfopanetext").css("height", "800px");

        });

    })

    
    $("[data-article-container-number]").each((index, element) => {

        $(element).css("height", "50%");



    })

   
})

function onMouseLeave(some) {

    console.log("mouseleave triggered")
    $(some).css("transition-duration", "3s");
    $(some).css("height", "30%");
    $(some).parent().parent().css("height", "400px");
    $(some).parent().parent().css("transition-duration", "2s");
}

function onMouseOver(some) {
    console.log("mouseover triggered");
    $(some).css("transition-duration", "2s");
    $(some).parent().parent().css("transition-duration", "2s");
    $(some).parent().css("transition-duration", "2s");
    $(some).css("height", "100%");
    $(some).parent().parent().css("height", "100%");

}