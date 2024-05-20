// @ts-ignore
import React, {useContext, useState} from 'react';
import {useNavigate} from "react-router-dom";
import {routesValues} from "../../routes/routesValues.ts";
import {sendRegisterRequest} from "../../axios/authRequests.ts";
import {PostRegisterDto} from "../../dtos/auth/register/postRegisterDto.ts";
import {UserContext} from "../../main.tsx";

const RegisterPage = () => {
    const [userName, setUserName] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const userContext = useContext(UserContext);
    const navigate = useNavigate();

    const register = async () => {
        const dto = PostRegisterDto.create(userName, password);
        await sendRegisterRequest(dto);
        userContext.isAuthorized = true;

        navigate(routesValues.main);
    }

    return (
        <div>
            <label>User Name</label><br/>
            <input type="text"
                   onChange={(event) => setUserName(event.target.value)}
                   value={userName}
                   placeholder="User name"/><br/><br/><br/>
            <label>Password</label><br/>
            <input type="password"
                   onChange={(event) => setPassword(event.target.value)}
                   value={password}
                   placeholder="Password"/><br/><br/><br/>
            <button type="button" onClick={register}>Register</button>
            <br/><br/>
            <a href={routesValues.login}>Already have an account?</a>
        </div>
    );
};

export default RegisterPage;