import React from "react";
import './App.css';
import { useDispatch, useSelector } from "react-redux";
import { error, loaded, loading } from "./features/exampleDataSlice.js";
import { getExampleData } from "./axios/getExample.js";
import loadingGif from "./assets/loading_gif.gif";

function App() {
    const data = useSelector((state) => state.exampleData.value);
    const dispatch = useDispatch();

    const setExampleData = () => {
        dispatch(loading());
        getExampleData()
        .then(x => x === null ? dispatch(error()) : dispatch(loaded(x)));
    }

    return (
        <div>
            <h1>TODOs</h1>
            <button onClick={setExampleData}>Get Data</button>
            <div>
                {data === "" && <p>Click on the button to load the todos</p>}
                {data === "loading" && <img src={loadingGif} alt="Loading..." />}
                {data.message === "error" && <p>Error occurred</p>}
                {data.message !== "error" && data !== "" && data !== "loading"
                    &&data.map(x => <p key={x.id}>user id: {x.userId} {x.title}
                        {x.completed
                            ? <span style={{ color: "green" }}> Completed</span>
                            : <span style={{ color: "red" }}> Not Completed</span>}</p>)
                }
            </div>
        </div>
    )
}

export default App;
