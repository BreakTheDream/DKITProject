import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { LayoutModule } from './layout/layout.module';
import { WebSiteModule } from './web-site/web-site.module';

import { AppComponent } from './app.component';

const ROUTES: Routes = [];

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot(ROUTES),
        LayoutModule,
        WebSiteModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
