// @ts-ignore
import React, {FC, useContext, useEffect, useState} from 'react';
import {routesValues} from "../../routes/routesValues.ts";
import {PostLoginDto} from "../../dtos/auth/login/postLoginDto.ts";
import {sendLoginRequest} from "../../axios/authRequests.ts";
import {UserContext} from "../../main.tsx";

const LoginPage: FC = () => {
    const [userName, setUserName] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [isPersistent, setIsPersistent] = useState<boolean>(false);
    const userStore = useContext(UserContext);

    const login = async () => {
        const dto = PostLoginDto.create(userName, password, isPersistent);
        await sendLoginRequest(dto);
        userStore.isAuthorized = true;
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
            <label>Remember Me?</label>
            <input type="checkbox" onChange={_ => setIsPersistent(!isPersistent)}/>
            <br/><br/>
            <button type="button" onClick={login}>Login</button>
            <br/><br/>
            <a href={routesValues.register}>Have no account?</a>
        </div>
    );
};

export default LoginPage;