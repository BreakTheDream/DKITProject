import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
    selector: 'app-administration-speciality-card',
    templateUrl: './administration-speciality-card.component.html',
    styleUrls: ['./administration-speciality-card.component.css']
})
export class AdministrationSpecialityCardComponent implements OnInit {

    specialityForm: FormGroup;

    constructor() { 
        this.specialityForm = new FormGroup({
            'Name': new FormControl('', Validators.required),
            'Announce': new FormControl('', Validators.required),
            'Content': new FormControl('', Validators.required),
            'ImgIcon': new FormControl(''),
            'ImgPreview': new FormControl('')
        })
    }

    ngOnInit() {
    }

    addSpeciality() {
        console.log(this.specialityForm.getRawValue());
    }

}