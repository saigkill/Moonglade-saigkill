function slugify(e) {
    return /^[A-Za-z][A-Za-z0-9 \(\)#,\.\?]*$/.test(e)
        ? e
            .toLowerCase()
            .replace(/[()#,.?]/g, "")
            .replace(/[^\w ]+/g, "")
            .replace(/ +/g, "-")
        : "";
}
function initEvents(e) {
    function t() {
        var e;
        window.tinyMCE && window.tinyMCE.triggerSave(),
            window.mdContentEditor && assignEditorValues(window.mdContentEditor, ".post-content-textarea"),
            "True" === document.querySelector('input[name="ViewModel.IsPublished"]').value &&
            ((e = document.querySelector("#btn-publish")) && (e.style.display = "none"), (e = document.querySelector("#btn-preview"))) &&
            (e.style.display = "none");
    }
    e &&
        document.querySelector("#ViewModel_Title").addEventListener("change", function () {
            var e = slugify(this.value);
            e && (document.querySelector("#ViewModel_Slug").value = e);
        }),
        document.querySelector("#btn-preview")?.addEventListener("click", function (e) {
            t();
        }),
        document.querySelector("#btn-save").addEventListener("click", function (e) {
            t();
        }),
        document.querySelector("#btn-publish")?.addEventListener("click", function (e) {
            (document.querySelector('input[name="ViewModel.IsPublished"]').value = "True"), t();
        }),
        document.querySelector(".btn-modify-slug")?.addEventListener("click", function () {
            var e;
            confirm("This post was published for a period of time, changing slug will result in breaking SEO, would you like to continue?") &&
                ((e = document.getElementById("ViewModel_Slug")).removeAttribute("readonly"), e.focus(), (document.querySelector(".btn-modify-slug").style.display = "none"));
        }),
        callApi("/api/tags/names", "GET", {}, async (e) => {
            var e = await e.json(),
                t = document.querySelector("#ViewModel_Tags");
            new Tagify(t, {
                pattern: /^[a-zA-Z 0-9\.\-\+\#\s]*$/i,
                whitelist: e,
                originalInputValueFormat: (e) => e.map((e) => e.value).join(","),
                maxTags: 10,
                dropdown: { maxItems: 30, classname: "tags-dropdown", enabled: 0, closeOnSelect: !1 },
            });
        }),
        document.querySelector("#ViewModel_Title").focus();
}
function warnDirtyForm(e) {
    e = document.querySelector(e);
    let t = !1;
    e.addEventListener("input", function () {
        t = !0;
    }),
        window.addEventListener("beforeunload", function (e) {
            if (t) return (e.returnValue = "You have unsaved changes, are you sure to leave this page?");
        }),
        e.addEventListener("submit", function () {
            t = !1;
        });
}
function loadTinyMCE(e) {
    void 0 !== window.tinyMCE &&
        window.tinyMCE.init({
            selector: textareaSelector,
            themes: 'silver',
            skin: (window.theme.getPreferredTheme() == 'dark' ? 'oxide-dark' : 'tinymce-5'),
            height: 'calc(100vh - 400px)',
            relative_urls: false, // avoid image upload fuck up
            browser_spellcheck: true,
            branding: false,
            promotion: false,
            block_formats: 'Paragraph=p; Header 2=h2; Header 3=h3; Header 4=h4; Preformatted=pre',
            plugins: 'advlist autolink autosave link image lists charmap preview anchor pagebreak searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking save table directionality codesample emoticons',
            toolbar: 'undo redo | blocks | bold italic underline strikethrough | forecolor backcolor | paste pastetext removeformat | hr link image codesample | charmap emoticons table media | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | code | fullscreen',
            save_onsavecallback: function () {
                document.querySelector("#btn-save").click();
            },
            paste_data_images: true,
            images_upload_url: '/image',
            images_upload_credentials: true,
            extended_valid_elements: 'img[class|src|border=0|alt|title|hspace|vspace|width|height|align|onmouseover|onmouseout|name|loading=lazy]',
            body_class: 'post-content',
            content_css: (window.theme.getPreferredTheme() == 'dark' ? "/css/tinymce-custom-dark.css" : '/css/tinymce-custom.css'),
            codesample_languages: [
                { text: "Bash", value: "bash" },
                { text: "C#", value: "csharp" },
                { text: "C", value: "c" },
                { text: "C++", value: "cpp" },
                { text: "CSS", value: "css" },
                { text: "Dockerfile", value: "dockerfile" },
                { text: "F#", value: "fsharp" },
                { text: "Go", value: "go" },
                { text: "HTML/XML", value: "xml" },
                { text: "JavaScript", value: "javascript" },
                { text: "Json", value: "json" },
                { text: "Kotlin", value: "kotlin" },
                { text: "LaTeX", value: "latex" },
                { text: "Lua", value: "lua" },
                { text: "Markdown", value: "markdown" },
                { text: "Nginx", value: "nginx" },
                { text: "PowerShell", value: "powershell" },
                { text: "Plain Text", value: "plaintext" },
                { text: "Puppet", value: "puppet" },
                { text: "Python", value: "python" },
                { text: "R", value: "r" },
                { text: "Rust", value: "rust" },
                { text: "SCSS", value: "scss" },
                { text: "Shell", value: "shell" },
                { text: "SQL", value: "sql" },
                { text: "Swift", value: "swift" },
                { text: "TypeScript", value: "typescript" },
                { text: "WASM", value: "wasm" },
                { text: "YAML", value: "yaml" },
            ],
            setup: function (editor) {
                editor.on('init', () => {
                    if (window.theme.getPreferredTheme() == 'dark') {
                        const container = editor.getContainer();
                        const iframe = container.querySelector('iframe');
                        const innerDoc = iframe.contentDocument || iframe.contentWindow.document;

                        innerDoc.documentElement.setAttribute('data-bs-theme', 'dark');
                    }
                });

                editor.on('NodeChange', function (e) {
                    if (e.element.tagName === 'IMG') {
                        e.element.setAttribute('loading', 'lazy');
                    }
                });
            }
        });
    }
}

export function keepAlive() {
    const tid = setInterval(postNonce, 60 * 1000);
    function postNonce() {
        const num = Math.random();
        fetch('/api/post/keep-alive',
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                credentials: 'include',
                body: JSON.stringify({ nonce: num })
            }).then(async (response) => {
                console.info('live');
            });
    }
    function abortTimer() {
        clearInterval(tid);
    }
}