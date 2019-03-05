import { Injectable } from "@angular/core";
import { StatesStore } from './states.store';

@Injectable()
export class StatesDispatcher {

    constructor(
        private states: StatesStore
    ) {
        this.states.isMenuOpened.state = false;
        this.states.isLoginFormOpened.state = false;
        this.states.isLogin.state = false;
        this.states.isAdmin.state = false;
    }

    clear() {
        this.states.clear();
    }

    setIsMenuOpened(value: boolean) {
        this.states.isMenuOpened.state = value;
    }

    setIsLoginFormOpened(value: boolean) {
        this.states.isLoginFormOpened.state = value;
    }

    setIsLogin(value: boolean) {
        this.states.isLogin.state = value;
    }

    setIsAdmin(value: boolean) {
        this.states.isAdmin.state = value;
    }

    setIsAuthFailed(value: boolean) {
        this.states.isAuthFailed.state = value;
    }

}