import * as React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';

import './custom.css'

export default class App extends React.Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/home' component={Home} />
        <Route path='/' component={FetchData} />
      </Layout>
    );
  }
}
