import { Component, OnInit } from '@angular/core';
import { MainPageService } from './../../../services/main-page.service';
import { MainPageModel } from './../../../models/mainPageModel';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { StatesStore } from './../../../states-store/states.store';
import { StatesDispatcher } from './../../../states-store/states.dispatcher';

@Component({
    selector: 'app-main-page',
    templateUrl: './main-page.component.html',
    styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

    mainPageInfo: Observable<MainPageModel>;

    constructor(
        private mainPageService: MainPageService,
        private states: StatesStore,
        private statesDispatcher: StatesDispatcher
    ) { }

    ngOnInit() {
        this.getAll();
        this.mainPageInfo.subscribe(resp => {
            this.statesDispatcher.setIsLoading(false);
        });
    }

    getAll() {
        this.statesDispatcher.setIsLoading(true);
        this.mainPageInfo = this.mainPageService.getAll();
    }

}
