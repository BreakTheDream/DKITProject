import { Injectable } from "@angular/core";
import { StateProvider } from './state.provider';


@Injectable()
export class StatesStore {
    readonly isMenuOpened = new StateProvider<boolean>(null);
    readonly isLoginFormOpened = new StateProvider<boolean>(null);
    readonly isLogin = new StateProvider<boolean>(null);
    readonly isAdmin = new StateProvider<boolean>(null);
    readonly isAuthFailed = new StateProvider<boolean>(null);
    readonly isUserName = new StateProvider<string>(null);

    public clear() {
        this.isMenuOpened.state = null;
        this.isLoginFormOpened.state = null;
        this.isLogin.state = null;
        this.isAdmin.state = null;
        this.isAuthFailed.state = null;
    }
}