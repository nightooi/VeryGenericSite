
function PlayPromiseHandler(playPromise) {
    if (playPromise !== undefined) {
        playPromise.then(() => {
         
        }).catch(error => {

        });
    }
}

$(function () {
    let vidLen = document.getElementsByTagName('video').length
    var k = 0;
    for (var i = 0; i < vidLen; i++) {
        document.getElementsByTagName('video')[i].addEventListener("loadedmetadata", (element) => {
            $(element.target).attr("data-video-len", element.target.duration)
            $(element.target).attr("video-metadataloaded", true);
            if (element.target.duration == document.getElementsByTagName('video')[0].duration) {
                $(element.target).trigger("LoopVideo", element.target);
                k++;
            }
        })
    }

    $("video").each(
        (index, element) => {
            if (index == 0)
            {
                $(element).fadeIn();
            }
            else
            {
                $(element).fadeOut();
            }
        }
    )
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

            $(nextVideo).css("transform", `translateX(-${pos}px)`);
        }
    })
})

function VideoFadeout(video, nextVideo, time) {

        if (video.currentTime <= time) {
            $(video).fadeTo(time, 0);
            setTimeout(() => { $(video).removeAttr("autoplay") }, time);
        }
        VideoFadeIn(nextVideo, time);
        var len = document.getElementsByTagName('video').length
        $(document).trigger("LoopVideo", nextVideo);
}

function VideoFadeIn(nextVideo, time) {

    $(nextVideo).attr("autoplay");
    $(nextVideo).fadeTo(time, 1);
    $(document).trigger("move-me", nextVideo, time);
    PlayPromiseHandler(nextVideo.play());
    console.log($(nextVideo).attr("data-video-len") + ":::NEXTVIDEOLEN");
}

function RunVideoLoop(vidLen, iterator) {

        iterator++;

        if ((0 < iterator) && (iterator < $("video").length - 1))
        {

            //const vid = $("video")[iterator - 1];
            //const nextVid = $("video")[iterator];
            const vid = document.getElementsByTagName("video")[iterator - 1];
            const nextVid = document.getElementsByTagName("video")[iterator];
            //$(vid).fadeOut(2000);
            //$($("video")[iterator]).fadeIn(2000);
            //PlayPromiseHandler($("video")[iterator].play());
             VideoFadeout(vid, nextVid, 2000);
        }
        else if (iterator == 0 && !isNaN(timeout))
        {
            //const vid = $("video")[$("video").length - 1];
            //const nextVid = $("video")[iterator];
            const vid = document.getElementsByTagName("video")[vidLen- 1];
            const nextVid = document.getElementsByTagName("video")[iterator];
            //$(vid).fadeOut(2000);
            //$($("video")[iterator]).fadeIn(2000);
            //$("video")[iterator].currentTime = 0;
            //PlayPromiseHandler($("video")[iterator].play());
            VideoFadeout(vid, nextVid, 2000);

        }
        else if (iterator == $("video").length - 1)
        {
            //const nextVid = document.getElementsByTagName("video")
            //const vid = $("video")[$("video").length - 2];
            const vid = document.getElementsByTagName("video")[vidLen-1];
            const nextVid = document.getElementsByTagName("video")[0];
            //$(vid).fadeOut(2000);
            //$($("video")[iterator]).fadeIn(2000);
            //$("video")[iterator].currentTime = 0;
            //PlayPromiseHandler($("video")[iterator].play());
            VideoFadeout(vid, nextVid, 2000);
        }
}






















