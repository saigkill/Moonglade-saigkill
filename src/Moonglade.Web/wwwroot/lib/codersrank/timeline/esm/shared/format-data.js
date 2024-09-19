function _extends() { _extends = Object.assign || function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; }; return _extends.apply(this, arguments); }

import { differenceInMonths } from './difference-in-months';
export var formatData = function formatData(items, type) {
  if (items === void 0) {
    items = [];
  }

  var rows = [];
  var startDate;
  var endDate;
  var totalCols;

  var datesOverlap = function datesOverlap(start1, end1, start2, end2) {
    if (start1 <= start2 && start2 <= end1) return true; // b starts in a

    if (start1 <= end2 && end2 <= end1) return true; // b ends in a

    if (start2 < start1 && end1 < end2) return true; // a in b

    return false;
  };

  var techItems = [];

  var addTechItem = function addTechItem(tech, start, end, item) {
    techItems.push({
      name: tech,
      start_date: start,
      end_date: end,
      items: [item]
    });
  };

  var processTechItem = function processTechItem(tech, item) {
    var start_date = item.start_date,
        end_date = item.end_date,
        is_current = item.is_current;
    var techStart = start_date ? new Date(start_date) : new Date();
    var techEnd = end_date && !is_current ? new Date(end_date) : new Date();
    var similarTechs = techItems.filter(function (t) {
      return t.name.toLowerCase() === tech.toLowerCase();
    });

    if (!similarTechs.length) {
      addTechItem(tech, techStart, techEnd, item);
    } else {
      var overlap;
      similarTechs.forEach(function (otherTech) {
        if (overlap) return;
        var otherTechStart = otherTech.start_date ? new Date(otherTech.start_date) : new Date();
        var otherTechEnd = otherTech.end_date ? new Date(otherTech.end_date) : new Date();

        if (datesOverlap(techStart, techEnd, otherTechStart, otherTechEnd)) {
          overlap = true;
          /* eslint-disable */

          otherTech.start_date = new Date(Math.min(techStart, otherTechStart));
          otherTech.end_date = new Date(Math.max(techEnd, otherTechEnd));
          /* eslint-enable */

          otherTech.items.push(item);
        }
      });

      if (!overlap) {
        addTechItem(tech, techStart, techEnd, item);
      }
    }
  };

  if (type === 'technologies') {
    items.sort(function (a, b) {
      var aStart = a.start_date ? new Date(a.start_date) : new Date();
      var bStart = b.start_date ? new Date(b.start_date) : new Date();
      return aStart - bStart;
    });
    items.forEach(function (item) {
      var techs = [].concat(item.highlighted_technologies || []);
      techs.forEach(function (tech) {
        processTechItem(tech, item);
      });
    }); // eslint-disable-next-line

    items = techItems;
  }

  var setStartDate = function setStartDate(d) {
    if (d === void 0) {
      d = '';
    }

    startDate = new Date(d);
    startDate.setMonth(0, 1);
  };

  var setEndDate = function setEndDate(d) {
    if (d === void 0) {
      d = '';
    }

    endDate = new Date(d);
  };

  setStartDate(new Date());
  items.forEach(function (item) {
    var itemStartDate = new Date(item.start_date);
    var itemEndDate = item.is_current ? new Date() : new Date(item.end_date);
    if (itemStartDate < startDate) setStartDate(itemStartDate);
    if (!endDate || itemEndDate > endDate) setEndDate(itemEndDate);
  });
  var itemsWithCols = [];
  items.forEach(function (item, index) {
    var itemStartDate = new Date(item.start_date);
    var itemEndDate = item.is_current ? new Date() : new Date(item.end_date);
    var itemStartCol = differenceInMonths(startDate, itemStartDate);
    var itemEndCol = itemStartCol + differenceInMonths(itemStartDate, itemEndDate);
    if (!totalCols || itemEndCol > totalCols) totalCols = itemEndCol;
    itemsWithCols.push(_extends({
      start_col: itemStartCol,
      end_col: itemEndCol,
      id: index
    }, item));
  });
  itemsWithCols.sort(function (a, b) {
    return a.start_col > b.start_col ? 1 : -1;
  });

  var getRowIndex = function getRowIndex(item, rowIndex) {
    var start_col = item.start_col;
    if (!rows[rowIndex]) return rowIndex;
    var previousItems = rows[rowIndex].slice(0, itemsWithCols.indexOf(item));
    var hasClash = previousItems.filter(function (el) {
      return el.end_col > start_col;
    }).length > 0;

    if (hasClash) {
      // eslint-disable-next-line
      rowIndex += 1;
      return getRowIndex(item, rowIndex);
    }

    return rowIndex;
  };

  itemsWithCols.forEach(function (item) {
    var rowIndex = getRowIndex(item, 0);

    if (!rows[rowIndex]) {
      rows[rowIndex] = [];
    }

    rows[rowIndex].push(item);
  });

  var getYears = function getYears() {
    var startYear = startDate.getFullYear();
    var endYear = endDate.getFullYear();
    var years = [startYear];

    if (endYear > startYear) {
      for (var i = 1; i <= endYear - startYear; i += 1) {
        years.push(startYear + i);
      }
    }

    return years;
  };

  return {
    rows: rows,
    years: getYears()
  };
};