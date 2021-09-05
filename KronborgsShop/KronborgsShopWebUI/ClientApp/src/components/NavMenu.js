import React, { Component } from 'react';
import { Collapse, Navbar, NavbarToggler, NavbarBrand, Nav, NavItem, NavLink, UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem, Container } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">KronborgsShopWebUI</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
            <Nav  className="mr-auto" navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                   
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                </NavItem>
              </ul>
              <UncontrolledDropdown nav inNavbar>
              <DropdownToggle nav caret>
                Produks
              </DropdownToggle>
              <DropdownMenu right>
                <DropdownItem>
                <NavLink tag={Link} className="text-dark" to="/Produkt">Find Produkt</NavLink>
                </DropdownItem>
                <DropdownItem>
                <NavLink tag={Link} className="text-dark" to="/Produkts">Produkts List</NavLink>
                </DropdownItem>
                <DropdownItem divider />
                <DropdownItem>
                  Reset
                </DropdownItem>
              </DropdownMenu>
            </UncontrolledDropdown>
            <UncontrolledDropdown nav inNavbar>
              <DropdownToggle nav caret>
                Members
              </DropdownToggle>
              <DropdownMenu right>
                <DropdownItem>
                <NavLink tag={Link} className="text-dark" to="/Produkt">Find Produkt</NavLink>
                </DropdownItem>
                <DropdownItem>
                <NavLink tag={Link} className="text-dark" to="/Produkts">Produkts List</NavLink>
                </DropdownItem>
                <DropdownItem divider />
                <DropdownItem>
                  Reset
                </DropdownItem>
              </DropdownMenu>
            </UncontrolledDropdown>
            <UncontrolledDropdown nav inNavbar>
              <DropdownToggle nav caret>
                Addresse
              </DropdownToggle>
              <DropdownMenu right>
                <DropdownItem>
                <NavLink tag={Link} className="text-dark" to="/Produkt">Find Produkt</NavLink>
                </DropdownItem>
                <DropdownItem>
                <NavLink tag={Link} className="text-dark" to="/Produkts">Produkts List</NavLink>
                </DropdownItem>
                <DropdownItem divider />
                <DropdownItem>
                  Reset
                </DropdownItem>
              </DropdownMenu>
            </UncontrolledDropdown>
            </Nav>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
