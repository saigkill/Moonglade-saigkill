import * as blogToast from "/js/app/blogtoast.module.js";
(window.blogToast = blogToast), (window.emptyGuid = "00000000-0000-0000-0000-000000000000");
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]')),
    tooltipList = tooltipTriggerList.map(function (o) {
        return new bootstrap.Tooltip(o);
    });
