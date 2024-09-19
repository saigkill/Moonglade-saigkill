let getStoredTheme = () => localStorage.getItem("theme"),
    setStoredTheme = (e) => localStorage.setItem("theme", e),
    getSystemTheme = () => (window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light"),
    getPreferredTheme = () => getStoredTheme() || getSystemTheme(),
    setTheme = (e) => {
        var t,
            m = document.documentElement;
        "auto" === e ? ((t = getSystemTheme()), m.setAttribute("data-bs-theme", t), localStorage.removeItem("theme")) : (m.setAttribute("data-bs-theme", e), setStoredTheme(e));
    };
export { getPreferredTheme, setTheme };
