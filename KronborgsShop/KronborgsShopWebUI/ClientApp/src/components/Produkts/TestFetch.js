import React from 'react';
import useFetch from './useFetch';
// import './App.css';

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