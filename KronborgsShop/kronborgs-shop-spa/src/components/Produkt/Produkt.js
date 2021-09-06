import React, { useState } from 'react';
import { Table, Button, Input, InputGroup, InputGroupAddon, InputGroupText, Card, Row, Col } from 'reactstrap';

// import produkts list

function Produkt() {
    const [produkt, setBooks] = useState('');
    const [id, setID] = useState();
    // const IDInput = React.createRef();

    async function getData() {
      
      const res = await fetch(`https://localhost:44363/Produkts/${id}`);
      const data = await res.json();

      // store the data into our books variable
      setBooks(data);
    }


    // const onOnclickHandler = () => {
    //   // setID(IDInput.current.value);
    //   // delay(500);
    //   getData();

    // };


    // if (id) {
    //   return (
    //     <div>
    //       <h1>Produkt {id}</h1>
    //       <div>
    //       {/* <input ref={IDInput} placeholder="Produkt ID"/> */}
    //       <input onChange={e => setID(e.target.value)} placeholder="Produkt ID"/>
    //       <button onClick={getData}>Click Here</button>
    //       </div>
    //            <Table>
    //            <thead>
    //              <tr>
    //                <th>ID</th>
    //                <th>Produkt Name</th>
    //                <th>Price</th>
    //              </tr>
    //            </thead>
    //            <tbody>
    //            {produkt && (
    //              <tr>
    //                <th key={ produkt.productID } scope="row">{ produkt.productID }</th>
    //                <td>{produkt.name}</td>
    //                <td>{produkt.price}</td>
    //              </tr>
    //                 )}
    //            </tbody>
    //          </Table>
    //          </div>
    //   )

    // } else {
    //   return (
    //     <div>
    //       <h1>Produkt's List</h1>
    //       <input onChange={e => setID(e.target.value)} placeholder="Produkt ID"/>
    //       {/* <input ref={IDInput} placeholder="Produkt ID"/> */}
    //       <ButtonGroup>
    //       <Button onClick={getData}>Find Product</Button>
    //       </ButtonGroup>
    //       {/* <input placeholder="Produkt ID" onChange={e => setID(e.target.value)} /> */}
    //       <Produkts />
    //     </div>
    //   )
    // }

      return (
        <div>
          <h1>ProduktID: {id}</h1>
          <div>
          {/* <input ref={IDInput} placeholder="Produkt ID"/> */}
          <Row>
                <br />
                <br />
                <Col xs="4">
                <Card>
            <InputGroup>
            <InputGroupAddon addonType="prepend">
          <InputGroupText>ID</InputGroupText>
        </InputGroupAddon>

        <Input onChange={e => setID(e.target.value)} placeholder="Produkt ID"/>
        <Button outline onClick={getData} color="primary">Find Product</Button>

            </InputGroup>
            </Card>
                </Col>
            </Row>
          </div>
               <Table>
               <thead>
                 <tr>
                   <th>ID</th>
                   <th>Produkt Name</th>
                   <th>Price</th>
                 </tr>
               </thead>
               <tbody>
               {produkt && (
                 <tr>
                   <th key={ produkt.productID } scope="row">{ produkt.productID }</th>
                   <td>{produkt.name}</td>
                   <td>{produkt.price}</td>
                 </tr>
                    )}
               </tbody>
             </Table>
             </div>
      )
  }

export default Produkt
