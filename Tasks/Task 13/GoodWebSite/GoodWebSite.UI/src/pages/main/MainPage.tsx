// @ts-ignore
import React, {useContext, useState} from 'react';
import {sendGetSecretRequest} from "../../axios/secretRequests.ts";
import {getUserName} from "../../services/userClaimsManager.ts";

const MainPage = () => {
    const [secret, setSecret] = useState('');

    const getSecret = async () => {
        let response = await sendGetSecretRequest();

        setSecret(response.message);
    }

    return (
        <div>
            <h1>Hi, {getUserName()}</h1>
            <h2>Click on then button bellow to get secret info</h2>
            {secret && <><a href={secret}><button>!🤡SUPER SECRET🤡!</button></a><br/><br/></>}
            {!secret && <button type="button" onClick={getSecret}>Get Secret</button>}
        </div>
    );
};

export default MainPage;