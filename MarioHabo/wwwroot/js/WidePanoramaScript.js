
//probably shouldve been a class...
var __cardID__protoype = {

    whileHover(){
        if (this.mouseLeaveTime == 0) {
            pcTimeSpent = (Date.now() / 1000) - mouseEnterTime;
        }
    },

    calcTime(){
        if (this.mouseEnterTime > 0 && this.mouseLeaveTime > 0) {
            return this.mouseEnterTime - mouseLeaveTime;
        }
        return undefined;
    },

    onMouseEnter(){
        clearTimeout(timeoutID);
        this.whileHover();
    },

    OnMouseLeave(){
        if (this.CurrentTime > 3000) {
            clearTimeout(timeoutID);
            timeoutID = setTimeout(this.TriggerNext(), extendTime);
        }
        else if (this.CurrentTime == undefined) {

        }
    },

    TriggerNext() {

        setTimeout(card.trigger('next', [event, card, this]), this.intervalTime)
    },
    //csseffectObject {"transition-duration": "2s", "opacity": "0"}, is not testing for null or anything else, care! duration first, other effects after.
    onTriggerNext(csseffectObject) {
        let a = this.__Card__.css();
        this.__Card__css(csseffectObject[0]);
        var b = Array.create(csseffectObject);
        b.remove(csseffectObject[0]);
        this.__Card__.css(csseffectObject);
        this.__Card__.css(a);
    },

    TimeLeft() {
        return Math.ceil((this.timeoutID)._idleStart + this.timeoutID._idleTimeout - Date.now() / 1000);
    },


}


function CardTrigger(htmlcard, intervalTime, extendTime){
    this.__Card__ = $(htmlcard);
    this.__Card__.on('mouseenter', (event) => {
        this.mouseEnterTime = Date.now() / 1000;
    })

    this.__Card__.on('mouseleave', (event) => {
        this.mouseLeaveTime = Date.now() / 1000;
    })

    this.__Card__.on('next', this.onNextHandler);

    this.timeoutID = setTimeout(() => { }, intervalTime);
    this.intervalTime = intervalTime;
    this.CurrentTime = this.TimeLeft();
    this.extendTime = extendTime;
    this.mouseEnterTime = 0;
    this.mouseLeaveTime = 0;
    let TimeSpent = this.calcTime();
    this.pcTimeSpent = 0;
}

function emplaceByDimesions(htmlcard  )
{
    this.htmlcard = $(htmlcard);
}

var __emplace__prototype__ = {

    _setElementVisibility() {

        if (this.htmlcard.hasClass("d-none"))
        {
            this.htmlcard.removeClass("d-none");
        }
       
    },

    moveElement() {
        
        
    },
}




$(function () {

    $(".card").parent().is(".column, .h-25, mb-lg-2, bg-opacity-75");
    
    $(".card").each((index, item) => {

        if ($(item).attr("data-transpose-top") != undefined) {
            let keyvaluep = $(item).attr("data-transpose-top").replace(";", "");
            let result = Object.fromEntries([keyvaluep.split(":")]);
            $(item).css(result);
            console.log($(item).attr("data-transpose-top"));
        }

        $(item)

            .on("mouseenter", (event) => {

                Object.assign(CardTrigger.prototype, __cardID__protoype);
                var a = new CardTrigger(event.target, 2000, 300);

                console.log(a);
                console.log(a.mouseEnterTime);
                Object.assign(emplaceByDimesions.prototype, __emplace__prototype__);
                var b = new emplaceByDimesions($(".card")[1]);
                b._setElementVisibility();
            })
    })
})

