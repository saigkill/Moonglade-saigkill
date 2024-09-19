let DocumentOutline;
!(function () {
    DocumentOutline = class {
        constructor(e) {
            (this._headingMap = []),
                (this._parentList = []),
                (this._open = 1440 < window.innerWidth),
                document.querySelectorAll(e).forEach((e) => {
                    this._headingMap.push({ tag: e, level: Number(e.tagName[1]) });
                }),
                this._buildOutline(),
                this._renderOutline();
        }
        _getParent = (t) => {
            for (let e = 0; e < this._parentList.length; e++) {
                var i = this._parentList[e];
                if (i.level < t) return i;
                if (i.level === t && "UL" == i.elem.tagName) return i;
            }
        };
        _hasSibilings = (t) => {
            var e = this._getParent(t),
                i = this._parentList.slice(0, this._parentList.indexOf(e) + 1);
            for (let e = 0; e < i.length; e++) if (i[e].level === t) return !0;
            return !1;
        };
        _buildOutline = () => {
            this._parentList = [{ elem: document.createElement("ul"), level: 0 }];
            for (let t = 0; t < this._headingMap.length; t++) {
                var i = this._headingMap[t].level,
                    n = this._getParent(i),
                    s = document.createElement("li"),
                    l = document.createElement("span"),
                    a = document.createElement("div"),
                    l =
                        ((l.innerHTML = this._headingMap[t].tag.innerHTML),
                            l.addEventListener("click", (e) => {
                                window.scrollTo(0, this._headingMap[t].tag.offsetTop);
                            }),
                            a.setAttribute("class", "li-content li-title-" + i),
                            a.setAttribute("role", "link"),
                            a.appendChild(l),
                            s.appendChild(a),
                            { elem: s, level: i });
                ("LI" != n.elem.tagName && this._hasSibilings(i)) || ((a = document.createElement("ul")).appendChild(s), (l.elem = a));
                let e = n.elem;
                (e = "UL" != n.elem.tagName || "LI" != n.elem?.childNodes[0]?.tagName || this._hasSibilings(i) ? e : n.elem.firstChild).setAttribute("class", "list-head"), e.appendChild(l.elem), this._parentList.unshift(l);
            }
            0 < this._headingMap.length && ((this._root = this._parentList[this._parentList.length - 2].elem), this._root.setAttribute("id", "outline-list-root"));
        };
        _renderOutline = () => {
            this._headingMap.length <= 0 ||
                ((this._nav = document.createElement("nav")),
                    (this._main = document.createElement("div")),
                    (this._menuIcon = document.createElement("div")),
                    (this._menuIcon.classList = "outline-menu-icon-container"),
                    (this._navHeader = document.createElement("div")),
                    (this._navHeader.classList = "outline-nav-header"),
                    this._navHeader.appendChild(this._menuIcon),
                    this._nav.appendChild(this._navHeader),
                    (this._nav.classList = "outline-nav"),
                    this._nav.setAttribute("aria-label", "Document outline"),
                    this._open || this.hideOutline(),
                    this._nav.appendChild(this._root),
                    document.body.appendChild(this._main),
                    document.body.appendChild(this._nav),
                    this._addIcon(this._menuIcon, this._open ? "close" : "menu"),
                    this._menuIcon.addEventListener("click", (e) => {
                        this._open ? this.hideOutline() : this.showOutline(), (this._open = !this._open);
                    }));
        };
        _addIcon = (e, t) => {
            e.innerHTML = "menu" === t ? '<i class="bi bi-list-ul"></i>' : '<i class="bi bi-arrow-left-circle" role="button" aria-label="Hide outline navigation menu"></i>';
        };
        showOutline = () => {
            (this._menuIcon.style.visibility = "hidden"),
                this._menuIcon.classList.remove("outline-menu-container-collapsed"),
                this._navHeader.classList.remove("outline-nav-header-collapsed"),
                this._main.classList.remove("no-outline"),
                this._nav.classList.remove("outline-nav-collapsed"),
                (this._root.style.display = "block"),
                (this._root.style.visibility = "visible"),
                setTimeout(() => {
                    (this._root.style.opacity = 1), (this._nav.style.overflowY = "visible"), (this._menuIcon.style.visibility = "visible"), this._addIcon(this._menuIcon, "close");
                }, 400);
        };
        hideOutline = () => {
            (this._menuIcon.style.visibility = "hidden"),
                this._addIcon(this._menuIcon, "menu"),
                this._navHeader.classList.add("outline-nav-header-collapsed"),
                (this._nav.style.overflowY = "hidden"),
                this._nav.classList.add("outline-nav-collapsed"),
                this._main.classList.add("no-outline"),
                (this._root.style.visibility = "hidden"),
                (this._root.style.opacity = 0),
                setTimeout(() => {
                    (this._root.style.display = "none"), this._menuIcon.classList.add("outline-menu-container-collapsed"), (this._menuIcon.style.visibility = "visible");
                }, 350);
        };
    };
})();
