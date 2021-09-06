import React, {useState} from 'react'
import { Button, Form, FormGroup, Label, Input, Card, Container, Row, Col } from 'reactstrap';

import './ProduktStyle.css'



function ProduktPost(props) {
    const [data, setData] = useState({
        name: '',
        price: ''
    })

    function submit(e) {
        e.preventDefault();

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ 
                name: data.name,
                price: data.price
             })
        };


            // .then(data => setPostId(data.id));
        // console.log(response)
        props.GetData(requestOptions);
    } 

    function handle(e) {
        const newdata = {...data}
        newdata[e.target.id] = e.target.value
        setData(newdata);
        console.log(newdata);
    }
    return (
        
        <Container>
            {/* <button outline onClick={() => setShowAddTask(!showAddTask)} color="primary">Find Produkt Med ID</button>  */}
            
            {/* {showAddTask && */}
            <Row>
                <br />
                <br />
                <Col xs="3">
                <Card>
                    <Form className="bg" onSubmit={(e) => submit(e)}>
                        <FormGroup>
                            <Label for="ProduktName">Produkt Name</Label>
                            <Input onChange={(e) => handle(e)} id="name" value={data.name} placeholder="Produkt Name" type="text" />
                        </FormGroup>
                        <FormGroup>
                            <Label for="ProduktPrice">Price</Label>
                            <Input onChange={(e) => handle(e)} id="price" value={data.price} placeholder="Price" type="number" />
                        </FormGroup>
                        <br />
                        <Button>Submit</Button>
                    </Form>
                </Card>
                </Col>
            </Row>
            {/* } */}
    </Container>
    )
}

export default ProduktPost