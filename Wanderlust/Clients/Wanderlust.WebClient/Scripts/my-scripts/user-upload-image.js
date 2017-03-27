'use strict';

//$(document).ready(() => {
    var redirectUrl = "";
    var buttonToHide;
    var url = window.location.toString().toLowerCase();
    if (url.indexOf("/profile/editprofile") > 0) {
        redirectUrl = "http://www.wanderlust.com/profile";
        buttonToHide = $("#MainContent_ButtonUpdateAvatarUrl");
    } else if (url.indexOf("/upload/useruploadimage") > 0) {
        redirectUrl = "http://www.wanderlust.com/posts";
        buttonToHide = $("#Submit");
    }

    buttonToHide.hide();

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

    function onAvatarUploadSuccess(e) {
        window.location.replace(redirectUrl);
    }

    function onAvatarUploadError(e) {
        var response = e.XMLHttpRequest.response;
    }
//});