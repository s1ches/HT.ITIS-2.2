import './App.css'
import {useState} from "react";
import {$host} from "./axios/mainAxios.ts";

const App = () => {
    const [userSecret, setUserSecret] =
        useState<string | undefined>(undefined);

    const getUserSecret = async () => {
        const response = await $host.get('api/Secret/GetSecret');

        setUserSecret(response.data.secretMessage);
    };

    return (
      <div>
          <div>
              <h1>Нажми на кнопку ниже и получи выигрыш в 500000 млн рублей</h1>
              <button onClick={getUserSecret}>🤡</button>
          </div>
          {userSecret && <h1>ЛОХ: YOUR SECRET {userSecret}</h1>}
      </div>
    );
}

export default App
