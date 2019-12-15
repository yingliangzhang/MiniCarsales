import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import AppAlert from './AppAlert'

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <AppAlert />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
