'use strict';

var maxFileSize = 5 * 1024 * 1024, // bytes
    invalidFileExtMsg = "The allowed file formats are .jpeg, .jpg and .png.",
    selectFileMsg = "Select image...";

$(document).ready(() => {
    var saveUrl = "";
    var redirectUrl = "";
    var buttonToHide;
    var url = window.location.toString().toLowerCase();
    if (url.indexOf("/profile/editprofile") > 0) {
        saveUrl = "http://www.dev.wanderlust.com/upload/uploadprofilepic";
        redirectUrl = "http://www.dev.wanderlust.com/profile";
        buttonToHide = $("#MainContent_ButtonUpdateAvatarUrl");
    } else if (url.indexOf("/upload/useruploadimage") > 0) {
        saveUrl = "http://www.dev.wanderlust.com/upload/uploadimage";
        redirectUrl = "http://www.dev.wanderlust.com/posts";
        buttonToHide = $("#Submit");
    }

    buttonToHide.hide();

    $("#file-upload-image").kendoUpload({
        async: {
            saveUrl: saveUrl,
            autoUpload: false
        },
        validation: {
            allowedExtensions: [".jpg", ".jpeg", ".png"],
            maxFileSize: maxFileSize
        },
        multiple: false,
        localization: {
            invalidFileExtension: invalidFileExtMsg,
            select: selectFileMsg
        },
        upload: onUpload,
        success: onSuccess,
        error: onError
    });

    $("#upload-by").change((e) => {
        var upload;
        if (e.currentTarget.value === "file") {
            upload = $("#file-upload-image").data("kendoUpload");
            if (upload) {
                upload.enable();
            }

            $("#ImageUrl").hide();
            buttonToHide.hide();
        } else {
            upload = $("#file-upload-image").data("kendoUpload");
            if (upload) {
                upload.disable();
            }

            $("#ImageUrl").show();
            buttonToHide.show();
        }
    });

    function onUpload(e) {
        var inputImgTitle = $('#ImageDescription');
        if (inputImgTitle) {
            var imgTitle = inputImgTitle.val();
            var xhr = e.XMLHttpRequest;
            if (xhr) {
                xhr.addEventListener("readystatechange", function (e) {
                    if (xhr.readyState === 1 /* OPENED */) {
                        xhr.setRequestHeader("Image-Description", encodeURIComponent(imgTitle));
                    }
                });
            }
        }

        var inputImgCountry = $('#Country');
        if (inputImgCountry) {
            var imgCountry = inputImgCountry.val();
            var xhr = e.XMLHttpRequest;
            if (xhr) {
                xhr.addEventListener("readystatechange", function (e) {
                    if (xhr.readyState === 1 /* OPENED */) {
                        xhr.setRequestHeader("Image-Country", encodeURIComponent(imgCountry));
                    }
                });
            }
        }

        var inputImgCity = $('#City');
        if (inputImgCity) {
            var imgCity = inputImgCity.val();
            var xhr = e.XMLHttpRequest;
            if (xhr) {
                xhr.addEventListener("readystatechange", function (e) {
                    if (xhr.readyState === 1 /* OPENED */) {
                        xhr.setRequestHeader("Image-City", encodeURIComponent(imgCity));
                    }
                });
            }
        }
    }

    function onSuccess(e) {
        $('#ErrorMessage').text("");
        window.location.replace(redirectUrl);
    }

    function onError(e) {
        var response = e.XMLHttpRequest.response;
        if (response.ErrorMsg) {
            $('#ErrorMessage').text(e.XMLHttpRequest.response);
        }
    }
});