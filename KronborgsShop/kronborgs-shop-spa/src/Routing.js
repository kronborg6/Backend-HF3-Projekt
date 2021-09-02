import React from 'react';
import { Route } from 'react-router';
import { Layout } from './Layout';

//Side
import Home from './components/Home'
import Header from './components/Header';
import Produkt from './components/Produkt';

const Routing = () => {
    return (
        <Layout>
          <Route exact path='/' component={Home} />
          <Route path='/Produkt' component={Produkt} />
          <Route path='/Header' component={Header} />
        </Layout>
      )
}

export default Routing
