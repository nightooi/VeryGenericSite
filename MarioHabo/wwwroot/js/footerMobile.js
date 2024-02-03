
$(function(){ 
    
    const isTouch = () => {return ('ontouchstart' in window) || (navigator.maxTouchPoints > 0) || (navigator.msMaxTouchPoints> 0)}
    if ((this.documentElement.clientWidth >= 320 * 2 || this.documentElement.clientWidth <= 500 * 2) && isTouch()) {

        let hoverState = 0;
        let container = $(".footercontainer");
        let downPos = container.css("bottom");
        let parsedDownPos = parseInt(downPos);
        let selected = 0;
        let dataAttr = "data-current-pos-b";
        let startCoords = 0;
        let upState = 0;
        let currentHeight = 0;

        container.on("vmousedown", (eventargs) => {
            selected = true;
            startCoords = eventargs.clientY;

            $('body').css({
                overflow: 'hidden',
                height: '100%'
            });

            if (parseInt($(".footercontainer").css("bottom")) != -420) {

                currentHeight = parseInt($(".footercontainer").css("bottom"));
                selected = true;
                upState = true;
                console.log(parseInt($(".footercontainer").css("bottom")) + "::UpState");
                console.log(upState + " ::bool");
            }
        })

        $(document).on("vmousemove", (eventargs) => {
            if (selected) {
                let scrollDistance = calcScrollHeight(startCoords, eventargs.clientY);
                let input = 0;
                if (upState) {
                    console.log(currentHeight + " :::CurrentHeight::upState")
                    input = (currentHeight + scrollDistance);
                    console.log(input + " ::input");
                    if (input > parsedDownPos - 5 && input < 0) {
                        container.css("transition-duration", "0s");
                        container.css("bottom", `${parseInt(input)}px`)
                    }
                }
                else {
                    console.log(currentHeight + "::currentHeightChecked");
                    currentHeight = -parsedDownPos;
                    input = 0 - (currentHeight - scrollDistance)

                    if (input > parsedDownPos - 5 && input < 0) {
                        console.log(currentHeight + " ::currentHeight");
                        container.css("transition-duration", "0s");
                        container.css("bottom", `${parseInt(input)}px`);
                    }
                }
            }
        })


        $(".footercontainer").on("tap", () => {
            offset = 0;
            $(".footercontainer").css("bottom", downPos);
            upState = false;
            selected = false;
            $('body', 'html').css({
                height: "auto",
                overflow: "auto"
            })
        })
        $(document).on("tap", () => {
            offset = 0;
            $(".footercontainer").css("transition-duration", "0.2s");
            $(".footercontainer").css("bottom", downPos);
            console.log(downPos + " ::downPos")
            selected = false;
            $('body', 'html').css({
                height: "auto",
                overflow: "auto"
            })
        })
    }
    else
    {
        $(".footercontainer").on("mouseenter", (event) => {

            if (window.matchMedia("(hover: hover").matches) {
                $(".footercontainer").css("transition-duration", "0.73s");
                hoverState = true;
                $(event.target).addClass("hover");
            }
        })

        $(".footercontainer").on("mouseleave", (event) => {
            if (window.matchMedia("(hover: hover)").matches) {
                if (hoverState) {
                    $(".footercontainer").css("transition-duration", "0.73s");
                    $(event.target).removeClass("hover");
                    hoverState = false;
                }
            }
        })
    }
})

function normaliseString(obj) {
    parseFloat(obj);
    console.log(obj +" ::obj at normalize")
    return obj
}
function calcScrollHeight(start, current) {

    console.log(start + " ::start");
    console.log(current + " ::current");
    console.log(start - current +" ::start-current");
    return start - current;
}
