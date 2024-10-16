let csrfFieldName = "CSRF-TOKEN-MOONGLADE-FORM";
async function callApi(e, r, a, o, t) {
    try {
        var n = document.querySelector(`input[name="${csrfFieldName}"]`).value,
            s = await fetch(e, { method: r, headers: { Accept: "application/json", "Content-Type": "application/json", "XSRF-TOKEN": n }, credentials: "include", body: "GET" === r ? null : JSON.stringify(a) });
        s.ok ? o && o(s) : await handleHttpError(s), t && t(s);
    } catch (e) {
        blogToast.error(e), console.error(e);
    }
}
async function handleHttpError(e) {
    switch (e.status) {
        case 400:
        case 409:
            blogToast.error(await buildErrorMessage2(e));
            break;
        case 401:
            blogToast.error("Unauthorized");
            break;
        case 404:
            blogToast.error("Endpoint not found");
            break;
        case 429:
            blogToast.error("Too many requests");
            break;
        case 500:
        case 503:
            blogToast.error("Server went boom");
            break;
        default:
            blogToast.error("Error " + e.status);
    }
}
async function buildErrorMessage2(e) {
    var r = e.headers.get("content-type");
    return r && r.includes("application/json")
        ? "string" == typeof (r = await e.json())
            ? r
            : r.combinedErrorMessage ||
            Object.entries(r)
                .map(([e, r]) => e + ": " + r)
                .join("\n\r")
        : e.text();
}
