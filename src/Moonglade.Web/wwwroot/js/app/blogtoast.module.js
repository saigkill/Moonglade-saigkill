let bsToast = new bootstrap.Toast(document.getElementById("liveToast")),
    blogtoastMessage = document.querySelector("#blogtoast-message"),
    lt = document.querySelector("#liveToast"),
    bgClasses = ["bg-success", "bg-warning", "bg-danger", "bg-info", "bg-primary", "bg-secondary"];
function removeToastBgColor() {
    bgClasses.forEach((s) => lt.classList.remove(s));
}
function showToast(s, o) {
    removeToastBgColor(), lt.classList.add(o), (blogtoastMessage.innerHTML = s), bsToast.show();
}
function success(s) {
    showToast(s, "bg-success");
}
function info(s) {
    showToast(s, "bg-info");
}
function warning(s) {
    showToast(s, "bg-warning");
}
function error(s) {
    showToast(s, "bg-danger");
}
export { bsToast, blogtoastMessage, success, info, warning, error };
