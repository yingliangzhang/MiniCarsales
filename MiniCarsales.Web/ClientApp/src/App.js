import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Cars from './components/Car/Cars'
import CreateCar from './components/Car/CreateCar'

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' render={() => <Cars />} />
        <Route exact path='/create-car' render={() => <CreateCar />} />
      </Layout>
    );
  }
}
