import { useState, useEffect } from 'react';

function Produkt() {
    const [Book, setBooks] = useState('');
  
    // + adding the use
    useEffect(() => {
      getData();
  
      // we will use async/await to fetch this data
      async function getData() {
        const res = await fetch("https://localhost:44363/Produkts/1");
        const data = await res.json();
  
        // store the data into our books variable
        setBooks(data);
      }
    },); // <- you may need to put the setBooks function in this array
  
    return (
        <div>
        <h1>Game of Thrones Books</h1>
    
        {/* display books from the API */}
        {Book && (
          <div>
    
            {/* loop over the books */}
            <p>{ Book.name }</p>
    
          </div>
        )}
      </div>
    )
  }

export default Produkt
