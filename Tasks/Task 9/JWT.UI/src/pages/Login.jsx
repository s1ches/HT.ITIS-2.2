import React, {useState} from 'react';
import {$host} from "../http/index.js";
import {useNavigate} from "react-router-dom";
import { getUserRole} from "../functions/getUserData.js";

const Login = () => {
    const [name, setName] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const login = (e) => {
        e.preventDefault();
        $host.post("api/Auth/login", {userName: name, password: password})
            .then((response) => {
               if(response.status === 200) {
                   localStorage.setItem("accessToken", response.data.accessToken);
                   if(response.data.roleNames[0] === "User")
                        navigate('/user');
                   else
                       navigate('/admin');
               } else alert("Login failed");
            });
    }

    return (
        <div>
            <input placeholder="User Name" type="text" onChange={e => setName(e.target.value)} />
            <input type="password" onChange={e => setPassword(e.target.value)}/>
            <input type="submit" value="Log in" onClick={(e) => login(e)} />
        </div>
    );
};

export default Login;