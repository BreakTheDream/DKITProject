import { Injectable } from "@angular/core";
import { StateProvider } from './state.provider';


@Injectable()
export class StatesStore {
    readonly isMenuOpened = new StateProvider<boolean>(null);
    readonly isLoginFormOpened = new StateProvider<boolean>(null);
    readonly isLogin = new StateProvider<boolean>(null);
    readonly isAdmin = new StateProvider<boolean>(null);
    readonly isUserName = new StateProvider<string>(null);
    readonly isUserMenuOpened = new StateProvider<boolean>(null);
    readonly isSpecialityMenuItemOpened = new StateProvider<boolean>(null);
    readonly isNewMenuItemOpened = new StateProvider<boolean>(null);
    readonly isWorkshopMenuItemOpened = new StateProvider<boolean>(null);
    readonly isAdditionalEducationMenuItemOpened = new StateProvider<boolean>(null);
    readonly isFablabMenuItemOpened = new StateProvider<boolean>(null);
    readonly isLoading = new StateProvider<boolean>(null);
    readonly isNotificationActive = new StateProvider<boolean>(null);
    readonly isErrorMessage = new StateProvider<string>(null);

    public clear() {
        this.isMenuOpened.state = null;
        this.isLoginFormOpened.state = null;
        this.isLogin.state = null;
        this.isAdmin.state = null;
        this.isUserName.state = null;
        this.isUserMenuOpened.state = null;
        this.isSpecialityMenuItemOpened.state = null;
        this.isNewMenuItemOpened.state = null;
        this.isWorkshopMenuItemOpened.state = null;
        this.isAdditionalEducationMenuItemOpened.state = null;
        this.isFablabMenuItemOpened.state = null;
        this.isLoading.state = null;
        this.isNotificationActive.state = null;
        this.isErrorMessage.state = null;
    }
}