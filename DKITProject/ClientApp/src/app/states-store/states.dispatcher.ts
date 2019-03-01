import { Injectable } from "@angular/core";
import { StatesStore } from './states.store';

@Injectable()
export class StatesDispatcter {

    constructor(
        private states: StatesStore
    ) {
        this.states.isMenuOpened.state = false;
    }

    clear() {
        this.states.clear();
    }

    setIsMenuOpened(value: boolean) {
        this.states.isMenuOpened.state = value;
    }
}