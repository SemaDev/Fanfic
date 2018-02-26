
$(document).ready(function () {
    


    $(".JanreSelect2").select2({
        placeholder: "Enter janre",
        ajax: {
            url: "/Fanfic/GetJanres",
            dataType: "json",
            delay: 250,
            data: function (params) {
                return {
                    searchTerm: params.term
                };
            },

            processResults: function (data, params) {
                return {
                    results: data
                };
            }
        }
    }
    );

    $(".tagSelect2").select2({
        placeholder: "EnterTags",
        tags: true,
        ajax: {
        url: "/Fanfic/GetTags",
            dataType: "json",
            delay: 250,
            width: "100%",
            data: function (params) {
                return {
        searchTerm: params.term
                };
            },

            processResults: function (data, params) {
                return {
        results: data
                };
            }
        }
    });



    var CLOUDINARY_URL = 'https://api.cloudinary.com/v1_1/dni30lw1x/upload';
    var CLOUDINARY_UPLOAD_PRESET = 'e92eplhi';
    $(".DropZone").on("drop", function (e) {
        this.className = "DropZone d-flex align-items-center";

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
        'Content-Type' : 'application/x-www-from-urlencoded'

            },
            data: formData

        }).then(function (res) {
        $("#DragImage").attr('src', res.data.secure_url);
        $(".Picture").attr('value', res.data.secure_url);

    })
    });
    $(".DropZone").on("dragover", function (e) {
        e.preventDefault();
    e.stopPropagation();
        this.className = "DropZone dragover";
        return false;
    });

    $(".DropZone").on("dragleave", function (e) {
        e.preventDefault();
    e.stopPropagation();
        this.className = "DropZone";
        return false;
    });
})
