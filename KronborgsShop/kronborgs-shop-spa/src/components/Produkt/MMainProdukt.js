import React, { useState, useEffect, useCallback } from 'react';
import { TabContent, TabPane, Nav, NavItem, NavLink, Button } from 'reactstrap';

//css Style
import './ProduktStyle.css'

// Sider
import Produkt from './Produkt';
import Produkter from './Produkts';
// import Members from '../Member/Members'
import ProduktDelete from './ProduktDelete';
import ProduktPost from './ProduktPost';
import ProduktPut from './ProduktPut';

function MainProdukt() {
    const [activeTab, setActiveTab] = useState('1');
    const [showAddProdukt, setShowAddProdukt] = useState(false)
    const [showDeleteProdukt, setShowDeleteProdukt] = useState(false)
    const [showEditProdukt, setEditProdukt] = useState(false)
    const [status, setStatus] = useState(null);


    const [produkts, setProdukts] = useState([]);

    const postData = async(requestOptions) => {
      await fetch('https://localhost:44363/Produkts', requestOptions)
      .then(response => response.json())

      getData();
    }
    const putData = async(requestOptions) => {
      await fetch('https://localhost:44363/Produkts', requestOptions)
      .then(response => response.json())
      // .then(data => setPostId(data.id));
      getData();
    }
    const deleteDate = async(requestOptions) => {
      await fetch('https://localhost:44363/Produkts', requestOptions)
      .then(() => setStatus('Delete successful'));

      getData();
    }
  
    const getData = useCallback(async() => {
      const res = await fetch("https://localhost:44363/Produkts");
      const data = await res.json();
      console.log(data)

      // store the data into our Produkt variable
      setProdukts(data) ;
    }, []);

    useEffect(() => {
      getData();

    }, [getData]); // <- you may need to put the setBooks function in this array

    const aktive = check => {

    }

    const toggle = tab => {
      if(activeTab !== tab) setActiveTab(tab);
    }
    return (
        <div>
          <Nav tabs className="tabs">
            <NavItem className="tab">
              <Button
              outline
              color="primary"
              size="lg"
                className={Produkter({ active: activeTab === '1' })}
                onClick={() => { toggle('1'); }}
              >
                Produkt's List
              </Button>
            </NavItem>
            <NavItem>
              <Button
              outline
              color="primary"
              size="lg"
                className={Produkt({ active: activeTab === '2' })}
                onClick={() => { toggle('2'); }}
              >
                Find Produkt
              </Button>
            </NavItem>
          </Nav>
          <TabContent activeTab={activeTab}>
            <TabPane tabId="1">
            <Button outline onClick={() => setShowAddProdukt(!showAddProdukt)} color="success">Create Produkt</Button>
            <Button outline onClick={() => setEditProdukt(!showEditProdukt)} color="warning">Edit Produkt</Button>
            <Button outline onClick={() => setShowDeleteProdukt(!showDeleteProdukt)} color="danger">Delete Produkt</Button>
            <div xs="15"></div>
            {showAddProdukt && 
            <div>
              <br />
              <ProduktPost GetData={postData}/>
            </div>
            } 
            {showDeleteProdukt && 
            <div>
              <br />
              <ProduktDelete DelData={deleteDate} />
            </div>
            }
            {showEditProdukt && 
              <div>
                <br />
              <ProduktPut PutData={putData}/>
            </div>
            }
            <div>
              <br />
            </div>

              <Produkter Produktss={produkts} />
            </TabPane>
            <TabPane tabId="2">
              <Produkt />
            </TabPane>
          </TabContent>
        </div>
      );
}

export default MainProdukt
