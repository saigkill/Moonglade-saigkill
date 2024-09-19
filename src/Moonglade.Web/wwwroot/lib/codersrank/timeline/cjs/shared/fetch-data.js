"use strict";

exports.__esModule = true;
exports.fetchData = void 0;
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

exports.fetchData = fetchData;