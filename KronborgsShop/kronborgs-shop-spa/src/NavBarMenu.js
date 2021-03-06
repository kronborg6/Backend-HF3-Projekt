import React from 'react';
import { Collapse, Navbar, NavbarToggler, NavbarBrand, Nav, NavItem, NavLink, UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem, Container } from 'reactstrap';

import { Link } from 'react-router-dom';





const NavBarMenu = () => {

  return (
    <header>
    <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
      <Container>
        <NavbarBrand tag={Link} to="/">Kronborg's Shop</NavbarBrand>
        <NavbarToggler className="mr-2" />
        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" navbar>
        <Nav  className="mr-auto" navbar>
          <ul className="navbar-nav flex-grow">
            <NavItem>
               
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/">Produkt</NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/">Member</NavLink>
            </NavItem>
          </ul>
          <UncontrolledDropdown nav inNavbar>
          
        </UncontrolledDropdown>
        </Nav>
        </Collapse>
      </Container>
    </Navbar>
  </header>
    
  );
}

export default NavBarMenu;