function getMode() {
    return localStorage.getItem('theme') || 'auto';
}

function applyTheme() {
    let mode = getMode();

    console.info('We are using mode:', mode)

    if (mode === 'auto') {
        mode = window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    }

    let cssFiles = [];
    if (mode === 'dark') {
        cssFiles = [
            "https://cdn.syncfusion.com/ej2/31.2.2/bootstrap5-dark.css"
        ];
    } else {
        cssFiles = [
            "https://cdn.syncfusion.com/ej2/31.2.2/bootstrap5.css"
        ];
    }

    cssFiles.forEach(cssFile => {
        let linkElement = document.createElement("link");
        linkElement.rel = "stylesheet";
        linkElement.type = "text/css";
        linkElement.href = cssFile;
        document.head.appendChild(linkElement);
    });
}

applyTheme();