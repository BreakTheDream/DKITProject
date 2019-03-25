import { Component, OnInit, Input } from '@angular/core';
import { SpecialityPreviewModel } from './../../../../models/speciality';
import { SpecialityService } from './../../../../services/speciality.service';
import { Observable, of } from 'rxjs';
import { StatesDispatcher } from './../../../../states-store/states.dispatcher';
import { NotificationService } from './../../../../services/notification.service';

@Component({
    selector: 'app-specialities-list',
    templateUrl: './specialities-list.component.html',
    styleUrls: ['./specialities-list.component.css']
})
export class SpecialitiesListComponent implements OnInit {

    @Input()
    entity: SpecialityPreviewModel[];
    
    entity$: Observable<SpecialityPreviewModel[]>;

    constructor(
        private specialityService: SpecialityService,
        private statesDispatcher: StatesDispatcher,
        private notificationService: NotificationService
    ) { }

    ngOnInit() {
        if(this.entity) {
            this.entity$ = of(this.entity);
        } else {
            this.getSpecialities(1);
            this.entity$.subscribe(() => {
                this.statesDispatcher.setIsLoading(false);
            }, error => {
                this.notificationService.setNotiofication(error.error ? error.error : error.statusText);
                this.statesDispatcher.setIsLoading(false)
            });
        }
    }

    getSpecialities(pageNumber: number) {
        this.statesDispatcher.setIsLoading(true);
        this.entity$ = this.specialityService.getAllSpecialities(pageNumber);
    }

}
