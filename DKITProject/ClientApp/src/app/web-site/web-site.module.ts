import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { MainPageComponent } from './components/main-page/main-page.component';

const ROUTES: Routes = [
    { path: '', component: MainPageComponent }
];

@NgModule({
    declarations: [
        MainPageComponent
    ],
    imports: [
        RouterModule.forChild(ROUTES),
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    ],
    exports: [
        MainPageComponent
    ]
})

export class WebSiteModule {}