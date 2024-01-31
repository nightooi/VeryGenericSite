import { ajax } from "jquery";

function PlayPromiseHandler(playPromise) {
    if (playPromise !== undefined) {
        playPromise.then(() => {
            
        }).catch(error => {

            console.log(error);
        });
    }
}

var totalVidLen = 0;
$(function () {

    $("video").each((index, element) => {
        $(element).on('loadedmetadata', () => {
            totalVidLen += $(element).length;
        })
    })

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

        }, totalVidLen);
})

function VideoFadeout(video, nextVideo, time) {

    if ($(video).currentTime >= time) {
        $(video).fadeOut(time)
    }
    VideoFadeIn(nextVideo, time);
}

function VideoFadeIn(nextVideo, time) {

        $(nextVideo).fadeIn(time);
}






















