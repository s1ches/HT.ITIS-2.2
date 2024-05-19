import './App.css'
import {Route, Routes} from "react-router-dom";
import {authRoutes, notAuthRoutes} from "./routes/routes.ts";
//@ts-ignore
import React, {FC, useContext, useEffect, useState} from "react";
import LoginPage from "./pages/login/LoginPage.tsx";
import MainPage from "./pages/main/MainPage.tsx";
import {observer} from "mobx-react-lite";
import {UserContext} from "./main.tsx";
import {isAccessTokenExpired} from "./functions/accessTokenManager.ts";
import {logout} from "./functions/logout.ts";

export const App = observer((() => {
    const userStore = useContext(UserContext);

    useEffect(() => {
        if (isAccessTokenExpired())
            userStore.isAuthorized = false;
        }, []);

    return (
        <>
            {userStore.isAuthorized && <button onClick={() => {
                logout();
                userStore.isAuthorized = false;
            }}>Logout</button>}
            <Routes>
                {
                    !userStore.isAuthorized && notAuthRoutes.map((x: { route: string, page: FC }) => (
                        <Route path={x.route} element={<x.page/>} key={x.route}/>
                    ))
                }
                {
                    userStore.isAuthorized && authRoutes.map((x: { route: string, page: FC }) => (
                        <Route path={x.route} element=<x.page/> key={x.route}/>
                    ))
                }
                {
                    userStore.isAuthorized
                        ? <Route path="*" element=<MainPage/>/>
                        : <Route path="*" element=<LoginPage/>/>
                }
            </Routes>
        </>
    )
}));

export default App
