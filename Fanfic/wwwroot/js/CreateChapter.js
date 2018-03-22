
$(document).ready(function () {
    var CLOUDINARY_URL = 'https://api.cloudinary.com/v1_1/dni30lw1x/upload';
    var CLOUDINARY_UPLOAD_PRESET = 'e92eplhi';
    $(".DropZone2").on("drop", function (e) {
        this.className = "DropZone2 d-flex align-items-center";

        e.preventDefault();
        e.stopPropagation();
        var file = e.originalEvent.dataTransfer.files[0];
        var formData = new FormData();
        formData.append('file', file);
        formData.append('upload_preset', CLOUDINARY_UPLOAD_PRESET);

        axios({
            url: CLOUDINARY_URL,
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-from-urlencoded'
            },
            data: formData

        }).then(function (res) {
            $("#DragImage").attr('src', res.data.secure_url);
            $(".Picture").attr('value', res.data.secure_url);

        })
    });
    $(".DropZone2").on("dragover", function (e) {
        e.preventDefault();
        e.stopPropagation();
        this.className = "DropZone2 dragover";
        return false;
    });

    $(".DropZone2").on("dragleave", function (e) {
        e.preventDefault();
        e.stopPropagation();
        this.className = "DropZone2";
        return false;
    });

    $("#nav-show-tab").click(function () {
        $.post(
            '/FanFic/RenderMarkDown/',
            {
                data: ($('#ChapterText').html()),
            },
            function (data) {
                $('#MarkDown').html(data);
            });
    });

    $(document).scroll(function () {
        if ((window.pageYOffset) >= 264)
            $(".Chapters").css("top", 0)
        else
            $(".Chapters").css("top", 264 - window.pageYOffset)

    })
})
