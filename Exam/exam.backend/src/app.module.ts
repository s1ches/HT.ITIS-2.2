import { Module } from '@nestjs/common';
import {NotificationHub} from "./hubs/notificationHub";

@Module({
  imports: [],
  controllers: [],
  providers: [NotificationHub],
})
export class AppModule {}
