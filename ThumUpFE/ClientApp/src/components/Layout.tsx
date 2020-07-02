import * as React from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { IDefaultProps, IDefaultState } from './interfaces/IDefault';

export class Layout extends React.Component<IDefaultProps, IDefaultState> {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
