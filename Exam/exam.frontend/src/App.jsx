import './App.css'
import {Route, Routes} from "react-router-dom";
import {routes} from "./routes/routes.js";
import MainPage from "./pages/mainPage/MainPage.jsx";
import React, {useEffect, useState} from "react";
import {routesValues} from "./routes/routesNames.js";
import {useNotificationHub} from "./hubs/notificationHub/useNotificationHub.js";
import {NotificationHub} from "./hubs/notificationHub/notificationHub.js";

function App() {
    useNotificationHub();

    const [notification, setNotification] = useState(null);

    useEffect(() => {
        NotificationHub.socket?.on('new-notification', (e) => {
            console.log('New notification!', e);

            setNotification( e);
        })
    }, []);

    return (
        <>
            {
                notification &&
                <div>
                    <span>{notification.message}</span><br/><br/>
                    <button onClick={() => setNotification(null)}>close</button>
                </div>
            }
            <Routes>
                {
                    routes.map(({routeName, Component}) => {
                    return (
                        <Route path={routeName} element={<Component/>} key={routeName}/>
                    )
                })
            }
            {
                <Route path="*" element={<MainPage/>} key={routesValues.mainPage}/>
            }
        </Routes>
        </>
    )
}

export default App
