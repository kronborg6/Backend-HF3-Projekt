import { useState, useEffect } from 'react';
import { Table } from 'reactstrap';



function Members() {
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [produkts, setProdukts] = useState([]);
  
    // Note: the empty deps array [] means
    // this useEffect will run once
    // similar to componentDidMount()
    useEffect(() => {
      fetch("https://localhost:44363/Member")
        .then(res => res.json())
        .then(
          (result) => {
            setIsLoaded(true);
            setProdukts(result);
          },
          // Note: it's important to handle errors here
          // instead of a catch() block so that we don't swallow
          // exceptions from actual bugs in components.
          (error) => {
            setIsLoaded(true);
            setError(error);
          }
        )
    }, [])
  
    if (error) {
      return <div>Error: {error.message}</div>;
    } else if (!isLoaded) {
      return <div>Loading...</div>;
    } else {
      return (
               <Table>
               <thead>
                 <tr>
                   <th>ID</th>
                   <th>Fristname</th>
                   <th>Lastname</th>
                   <th>Mobil</th>
                   <th>Email</th>
                   <th>AddressID</th>
                   <th>streetName</th>
                   <th>streetNumber</th>
                   <th>postnummerID</th>
                   <th>city</th>
                 </tr>
               </thead>
               <tbody>
               {produkts.map(product => (
                 <tr>
                   <th key={product.memberID} scope="row">{ product.memberID }</th>
                   <td>{product.fristname}</td>
                   <td>{product.lastname}</td>
                   <td>{product.mobil}</td>
                   <td>{product.email}</td>
                   <td>{product.address.addressID}</td>
                   <td>{product.address.streetName}</td>
                   <td>{product.address.streetNumber}</td>
                   <td>{product.address.postnummer.postnummerID}</td>
                   <td>{product.address.postnummer.city}</td>
                 </tr>
                    ))}
               </tbody>
             </Table>
      );
    }
  }
export default Members
