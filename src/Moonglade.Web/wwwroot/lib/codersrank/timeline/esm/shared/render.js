import { codersRankLogo } from './codersrank-logo';
export var render = function render(_temp) {
  var _ref = _temp === void 0 ? {} : _temp,
      data = _ref.data,
      preloader = _ref.preloader,
      branding = _ref.branding,
      type = _ref.type;

  var _data$rows = data.rows,
      rows = _data$rows === void 0 ? [] : _data$rows,
      _data$years = data.years,
      years = _data$years === void 0 ? [] : _data$years;

  var itemText = function itemText(item) {
    if (item.end_col - item.start_col < 2) return '';

    if (type === 'workexperience') {
      return item.title + " @ " + item.company;
    }

    if (type === 'portfolio') {
      return item.project_title || '';
    }

    if (type === 'technologies') {
      return "<img src=\"https://icon-widget.codersrank.io/api/" + encodeURIComponent(item.name) + "\">" + item.name;
    }

    return '';
  }; // prettier-ignore


  return (
    /* html */
    "\n    <div class=\"codersrank-timeline " + (preloader ? 'codersrank-timeline-loading' : '') + "\">\n      " + (preloader ?
    /* html */
    "\n      <div class=\"codersrank-timeline-preloader\"></div>\n      " : '') + "\n      <div class=\"codersrank-timeline-wrap\">\n        <div class=\"codersrank-timeline-year-lines\">\n        " + years.map(function (year, yearIndex) {
      return (
        /* html */
        "\n          <div class=\"codersrank-timeline-year-line\" style=\"left: calc(var(--col-width) * " + 12 * yearIndex + ")\"></div>\n        "
      );
    }).join('') + "\n        </div>\n        <div class=\"codersrank-timeline-years\">\n          " + years.map(function (year) {
      return (
        /* html */
        "\n            <div class=\"codersrank-timeline-year\" style=\"width: calc(var(--col-width) * 12)\">\n              <span>" + year + "</span>\n            </div>\n          "
      );
    }).join('') + "\n        </div>\n        <div class=\"codersrank-timeline-chart\" style=\"height: calc(var(--row-height) * " + rows.length + ")\">\n          " + rows.map(function (row, rowIndex) {
      return (
        /* html */
        "\n          <div class=\"codersrank-timeline-row\">\n            " + row.map(function (item) {
          return (
            /* html */
            "\n              <div class=\"codersrank-timeline-item-wrap\" style=\"left: calc(var(--col-width) * " + item.start_col + "); width: calc(var(--col-width) * " + (item.end_col - item.start_col) + "); height: var(--row-height); top: calc(var(--row-height) * " + rowIndex + ")\">\n                <div class=\"codersrank-timeline-item\" data-id=\"" + item.id + "\">\n                  <span>" + itemText(item) + "</span>\n                </div>\n              </div>\n            "
          );
        }).join('') + "\n          </div>\n        "
      );
    }).join('') + "\n        </div>\n      </div>\n\n      " + (branding ?
    /* html */
    "\n      <div class=\"codersrank-timeline-branding\">\n        <a href=\"https://codersrank.io\" target=\"_blank\" rel=\"noopener noreferrer\">\n          <span>Powered by </span>\n          " + codersRankLogo + "\n        </a>\n      </div>\n      " : '') + "\n    </div>\n  "
  );
};