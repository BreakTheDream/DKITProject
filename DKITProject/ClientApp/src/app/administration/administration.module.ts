import { NgModule } from "@angular/core";

import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material';

import { AdministrationMenuComponent } from './administration-menu/administration-menu.component';
import { AdministrationPanelComponent } from './administration-panel/administration-panel.component';
import { AdministrationTestComponent } from './administration-test/administration-test.component';

const ROUTES: Routes = [
    // { path: 'administration/test', component: AdministrationTestComponent }
    { path: 'administration', component: AdministrationPanelComponent, children: [
        { path: 'test', component: AdministrationTestComponent  }
    ] }
];

@NgModule({
    declarations: [
        AdministrationMenuComponent,
        AdministrationPanelComponent,
        AdministrationTestComponent
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
        AdministrationTestComponent
    ]
})

export class AdministrationModule {}