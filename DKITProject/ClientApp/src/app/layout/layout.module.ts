import { NgModule } from "@angular/core";
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { LoginFormComponent } from './components/login-form/login-form.component';
import { MenuComponent } from './components/menu/menu.component';
import { HeaderComponent } from './../layout/components/header/header.component';

@NgModule({
    declarations: [
        HeaderComponent,
        MenuComponent,
        LoginFormComponent
    ],
    imports: [
        RouterModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        ReactiveFormsModule
    ],
    exports: [
        HeaderComponent,
        MenuComponent,
        LoginFormComponent
    ]
})

export class LayoutModule {}