import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';

import { MainPageComponent } from './components/main-page/main-page.component';
import { SpecialityBlockComponent } from './components/specialities/speciality-block/speciality-block.component';
import { SpecialitiesPageComponent } from './components/specialities/specialities-page/specialities-page.component';
import { SpecialitiesListComponent } from './components/specialities/specialities-list/specialities-list.component';

const ROUTES: Routes = [
    { path: '', component: MainPageComponent },
    { path: 'specialties', component: SpecialitiesPageComponent }
];

@NgModule({
    declarations: [
        MainPageComponent,
        SpecialityBlockComponent,
        SpecialitiesListComponent,
        SpecialitiesPageComponent
    ],
    imports: [
        RouterModule.forChild(ROUTES),
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    ],
    exports: [
        MainPageComponent,
        SpecialityBlockComponent,
        SpecialitiesListComponent,
        SpecialitiesPageComponent
    ]
})

export class WebSiteModule {}