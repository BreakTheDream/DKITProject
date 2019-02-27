import { NgModule } from "@angular/core";
import { HeaderComponent } from './../layout/components/header/header.component';
import { RouterModule } from '@angular/router';
import { MenuComponent } from './components/menu/menu.component';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
    declarations: [
        HeaderComponent,
        MenuComponent
    ],
    imports: [
        RouterModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    ],
    exports: [
        HeaderComponent,
        MenuComponent
    ]
})

export class LayoutModule {}