import React, {useEffect, useState} from 'react';
import {$authHost} from "../http/index.js";
import {getUserName} from "../functions/getUserData.js";

const User = () => {
    const [message, setMessage] = useState('');

    useEffect(() => {
        $authHost.get("api/Hello/HelloUser")
            .then(response => setMessage(response.data))
    }, []);

    return (
        <div>
            <h1>{message}</h1>
            <h2>Your name is {getUserName(localStorage.getItem("accessToken"))}</h2>
        </div>
    );
};

export default User;