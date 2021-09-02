import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';

import './index.css';
import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.css';

// import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
// import NavMenu from './NavMenu';
// import NavMenu from './components/NavMenu';
// import NavBarMenu from './NavBarMenu';
// Sider
// import App from './App';
import Routing from './Routing';

// const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');


ReactDOM.render(
  <BrowserRouter>
    <Routing />
  </BrowserRouter>,
  rootElement);
// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
