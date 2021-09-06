import React from 'react';
import { Table } from 'reactstrap';

const Produkter = (props) => {
  console.log("INside list")
  console.log(props.Produktss)
  // const [Produkt, setBooks] = useState([]);
 // <- you may need to put the setBooks function in this array
  // setBooks(props);

  if (props.Produktss) {
    return (
      <div>
        <Table>
        <thead>
                 <tr>
                   <th>ID</th>
                   <th>Produkt Name</th>
                   <th>Price</th>
                 </tr>
               </thead>
               <tbody>
                  {props.Produktss.map(product => (
                    
                    <tr>
                   <th key={product.productID} scope="row">{ product.productID }</th>
                   <td>{product.name}</td>
                   <td>{product.price}</td>
                    {/* <h1 key={index} scope="row">{ product.productID }</h1> */}
                 </tr>
                    ))}
               </tbody>

        </Table>
        </div>
    )

  } else {
    return (
      // <div></div>

      
        <div>
          <h1>Loading</h1>          
        </div>
      
          
    //   <div>
    //   {Produkt.map((product, index) => (
    //     <div>
    //     <h1 key={index} scope="row">{ product.productID }</h1>
    //     <h2>{product.name}</h2>
    //     <h2>{product.price}</h2>
    //     </div>
    //     ))}
    // </div>
    //    <Table>
    //    <thead>
    //      <tr>
    //        <th>ID</th>
    //        <th>Produkt Name</th>
    //        <th>Price</th>
    //      </tr>
    //    </thead>
    //    <tbody>
    //    {props.Produkts.map((product, index) => (
    //      <tr>
    //        <th key={index} scope="row">{ product.productID }</th>
    //        <td>{product.name}</td>
    //        <td>{product.price}</td>
    //      </tr>
    //         ))}
    //    </tbody>
    //  </Table>
      

    )
  }
    
  }

export default Produkter
