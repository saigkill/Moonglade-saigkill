function toMagicJson(e) {
    var t,
        r = {};
    for (t in e)
        Object.prototype.hasOwnProperty.call(e, t) &&
            (e[t]
                ? (e[t],
                    Array.isArray(e[t]) || "true" !== e[t].toLowerCase()
                        ? e[t] && !Array.isArray(e[t]) && "false" === e[t].toLowerCase()
                            ? ((r[t.replace("ViewModel.", "")] = !1), (r[t.replace("settings.", "")] = !1))
                            : ((r[t.replace("ViewModel.", "")] = e[t]), (r[t.replace("settings.", "")] = e[t]))
                        : ((r[t.replace("ViewModel.", "")] = !0), (r[t.replace("settings.", "")] = !0)))
                : ((r[t.replace("ViewModel.", "")] = null), (r[t.replace("settings.", "")] = null)));
    return r;
}
function formatUtcTime(r = !0) {
    document.querySelectorAll("time").forEach((e) => {
        var t = e.getAttribute("data-utc-label");
        t && ((t = new Date(t.replace(/-/g, "/"))), (t = r ? t.toLocaleString() : t.toLocaleDateString()), (e.innerHTML = t));
    });
}
export { toMagicJson, formatUtcTime };
