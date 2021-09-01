import React from 'react';
import { Table } from 'reactstrap';

class GetProdukts extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            Produkts:[]
        };
    }
    componentDidMount() {
        fetch("https://localhost:44363/Produkts").then(res=>res.json()).then(
            result => {
                this.setState({Produkts:result});
            }
        )
    }

    render() {
        return (
                  <Table>
                  <thead>
                    <tr>
                      <th>ID</th>
                      <th>Produkt Name</th>
                      <th>Price</th>
                    </tr>
                  </thead>
                  <tbody>
                  {this.state.Produkts.map(emp=>(
                    <tr>
                        <th scope="row">{emp.productID}</th>
                        <td>{emp.name}</td>
                        <td>{emp.price}</td>
                    </tr>
                    ))}
                  </tbody>
                </Table>
        );
    }
}


export default GetProdukts;