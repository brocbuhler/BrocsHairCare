const _apiUrl = "/api/services";

export const getService = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((r) => r.json());
};
