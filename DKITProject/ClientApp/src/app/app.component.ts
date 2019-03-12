import { Component } from '@angular/core';
import { StatesStore } from './states-store/states.store';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {

    constructor(
        private states: StatesStore
    ) {}

}
