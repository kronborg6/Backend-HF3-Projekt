import React, {useState} from 'react'
import { Button, Form, FormGroup, Label, Input, Card, Container, Row, Col } from 'reactstrap';

//css Style
import './ProduktStyle.css'

function ProduktPut(props) {
    const [id, setID] = useState();
    const [pName, setName] = useState();
    const [pPrice, setPrice] = useState();

    // const [Edata, setData] = useState({
    //     productID: '',
    //     name: '',
    //     price: ''
    // })
    
    function submit(e) {
        e.preventDefault();
    
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ 
                productID: id,
                name: pName,
                price: pPrice
            })
        };
        props.PutData(requestOptions);
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
                            <Label for="gg">Produkt Name</Label>
                            <Input onChange={e => setID(e.target.value)} id="productID" placeholder="Produkt Name" type="number" />
                            {/* <Input onChange={(e) => handle(e)} id="productID" value={Edata.productID} placeholder="Produkt Name" type="number" /> */}
                        </FormGroup>
                        <FormGroup>
                            <Label for="df">Produkt Name</Label>
                            <Input onChange={e => setName(e.target.value)} id="name" placeholder="Produkt Name" type="text" />
                            {/* <Input onChange={(e) => handle(e)} id="name" value={Edata.name} placeholder="Produkt Name" type="text" /> */}
                        </FormGroup>
                        <FormGroup>
                            <Label for="dfs">Price</Label>
                            <Input onChange={e => setPrice(e.target.value)} id="price" placeholder="Price" type="number" />
                            {/* <Input onChange={(e) => handle(e)} id="price" value={Edata.price} placeholder="Price" type="number" /> */}
                        </FormGroup>
                        <br />
                        <Button>Submit</Button>
                    </Form>
                </Card>
                </Col>
                <Col xs="15">
                </Col>
            </Row>
            {/* } */}
    </Container>
    )
}

export default ProduktPut
