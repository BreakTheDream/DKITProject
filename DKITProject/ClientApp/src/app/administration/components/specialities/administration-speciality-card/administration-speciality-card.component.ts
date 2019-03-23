import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { SpecialityService } from './../../../../services/speciality.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { AdministrationSpecialityModel } from './../../../../models/speciality';

@Component({
    selector: 'app-administration-speciality-card',
    templateUrl: './administration-speciality-card.component.html',
    styleUrls: ['./administration-speciality-card.component.css']
})
export class AdministrationSpecialityCardComponent implements OnInit {

    specialityForm: FormGroup;
    imgIconPath: string = '/files/icon_test.png';
    isRequest: boolean = false;
    selectedId: number;
    entity$: Observable<boolean>;

    constructor(
        private specialityService: SpecialityService,
        private route: ActivatedRoute
    ) { 
        this.specialityForm = new FormGroup({
            'Name': new FormControl('', Validators.required),
            'Announce': new FormControl('', Validators.required),
            'Content': new FormControl('', Validators.required),
            'ControlNumber': new FormControl('', Validators.required)
        })
    }

    ngOnInit() {
        this.entity$ = this.route.paramMap.pipe(
            switchMap(param => {
                this.selectedId = +param.get('id');
                return of(true);
            })
        )
        console.log(this.entity$);
    }

    addSpeciality() {
        this.isRequest = true;
        this.specialityForm.addControl('ImgIcon', new FormControl(this.imgIconPath));
        console.log(this.specialityForm.getRawValue());
        this.specialityService.addSpeciality(this.specialityForm.getRawValue()).subscribe((response: boolean) => {
            console.log(response);
            this.isRequest = false;
            this.clear();
        }, error => {
            console.log(error);
        });
    }

    clear() {
        this.specialityForm.reset();
        this.specialityForm.removeControl('ImgIcon');
    }

}