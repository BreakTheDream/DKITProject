import { Component, OnInit } from '@angular/core';
import { MainPageService } from './../../../services/main-page.service';
import { MainPageModel } from './../../../models/mainPageModel';
import { Observable } from 'rxjs';
import { StatesStore } from './../../../states-store/states.store';
import { StatesDispatcher } from './../../../states-store/states.dispatcher';
import { NotificationService } from './../../../services/notification.service';

@Component({
    selector: 'app-main-page',
    templateUrl: './main-page.component.html',
    styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

    mainPageInfo$: Observable<MainPageModel>;

    constructor(
        private mainPageService: MainPageService,
        private states: StatesStore,
        private statesDispatcher: StatesDispatcher,
        private notificationService: NotificationService
    ) { }

    ngOnInit() {
        this.getAll();
        this.mainPageInfo$.subscribe(resp => {
            this.statesDispatcher.setIsLoading(false);
        }, error => {
            this.notificationService.setNotiofication(error.error ? error.error : error.statusText);
            console.log(error);
        });
    }

    getAll() {
        this.statesDispatcher.setIsLoading(true);
        this.mainPageInfo$ = this.mainPageService.getAll();
    }

}
