import { useState, useEffect } from 'react';

function Member() {
    const [members, setmebers] = useState(null);

    useEffect(() => {
        getData();
    
        // we will use async/await to fetch this data
        async function getData() {
          const res = await fetch("https://localhost:44363/Member");
          const data = await res.json();
    
          // store the data into our books variable
          setmebers(data) ;
        }
      }, []);

    return (
        <div>
            
        </div>
    )
}

export default Member
