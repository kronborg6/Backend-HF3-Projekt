import React, { useState } from 'react';
import { Button, Input, InputGroup, InputGroupAddon, InputGroupText, Card, Row, Col } from 'reactstrap';


function ProduktDelete(props) {
    const [id, setID] = useState('');
    const [status, setStatus] = useState(null);
    const [errorMessage, setErrorMessage] = useState(null);

    if (false) {
        console.log(errorMessage);
        console.log(status);
    }


    async function DeleteData() {
        const requestOptions = {
            method: 'DELETE',
            headers: { 
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ productID: id })
        };
        props.DelData(requestOptions);

       
      }

    


    
    return (
        <div>
            <h1>Delete Produkt</h1>
            
        <div>
        <Row>
                <br />
                <br />
                <Col xs="4">
                <Card>
            <InputGroup>
            <InputGroupAddon addonType="prepend">
          <InputGroupText>ID</InputGroupText>
        </InputGroupAddon>

            <Input className="smaller-input" onChange={e => setID(e.target.value)} placeholder="Produkt ID"/>
            <Button outline onClick={DeleteData} color="danger">Delete Produkt</Button> 

            </InputGroup>
            </Card>
                </Col>
            </Row>
        </div>
        </div>
    )
}

export default ProduktDelete



// https://localhost:44363/Produkts?id=9