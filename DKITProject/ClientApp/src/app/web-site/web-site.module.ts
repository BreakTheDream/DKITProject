import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';

import { MainPageComponent } from './components/main-page/main-page.component';
import { SpecialtyBlockComponent } from './components/specialties/specialty-block/specialty-block.component';
import { SpecialtiesListComponent } from './components/specialties/specialties-list/specialties-list.component';
import { SpecialtiesPageComponent } from './components/specialties/specialties-page/specialties-page.component';

const ROUTES: Routes = [
    { path: '', component: MainPageComponent },
    { path: 'specialties', component: SpecialtiesPageComponent }
];

@NgModule({
    declarations: [
        MainPageComponent,
        SpecialtyBlockComponent,
        SpecialtiesListComponent,
        SpecialtiesPageComponent
    ],
    imports: [
        RouterModule.forChild(ROUTES),
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    ],
    exports: [
        MainPageComponent,
        SpecialtyBlockComponent,
        SpecialtiesListComponent,
        SpecialtiesPageComponent
    ]
})

export class WebSiteModule {}