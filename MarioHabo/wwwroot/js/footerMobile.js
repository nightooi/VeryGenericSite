
$(function(){ 
    

    if (this.documentElement.clientWidth >= 320*2 || this.documentElement.clientWidth <= 500*2)
    {
        let container = $(".footercontainer");
        let selected = 0;
        let dataAttr = "data-current-pos-b";
        let startCoords = 0;
        let upState = 0;
        let currentHeight = 0;

            container.on("vmousedown", (eventargs) => {
                selected = true;
                startCoords = eventargs.clientY;
                if (parseInt($(".footercontainer").css("bottom")) != -420) {

                    currentHeight = parseInt($(".footercontainer").css("bottom"));
                    selected = true;
                    upState = true;
                    console.log(parseInt($(".footercontainer").css("bottom")) + "::UpState");
                    console.log(upState + " ::bool");
                }
            })

        $(document).on("vmousemove", (eventargs) => {

            if (selected)
            {
                let scrollDistance = calcScrollHeight(startCoords, eventargs.clientY);
                let input = 0;
                if (upState) {
                    console.log(currentHeight + " :::CurrentHeight::upState")
                    input = (currentHeight + scrollDistance);
                    console.log(input + " ::input");
                    if ( input > -425 && input < 0) {
                        container.css("transition-duration", "0s");
                        container.css("bottom", `${parseInt(input)}px`)
                    }
                }
                else
                {
                    console.log(currentHeight + "::currentHeightChecked");
                    currentHeight = 420;
                    input = 0- (currentHeight - scrollDistance)

                    if (input < 0) {
                        console.log(currentHeight + " ::currentHeight");
                        container.css("transition-duration", "0s");
                        container.css("bottom", `${parseInt(input)}px`);
                    }
                }
                
            }
        })
        $(document).on("vmouseup", ()=> {

            seleced = false;
        })
            
            $(".footercontainer").on("tap", () => {
                offset = 0;
                $(".footercontainer").css("transition-duration", "0.2s");
                $(".footercontainer").css("bottom", "-420px");
                upState = false;
                selected = false;
                $(".footercontainer")[1].setAttribute(dataAttr, "-420");
            })
            $(document).on("tap", () => {
                offset = 0;
                $(".footercontainer").css("transition-duration", "0.2s");
                $(".footercontainer").css("bottom", "-420px");
                $(".footercontainer")[1].setAttribute(dataAttr, "-420");
                selected = false;
            })
    }

})

function normaliseString(obj) {
    parseFloat(obj);
    console.log(obj +" ::obj at normalise")
    return obj
}

function calcScrollHeight(start, current) {

    console.log(start + " ::start");
    console.log(current + " ::current");
    console.log(start - current +" ::start-current");
    return start - current;
}
