import './App.css'
import {GoogleOAuthProvider} from "@react-oauth/google";
import React, {useEffect, useState} from "react";
import {getData} from "./functions/jwt.js";

const clientId = '366951962313-gkbuvo071lek2rcnjhvn92lip2229864.apps.googleusercontent.com';

function App() {
    const [isLoginedUser, setIsLoginedUser] = useState(localStorage.getItem('accessToken') ? localStorage.getItem('accessToken') : false)
    const urlParams = new URLSearchParams(window.location.search);
    const code = urlParams.get('code')
    console.log(clientId);

    useEffect(() => {
        if(code){
            console.log(code);
            fetch("https://localhost:44332/api/OAuth/GetAccessToken", {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({code: code}),
            })
                .then(x => x.json())
                .then(x => {
                    console.log(x);
                    localStorage.setItem('accessToken', x.accessToken)})
                .then(x => {
                    fetch("https://localhost:44332/api/OAuth/GetIdentityToken", {
                        method: "POST",
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify({accessToken: localStorage.getItem("accessToken")})
                    }).then(x => x.json())
                        .then(x => {
                            console.log(x);
                            console.log(x.identityToken);
                        localStorage.setItem("identityToken", x.identityToken)
                        setIsLoginedUser(true);
                    })
                });
        }
    }, []);


    const handleLogoutSuccess = () => {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('identityToken');
        setIsLoginedUser(false);
    };

    return (
        <>
        <GoogleOAuthProvider clientId={clientId}>
            <div>
                {!isLoginedUser ? (
                    <a href={`https://accounts.google.com/o/oauth2/v2/auth?client_id=${clientId}&access_type=offline&response_type=code&scope=openid profile email&redirect_uri=http://localhost:5173/`}>ВОЙТИ НАХУЙ В ГУГЛ, БРО</a>
                ) : (
                    <div>
                        <p>Вы вошли как: {getData("name")}</p>
                        <img src={getData("picture")} alt="Google avatar" /><br/>
                        <button onClick={handleLogoutSuccess}>
                           Exit
                        </button>
                    </div>
                )}
            </div>
        </GoogleOAuthProvider>
        </>
    );
}

export default App
