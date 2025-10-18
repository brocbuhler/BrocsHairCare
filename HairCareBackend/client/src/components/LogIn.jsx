import { useEffect, useState } from "react";
import { getCustomer } from "../Data/Customers";
import { getAppointment } from "../Data/Appointments";
import { getService } from "../Data/Services";
import { getStylists } from "../Data/Stylists";

export default function LogIn() 
{
//testing fetch requests
  const [service, setService] = useState([]);
  const [stylist, setStylists] = useState([]);
  const [appointment, setAppointment] = useState([]);
  const [customer, setCustomer] = useState([]);

  useEffect(() => {
    //appointments
    getAppointment(1).then(setAppointment);
    // createAppointment("add object")
    // patchAppointment("add id, object")
    // deleteAppointment("add id");
    //
    //Customers
    getCustomer(1).then(setCustomer)
    // createCustomer("add id, object")
    //
    //Services
    getService(1).then(setService)
    //
    //Stylists
    getStylists().then(setStylists)
    // createStylist("object")
    // patchStylist("add id, object")
    //
  }, []);
//
  return (
  <>
    <h2>Appointment Test</h2>
    <div>
      ID: {appointment.id} <br />
      StylistId: {appointment.stylistId} <br />
      Stylist: {appointment.stylist?.name} <br />
      CustomerId: {appointment.customerId} <br />
      Customer: {appointment.customer?.name} <br />
      Time: {appointment.appointmentTime} <br />
      Services: <pre>{JSON.stringify(appointment.appointmentServices, null, 2)}</pre>
    </div>

    <h2>Customer Test</h2>
    <div>
      ID: {customer.id} <br />
      Name: {customer.name} <br />
      Password: {customer.password}
    </div>

    <h2>Service Test</h2>
    <div>
      ID: {service.id} <br />
      Type: {service.type} <br />
      Price: {service.price}
    </div>

    <h2>Stylist List</h2>
    <table>
      <tbody>
        {stylist.map((m) => (
          <tr key={`stylist-${m.id}`}>
            <th scope="row">{m.id}</th>
            <td>{m.name}</td>
            <td>{m.isActive ? "Active" : "Inactive"}</td>
          </tr>
        ))}
      </tbody>
    </table>
  </>
);

}
