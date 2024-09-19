"use strict";

var _fetchData = require("./shared/fetch-data");

var _render2 = require("./shared/render");

var _renderError = require("./shared/render-error");

var _renderLoading = require("./shared/render-loading");

var _formatData = require("./shared/format-data");

var _renderTooltip = require("./shared/render-tooltip");

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

function _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return self; }

function _inheritsLoose(subClass, superClass) { subClass.prototype = Object.create(superClass.prototype); subClass.prototype.constructor = subClass; subClass.__proto__ = superClass; }

function _wrapNativeSuper(Class) { var _cache = typeof Map === "function" ? new Map() : undefined; _wrapNativeSuper = function _wrapNativeSuper(Class) { if (Class === null || !_isNativeFunction(Class)) return Class; if (typeof Class !== "function") { throw new TypeError("Super expression must either be null or a function"); } if (typeof _cache !== "undefined") { if (_cache.has(Class)) return _cache.get(Class); _cache.set(Class, Wrapper); } function Wrapper() { return _construct(Class, arguments, _getPrototypeOf(this).constructor); } Wrapper.prototype = Object.create(Class.prototype, { constructor: { value: Wrapper, enumerable: false, writable: true, configurable: true } }); return _setPrototypeOf(Wrapper, Class); }; return _wrapNativeSuper(Class); }

function _construct(Parent, args, Class) { if (_isNativeReflectConstruct()) { _construct = Reflect.construct; } else { _construct = function _construct(Parent, args, Class) { var a = [null]; a.push.apply(a, args); var Constructor = Function.bind.apply(Parent, a); var instance = new Constructor(); if (Class) _setPrototypeOf(instance, Class.prototype); return instance; }; } return _construct.apply(null, arguments); }

function _isNativeReflectConstruct() { if (typeof Reflect === "undefined" || !Reflect.construct) return false; if (Reflect.construct.sham) return false; if (typeof Proxy === "function") return true; try { Date.prototype.toString.call(Reflect.construct(Date, [], function () {})); return true; } catch (e) { return false; } }

function _isNativeFunction(fn) { return Function.toString.call(fn).indexOf("[native code]") !== -1; }

function _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }

function _getPrototypeOf(o) { _getPrototypeOf = Object.setPrototypeOf ? Object.getPrototypeOf : function _getPrototypeOf(o) { return o.__proto__ || Object.getPrototypeOf(o); }; return _getPrototypeOf(o); }

// eslint-disable-next-line
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

  _proto.render = function render() {
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
      this.tempDiv.innerHTML = (0, _render2.render)(ctx);
    } else if (state === STATE_ERROR) {
      this.tempDiv.innerHTML = (0, _renderError.renderError)(ctx);
    } else if (state === STATE_IDLE || state === STATE_LOADING) {
      this.tempDiv.innerHTML = (0, _renderLoading.renderLoading)(ctx);
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
    (0, _fetchData.fetchData)(username, type).then(function (items) {
      _this2.emitData(items);

      _this2.data = (0, _formatData.formatData)(items, type);
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
    return (0, _renderTooltip.renderTooltip)(item, this.type);
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
module.exports = CodersrankTimeline;
