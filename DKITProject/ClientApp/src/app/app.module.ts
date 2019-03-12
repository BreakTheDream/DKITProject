import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { LayoutModule } from './layout/layout.module';
import { WebSiteModule } from './web-site/web-site.module';
import { AdministrationModule } from './administration/administration.module';

import { StatesStore } from './states-store/states.store';
import { StatesDispatcher } from './states-store/states.dispatcher';

import { AppComponent } from './app.component';

import { AuthService } from './services/auth.service';
import { LocalStorageService } from './services/local-storage.service';

import { AuthInterceptor } from './interceptors/auth.interceptor';

// import { AdministrationPanelComponent } from './administration/administration-panel/administration-panel.component';

const ROUTES: Routes = [
    // { path: 'administration', component: AdministrationPanelComponent }
];

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot(ROUTES),
        LayoutModule,
        WebSiteModule,
        AdministrationModule
    ],
    providers: [
        StatesStore,
        StatesDispatcher,
        AuthService,
        LocalStorageService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptor,
            multi: true
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
