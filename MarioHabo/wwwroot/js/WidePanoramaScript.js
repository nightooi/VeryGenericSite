
//probably shouldve been a class...
const __cardID__protoype = {

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
        const a = this.__Card__.css();
        this.__Card__.css(csseffectObject);
        this.__Card__.css(a);
    },

    TimeLeft() {
        return Math.ceil((this.timeoutID)._idleStart + this.timeoutID._idleTimeout - Date.now());
    },

    setElementVisibility() {
        if (this.htmlcard.hasClass("d-none") || (this.htmlcard.css("opacity") == 0)) {
            this.htmlcard.removeClass("d-none"); this.htmlcard.css("opacity", "1");
        }
    },


}
function CardTrigger(htmlcard, intervalTime, extendTime) {
    //baseobject
    this.__Card__ = $(htmlcard);
    //eventHandlers for base data;
    this.__Card__.on('mouseenter', (event) => {
        this.mouseEnterTime = Date.now() / 1000;
    })
    this.__Card__.on('mouseleave', (event) => {
        this.mouseLeaveTime = Date.now() / 1000;
    })
    //base data;
    this.__Card__.on('next', this.onNextHandler);
    this.timeoutID = setTimeout(() => { }, intervalTime);
    this.intervalTime = intervalTime;
    this.CurrentTime = this.TimeLeft();
}

//defaults too 5400ms
function CardLoop(TimePerCard = 5400, Validator, cardSelector,
    preSelector = [ 'gs-*'], Attribute,  preAttributeSelector = ['gs-*']) {

    static const defaultPerItem = 5400; 
    this.ElementsCount = $(cardSelector).length;
    this.TotalCardLoopTime = TimePerCard * this.ElementsCount;
    this.IndividualTime = new Array(this.ElementsCount);
    
    this.Validator = () => { 
        const RegexChecker = (checkAgainst, patterns) => {

            if (Array.isArray(patterns) || patterns === undefined) {
                var RegexArray = {
                    objectRegexPattern: {
                        time: ['time', 'timeCard', 'timeperCard'],
                        timePerCard: ['\\d'],
                        ArrayRegexPatterns: () => {
                            return [...RegexArray.objectRegexPattern.time, ...RegexArray.ObjectRegexPattern.timePerCard];
                        }
                    }
                };
                if (patterns.objectRegexPattern !== undefined) {
                    RegexArray = [...patterns.objectRegexPattern, ...RegexArray.objectRegexPattern];
                } else if (patterns.time !== undefined && patterns.objectRegexPattern === undefined) {
                    RegexArray  = [...patterns.time, ...RegexArray.objectRegexPattern.time];
                }

                var cheCheck = (key, object) => {
                    if (key.toString() == RegexArray.objectRegexPattern.time[0]) {
                        return this.Validator(object[key])
                    }
                    if (key.toString().toLowerCase().match(`/(${RegexArray.objectRegexPattern.time})`) &&
                        (Object.keys(object).indexOf(
                            str => String(str).match(`/(time)`)).length < 2)) {
                        return this.Validator(object[key]);
                    }


                    if (key.toString().toLowerCase().match('/(timeper)')) {
                        if (key.toString().tolowerCase().match('/(card)')) {
                            let number = key.toString().tolowerCase().match('\\d');
                            number = Number.parseInt(number) > this.ElementsCount - 1 ? -1 : number;
                            if (number > -1) {
                                this.IndividualTime[number] = this.Validator(object[key]);
                            } else {

                            }
                        } else if (key.toString().tolowerCase().match('/')) {
                        } else {

                    }
                    } else if (key.toSTring().tolowerCase().match()) {

                    }
                }



             
            } else {
                throw "I literally can't be fucked to write another checker"
            }
        }

        const check = patterns => 
                (function (object, Validate) {
                    if (typeof (object) !== 'Number' && Validate) {
                        return (Validate) => Validate;
                    } else if (typeof (object) !== 'Number' && !(Validate)) {
                        if (Array.isArray(object)) {

                        } else if (typeof (object) === 'object') {
                            
                            for (key in object) {

                            }
                        }
                    } else if (Number.isInteger(object)) {
                        if (object < 100) {
                            debugger
                            console.log(`Value supplied for element is too short,
                                        increasing by 1000 at element ${$(cardSelector)}`)
                            return object * 1000;
                        }
                        return object;
                    } else if (typeof (object) === 'string') {
                        object.replace([' ', ';', '.', ','], '');
                        if (object.indexOf('s') == object.length) {
                            return Number.parseInt(object) * 1000;
                        } else {
                            debugger
                            console.log(`could not parse out string,
                               using default value for
                               Element::\n${$(cardSelector)}\n\n Value${this.defaultPerItem}`)
                            return this.defaultPerItem;
                        }
                    } else if (Number.isInteger(object)
                        && ((() => { return object % 1 }) > 0)) {
                        if (Math.ceil(object) < 100) {
                            debugger
                            console.log(`value supplied for element is too short,
                                increasing by 1000 at element${$(element)}`);
                            return object * 1000;
                        }
                        else {
                            return Math.ceil(object);
                        }
                    }
                })(object, Validattor);
    };

    this.CardValidator = () => {

    };

    this.preSelectorValidator = () => {
        if (cardSelector.contains('-')) {
            return (function (cardSelector) {
                var a = cardSelector.firstIndexOf('-');

            })(cardSelector);
        } else if (Array.isArray(cardSelector)) {
            return (function (ArraySelector) {
                for (var item of ArraySelector) {
                    if (typeof (item) == 'object') {
                    }
                }
            })(cardSelector)
        } else if (typeof (cardSelector) === 'object') {

        }
    }

    //validator function that returns a object which contains the 
    //fields selectorVal..cardVal..preSelecVal... or just one of them depeding on the object context.
    this.Validator = (validator) => {
        if (validator) {
            return validator();
        }
        const Props = ["selectorValidator", "cardValidator", "preSelectorValidator"];
        for (var key of Props) {
            if (Validator.hasOwnProperty(key)) {
                return Validator[key](this[key]);
            }
        } (function () {
            if (Validator) return () => {
                if (Validator(this.preSelector).hasOwnProperty(key))
                {
                   return Validator(Validator.)
                }
            }
        })
}



var __emplace__prototype__ = {

}
$(function () {
    let somel = 2;

    const b = {
        'some2': somel => somel*2 
    }

    const a = (some) => {
        const i = ["some1", "some3", "some2"];
         for (let k of i) {
            if (some.hasOwnProperty(k)) {
                console.log("found prop");
                return console.log(some[k](some[k].arguments));
            }
         }
    }
    b.some2(2);
    console.log(a(b));



    
    console.log(Date.now());
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
                a.setElementVisibility();
            })
    })

})

