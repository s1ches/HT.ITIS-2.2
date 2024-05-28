import React from 'react';
import {useNavigate} from "react-router-dom";
import {routesValues} from "../../routes/routesNames.js";

const MainPage = () => {
    const navigate = useNavigate();

    return (
        <div>
            <h1>Hello it's main Page!</h1>
            <button onClick={() => navigate(routesValues.imagesPage)}>Go to Funny Images!</button>
            <h2>OR</h2>
            <button onClick={() => navigate(routesValues.createNotificationPage)}>Try to Create Notification</button>
        </div>
    );
};

export default MainPage;