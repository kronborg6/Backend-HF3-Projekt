import React from 'react';
import { Route } from 'react-router';
import { Layout } from './Layout';

//Side
import Home from './components/Home'
import Header from './components/Header';
import Produkt from './components/Produkt/Produkt';
import Produkts from './components/Produkt/Produkts';
import MyComponent from './components/ApiTest/MyComponent';
import Member from './components/Member/Member';
import Adresses from './components/Adresse/Adresses';
import ProduktDelete from './components/Produkt/ProduktDelete';
import MainProdukt from './components/Produkt/MainProdukt';
import ProduktPost from './components/Produkt/ProduktPost';



const Routing = () => {
    return (
        <Layout>
          <Route exact path='/' component={MainProdukt} />
          <Route path='/Produkt' component={Produkt} />
          <Route path='/Produkts' component={Produkts} />
          <Route path='/Header' component={Header} />
          <Route path='/Kronborg/Er/Gud' component={MyComponent} />
          <Route path='/Members' component={Member} />
          <Route path='/Adresses' component={Adresses} />
          <Route path='/del' component={ProduktDelete} />
          <Route path='/MP' component={MainProdukt} />
          <Route path='/PP' component={ProduktPost} />

        </Layout>
      )
}

export default Routing
