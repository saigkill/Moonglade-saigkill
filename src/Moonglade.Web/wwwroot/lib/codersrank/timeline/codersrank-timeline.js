/**
 * Codersrank Timeline Widget 0.9.2
 * undefined
 * https://github.com/codersrank-org/timeline-widget#readme
 *
 * Copyright 2021-2021 CodersRank Ltd.
 *
 * Released under the MIT License
 *
 * Released on: June 21, 2021
 */

(function (factory) {
  typeof define === 'function' && define.amd ? define(factory) :
  factory();
}((function () { 'use strict';

  function _defineProperties(target, props) {
    for (var i = 0; i < props.length; i++) {
      var descriptor = props[i];
      descriptor.enumerable = descriptor.enumerable || false;
      descriptor.configurable = true;
      if ("value" in descriptor) descriptor.writable = true;
      Object.defineProperty(target, descriptor.key, descriptor);
    }
  }

  function _createClass(Constructor, protoProps, staticProps) {
    if (protoProps) _defineProperties(Constructor.prototype, protoProps);
    if (staticProps) _defineProperties(Constructor, staticProps);
    return Constructor;
  }

  function _extends() {
    _extends = Object.assign || function (target) {
      for (var i = 1; i < arguments.length; i++) {
        var source = arguments[i];

        for (var key in source) {
          if (Object.prototype.hasOwnProperty.call(source, key)) {
            target[key] = source[key];
          }
        }
      }

      return target;
    };

    return _extends.apply(this, arguments);
  }

  function _inheritsLoose(subClass, superClass) {
    subClass.prototype = Object.create(superClass.prototype);
    subClass.prototype.constructor = subClass;
    subClass.__proto__ = superClass;
  }

  function _getPrototypeOf(o) {
    _getPrototypeOf = Object.setPrototypeOf ? Object.getPrototypeOf : function _getPrototypeOf(o) {
      return o.__proto__ || Object.getPrototypeOf(o);
    };
    return _getPrototypeOf(o);
  }

  function _setPrototypeOf(o, p) {
    _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) {
      o.__proto__ = p;
      return o;
    };

    return _setPrototypeOf(o, p);
  }

  function _isNativeReflectConstruct() {
    if (typeof Reflect === "undefined" || !Reflect.construct) return false;
    if (Reflect.construct.sham) return false;
    if (typeof Proxy === "function") return true;

    try {
      Date.prototype.toString.call(Reflect.construct(Date, [], function () {}));
      return true;
    } catch (e) {
      return false;
    }
  }

  function _construct(Parent, args, Class) {
    if (_isNativeReflectConstruct()) {
      _construct = Reflect.construct;
    } else {
      _construct = function _construct(Parent, args, Class) {
        var a = [null];
        a.push.apply(a, args);
        var Constructor = Function.bind.apply(Parent, a);
        var instance = new Constructor();
        if (Class) _setPrototypeOf(instance, Class.prototype);
        return instance;
      };
    }

    return _construct.apply(null, arguments);
  }

  function _isNativeFunction(fn) {
    return Function.toString.call(fn).indexOf("[native code]") !== -1;
  }

  function _wrapNativeSuper(Class) {
    var _cache = typeof Map === "function" ? new Map() : undefined;

    _wrapNativeSuper = function _wrapNativeSuper(Class) {
      if (Class === null || !_isNativeFunction(Class)) return Class;

      if (typeof Class !== "function") {
        throw new TypeError("Super expression must either be null or a function");
      }

      if (typeof _cache !== "undefined") {
        if (_cache.has(Class)) return _cache.get(Class);

        _cache.set(Class, Wrapper);
      }

      function Wrapper() {
        return _construct(Class, arguments, _getPrototypeOf(this).constructor);
      }

      Wrapper.prototype = Object.create(Class.prototype, {
        constructor: {
          value: Wrapper,
          enumerable: false,
          writable: true,
          configurable: true
        }
      });
      return _setPrototypeOf(Wrapper, Class);
    };

    return _wrapNativeSuper(Class);
  }

  function _assertThisInitialized(self) {
    if (self === void 0) {
      throw new ReferenceError("this hasn't been initialised - super() hasn't been called");
    }

    return self;
  }

  var cache = {
    projects: {},
    work_experiences: {}
  };
  var fetchData = function fetchData(username, type) {
    var endpoint = 'work_experiences';
    if (type === 'portfolio') endpoint = 'projects';
    if (cache[endpoint][username]) return Promise.resolve(cache[endpoint][username]);

    if (type === 'technologies') {
      return Promise.all([fetchData(username, 'portfolio'), fetchData(username, 'workexperience')]).then(function (_ref) {
        var projects = _ref[0],
            work_experiences = _ref[1];
        projects.forEach(function (item) {
          // eslint-disable-next-line
          item._type = 'portfolio';
        });
        work_experiences.forEach(function (item) {
          // eslint-disable-next-line
          item._type = 'workexperience';
        });
        return [].concat(projects, work_experiences);
      })["catch"](function (err) {
        // eslint-disable-next-line
        console.error(err);
        return Promise.reject(err);
      });
    }

    return fetch("https://api.codersrank.io/v2/users/" + username + "/" + endpoint, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      }
    }).then(function (res) {
      return res.json();
    }).then(function (data) {
      var projects;
      var workExperiences;

      if (typeof data.projects !== 'undefined') {
        projects = data.projects.filter(function (e) {
          return e.start_date !== '0001-01';
        });
      }

      if (typeof data.work_experiences !== 'undefined') {
        workExperiences = data.work_experiences.filter(function (e) {
          return e.start_date !== '0001-01';
        });
      }

      cache[endpoint][username] = projects || workExperiences || [];
      return projects || workExperiences || [];
    })["catch"](function (err) {
      // eslint-disable-next-line
      console.error(err);
      return Promise.reject(err);
    });
  };

  var codersRankLogo = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"258\" height=\"39\" viewBox=\"0 0 258 39\"><path fill=\"#19223C\" d=\"M71.358 27.687A8.076 8.076 0 0 1 69 21.999c0-2.122.846-4.162 2.358-5.687a8.022 8.022 0 0 1 2.664-1.688 8.175 8.175 0 0 1 3.126-.543 8.298 8.298 0 0 1 4.723 1.339 7.155 7.155 0 0 1 2.895 3.791H80.12a3 3 0 0 0-1.182-1.283 3.106 3.106 0 0 0-1.713-.427 4.128 4.128 0 0 0-1.694.264 4.046 4.046 0 0 0-1.43.926 5.197 5.197 0 0 0-1.133 3.234c0 1.17.399 2.309 1.134 3.234.403.405.89.72 1.43.926a4.128 4.128 0 0 0 1.693.264c.586.039 1.17-.087 1.684-.364a3.01 3.01 0 0 0 1.211-1.198h4.571a7.156 7.156 0 0 1-2.895 3.792 8.298 8.298 0 0 1-4.723 1.338 8.173 8.173 0 0 1-3.085-.557 8.02 8.02 0 0 1-2.629-1.673zM88.652 27.687a8.076 8.076 0 0 1-2.359-5.688c0-2.122.846-4.162 2.359-5.687a8.57 8.57 0 0 1 5.79-2.238c2.15 0 4.221.8 5.79 2.238a8.076 8.076 0 0 1 2.358 5.687 8.076 8.076 0 0 1-2.359 5.688 8.491 8.491 0 0 1-5.79 2.266 8.491 8.491 0 0 1-5.79-2.266zm8.837-2.454A5.197 5.197 0 0 0 98.623 22c0-1.17-.4-2.308-1.134-3.234a4.398 4.398 0 0 0-3.048-1.219c-1.14 0-2.234.438-3.047 1.22a5.197 5.197 0 0 0-1.134 3.233c0 1.171.399 2.309 1.134 3.234a4.398 4.398 0 0 0 3.047 1.219c1.14 0 2.235-.438 3.048-1.219zM110.592 14.304a9.126 9.126 0 0 1 6.247 2.156 7.73 7.73 0 0 1 1.8 2.546 7.573 7.573 0 0 1 0 6.06 7.73 7.73 0 0 1-1.8 2.546 9.049 9.049 0 0 1-6.247 2.156h-5.561V14.304h5.561zm-1.752 12.64h1.752a4.596 4.596 0 0 0 1.903-.295 4.504 4.504 0 0 0 1.602-1.044 4.909 4.909 0 0 0 1.295-3.569 4.909 4.909 0 0 0-1.295-3.568 4.504 4.504 0 0 0-1.602-1.044 4.595 4.595 0 0 0-1.903-.294h-1.752v9.813zM131.313 14.23v2.9h-5.714v3.345h5.104v2.9H125.6v3.568h5.714v2.9h-9.599V14.23zM138.55 23.746v6.022h-3.885V14.304h6.247a6.19 6.19 0 0 1 4.266 1.413c.486.418.874.933 1.137 1.51.263.578.395 1.204.387 1.836a4.752 4.752 0 0 1-.838 2.602 4.578 4.578 0 0 1-2.743 1.784l3.885 6.32h-4.418l-3.58-6.023h-.458zm0-6.616v3.717h2.362c.253.01.505-.03.742-.12.236-.09.45-.226.63-.4.175-.178.312-.388.404-.617.091-.23.135-.475.128-.722a1.819 1.819 0 0 0-.128-.721 1.854 1.854 0 0 0-.405-.617 1.833 1.833 0 0 0-.63-.4 1.87 1.87 0 0 0-.741-.12h-2.362zM155.158 17.055a1.86 1.86 0 0 0-1.22.372c-.159.138-.284.311-.363.505-.08.193-.111.402-.093.61a1.528 1.528 0 0 0 .457 1.115c.32.31.712.539 1.143.67l1.523.445 1.676.52 1.524.744c.487.317.881.753 1.143 1.264.31.6.466 1.262.457 1.933a4.227 4.227 0 0 1-.45 1.859 4.333 4.333 0 0 1-1.226 1.487 6.424 6.424 0 0 1-4.343 1.412 6.899 6.899 0 0 1-4.342-1.263 4.331 4.331 0 0 1-1.278-1.588 4.223 4.223 0 0 1-.398-1.981h4.114c-.012.253.032.507.128.742.097.236.244.449.431.625a1.87 1.87 0 0 0 1.421.492c.475.02.94-.14 1.296-.447a1.382 1.382 0 0 0 .457-1.115 1.455 1.455 0 0 0-.457-1.115 2.986 2.986 0 0 0-1.143-.669l-1.524-.446-1.676-.52-1.523-.744a3.148 3.148 0 0 1-1.143-1.264 4 4 0 0 1-.305-1.859 4.15 4.15 0 0 1 .407-1.944 4.258 4.258 0 0 1 1.27-1.55 6.582 6.582 0 0 1 4.19-1.338 6.982 6.982 0 0 1 4.113 1.115 4.33 4.33 0 0 1 1.278 1.588c.292.62.428 1.299.398 1.98h-4.19a2.056 2.056 0 0 0-.533-1.263 1.611 1.611 0 0 0-1.22-.372zM168.261 23.746v6.022h-3.885V14.304h6.247a6.19 6.19 0 0 1 4.266 1.413c.486.418.874.933 1.137 1.51.263.578.395 1.204.387 1.836a4.752 4.752 0 0 1-.838 2.602 4.578 4.578 0 0 1-2.743 1.784l3.885 6.32H172.3l-3.58-6.023h-.458zm0-6.616v3.717h2.362c.253.01.505-.03.742-.12.236-.09.45-.226.63-.4.175-.178.312-.388.404-.617.091-.23.135-.475.128-.722a1.819 1.819 0 0 0-.128-.721 1.854 1.854 0 0 0-.405-.617 1.833 1.833 0 0 0-.63-.4 1.87 1.87 0 0 0-.741-.12h-2.362zM189.592 29.768l-.914-2.602h-5.714l-.914 2.602h-4.114l5.485-15.538h4.723l5.485 15.538h-4.037zm-5.638-5.501h3.733l-1.828-5.428-1.905 5.428zM205.972 14.23h3.885v15.538h-3.885l-6.476-9.813v9.813h-3.885V14.23h3.885l6.476 9.814zM217.093 29.768h-3.885V14.304h3.885v6.766l5.257-6.766h5.104l-6.552 7.732 6.552 7.732h-4.952l-5.333-6.84zM232.863 27.761a1.98 1.98 0 0 1-.5 1.253 2.07 2.07 0 0 1-1.197.664 2.1 2.1 0 0 1-1.359-.222 2.024 2.024 0 0 1-.91-1.01 1.962 1.962 0 0 1-.054-1.342c.141-.44.433-.82.827-1.076a2.096 2.096 0 0 1 2.583.246c.201.194.359.426.464.682.105.256.154.53.146.805z\"></path> <path fill=\"#67a4ac\" d=\"M235.301 29.768V14.304h3.885v15.464zM244.062 27.687a8.076 8.076 0 0 1-2.358-5.688c0-2.122.846-4.162 2.358-5.687a8.57 8.57 0 0 1 5.79-2.238c2.151 0 4.222.8 5.79 2.238A8.076 8.076 0 0 1 258 21.999a8.076 8.076 0 0 1-2.358 5.688 8.491 8.491 0 0 1-5.79 2.266 8.491 8.491 0 0 1-5.79-2.266zm8.837-2.454A5.197 5.197 0 0 0 254.033 22c0-1.17-.399-2.308-1.134-3.234a4.398 4.398 0 0 0-3.047-1.219c-1.14 0-2.235.438-3.047 1.22a5.197 5.197 0 0 0-1.134 3.233c0 1.171.399 2.309 1.134 3.234a4.398 4.398 0 0 0 3.047 1.219c1.14 0 2.235-.438 3.047-1.219z\"></path> <path d=\"M33.25.054L2.147 19.634C.682 20.52-.034 21.512.001 22.611v2.98c.035 1.1.768 2.075 2.2 2.926l15.393 8.885a.726.726 0 0 0 1.047-.373l3.456-8.352-7.33-4.15a1.317 1.317 0 0 1-.514-.477 1.346 1.346 0 0 1 .461-1.864l13.457-8.247L33.72.427a.324.324 0 0 0-.103-.36.31.31 0 0 0-.369-.013z\" fill=\"#19223c\"></path> <path d=\"M58.8 10.961L43.618 1.757a.726.726 0 0 0-1.047.32l-3.56 8.352 7.225 4.31c.208.113.381.282.502.488a1.347 1.347 0 0 1 0 1.363 1.318 1.318 0 0 1-.502.49l-13.561 7.98-5.76 13.407a.323.323 0 0 0 .026.452.312.312 0 0 0 .445-.026l9.949-6.012 3.927 5.64a.947.947 0 0 0 .785.425h9.425a.932.932 0 0 0 .832-.506.97.97 0 0 0-.047-.984l-6.388-9.79 12.933-7.82c1.466-.887 2.199-1.88 2.199-2.98V13.94c0-1.1-.733-2.092-2.2-2.979z\" fill=\"#67a4ac\"></path></svg>";

  var render = function render(_temp) {
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

  var renderError = function renderError() {
    return '';
  };

  var renderLoading = function renderLoading(ctx) {
    return render(_extends({}, ctx, {
      preloader: true,
      data: []
    }));
  };

  var differenceInMonths = function differenceInMonths(d1, d2) {
    var months;
    months = (d2.getFullYear() - d1.getFullYear()) * 12;
    months -= d1.getMonth();
    months += d2.getMonth();
    return Math.abs(months <= 0 ? 0 : months);
  };

  var formatData = function formatData(items, type) {
    if (items === void 0) {
      items = [];
    }

    var rows = [];
    var startDate;
    var endDate;

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

  /* eslint-disable no-bitwise */
  function hashCode(str) {
    var hash = 0;

    for (var i = 0; i < str.length; i += 1) {
      hash = str.charCodeAt(i) + ((hash << 5) - hash);
    }

    return hash;
  }

  function intToRGB(i) {
    var c = (i & 0x00ffffff).toString(16).toUpperCase();
    return '00000'.substring(0, 6 - c.length) + c;
  }

  function stringToColor(str) {
    var hashedHexNumber = intToRGB(hashCode(str));
    return ("#" + hashedHexNumber).toLowerCase();
  }

  var companyLogo = function companyLogo(name, url) {
    var iconColor = stringToColor(name || ''); // prettier-ignore

    return url ?
    /* html */
    "\n    <img src=\"" + url + "\" alt=\"" + name + "\" title=\"" + name + "\" />\n  " :
    /* html */
    "\n    <svg title=\"" + name + "\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 32 32\">\n      <rect width=\"32\" height=\"32\" fill=\"" + iconColor + "\" rx=\"3\" />\n      " + (name ?
    /* html */
    "\n      <text\n        x=\"50%\"\n        y=\"50%\"\n        font-weight=\"bold\"\n        font-size=\"20\"\n        fill=\"#fff\"\n        dy=\"0\"\n        text-anchor=\"middle\"\n        dominant-baseline=\"middle\"\n      >\n        " + name[0].toUpperCase() + "\n      </text>\n      " : '') + "\n\n    </svg>\n  ";
  };

  var sanitizeDescription = function sanitizeDescription(html) {
    if (html === void 0) {
      html = '';
    }

    return (html || '').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/\n/g, '<br>');
  };

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
      return differenceInMonths(new Date(startDate), end);
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

      return type === 'workexperience' ? companyLogo(item.company, item.company_logo) : companyLogo(item.project_title, item.image);
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
      "\n        <div class=\"description\">\n          <div>" + sanitizeDescription(item.description) + "</div>\n        </div>\n        " : '') + "\n        " + (item.highlighted_technologies || item.other_technologies ?
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

  var COMPONENT_TAG = 'codersrank-timeline';
  var STATE_IDLE = 0;
  var STATE_LOADING = 1;
  var STATE_ERROR = 2;
  var STATE_SUCCESS = 3; // eslint-disable-next-line

  var STYLES = ":host{--preloader-color:#72a0a8;--year-font-size:12px;--year-opacity:0.5;--year-height:24px;--year-text-color:currentColor;--year-line-color:currentColor;--year-line-opacity:0.25;--col-width:24px;--row-height:36px;--timeline-item-bg-color:#f1f1f1;--timeline-item-text-color:inherit;--timeline-item-font-size:12px;--timeline-item-padding:4px 8px;--timeline-item-border-radius:4px;--tooltip-logo-size:32px;--tooltip-font-size:14px;--tooltip-width:320px;--tooltip-padding:16px;--tooltip-bg-color:#fff;--tooltip-border-radius:4px;--tooltip-text-color:#333;--tooltip-box-shadow:0px 10px 20px rgba(0, 0, 0, 0.1);--tag-border:none;--tag-star-color:#ff9900;--tag-bg-color:rgba(0, 0, 100, 0.075);--tag-font-size:0.85em;--tag-font-weight:bold;--tag-padding:0.35em 0.57em;--tag-margin:0.28em;--tag-border-radius:4px;--tag-text-color:inherit;--branding-text-color:inherit;width:100%;display:block;position:relative}.codersrank-timeline{position:relative}.codersrank-timeline-loading{height:100px}.codersrank-timeline-preloader{position:absolute;left:50%;top:50%;width:32px;height:32px;margin:-16px 0 0 -16px;border:3px solid var(--preloader-color);border-left-color:transparent;border-bottom-color:transparent;border-radius:50%;box-sizing:border-box;-webkit-animation:preloader 1s infinite linear;animation:preloader 1s infinite linear}.codersrank-timeline-wrap{position:relative;overflow:auto;padding-bottom:var(--year-height)}.codersrank-timeline-years{display:flex}.codersrank-timeline-year{font-size:var(--year-font-size);opacity:var(--year-opacity);flex-shrink:0;height:var(--year-height);display:flex;align-items:center;color:var(--year-text-color)}.codersrank-timeline-year>span{padding-left:4px;padding-right:4px;position:-webkit-sticky;position:sticky;left:0}.codersrank-timeline-year-line{position:absolute;top:0;border-left:1px dashed var(--year-line-color);opacity:var(--year-line-opacity);height:100%;z-index:0;margin-left:-2px}.codersrank-timeline-chart{position:relative;z-index:10}.codersrank-timeline-item-wrap{position:absolute}.codersrank-timeline-item{position:absolute;left:2px;top:2px;right:2px;bottom:2px;background-color:var(--timeline-item-bg-color);font-size:var(--timeline-item-font-size);display:flex;align-items:center;border-radius:var(--timeline-item-border-radius);color:var(--timeline-item-text-color);cursor:pointer;transition-duration:.2s}.codersrank-timeline-item:hover{opacity:.8}.codersrank-timeline-item span{white-space:nowrap;text-overflow:ellipsis;overflow:hidden;max-width:100%;position:-webkit-sticky;position:sticky;padding:var(--timeline-item-padding);left:0;display:flex;align-items:center}.codersrank-timeline-item span img{width:24px;height:24px;margin-right:4px}.codersrank-timeline-tooltip{text-align:left;position:absolute;background:var(--tooltip-bg-color);transform:translateX(-50%) translateY(-100%);border-radius:var(--tooltip-border-radius);color:var(--tooltip-text-color);box-shadow:var(--tooltip-box-shadow);font-family:var(--font-family);font-size:var(--tooltip-font-size,14px);margin-top:-10px;width:var(--tooltip-width);max-width:80vw;line-height:1.5;z-index:1000}.codersrank-timeline-tooltip-content{max-height:80vh;overflow:auto;padding:var(--tooltip-padding)}.codersrank-timeline-tooltip-angle{width:0px;height:0px;position:absolute;left:50%;top:100%;border-left:10px solid transparent;border-right:10px solid transparent;border-top:10px solid var(--tooltip-bg-color);margin-left:-5px}.codersrank-timeline-tooltip-bottom{transform:translateX(-50%);margin-top:34px}.codersrank-timeline-tooltip-bottom .codersrank-timeline-tooltip-angle{bottom:100%;top:auto;transform:rotate(180deg)}.codersrank-timeline-tooltip-divider{height:1px;background:rgba(0,0,0,.1);margin:16px 0}.codersrank-timeline-tooltip-item+.codersrank-timeline-tooltip-item{margin-top:16px}.codersrank-timeline-tooltip-item{display:flex}.codersrank-timeline-tooltip-item .logo{width:var(--tooltip-logo-size);height:var(--tooltip-logo-size);margin-right:16px;flex-shrink:0}.codersrank-timeline-tooltip-item .logo img,.codersrank-timeline-tooltip-item .logo svg{width:100%}.codersrank-timeline-tooltip-item .content{width:100%;min-width:0;flex-shrink:10}.codersrank-timeline-tooltip-item .title{font-weight:700;font-size:1.25em}.codersrank-timeline-tooltip-item .subtitle{font-weight:700}.codersrank-timeline-tooltip-item .details{opacity:.5}.codersrank-timeline-tooltip-item .description{margin:.5em 0}.codersrank-timeline-tooltip-item .tags{margin-top:.5em;display:flex;flex-wrap:wrap;align-items:center;justify-content:flex-start}.codersrank-timeline-tooltip-item .tag{display:inline-flex;padding:var(--tag-padding);font-size:var(--tag-font-size);background:var(--tag-bg-color);border-radius:var(--tag-border-radius);font-weight:var(--tag-font-weight);line-height:1;margin-right:var(--tag-margin);margin-bottom:var(--tag-margin);border:var(--tag-border);color:var(--tag-text-color)}.codersrank-timeline-tooltip-item .tag-star{color:var(--tag-star-color);margin-right:4px}.codersrank-timeline-branding{justify-content:flex-end;align-items:center;font-size:12px;color:var(--branding-text-color);display:flex;margin-top:.5em}.codersrank-timeline-branding a{opacity:.5;display:flex;align-items:center;color:inherit;text-decoration:none;transition-duration:.2s;position:relative;z-index:1;transform:translate3d(0,0,0)}.codersrank-timeline-branding a:hover{opacity:1}.codersrank-timeline-branding span{margin-right:4px}.codersrank-timeline-branding svg{height:16px;width:auto}@-webkit-keyframes preloader{from{transform:rotate(0deg)}to{transform:rotate(360deg)}}@keyframes preloader{from{transform:rotate(0deg)}to{transform:rotate(360deg)}}"; // eslint-disable-next-line

  var CodersrankTimeline = /*#__PURE__*/function (_HTMLElement) {
    _inheritsLoose(CodersrankTimeline, _HTMLElement);

    function CodersrankTimeline() {
      var _this;

      _this = _HTMLElement.call(this) || this;
      _this.shadowEl = _this.attachShadow({
        mode: 'closed'
      });
      _this.tempDiv = document.createElement('div');
      _this.stylesEl = document.createElement('style');
      _this.stylesEl.textContent = STYLES;

      _this.shadowEl.appendChild(_this.stylesEl);

      _this.onDocumentClick = _this.onDocumentClick.bind(_assertThisInitialized(_this));
      _this.onWidgetClick = _this.onWidgetClick.bind(_assertThisInitialized(_this));
      _this.mounted = false;
      _this.state = STATE_IDLE;
      _this.data = null;
      return _this;
    }

    var _proto = CodersrankTimeline.prototype;

    _proto.render = function render$1() {
      var username = this.username,
          mounted = this.mounted,
          state = this.state,
          shadowEl = this.shadowEl,
          data = this.data,
          type = this.type,
          branding = this.branding;
      var ctx = {
        data: data,
        type: type,
        branding: branding
      };
      if (!username || !mounted) return;

      if (state === STATE_SUCCESS) {
        this.tempDiv.innerHTML = render(ctx);
      } else if (state === STATE_ERROR) {
        this.tempDiv.innerHTML = renderError();
      } else if (state === STATE_IDLE || state === STATE_LOADING) {
        this.tempDiv.innerHTML = renderLoading(ctx);
      }

      var widgetEl = shadowEl.querySelector('.codersrank-timeline');

      if (widgetEl) {
        widgetEl.parentNode.removeChild(widgetEl);
      }

      widgetEl = this.tempDiv.querySelector('.codersrank-timeline');
      if (!widgetEl) return;
      this.widgetEl = widgetEl;
      this.detachEvents();
      this.attachEvents();
      shadowEl.appendChild(widgetEl);
    };

    _proto.loadAndRender = function loadAndRender() {
      var _this2 = this;

      var username = this.username,
          type = this.type;
      this.state = STATE_LOADING;
      this.render();
      fetchData(username, type).then(function (items) {
        _this2.emitData(items);

        _this2.data = formatData(items, type);
        _this2.state = STATE_SUCCESS;

        _this2.render();
      })["catch"](function () {
        _this2.state = STATE_ERROR;

        _this2.render();
      });
    };

    _proto.tooltipText = function tooltipText(id) {
      var item;
      this.data.rows.forEach(function (row) {
        row.forEach(function (el) {
          if (el.id === parseInt(id, 10)) item = el;
        });
      });
      if (!item) return '';
      return renderTooltip(item, this.type);
    };

    _proto.showTooltip = function showTooltip(id) {
      if (!this.data || !id || !this.widgetEl) return;
      var itemEl = this.shadowEl.querySelector("[data-id=\"" + id + "\"]");
      if (!itemEl) return;
      var tooltipText = this.tooltipText(id);
      if (!tooltipText) return;
      this.tempDiv.innerHTML = "\n      <div class=\"codersrank-timeline-tooltip\">\n        <div class=\"codersrank-timeline-tooltip-content\">\n          " + tooltipText + "\n        </div>\n        <div class=\"codersrank-timeline-tooltip-angle\"></div>\n      </div>\n    ";
      var widgetElRect = this.getBoundingClientRect();
      var itemElRect = itemEl.getBoundingClientRect();
      var tooltipEl = this.tempDiv.querySelector('.codersrank-timeline-tooltip');
      var itemLeft = itemElRect.left - widgetElRect.left < 0 ? 0 : itemElRect.left - widgetElRect.left;
      var itemWidth = itemElRect.width;

      if (itemElRect.left < 0) {
        itemWidth = itemElRect.width + itemElRect.left - widgetElRect.left;
      }

      if (itemLeft + itemWidth > widgetElRect.width) {
        itemWidth = widgetElRect.width - itemLeft;
      }

      var left = itemLeft + itemWidth / 2;
      if (left < 0) left = 0;
      if (left > widgetElRect.width) left = widgetElRect.width;
      tooltipEl.style.left = left + "px";
      tooltipEl.style.top = itemElRect.top - widgetElRect.top + "px";
      tooltipEl.querySelector('.codersrank-timeline-tooltip-angle');
      this.shadowEl.appendChild(tooltipEl);
      var tooltipRect = tooltipEl.getBoundingClientRect();

      if (tooltipRect.top < 0) {
        tooltipEl.classList.add('codersrank-timeline-tooltip-bottom');
      }
    };

    _proto.hideTooltip = function hideTooltip() {
      if (!this.widgetEl) return;
      var tooltipEl = this.shadowEl.querySelector('.codersrank-timeline-tooltip');
      if (!tooltipEl) return;
      this.shadowEl.removeChild(tooltipEl);
    };

    _proto.onDocumentClick = function onDocumentClick(e) {
      if (e.target === this) return;
      this.hideTooltip();
    };

    _proto.onWidgetClick = function onWidgetClick(e) {
      this.hideTooltip();
      var targetEl = e.target;
      var parentEl = targetEl && targetEl.parentElement;
      var itemEl;

      if (targetEl.classList && targetEl.classList.contains('codersrank-timeline-item')) {
        itemEl = targetEl;
      } else if (parentEl.classList && parentEl.classList.contains('codersrank-timeline-item')) {
        itemEl = parentEl;
      }

      if (itemEl) this.showTooltip(itemEl.getAttribute('data-id'));
    };

    _proto.emitData = function emitData(items) {
      if (items === void 0) {
        items = [];
      }

      var event = new CustomEvent('data', {
        detail: {
          items: items
        }
      });
      this.dispatchEvent(event);
    };

    _proto.attachEvents = function attachEvents() {
      if (!this.widgetEl) return;
      document.addEventListener('click', this.onDocumentClick, true);
      this.widgetEl.addEventListener('click', this.onWidgetClick, true);
    };

    _proto.detachEvents = function detachEvents() {
      if (!this.widgetEl) return;
      document.removeEventListener('click', this.onDocumentClick, true);
      this.widgetEl.removeEventListener('click', this.onWidgetClick, true);
    };

    _proto.attributeChangedCallback = function attributeChangedCallback() {
      if (!this.mounted) return;
      this.loadAndRender();
    };

    _proto.connectedCallback = function connectedCallback() {
      this.width = this.offsetWidth;
      this.mounted = true;
      this.loadAndRender();
    };

    _proto.disconnectedCallback = function disconnectedCallback() {
      this.mounted = false;
      this.detachEvents();
    };

    _createClass(CodersrankTimeline, [{
      key: "username",
      get: function get() {
        return this.getAttribute('username');
      },
      set: function set(value) {
        this.setAttribute('username', value);
      }
    }, {
      key: "type",
      get: function get() {
        return this.getAttribute('type') || 'workexperience';
      },
      set: function set(value) {
        this.setAttribute('type', value);
      }
    }, {
      key: "branding",
      get: function get() {
        return this.getAttribute('branding') !== 'false';
      },
      set: function set(value) {
        this.setAttribute('branding', value);
      }
    }], [{
      key: "observedAttributes",
      get: function get() {
        return ['username', 'type'];
      }
    }]);

    return CodersrankTimeline;
  }( /*#__PURE__*/_wrapNativeSuper(HTMLElement));

  if (window.customElements && !window.customElements.get(COMPONENT_TAG)) {
    window.customElements.define(COMPONENT_TAG, CodersrankTimeline);
  }

})));
//# sourceMappingURL=codersrank-timeline.js.map
