import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { SpecialityService } from './../../../../services/speciality.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { AdministrationSpecialityModel } from './../../../../models/speciality';
import { StatesDispatcher } from './../../../../states-store/states.dispatcher';
import { StatesStore } from './../../../../states-store/states.store';

@Component({
    selector: 'app-administration-speciality-card',
    templateUrl: './administration-speciality-card.component.html',
    styleUrls: ['./administration-speciality-card.component.css']
})
export class AdministrationSpecialityCardComponent implements OnInit {

    specialityForm: FormGroup;
    imgIconPath: string = '/files/icon_test.png';
    isRequest: boolean = false;
    isEdit: boolean = false;
    selectedId: string;
    entity: AdministrationSpecialityModel;

    constructor(
        private specialityService: SpecialityService,
        private route: ActivatedRoute,
        private statesDispatcher: StatesDispatcher,
        private states: StatesStore
    ) { }

    ngOnInit() {
        this.statesDispatcher.setIsLoading(true);

        this.selectedId = this.route.snapshot.params['id'];
        if(this.selectedId == 'create') {
            this.formReload();
            this.statesDispatcher.setIsLoading(false);
        } else {
            this.isEdit = true;
            this.getSpeciality(+this.selectedId);
        }
    }

    formReload() {
        this.specialityForm = new FormGroup({
            'id': new FormControl(this.entity ? this.entity.id : null),
            'Name': new FormControl(this.entity ? this.entity.name : null, Validators.required),
            'Announce': new FormControl(this.entity ? this.entity.announce : null, Validators.required),
            'Content': new FormControl(this.entity ? this.entity.content : null, Validators.required),
            'ControlNumber': new FormControl(this.entity ? this.entity.controlNumber : null, Validators.required),
            'ControlNumberId': new FormControl(this.entity ? this.entity.controlNumberId : null),
        })
    }

    addSpeciality() {
        this.isRequest = true;
        this.specialityForm.addControl('ImgIcon', new FormControl(this.imgIconPath));
        this.specialityService.addSpeciality(this.specialityForm.getRawValue()).subscribe((response: boolean) => {
            this.isRequest = false;
            this.clear();
        }, error => {
            this.isRequest = false;
            console.log(error);
        });
    }

    getSpeciality(id: number) {
        this.specialityService.getSpecialityForEdit(id).subscribe(resp => {
            this.entity = resp;
            this.imgIconPath = this.entity.imgIcon;
            this.formReload();
            this.statesDispatcher.setIsLoading(false);
        }, error => {
            console.log(error);
        });
    }

    editSpeciality() {
        this.isRequest = true;
        this.specialityForm.addControl('ImgIcon', new FormControl(this.imgIconPath));
        this.specialityService.editSpeciality(this.specialityForm.getRawValue()).subscribe((resp: boolean) => {
            this.isRequest = false;
        }, error => {
            this.isRequest = false;
            console.log(error);
        })

    }

    clear() {
        this.specialityForm.reset();
        this.specialityForm.removeControl('ImgIcon');
    }

}