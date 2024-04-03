
function PlayPromiseHandler(playPromise) {
    if (playPromise !== undefined) {
        playPromise.then(() => {
           
        }).catch(error => {
            console.log(error);
        });
    }
}
function ScreenSize() {
    this.screenSize;
}
$(function () {
    let vidLen = document.getElementsByTagName('video').length
    for (var i = 0; i < vidLen; i++) {
        document.getElementsByTagName('video')[i].load();
        var vid = $(document.getElementsByTagName('video')[i]);
        document.getElementsByTagName('video')[i].addEventListener("loadedmetadata", (element) => {
            $(element.target).attr("data-video-len", element.target.duration)
            if (element.target.duration == document.getElementsByTagName('video')[vidLen - 1].duration) {
                $(document).trigger("LoopVideo", document.getElementsByTagName('video')[0]);
            }
        })
    }

        $(document).on("LoopVideo", (event, obj) => {
            console.log($(obj).attr("data-video-len"))
            setTimeout(() => {
                var vids = document.getElementsByTagName('video');
                for (var i = 0; i < vids.length; i++) {
                    if ($(obj).attr("data-video-len") == $(vids[i]).attr("data-video-len")){
                        if (i+1 < vids.length) {
                            VideoFadeout(obj, vids[i+1], 2000, i);
                        }
                        else {
                            VideoFadeout(obj, vids[0], 2000, i);
                        }
                    }
                }
            }, (parseFloat($(obj).attr("data-video-len")) - 2) * 1000);
        })

    $(document).on("move-me", (event, nextVideo, time) => {
        console.log($(nextVideo).position());
        var pos = 0;
        if ((pos = $(nextVideo).position().left) > 0) {
        console.log($(nextVideo).parent().width().toPrecision() +":::precision width");
        }
    })
})

function VideoFadeout(video, nextVideo, time) {

        if (video.currentTime <= time) {
            $(video).fadeTo(time, 0);
            setTimeout(() => {
                video.pause();
                $(video).removeAttr("autoplay")
            }, time);
        }
        VideoFadeIn(nextVideo, time);
        var len = document.getElementsByTagName('video').length
        $(document).trigger("LoopVideo", nextVideo);
}

function VideoFadeIn(nextVideo, time) {
    Show(nextVideo);
    $(nextVideo).attr("autoplay");
    $(nextVideo).fadeTo(time, 1);
    $(document).trigger("move-me", nextVideo, time);
    nextVideo.currentTime = 0;
    PlayPromiseHandler(nextVideo.play());
    console.log($(nextVideo).attr("data-video-len") + ":::NEXTVIDEOLEN");
}


function Show(video) {

    if ($(video).css("display").match("none"))
    {
        $(video).fadeIn();
    }
}


















