const _apiUrl = "/api/stylists";

const getStylist = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((r) => r.json());
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

export {getStylist, createStylist, patchStylist};
