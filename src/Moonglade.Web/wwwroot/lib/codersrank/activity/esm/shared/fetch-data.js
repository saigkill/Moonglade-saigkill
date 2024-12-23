var cache = {};
export var fetchData = function fetchData(username, id) {
  if (username && cache[username]) return Promise.resolve(cache[username]);
  if (id && cache[id]) return Promise.resolve(cache[id]);
  var endpoint = "https://api.codersrank.io/v2/users/" + (username || id) + "/activities";
  if (id) endpoint += '?get_by=id';
  return fetch(endpoint, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json'
    }
  }).then(function (res) {
    return res.json();
  }).then(function (data) {
    if (id) {
      cache[id] = data;
    } else {
      cache[username] = data;
    }

    return data;
  })["catch"](function (err) {
    // eslint-disable-next-line
    return Promise.reject(err);
  });
};