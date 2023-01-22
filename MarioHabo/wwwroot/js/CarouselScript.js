function changeTexContents(hiddeninput, stat, increaseImgNumb) {
    increaseImgNumb;
    it = 0;
    hiddeninput.each((index, value) => {
        if (`imgnumbcarouselevent+${it}` == value.getAttribute("id")) {
            console.log(it + " :hiddencontent it changeTexContents")
            it++;
            if (stat == parseInt(value.getAttribute("value"))) {
                let header;
                let tex;

                var number = parseInt(hiddeninput[index + 1].getAttribute("value"))
                console.log(number + " :number to decide what text")

                header = $(".hiddencontentsubheader")[number];
                tex = $(".hiddencontenttext")[number];

                console.log(header.innerText + " :header trimmed");
                console.log(tex.innerText + " :text not trimmed");



                $(".carouseltextcontainer").trigger("onPicEventTrigger", [header.innerText.replace(tex.innerText, ""), tex.innerText, stat]);
            }
        }
    })
}

function setCorrBodyBlockHeight() {

    if ($(window).height() > $("body > .d-block").height()) {

        var px = parseFloat($(window).height()) - parseFloat($("body > .d-block").height());
        $("body > .d-block").css("margin-bottom", `${px}px`);
    }
}

$(function () {


    $(".carousel").on(
        "onPicEventTrigger", (event, header, tex, index) => {

            if (header == $("#textheader").text().replace(tex, "")) return;
            $("#textheader").fadeTo(500,0);
            $("#textparagraph").fadeTo(500, 0);
            setTimeout(() => {
                $("#textheader").text(header).stop().fadeTo(1000, 1);
                $("#textparagraph").text(tex).stop().fadeTo(1000, 1);
            }, 600);
            
            
            
            console.log(" ::: event was caught::: header: " + header + " ::: " + "text: " + tex);
    })


    $(".carousel").on(
        "onPicEventTrigger", (event, header, text, index) => {

            console.log(index + " ::: CarouDotsEventHandler INDEX");


            $(".caroudots").eq(index - 1).removeClass("caroudotstoggle"); $(".caroudots").eq(index + 1).removeClass("caroudotstoggle");
            $(".caroudots").eq(index).addClass("caroudotstoggle");
        }
    )

  
    

    const items = $(".imgimgcont").length;
    var itemid = "imgcont";

    for (i = 0; i < items; i++) {

        if (i > 0) {

            $(`#${itemid + i}`).css("visibility", "hidden");
        }
    }
    var negative = 1280;
    var state = 0;
    var itemid = "imgcont";
    const showpic = {
        "transform": "translateX(1280px)"
    };
    const showpicneg = {
        "transform": "translateX(-1280px)"
    }
    const moveout = {
        "transition-duration": "1s",
        "transform": "translateX(-1280px)",
    }
    const movein = {
        "visibility": "visible",
        "transistion-duration": "1s",
        "transform": "translateX(0px)",
    }
    const moveoutneg = {

        "transition-duration": "1s",
        "transform": "translateX(1280px)",
    }

    const carouselTextContext = $("<inputs>[type=:hidden]");
    const hiddeninputs = $('input[type=hidden]');
    var increaseOnImgNumb = 0;

    $(".mycarouselnextbutton").click(() => {


        increaseOnImgNumb = 0;

        console.log(state);

        if (state == items - 1) {
            console.log(items);
            let previmg = $(`#${itemid + (items - 1)}`);
            console.log(state + " första");
            let nextimg = $(`#${itemid + 0}`);
            previmg.css(moveout);
            nextimg.css(movein);
            changeTexContents(hiddeninputs, state, increaseOnImgNumb);
            state = 0;
        } else if (1 < state < items) {
            console.log("second triggered");
            let previmg = $(`#${itemid + state}`);
            let nextimg = $(`#${itemid + (state + 1)}`);
            let prevprev = $(`#${itemid + (state - 1)}`);
            prevprev.css(showpic);
            previmg.css(moveout);
            nextimg.css(movein);
            console.log(state);
            console.log(state);
            changeTexContents(hiddeninputs, state, increaseOnImgNumb);
            increaseOnImgNumb = 0;
            state++;
        } else if (state == 31) {
            console.log(state + " third trigger");
            let nextnext = $(`#${itemid + (state + 0)}`)
            let nextimg = $(`#${itemid + (state - 1)}`);
            let previmg = $(`#${itemid + (state)}`);
            nextnext.css(showpic);
            prevprev.css(showpicneg);
            console.log(state);
            previmg.css(moveoutneg);
            nextimg.css(movein);
            console.log(state);
            changeTexContents(hiddeninputs, state, increaseOnImgNumb);
            increaseOnImgNumb = 0;
            state++;
        }
        changeTexContents(hiddeninputs, state, increaseOnImgNumb);

    })
    $(".mycarouselprevbutton").click(() => {


        if (state == 0) {

            console.log(state)
            let previmg = $(`#${itemid + (0)}`);
            let nextimg = $(`#${itemid + (items - 1)}`);
            nextimg.css(showpicneg);
            console.log(state);
            previmg.css(moveoutneg);
            nextimg.css(movein);
            console.log(state);
            state = items;
            console.log(state);
            changeTexContents(hiddeninputs, state, increaseOnImgNumb);
            state--;
        } else if (state == items) {
            state = items;
            let nextimg = $(`#${itemid + (state - 0)}`);
            let previmg = $(`#${itemid + (state)}`);
            console.log(state);
            previmg.css(moveoutneg);
            nextimg.css(movein);
            console.log(state);
            changeTexContents(hiddeninputs, state, increaseOnImgNumb);
            increaseOnImgNumb = 0;
            state--;
        }
        else if (state < items) {
            let prevprev = $(`#${itemid + (state + 2)}`)
            let nextnext = $(`#${itemid + (state - 2)}`)
            let nextimg = $(`#${itemid + (state - 1)}`);
            let previmg = $(`#${itemid + (state)}`);
            prevprev.css(showpic);
            nextnext.css(showpicneg);
            console.log(state);
            previmg.css(moveoutneg);
            nextimg.css(movein);
            console.log(state);
            changeTexContents(hiddeninputs, state, increaseOnImgNumb);
            increaseOnImgNumb = 0;
            state--;
        }
        else if (state == 31) {
            let prevprev = $(`#${itemid + (state + 2)}`)
            let nextnext = $(`#${itemid + (state + 0)}`)
            let nextimg = $(`#${itemid + (state - 1)}`);
            let previmg = $(`#${itemid + (state)}`);
            nextnext.css(showpic);
            prevprev.css(showpicneg);
            console.log(state);
            previmg.css(moveoutneg);
            nextimg.css(movein);
            console.log(state);
            changeTexContents(hiddeninputs, state, increaseOnImgNumb);
            increaseOnImgNumb = 0;
            state--;
        }

        changeTexContents(hiddeninputs, state, increaseOnImgNumb);
        increaseOnImgNumb = 0;

    })


    var circles = $(".caroudots").length;
    var circlescont = $(".subtextdotcontainer");
    var movpx = 14 * circles;

    var parentcontwidth = $(".carouseltextcontainer").width();
    console.log(parentcontwidth);
    var parentcontpos = $(".carouseltextcontainer").css("left");
    console.log(parseInt(parentcontpos))


    var visiblearea = parseInt(parentcontpos) - parentcontwidth;
    console.log(visiblearea);

    var middleoffset = (visiblearea / 2) - (circlescont.width() / 2) - $(".mycarouselprevbutton").width();
    console.log(middleoffset);
    circlescont.css("left", `${1000 + middleoffset}px`);

    const translateXAmount = 35;
    var timeoutresetdots;

    $(".carouseltextcontainer").hover(() => {
        var translatedots = (visiblearea * 0.35);
        circlescont.css("transform", `translateX(-${translatedots}px) scale(0.40)`);
        if (timeoutresetdots != null) {
            clearInterval(timeoutresetdots);
        }
        clearTimeout(leavetimeoutdotscont);

        console.log(translatedots + " :dots")
        $(".carouseltextcontainer").css("transform", `translateX(-${translateXAmount}%)`);
        timeoutresetdots = setInterval(() => { circlescont.css("transform", `translateX(-${translatedots}px) scale(0.40)`) }, 1000)
    })

    var leavetimeoutdotscont;

    $(".carouseltextcontainer").mouseleave((e) => {
        leavetimeoutdotscont = setTimeout(() => {

            for (i = 0; i < $(".mycarouselnextbutton").children().length; i++) {
                clearInterval(timeoutresetdots);
                if (e.relatedTarget.className == ".mycarouselnextbutton.border-0") {
                    e.stopImmediatePropagation();
                    e.stopPropagation();
                } else if (e.relatedTarget.nodeName == "BUTTON") {
                    e.stopImmediatePropagation();
                }
                else if (e.relatedTarget.nodeName == "SPAN") {

                    e.stopImmediatePropagation();
                }
                else {
                    $(".subtextdotcontainer").stop();

                    $(".subtextdotcontainer").css("transform", "translateX(0%) scale(0.4)");
                    $(".carouseltextcontainer").css("transform", "translateX(0%)");

                }
            }
            console.log(e.relatedTarget);
            console.log(e.relatedTarget.nodeName);
            console.log(e);

        }, 1000)
    })
    $(".mycarouselnextbutton").hover((e) => {
        $(".carouseltextcontainer").trigger('mouseover', e);

    })

    changeTexContents(hiddeninputs, state, increaseOnImgNumb);
    
    increaseOnImgNumb = 0;
    setCorrBodyBlockHeight();

})


