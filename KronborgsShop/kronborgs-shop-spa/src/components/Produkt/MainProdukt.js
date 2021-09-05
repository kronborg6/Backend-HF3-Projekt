import React, { useState } from 'react';
import { TabContent, TabPane, Nav, NavItem, NavLink, Card, Button, CardTitle, CardText, Row, Col } from 'reactstrap';

// Sider
import Produkt from './Produkt';
import Produkts from './Produkts';
// import Members from '../Member/Members'
import ProduktDelete from './ProduktDelete';
import ProduktPost from './ProduktPost';

function MainProdukt() {
    const [activeTab, setActiveTab] = useState('1');
    const [showAddProdukt, setShowAddProdukt] = useState(false)
    const [showDeleteProdukt, setShowDeleteProdukt] = useState(false)
    const [showEditProdukt, setEditProdukt] = useState(false)


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
            {/* <NavItem>
              <NavLink
                className={ProduktDelete({ active: activeTab === '3' })}
                onClick={() => { toggle('3'); }}
              >
                Delete Produkt
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink
                className={ProduktDelete({ active: activeTab === '4' })}
                onClick={() => { toggle('4'); }}
              >
                Delete Produkt
              </NavLink>
            </NavItem> */}
          </Nav>
          <TabContent activeTab={activeTab}>
            <TabPane tabId="1">
            <Button outline onClick={() => setShowAddProdukt(!showAddProdukt)} color="success">Create Produkt</Button>
            <Button outline onClick={() => setShowDeleteProdukt(!showDeleteProdukt)} color="danger">Delete Produkt</Button>
            <Button outline onClick={() => setEditProdukt(!showEditProdukt)} color="primary">Edit Produkt</Button>
            {showAddProdukt && 
              <ProduktPost />
            } 
            {showDeleteProdukt && 
              <ProduktDelete />
            }
              <Produkts />
            </TabPane>
            <TabPane tabId="2">
              <Produkt />
            </TabPane>
            <TabPane tabId="3">
              <ProduktDelete />
            </TabPane>
            <TabPane tabId="4">
            <Button outline onClick={() => setShowAddProdukt(!showAddProdukt)} color="primary">Test</Button>
            <Button outline onClick={() => setShowDeleteProdukt(!showDeleteProdukt)} color="primary">Test</Button>
            <Button outline onClick={() => setEditProdukt(!showEditProdukt)} color="primary">Test</Button>

            {showAddProdukt && 
              <ProduktPost />
            }
            {showDeleteProdukt && 
              <ProduktDelete />
            }
            {showEditProdukt &&
              <div></div>
            }
              {/* <ProduktDelete /> */}
            </TabPane>
          </TabContent>
        </div>
      );
}

export default MainProdukt
