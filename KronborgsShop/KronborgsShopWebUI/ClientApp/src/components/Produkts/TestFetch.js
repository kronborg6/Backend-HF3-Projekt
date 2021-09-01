import React from 'react';
import useFetch from './useFetch';
import { Table } from 'reactstrap';
// import './App.css';


// class testFetch extends React.Component {
//   constructor(props) {
//       super(props);

//       this.state = {
//           Produkts:[]
//       };
//   }
//   componentDidMount () {
//     this.setState({Produkts:[useFetch('https://localhost:44363/Produkts')]});
//   };


//   return (
      
//   );
// }


function testFetch() {
  const { data: quote, loading, error } = useFetch('https://localhost:44363/Produkts')

  return (
    <div className="testFetch">
      { loading && <p>{loading}</p> }
      { quote && <p>"{quote}"</p> }
      { error && <p>{error}</p> }
    </div>
  );
}
export default testFetch;
