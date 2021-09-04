import { useState, useEffect } from 'react';
import { Table } from 'reactstrap';

import Members from './Members';

function Member() {
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [member, setProdukts] = useState([]);
  const [id, setID] = useState(false);


  // Note: the empty deps array [] means
  // this useEffect will run once
  // similar to componentDidMount()
  useEffect(() => {
    fetch(`https://localhost:44363/Member/${id}`)
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
  }, );

  if (error) {
    return <div>Error: {error.message}</div>;
  } else if (!isLoaded) {
    return <div>Loading...</div>;
  } else {
   if (id) {
    return (
      <div>
        <h1>MemberID: {id}</h1>
         <input placeholder="Søge efter member med ID" onChange={e => setID(e.target.value)} />
             <Table>
             <thead>
               <tr>
                 <th>ID</th>
                 <th>Fristname</th>
                 <th>Lastname</th>
                 <th>Mobil</th>
                 <th>Email</th>
               </tr>
             </thead>
             <tbody>
             {member && (
               <tr>
                 <th key={ member.memberID } scope="row">{ member.memberID }</th>
                 <td>{member.fristname}</td>
                 <td>{member.lastname}</td>
                 <td>{member.mobil}</td>
                 <td>{member.email}</td>
                 {/* <td>{member.address.addressID}</td> can't find member's  */}
               </tr>
                  )}
             </tbody>
           </Table>
           </div>
    )

   } else {

    return (
      <div>
        <h1>Member's List</h1>
          <input placeholder="Søge efter member med ID" onChange={e => setID(e.target.value)} />
        <Members />
      </div>
);
   }
  }
}

export default Member
