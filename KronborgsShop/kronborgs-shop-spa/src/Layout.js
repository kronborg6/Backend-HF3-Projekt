import React, { Component } from 'react';
import { Container } from 'reactstrap';
import NavBarMenu from './NavBarMenu';
import './App.css'

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
      <NavBarMenu />
        <div>

        <Container>
          {this.props.children}
        </Container>
        </div>
      </div>
    );
  }
}
