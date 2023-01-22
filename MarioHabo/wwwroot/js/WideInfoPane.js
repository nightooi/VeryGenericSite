$(function() {
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
        $(element).css("overflow", "hidden");

        $(element).on("mouseover", () => {
            console.log("mouseover triggered");

            $("body").css("height", "150%");
            $("body").css("transition-duration", "2s");
            $(element).parent().parent().css("transition-duration", "2s");
            $(element).parent().parent().css("height", "100%");
            $(element).parent().parent().css("overflow", "initial");
            $(element).css("height", "100%");
            $(element).css("overflow", "initial");
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
            $(element).parent().parent().css("overflow", "hidden");
            $(element).parent().parent().css("transition-duration", "2s");
            $(".wideinfopanetext").css("height", "800px");

        });

    })
        $("body").css("transition-duration", "2s");

    
    $("[data-article-container-number]").each((index, element) => {

        $(element).css("height", "50%");
        $(element).css("overflow", "hidden");



    })

   
})

function onMouseLeave(some) {

    console.log("mouseleave triggered")
    $(some).css("height", "30%");
    $(some).css("overflow", "hidden");
    $(some).css("transition-duration", "1s");
    $(some).parent().parent().css("height", "400px");
    $(some).parent().parent().css("overflow", "hidden");
    $(some).parent().parent().css("transition-duration", "1s");
}

function onMouseOver(some) {
    console.log("mouseover triggered");
    $(some).css("height", "100%");
    $(some).css("overflow", "initial");
    $(some).css("transition-duration", "1s");
    $(some).parent().parent().css("height", "100%");
    $(some).parent().parent().css("overflow", "initial");
    $(some).parent().parent().css("transition-duration", "1s");

}