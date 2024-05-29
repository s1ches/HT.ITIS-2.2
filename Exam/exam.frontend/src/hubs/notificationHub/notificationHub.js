import {io} from "socket.io-client";

export class NotificationHub{
    static socket;

    static createConnection(){
        this.socket = io('http://localhost:3000/');

        this.socket.on('connect', (_) => {
            console.log('Connected!');
        });

        this.socket.on('disconnect', (_) => {
            console.log('Disconnected!');
        });
    }
}