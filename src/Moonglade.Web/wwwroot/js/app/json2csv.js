<<<<<<< HEAD:src/Moonglade.Web/wwwroot/js/app/dataexport.js
function convertJSONtoCSV(e) {
    var o = [],
        n = Object.keys(e[0]);
    o.push(n.join(","));
    for (let t of e) {
        var r = n.map((e) => `"${("" + t[e]).replace(/"/g, '\\"')}"`);
        o.push(r.join(","));
=======
function convertJSONtoCSV(data) {
    if (!data || !data.length) {
        console.error('No data provided');
        return '';
    }

    const csvRows = [];
    const headers = Object.keys(data[0]);
    csvRows.push(headers.join(','));

    for (const row of data) {
        const values = headers.map(header => {
            let value = row[header];
            if (value === null || value === undefined) {
                value = '';
            }
            const escapedValue = ('' + value).replace(/"/g, '""');
            return `"${escapedValue}"`;
        });
        csvRows.push(values.join(','));
>>>>>>> 5ee94ef815de12abcb06c41ff08a48036064184b:src/Moonglade.Web/wwwroot/js/app/json2csv.js
    }
    return o.join("\n");
}
<<<<<<< HEAD:src/Moonglade.Web/wwwroot/js/app/dataexport.js
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
=======

function downloadCSV(csvData, filename) {
    if (!csvData) {
        console.error('No CSV data to download');
        return;
    }

    const blob = new Blob([csvData], { type: 'text/csv;charset=utf-8;' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.style.display = 'none';
    a.href = url;
    a.download = filename;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
}

function exportCSV(api, filename) {
    fetch(api)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            const csvData = convertJSONtoCSV(data);
            downloadCSV(csvData, filename);
>>>>>>> 5ee94ef815de12abcb06c41ff08a48036064184b:src/Moonglade.Web/wwwroot/js/app/json2csv.js
        })
        .catch((e) => {
            console.error("Error:", e);
        });
}
