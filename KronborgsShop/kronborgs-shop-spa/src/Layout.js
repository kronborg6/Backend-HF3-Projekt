import React, { Component } from 'react';
import { Container } from 'reactstrap';
import NavBarMenu from './NavBarMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavBarMenu />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
