import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { Router } from 'react-router-dom';
import history from './history'
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import { Provider } from 'react-redux'
import createStore from './store/createStore'

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const store = createStore()

ReactDOM.render(  
  <Provider store={store}>
    <Router basename={baseUrl} history={history}>
      <App />
    </Router>
  </Provider>,
  rootElement
);

registerServiceWorker();

