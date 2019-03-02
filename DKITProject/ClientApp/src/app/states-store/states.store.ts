import { Injectable } from "@angular/core";
import { StateProvider } from './state.provider';


@Injectable()
export class StatesStore {
    readonly isMenuOpened = new StateProvider<boolean>(null);
    readonly isLoginFormOpened = new StateProvider<boolean>(null);

    public clear() {
        this.isMenuOpened.state = null;
        this.isLoginFormOpened.state = null;
    }
}