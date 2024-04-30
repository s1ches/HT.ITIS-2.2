import React, {useState} from 'react';
import {$host} from "../http/index.js";
import {getUserRole} from "../functions/getUserData.js";
import {useNavigate} from "react-router-dom";

const Register = () => {
    const [name, setName] = useState('');
    const [password, setPassword] = useState('');
    const [role, setRole] = useState('');
    const navigate = useNavigate();

    const login = (e) => {
        e.preventDefault();
        $host.post("api/Auth/Register", {userName: name, password: password, roleNames: [role]})
            .then((response) => {
                if(response.status === 200) {
                    localStorage.setItem("accessToken", response.data.accessToken);
                    if(response.data.roleNames[0] === "User")
                        navigate('/user');
                    else
                        navigate('/admin');
                } else alert("Register failed");
            });
    }

    return (
            <div>
                <input placeholder="User Name" type="text" onChange={e => setName(e.target.value)}/>
                <input type="password" onChange={e => setPassword(e.target.value)}/>
                <select onChange={e => setRole(e.target.value)}>
                    <option value={"User"}>User</option>
                    <option value="Admin">Admin</option>
                </select>
                <input type="submit" value="Log in" onClick={(e) => login(e)}/>
            </div>
    );
};

export default Register;