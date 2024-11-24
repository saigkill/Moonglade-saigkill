<<<<<<< HEAD
import * as utils from "./utils.module.js";
function handleSettingsSubmit(e) {
    e.preventDefault();
    var t = "#btn-save-settings",
        r = (document.querySelector(t).classList.add("disabled"), document.querySelector(t).setAttribute("disabled", "disabled"), new FormData(e.target)),
        r = Object.fromEntries(r.entries()),
        r = utils.toMagicJson(r);
    callApi(e.currentTarget.action, "POST", r, (e) => {
        blogToast.success("Settings Updated"), document.querySelector(t).classList.remove("disabled"), document.querySelector(t).removeAttribute("disabled");
    });
=======
﻿import * as utils from './utils.module.js'

export function handleSettingsSubmit(event) {
    event.preventDefault();

    const btnSaveSettingsSelector = '#btn-save-settings';
    const btnSaveSettings = document.querySelector(btnSaveSettingsSelector);

    const disableButton = () => {
        btnSaveSettings.classList.add('disabled');
        btnSaveSettings.setAttribute('disabled', 'disabled');
    };

    const enableButton = () => {
        btnSaveSettings.classList.remove('disabled');
        btnSaveSettings.removeAttribute('disabled');
    };

    disableButton();

    const formData = new FormData(event.target);
    const formValues = Object.fromEntries(formData.entries());
    const formattedValues = utils.toMagicJson(formValues);

    callApi(event.currentTarget.action, 'POST', formattedValues,
        (resp) => {
            blogToast.success('Settings Updated');
            enableButton();
        });
>>>>>>> 5ee94ef815de12abcb06c41ff08a48036064184b
}
function compareVersionNumbers(e, t) {
    var r = e.split("."),
        i = t.split(".");
    function n(e) {
        for (var t = 0; t < e.length; ++t) if (!isPositiveInteger(e[t])) return;
        return 1;
    }
    if (!n(r) || !n(i)) return NaN;
    for (var s = 0; s < r.length; ++s) {
        if (i.length === s) return 1;
        if (r[s] !== i[s]) return r[s] > i[s] ? 1 : -1;
    }
    return r.length != i.length ? -1 : 0;
}
function isPositiveInteger(e) {
    return /^\d+$/.test(e);
}
export { handleSettingsSubmit, compareVersionNumbers };
