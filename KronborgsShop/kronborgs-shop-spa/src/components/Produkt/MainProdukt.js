import React, { useState } from 'react';
import { TabContent, TabPane, Nav, NavItem, NavLink, Card, Button, CardTitle, CardText, Row, Col } from 'reactstrap';

// Sider
import Produkt from './Produkt';
import Produkts from './Produkts';
// import Members from '../Member/Members'
import ProduktDelete from './ProduktDelete';

function MainProdukt() {
    const [activeTab, setActiveTab] = useState('1');

    const toggle = tab => {
      if(activeTab !== tab) setActiveTab(tab);
    }
    return (
        <div>
          <Nav tabs>
            <NavItem>
              <NavLink
                className={Produkts({ active: activeTab === '1' })}
                onClick={() => { toggle('1'); }}
              >
                Produkt's List
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink
                className={Produkt({ active: activeTab === '2' })}
                onClick={() => { toggle('2'); }}
              >
                Find Produkt
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink
                className={ProduktDelete({ active: activeTab === '3' })}
                onClick={() => { toggle('3'); }}
              >
                Delete Produkt
              </NavLink>
            </NavItem>
          </Nav>
          <TabContent activeTab={activeTab}>
            <TabPane tabId="1">
              <Produkts />
            </TabPane>
            <TabPane tabId="2">
              <Produkt />
            </TabPane>
            <TabPane tabId="3">
              <ProduktDelete />
            </TabPane>
          </TabContent>
        </div>
      );
}

export default MainProdukt
