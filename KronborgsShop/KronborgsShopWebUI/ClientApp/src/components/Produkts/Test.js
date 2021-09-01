import React from "react";
// import { render } from "react-dom";
import useFetch from "react-fetch-hook";


export default function TestFetch() {
  const { isLoading, error, data } = useFetch("https://localhost:44363/Produkts");

  if (isLoading) return "Loading...";
  if (error) return "Error!";

//   render()

  return (
      <div>
            {/* <img src="" alt="random user" /> */}
            <pre>{JSON.stringify(data, null, 2)}</pre>
      </div>

  );
}
