import { useState, useEffect } from 'react';
import { Table } from 'reactstrap';

function Produkts() {
    const [produkts, setProdukts] = useState([]);
  
    // + adding the use
    useEffect(() => {
      getData();
  
      // we will use async/await to fetch this data
      async function getData() {
        const res = await fetch("https://localhost:44363/Produkts");
        const data = await res.json();
  
        // store the data into our books variable
        setProdukts(data) ;
      }
    }, []); // <- you may need to put the setBooks function in this array
  
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
       {produkts.map((product, index) => (
         <tr>
           <th key={index} scope="row">{ product.productID }</th>
           <td>{product.name}</td>
           <td>{product.price}</td>
         </tr>
            ))}
       </tbody>
     </Table>
      

    )
  }

export default Produkts
