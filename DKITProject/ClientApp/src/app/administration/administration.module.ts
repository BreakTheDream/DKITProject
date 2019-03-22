import { NgModule } from "@angular/core";

import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material';

import { AdministrationMenuComponent } from './components/administration-menu/administration-menu.component';
import { AdministrationPanelComponent } from './components/administration-panel/administration-panel.component';
import { AdministrationSpecialityCardComponent } from './components/specialities/administration-speciality-card/administration-speciality-card.component';
import { AdministrationSpecialityGridComponent } from './components/specialities/administration-speciality-grid/administration-speciality-grid.component';

const ROUTES: Routes = [
    { path: 'administration', component: AdministrationPanelComponent, children: [
        { path: 'specialities/card', component: AdministrationSpecialityCardComponent },
        { path: 'specialities/grid', component: AdministrationSpecialityGridComponent }
    ] }
];

@NgModule({
    declarations: [
        AdministrationMenuComponent,
        AdministrationPanelComponent,
        AdministrationSpecialityCardComponent,
        AdministrationSpecialityGridComponent,
    ],
    imports: [
        RouterModule.forChild(ROUTES),
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        ReactiveFormsModule,
        BrowserAnimationsModule,
        MatInputModule
    ],
    exports: [
        AdministrationMenuComponent,
        AdministrationPanelComponent,
        AdministrationSpecialityCardComponent,
    ]
})

export class AdministrationModule {}