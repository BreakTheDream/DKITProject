import { Component, OnInit, Input } from '@angular/core';
import { SpecialityPreviewModel } from './../../../../models/speciality';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
    selector: 'app-speciality-block',
    templateUrl: './speciality-block.component.html',
    styleUrls: ['./speciality-block.component.css']
})
export class SpecialityBlockComponent implements OnInit {

    @Input()
    entity: SpecialityPreviewModel;

    imgPath;

    constructor(
        private _sanitizer: DomSanitizer
    ) { }

    ngOnInit() {
        this.imgPath = this._sanitizer.bypassSecurityTrustUrl(this.entity.imgIcon);
    }

}
