"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    Object.defineProperty(o, k2, { enumerable: true, get: function() { return m[k]; } });
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __exportStar = (this && this.__exportStar) || function(m, exports) {
    for (var p in m) if (p !== "default" && !exports.hasOwnProperty(p)) __createBinding(exports, m, p);
};
exports.__esModule = true;
var index = require("@syncfusion/ej2-dropdowns");
index.DropDownList.Inject(index.VirtualScroll);
index.ComboBox.Inject(index.VirtualScroll);
index.AutoComplete.Inject(index.VirtualScroll);
index.MultiSelect.Inject(index.CheckBoxSelection, index.VirtualScroll);
index.ListBox.Inject(index.CheckBoxSelection);
__exportStar(require("@syncfusion/ej2-dropdowns"), exports);
