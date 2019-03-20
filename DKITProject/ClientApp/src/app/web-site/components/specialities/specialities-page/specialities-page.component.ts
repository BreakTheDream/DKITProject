import { Component, OnInit, Input } from '@angular/core';
import { SpecialityPreviewModel } from './../../../../models/speciality';

@Component({
  selector: 'app-specialities-page',
  templateUrl: './specialities-page.component.html',
  styleUrls: ['./specialities-page.component.css']
})
export class SpecialitiesPageComponent implements OnInit {

  @Input()
  entity: SpecialityPreviewModel[];

  constructor() { }

  ngOnInit() {
  }

}
