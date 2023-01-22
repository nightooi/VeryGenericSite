function PlayPromiseHandler(playPromise) {
    if (playPromise !== undefined) {
        playPromise.then(() => {
            
        }).catch(error => {

        });
    }
}
$(function () {

    var iterator = 0;
    var playPromIter = 0;
    $("video").each((index, element) => {

        if ($(element).attr("autoplay")) {
            
            
            $(element).fadeIn();
        } else {
            $(element).fadeOut();
        }

    })
 

        setInterval(() => {
            iterator++;

            if ((0 < iterator) && (iterator < $("video").length - 1)) {

                const vid = $("video")[iterator - 1];
                $(vid).fadeOut(2000);
                $($("video")[iterator]).fadeIn(2000);
                //$("video")[iterator].currentTime = 0;
                PlayPromiseHandler($("video")[iterator].play());
            }
            else if (iterator == 0) {
                const vid = $("video")[$("video").length - 1];
                $(vid).fadeOut(2000);
                $($("video")[iterator]).fadeIn(2000);
                //$("video")[iterator].currentTime = 0;
                PlayPromiseHandler($("video")[iterator].play());
            }
            else if (iterator == $("video").length - 1) {

                const vid = $("video")[$("video").length - 2];
                $(vid).fadeOut(2000);
                $($("video")[iterator]).fadeIn(2000);
                //$("video")[iterator].currentTime = 0;
                PlayPromiseHandler($("video")[iterator].play());
                iterator = -1;
            }

        }, 6000);
})
            