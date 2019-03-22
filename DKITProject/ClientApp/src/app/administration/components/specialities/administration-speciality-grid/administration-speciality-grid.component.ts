import { Component, OnInit } from '@angular/core';
import { SpecialityService } from './../../../../services/speciality.service';
import { Observable } from 'rxjs';
import { SpecialityPreviewModel } from 'src/app/models/speciality';
import { StatesDispatcher } from './../../../../states-store/states.dispatcher';
import { DomSanitizer } from '@angular/platform-browser';

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
        private _sanitizer: DomSanitizer
    ) { }

    ngOnInit() {
        this.getAll(1);
        this.entity$.subscribe(() => this.statesDispatcher.setIsLoading(false));
    }

    getAll(pageNumber: number) {
        this.statesDispatcher.setIsLoading(true);
        this.entity$ = this.specialityService.getAllSpecialities(pageNumber);
    }

}
