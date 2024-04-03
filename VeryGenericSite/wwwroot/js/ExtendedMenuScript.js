
$(function () {
var timeoucallb;
    let i = $("#extendedmenu")
    let b = { transform: "translateX(-1500px)" };
    let c = { transform: "translateX(0px)" }
    let v = $("#menubutton");
    $(document).ready(() => {

        i.css(b)

    });

    v.click(() => {
        clearTimeout(timeoucallb);
        i.css(c);

    })

    i.mouseleave(() => { timeoucallb = setTimeout(() => { i.css(b) }, 1230) })

    i.mouseenter(() => { clearTimeout(timeoucallb); i.css(c) })
})

