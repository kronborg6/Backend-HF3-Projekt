import React from 'react';
import { Route } from 'react-router';
import { Layout } from './Layout';

//Side
import Home from './components/Home'
import Header from './components/Header';
import Produkt from './components/Produkt/Produkt';
import Produkts from './components/Produkt/Produkts';
import MyComponent from './components/ApiTest/MyComponent';
import Members from './components/Member/Members';
import Adresses from './components/Adresse/Adresses';

const Routing = () => {
    return (
        <Layout>
          <Route exact path='/' component={Home} />
          <Route path='/Produkt' component={Produkt} />
          <Route path='/Produkts' component={Produkts} />
          <Route path='/Header' component={Header} />
          <Route path='/Kronborg/Er/Gud' component={MyComponent} />
          <Route path='/Members' component={Members} />
          <Route path='/Adresses' component={Adresses} />
        </Layout>
      )
}

export default Routing
