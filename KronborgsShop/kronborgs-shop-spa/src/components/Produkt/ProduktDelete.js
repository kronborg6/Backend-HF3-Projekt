import React, { useState, useEffect } from 'react';
import { Button, Input, InputGroup, InputGroupAddon, InputGroupText, Container, Card, Row, Col } from 'reactstrap';

import Produkts from './Produkts';


function ProduktDelete() {
    const [id, setID] = useState('');
    const [status, setStatus] = useState(null);
    const [errorMessage, setErrorMessage] = useState(null);
    const IDInput = React.createRef();
    const [showAddTask, setShowAddTask] = useState(false)


    async function DeleteData() {
        fetch(`https://localhost:44363/Produkts?id=${id}`, { method: 'DELETE' })
            .then(async response => {
                const data = await response.json();
    
                // check for error response
                if (!response.ok) {
                    // get error message from body or default to response status
                    const error = (data && data.message) || response.status;
                    console.log(id + 'den var slette')
                    return Promise.reject(error);
                }
    
                setStatus('Delete successful');
            })
            .catch(error => {
                setErrorMessage(error);
                console.error('There was an error!', error);
            });
            console.log(id);
      }

    
    // const onOnclickHandler = () => {
    //   setID(IDInput.current.value);
    // };
    // useEffect(() => {
    //     // DELETE request using fetch with error handling
    //     fetch(`https://localhost:44363/Produkts?id=${id}`, { method: 'DELETE' })
    //         .then(async response => {
    //             const data = await response.json();
    
    //             // check for error response
    //             if (!response.ok) {
    //                 // get error message from body or default to response status
    //                 const error = (data && data.message) || response.status;
    //                 return Promise.reject(error);
    //             }
    
    //             setStatus('Delete successful');
    //         })
    //         .catch(error => {
    //             setErrorMessage(error);
    //             console.error('There was an error!', error);
    //         });
    // }, [id]);


    
    return (
        <div>
            <h1>Delete Produkt</h1>
            {/* <input placeholder="Søge efter member med ID" onChange={e => setID(e.target.value)} /> */}
            
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
        {/* <h1> {status} </h1> */}
            {/* <button onClick={onOnclickHandler}>Click Here</button> */}
          {/* <Produkts />  */}
        </div>
    )
}

export default ProduktDelete



// https://localhost:44363/Produkts?id=9