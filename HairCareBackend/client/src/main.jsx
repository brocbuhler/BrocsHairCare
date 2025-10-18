import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import LogIn from "./components/LogIn";
import CustomerForm from "./components/CustomerForm";
import AppointmentDisplay from "./components/AppointmentDisplay";
import StylistDisplay from "./components/StylistDisplay";
import PickDate from "./components/PickDate";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route path="Appointmets">
          <Route path="LogIn" element={<LogIn />} />
          <Route path="CreateAccount" element={<CustomerForm />} />
          <Route path="Display" element={<AppointmentDisplay/>}/>
        </Route>
        <Route path="Stylists">
          <Route path="Display" element={<StylistDisplay />}/>
          <Route path="PickDate" element={<PickDate />}/>
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>,
);
