const _apiUrl = "/api/customers";

const createCustomer = (customer) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(customer),
  }).then((res) => res.json());
};

const getCustomer = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((r) => r.json());
};

export {createCustomer, getCustomer};
