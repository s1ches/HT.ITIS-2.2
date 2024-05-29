import React, {useState} from 'react';
import {
    sendCreateNotificationRequest
} from "../../requests/createNotification/sendCreateNotificationRequest.js";

const CreateNotificationPage = () => {
    const [notificationMessage, setNotificationMessage] = useState('')

    const createNotification = () =>
        sendCreateNotificationRequest(notificationMessage)

    return (
        <div>
            <h1>You can create a notification for all users</h1>
            <div>
                <div>
                    <label>Input notification message: </label><br/>
                    <input type='text' onChange={e => setNotificationMessage(e.target.value)}/>
                </div>
                <div>
                    <button onClick={createNotification} type='button'>Create notification</button>
                </div>
            </div>
        </div>
    );
};

export default CreateNotificationPage;