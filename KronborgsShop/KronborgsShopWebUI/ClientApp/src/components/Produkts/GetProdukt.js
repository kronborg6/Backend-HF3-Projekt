// import React, { useState } from 'react';
// import { Table, Button, Form, FormGroup, Label, Input } from 'reactstrap';

// function Test() {
//     // const [id, SetID] = useState('');
// };

// class GetProdukt extends React.Component {
//     constructor(props) {
//         super(props);

//         this.state = {
//             Produkts:[],
//             value: ''
//         };
//     }


//     handleChange(event) {
//         this.setState({value: event.target.value});
//       }
//     handleSubmit(event) {
//         alert('A name was submitted: ' + this.state.value);
//         event.preventDefault();
//       }
//     componentDidMount() {
//         fetch("https://localhost:44363/Produkts/").then(res=>res.json()).then(
//             result => {
//                 this.setState({Produkts:[result]});
//             }
//         )
//     }

//     render() {
//         return (
//             <Form inline>
//             <FormGroup className="mb-2 mr-sm-2 mb-sm-0">
//               <Label for="exampleEmail" className="mr-sm-2">Email</Label>
//               <Input type="text" value={this.state.value} onChange={e => Test.SetID(e.target.value)} />
//             </FormGroup>
//             <Button>Submit</Button>
          
//             <Table>
//                 <form onSubmit={this.handleSubmit}>
//                 <label>
//                 <input type="text" value={this.state.value} onChange={e => SetID(e.target.value)} />
//                 <input type="submit" value="Submit" />
//                 </label>
//                 </form>
//             <thead>
//               <tr>
//                 <th>ID</th>
//                 <th>Produkt Name</th>
//                 <th>Price</th>
//               </tr>
//             </thead>
//             <tbody>
//             {this.state.Produkts.map(emp=>(
//               <tr>
//                   <th scope="row">{emp.productID}</th>
//                   <td>{emp.name}</td>
//                   <td>{emp.price}</td>
//               </tr>
//               ))}
//             </tbody>
//           </Table>
//           </Form>
//         );
//     }
// }

// export default GetProdukt;