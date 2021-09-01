import React, { useState, useEffect } from "react";
import { Spinner } from 'reactstrap';
// import useFetch from "react-fetch-hook";

export default function Test() {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetch("https://localhost:44363/Produkts")
            .then((response) => {
            if (response.ok) {
                return response.json();
            }
            throw response;
        })
        .catch((error) => {
            console.error("Error fetching data: ", error);
            setError(error);
        })
        .finally(() => {
            setLoading(false);
        });
    }, []);

    if (loading) return (<Spinner color="primary" />);
    if (error) return "Error!";
    return (
        // <>
        //     {/* <img src={data.results[0].picture.medium} alt="random user" /> */}
        //     <pre>{JSON.stringify(data, null, 2)}</pre>
        // </>
        <div>
            {/* {JSON.stringify(data, null, 2)} */}
        </div>
    );
}