import {useState} from 'react'
import './App.css'

function App() {
    const [data, setData] = useState("")

    const handleLoadClick = () => {
        fetch('http://localhost:2323/api/Docker')
            .then(data => data.json())
            .then(json => setData(json.message));
    }

    return (<>
            <div>
                <p>{data}</p>
                <button onClick={handleLoadClick}>Загрузить</button>
            </div>
        </>)
}

export default App
