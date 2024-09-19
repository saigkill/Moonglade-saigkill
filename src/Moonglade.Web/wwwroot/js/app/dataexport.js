function convertJSONtoCSV(e) {
    var o = [],
        n = Object.keys(e[0]);
    o.push(n.join(","));
    for (let t of e) {
        var r = n.map((e) => `"${("" + t[e]).replace(/"/g, '\\"')}"`);
        o.push(r.join(","));
    }
    return o.join("\n");
}
function downloadCSV(e, t) {
    var e = new Blob([e], { type: "text/csv" }),
        e = URL.createObjectURL(e),
        o = document.createElement("a");
    o.setAttribute("hidden", ""), o.setAttribute("href", e), o.setAttribute("download", t), document.body.appendChild(o), o.click(), document.body.removeChild(o);
}
function exportCSV(e, t) {
    fetch(e)
        .then((e) => e.json())
        .then((e) => {
            downloadCSV(convertJSONtoCSV(e), t);
        })
        .catch((e) => {
            console.error("Error:", e);
        });
}
