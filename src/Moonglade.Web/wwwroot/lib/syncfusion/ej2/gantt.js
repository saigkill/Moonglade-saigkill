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
var index = require("@syncfusion/ej2-gantt");
index.Gantt.Inject(index.Filter, index.Selection, index.Sort, index.Reorder, index.Resize, index.Edit, index.DayMarkers, index.Toolbar, index.ContextMenu, index.ExcelExport, index.RowDD, index.ColumnMenu, index.PdfExport, index.VirtualScroll, index.CriticalPath, index.UndoRedo);
__exportStar(require("@syncfusion/ej2-gantt"), exports);
