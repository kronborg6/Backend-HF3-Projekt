import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Produkt } from './components/Produkts/Produkt';
import { Produkts } from './components/Produkts/Produkts';
// import { ProduktList } from './components/Produkts/ProduktList';
import ProduktComponent from './components/TestMappe/GetProdukt';

import Test from './components/Produkts/Test';
import TestFetch from './components/Produkts/TestFetch';

//Real add to finsh website
import GetProdukts from './components/Produkts/GetProdukts';
import GetProdukt from './components/Produkts/GetProdukt';



// import GetAll from './components/TestMappe/GetAll';


import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route path='/GP' component={ProduktComponent} />
        <Route exact path='/' component={Home} />
        <Route path='/Produkt' component={Produkt} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/Produkts' component={Produkts} />
        <Route path='/Test' component={Test} />
        <Route path='/TestFetch' component={TestFetch} />
        <Route path='/tt' component={GetProdukt} />
        <Route path='/rtd' component={GetProdukts} />
        
      </Layout>
    );
  }
}
