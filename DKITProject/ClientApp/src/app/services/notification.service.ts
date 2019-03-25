import { Injectable } from "@angular/core";
import { StatesDispatcher } from './../states-store/states.dispatcher';

@Injectable()
export class NotificationService {

    constructor(
        private statesDispatcher: StatesDispatcher
    ) { }

    setNotiofication(message: string) {
        this.statesDispatcher.setIsErrorMessage(message);
        this.statesDispatcher.setIsNotificationActive(true);
        setTimeout(() => {
            this.statesDispatcher.setIsNotificationActive(false);
        }, 10000)
    }

}