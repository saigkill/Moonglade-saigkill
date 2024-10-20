function ImageUploader(n, i, o) {
    var d = "";
    (this.uploadImage = function (e) {
        var t, a;
        d
            ? ((t = document.querySelector("#btn-upload-" + n)).classList.add("disabled"),
                t.setAttribute("disabled", "disabled"),
                (a = d.replace(/^data:image\/(png|jpeg|jpg);base64,/, "")),
                callApi(
                    e,
                    "POST",
                    a,
                    function (e) {
                        var t = document.getElementById(n + "modal"),
                            t = (t && (t.style.display = "none"), blogToast.success("Updated"), new Date());
                        document.querySelector(".blogadmin-" + n).src = `/${n}?` + t.getTime();
                    },
                    function (e) {
                        t.classList.remove("disabled"), t.removeAttribute("disabled");
                    }
                ))
            : blogToast.error("Please select an image");
    }),
        (this.fileSelect = function (e) {
            var t, a;
            e.stopPropagation(),
                e.preventDefault(),
                window.File && window.FileReader && window.FileList && window.Blob
                    ? (e.dataTransfer ? ((t = e.dataTransfer.files[0]), (document.querySelector(".custom-file-label-" + n).innerText = t.name)) : (t = e.target.files[0]),
                        t.type.match("image.*")
                            ? (((a = new FileReader()).onloadend = function () {
                                var r = new Image();
                                (r.src = a.result),
                                    (r.onload = function () {
                                        var e = r.width,
                                            t = r.height,
                                            a = (t < e ? i < e && ((t *= i / e), (e = i)) : i < t && ((e *= i / t), (t = i)), document.createElement("canvas"));
                                        (a.width = e), (a.height = t), a.getContext("2d").drawImage(r, 0, 0, e, t), (d = a.toDataURL(o));
                                        document.querySelector(`#${n}DropTarget`).innerHTML = `<img class="img-fluid" src="${d}" />`;
                                        e = document.querySelector("#btn-upload-" + n);
                                        e.classList.remove("disabled"), e.removeAttribute("disabled");
                                    });
                            }),
                                a.readAsDataURL(t))
                            : blogToast.error("Please select an image file."))
                    : blogToast.error("The File APIs are not fully supported in this browser.");
        }),
        (this.dragOver = function (e) {
            e.stopPropagation(), e.preventDefault(), (e.dataTransfer.dropEffect = "copy");
        }),
        (this.bindEvents = function () {
            document.getElementById(n + "ImageFile").addEventListener("change", this.fileSelect, !1);
            var e = document.getElementById(n + "DropTarget");
            e.addEventListener("dragover", this.dragOver, !1), e.addEventListener("drop", this.fileSelect, !1);
        }),
        (this.getDataUrl = function () {
            return d;
        });
}
