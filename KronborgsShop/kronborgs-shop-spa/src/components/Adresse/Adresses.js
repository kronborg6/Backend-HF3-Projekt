import { useState, useEffect } from 'react';
import { Table } from 'reactstrap';



function Addresses() {
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [address, setAddress] = useState([]);
  
    // Note: the empty deps array [] means
    // this useEffect will run once
    // similar to componentDidMount()
    useEffect(() => {
      fetch("https://localhost:44363/Address")
        .then(res => res.json())
        .then(
          (result) => {
            setIsLoaded(true);
            setAddress(result);
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
                   <th>streetName</th>
                   <th>streetNumber</th>
                   <th>postnummerID</th>
                   <th>city</th>
                 </tr>
               </thead>
               <tbody>
               {address.map(addres => (
                 <tr>
                   <th key={addres.addressID} scope="row">{ addres.addressID }</th>
                   <td>{addres.streetName}</td>
                   <td>{addres.streetNumber}</td>
                   <td>{addres.postnummer.postnummerID}</td>
                   <td>{addres.postnummer.city}</td>

                 </tr>
                    ))}
               </tbody>
             </Table>
      );
    }
  }
export default Addresses
