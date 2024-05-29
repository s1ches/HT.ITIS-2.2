import {
    ConnectedSocket,
    MessageBody,
    OnGatewayConnection, OnGatewayDisconnect,
    SubscribeMessage,
    WebSocketGateway
} from "@nestjs/websockets";

@WebSocketGateway({
    cors: {
        origin: '*',

    }
})
export class NotificationHub implements OnGatewayConnection, OnGatewayDisconnect{
    static clients: any[] = [];

    handleDisconnect(client: any) {
        NotificationHub.clients = NotificationHub.clients.filter(x => x.id !== client.id);
        console.log('Disconnected client');
    }

    handleConnection(client: any): any {
        console.log(`Joined client`)
        NotificationHub.clients.push(client);
    }

    @SubscribeMessage('create-notification')
    handleCreateNotification(@MessageBody() createNotificationDto: any, @ConnectedSocket() client: any, ...args: any[]): any {
        const clientsToSend = NotificationHub.clients.filter(x => x.id !== client.id);

        console.log(createNotificationDto);

        for(let i = 0; i < clientsToSend.length; i++){
            clientsToSend[i].emit('new-notification', createNotificationDto);
        }
    }
}