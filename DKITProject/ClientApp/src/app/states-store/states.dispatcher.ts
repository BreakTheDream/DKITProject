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
        this.states.isUserName.state = '';
        this.states.isUserMenuOpened.state = false;
        this.states.isNewMenuItemOpened.state = false;
        this.states.isWorkshopMenuItemOpened.state = false;
        this.states.isAdditionalEducationMenuItemOpened.state = false;
        this.states.isFablabMenuItemOpened.state = false;
        this.states.isSpecialityMenuItemOpened.state = false;
        this.states.isLoading.state = false;
        this.states.isNotificationActive.state = false;
        this.states.isErrorMessage.state = '';
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

    setUserName(value: string) {
        this.states.isUserName.state = value;
    }

    setIsUserMenuOpened(value: boolean) {
        this.states.isUserMenuOpened.state = value;
    }

    setIsSpecialityMenuItemOpened(value: boolean) {
        this.states.isSpecialityMenuItemOpened.state = value;
    }

    setIsNewMenuItemOpened(value: boolean) {
        this.states.isNewMenuItemOpened.state = value;
    }
    setIsWorkshopMenuItemOpened(value: boolean) {
        this.states.isWorkshopMenuItemOpened.state = value;
    }
    setIsAdditionalEducationMenuItemOpened(value: boolean) {
        this.states.isAdditionalEducationMenuItemOpened.state = value;
    }
    setIsFablabMenuItemOpened(value: boolean) {
        this.states.isFablabMenuItemOpened.state = value;
    }

    setIsLoading(value: boolean) {
        this.states.isLoading.state = value;
    }

    setIsNotificationActive(value: boolean) {
        this.states.isNotificationActive.state = value;
    }

    setIsErrorMessage(value: string) {
        this.states.isErrorMessage.state = value;
    }

}