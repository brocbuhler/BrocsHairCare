const _apiUrl = "/api/appointments";

const getAppointment = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((r) => r.json());
};

const createAppointment = (appointment) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(appointment),
  }).then((res) => res.json());
};

const patchAppointment = (id, appointment) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "PATCH",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(appointment),
  }).then((res) => res.json());
};

const deleteAppointment = (id) => {
  fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
  });
};


export {getAppointment, patchAppointment, createAppointment, deleteAppointment}
