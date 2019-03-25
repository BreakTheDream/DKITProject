import { Component, OnInit } from '@angular/core';
import { SpecialityService } from './../../../../services/speciality.service';
import { Observable } from 'rxjs';
import { SpecialityPreviewModel } from './../../../../models/speciality';
import { StatesDispatcher } from './../../../../states-store/states.dispatcher';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { NotificationService } from './../../../../services/notification.service';

@Component({
    selector: 'app-administration-speciality-grid',
    templateUrl: './administration-speciality-grid.component.html',
    styleUrls: ['./administration-speciality-grid.component.css']
})
export class AdministrationSpecialityGridComponent implements OnInit {

    entity$: Observable<SpecialityPreviewModel[]>;

    constructor(
        private specialityService: SpecialityService,
        private statesDispatcher: StatesDispatcher,
        private _sanitizer: DomSanitizer,
        private router: Router,
        private notificationService: NotificationService
    ) { }

    ngOnInit() {
        this.getAll(1);
        this.entity$.subscribe(() => {
            this.statesDispatcher.setIsLoading(false)
        }, error => {
            this.notificationService.setNotiofication(error.error ? error.error : error.statusText);
            console.log(error);
        });
    }

    getAll(pageNumber: number) {
        this.statesDispatcher.setIsLoading(true);
        this.entity$ = this.specialityService.getAllSpecialities(pageNumber);
    }

    delete(id: number) {
        this.specialityService.deleteSpeciality(id).subscribe(resp => {
            if(resp) {
                this.getAll(1);
            }
        }, error => {
            this.notificationService.setNotiofication(error.error ? error.error : error.statusText);
            console.log(error);
        })
    }

    edit(id: number) {
        this.router.navigate(['administration/specialities/card', id]);
    }

}
