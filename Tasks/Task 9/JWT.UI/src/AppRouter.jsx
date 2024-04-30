import React, {useState} from 'react';
import {Route, Routes} from "react-router-dom";
import {adminRoutes, notAuthRoutes, userRoutes} from "./routes.js";
import {getUserName, getUserRole} from "./functions/getUserData.js";
import {observer} from "mobx-react-lite";

const AppRouter = observer(() => {
    const [user, setUser] =  useState(null);

    if(localStorage.getItem("accessToken")?.length > 0 && user == null) {
        let accessToken = localStorage.getItem("accessToken");
        setUser({
            name: getUserName(accessToken),
            role: getUserRole(accessToken)
        })
    }

    console.log(user);

    return (
        <Routes>
            {
                user?.role === "Admin" && adminRoutes.map(({path, Component}) => (
                    <Route path={path} element={<Component/>} key={path}/>))
            }
            {
                user?.role === "User" && userRoutes.map(({path, Component}) => (
                    <Route path={path} element={<Component/>} key={path}/>))
            }
            {
                user == null && notAuthRoutes.map(({path, Component}) => (
                <Route path={path} element={<Component/>} key={path}/>))
            }
        </Routes>
    );
});

export default AppRouter;