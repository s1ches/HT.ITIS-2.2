import {NotificationHub} from "./notificationHub.js";
import {useEffect} from "react";

export const useNotificationHub = () => {
    const connectSocket = () => {
        NotificationHub.createConnection();
    }

    useEffect(() => {
        connectSocket()
    }, []);
}