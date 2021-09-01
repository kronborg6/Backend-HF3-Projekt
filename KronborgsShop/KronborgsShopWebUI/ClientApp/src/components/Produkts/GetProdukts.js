import React from 'react';

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
            <div>
                <h2>Kronborg's Produkts</h2>
                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Name</th>
                            <th>Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.Produkts.map(emp=>(
                            <tr key={emp.productID}>
                                <td>{emp.productID}</td>
                                <td>{emp.name}</td>
                                <td>{emp.price}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }
}


export default GetProdukts;