$(function () { 
    timer = 500;
    $(".footercontainer").css("transition-duration", "0.75s");
    lastscroll = 0;
    setTimeout(() => {
        if (this.documentElement.clientWidth >= 320 || this.documentElement.clientWidth <= 500) {
            $(window).scroll((event) => {
                var current = $(this).scrollTop();
                if (current > lastscroll) {
                    $(".footercontainer").css("bottom", "-380px");
                }
                else {
                    $(".footercontainer").css("bottom", "-420px");
                }
                lastscroll = current;
            })

            $(".footercontainer").on("click", (event) => {

                $(".footercontainer").css("bottom", "0px");
            })
        }
    }, timer);
})