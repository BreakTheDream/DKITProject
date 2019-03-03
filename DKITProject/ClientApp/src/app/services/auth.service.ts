import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { API_URLS } from './api-urls';
import { tap } from 'rxjs/operators';
import { LocalStorageService } from './local-storage.service';
import { StatesDispatcher } from './../states-store/states.dispatcher';

@Injectable()
export class AuthService {

    constructor(
        private http: HttpClient,
        private localStorageService: LocalStorageService,
        private statesDispatcher: StatesDispatcher
    ){ }
    
    getToken(data: any) {
        this.http.post(API_URLS.AUTH_URL, data).pipe(
            tap(response => {
                this.localStorageService.setUser(response);
            },
            error => {
                console.log(error);
            }),

        );
    }

    checkAccess() {
        this.http.get(API_URLS.CHECK_ACCESS_URL).pipe(
            tap(response => {
                if(!response) {
                    this.logOut();
                    return;
                }
                this.statesDispatcher.setIsLogin(true);
                let role = this.localStorageService.getRole();
                if(role == 'admin') {
                    this.statesDispatcher.setIsAdmin(true);
                }
            }, 
            error => {
                this.logOut();
                console.log(error);
            })
        )
    }

    logOut() {
        this.localStorageService.userClear();
    }
}