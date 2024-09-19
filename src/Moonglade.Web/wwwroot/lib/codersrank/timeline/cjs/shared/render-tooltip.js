"use strict";

exports.__esModule = true;
exports.renderTooltip = void 0;

var _companyLogo = require("./company-logo");

var _differenceInMonths = require("./difference-in-months");

var _sanitizeDescription = require("./sanitize-description");

var renderTooltip = function renderTooltip(item, type) {
  var formatLocation = function formatLocation(_ref) {
    var location = _ref.location,
        is_remote = _ref.is_remote;
    if (location === 'Remote, Earth' || is_remote) return 'Remote';
    return location || '';
  };

  var formatDate = function formatDate(date) {
    if (!date) return '';
    var formatter = Intl.DateTimeFormat('en', {
      month: 'short',
      year: 'numeric'
    });
    return formatter.format(new Date(date));
  };

  var formatInterval = function formatInterval(months) {
    var output = '';
    if (months === 0) return 'Less than a month';

    if (months >= 12) {
      output += Math.floor(months / 12);
      output += ' year';
      if (Math.floor(months / 12) !== 1) output += 's';
    }

    if (months % 12 !== 0) {
      if (months >= 12) output += ' ';
      output += months % 12;
      output += ' month';
      if (months % 12 !== 1) output += 's';
    }

    return output;
  };

  var calculateMonths = function calculateMonths(startDate, endDate, is_current) {
    var end = is_current ? new Date() : new Date(endDate);
    return (0, _differenceInMonths.differenceInMonths)(new Date(startDate), end);
  };

  var dates = function dates(showInterval) {
    if (showInterval === void 0) {
      showInterval = true;
    }

    var startDate = formatDate(item.start_date || item.date_from);
    var endDate = item.is_current ? 'Present' : formatDate(item.end_date || item.date_to);

    if (!showInterval) {
      return startDate + " - " + endDate;
    }

    return startDate + " - " + endDate + " (" + formatInterval(calculateMonths(item.start_date || item.date_from, item.end_date || item.date_to, item.is_current)) + ")";
  };

  var itemLogo = function itemLogo() {
    if (type === 'technologies') {
      return "<img src=\"https://icon-widget.codersrank.io/api/" + encodeURIComponent(item.name) + "\">";
    }

    return type === 'workexperience' ? (0, _companyLogo.companyLogo)(item.company, item.company_logo) : (0, _companyLogo.companyLogo)(item.project_title, item.image);
  };

  var itemTitle = function itemTitle() {
    return type === 'workexperience' ? item.company : item.project_title;
  };

  var itemSubtitle = function itemSubtitle() {
    return type === 'workexperience' ? item.title : item.role;
  };

  if (type === 'technologies') {
    // prettier-ignore
    return (
      /* html */
      "\n      <div class=\"codersrank-timeline-tooltip-item\">\n        <div class=\"logo\">\n          " + itemLogo() + "\n        </div>\n        <div class=\"content\">\n          <div class=\"title\">\n            " + item.name + "\n          </div>\n          <div class=\"details\">\n            <div>" + dates(true) + "</div>\n          </div>\n        </div>\n      </div>\n      <div class=\"codersrank-timeline-tooltip-divider\"></div>\n      " + item.items.map(function (subItem) {
        return renderTooltip(subItem, subItem._type);
      }).join('') + "\n    "
    );
  } // prettier-ignore


  return (
    /* html */
    "\n    <div class=\"codersrank-timeline-tooltip-item\">\n      <div class=\"logo\">\n        " + itemLogo() + "\n      </div>\n      <div class=\"content\">\n        <div class=\"title\">\n          " + itemTitle() + "\n        </div>\n        " + (itemSubtitle() ?
    /* html */
    "\n        <div class=\"subtitle\">\n          " + itemSubtitle() + "\n        </div>\n        " : '') + "\n        <div class=\"details\">\n          <div>" + dates(true) + "</div>\n          " + (item.location ?
    /* html */
    "\n          <div>" + formatLocation(item) + "</div>\n          " : '') + "\n        </div>\n        " + (item.description ?
    /* html */
    "\n        <div class=\"description\">\n          <div>" + (0, _sanitizeDescription.sanitizeDescription)(item.description) + "</div>\n        </div>\n        " : '') + "\n        " + (item.highlighted_technologies || item.other_technologies ?
    /* html */
    "\n        <div class=\"tags\">\n          " + item.highlighted_technologies.map(function (tech) {
      return (
        /* html */
        "\n            <span class=\"tag\"><span class=\"tag-star\">\u2605</span>" + tech + "</span>\n          "
      );
    }).join('') + "\n\n          " + item.other_technologies.map(function (tech) {
      return (
        /* html */
        "\n            <span class=\"tag\">" + tech + "</span>\n          "
      );
    }).join('') + "\n        </div>\n      " : '') + "\n      </div>\n    </div>\n  "
  );
};

exports.renderTooltip = renderTooltip;