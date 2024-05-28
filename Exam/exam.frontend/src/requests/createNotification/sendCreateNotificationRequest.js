import {NotificationHub} from "../../hubs/notificationHub/notificationHub.js";

export const sendCreateNotificationRequest = (notificationMessage, notificationImageUrl) => {
    NotificationHub.socket?.emit('create-notification', {
        message: notificationMessage,
        imageUrl: notificationImageUrl
    });
}