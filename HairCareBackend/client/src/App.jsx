import { Navbar, NavbarBrand, Nav, NavItem, NavLink } from "reactstrap";
import "./App.css";
import "bootstrap/dist/css/bootstrap.css";
import { Outlet } from "react-router-dom";
function App() {
  return (
    <>
      <Navbar color="info" expand="md">
        <Nav navbar>
          <NavbarBrand href="/">Broc's Hair Care</NavbarBrand>
          <NavItem>
            <NavLink href="/LogIn">View Your Appointment</NavLink>
          </NavItem>
        </Nav>
      </Navbar>
      <Outlet />
    </>
  );
}

export default App;
