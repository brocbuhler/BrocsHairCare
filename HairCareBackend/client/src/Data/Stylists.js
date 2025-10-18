const _apiUrl = "/api/stylists";

const getStylists = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

const createStylist = (stylist) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(stylist),
  }).then((res) => res.json());
};

const patchStylist = (id, stylist) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "PATCH",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(stylist),
  }).then((res) => res.json());
};

export {getStylists, createStylist, patchStylist};
