import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StatesDispatcher } from './../../../../states-store/states.dispatcher';
import { SpecialityService } from './../../../../services/speciality.service';
import { Observable, of } from 'rxjs';
import { SpecialityModel } from './../../../../models/speciality';
import { tap, map } from 'rxjs/operators';
import { NotificationService } from './../../../../services/notification.service';

@Component({
    selector: 'app-speciality-card',
    templateUrl: './speciality-card.component.html',
    styleUrls: ['./speciality-card.component.css']
})
export class SpecialityCardComponent implements OnInit {

    selectedItem: number;
    entity$: Observable<SpecialityModel>;
    test: SpecialityModel;

    constructor(
        private route: ActivatedRoute,
        private statesDispatcher: StatesDispatcher,
        private specialityService: SpecialityService,
        private notificationService: NotificationService
    ) { }

    ngOnInit() {
        this.selectedItem = this.route.snapshot.params['id'];

        this.getSpeciality(this.selectedItem);

        this.entity$.subscribe(() => {
            this.statesDispatcher.setIsLoading(false)
        }, error => {
            this.notificationService.setNotiofication(error.error ? error.error : error.statusText);
            console.log(error);
        })
    }

    getSpeciality(id: number) {
        this.statesDispatcher.setIsLoading(true);
        this.entity$ = this.specialityService.getSpeciality(id);
    }

}
