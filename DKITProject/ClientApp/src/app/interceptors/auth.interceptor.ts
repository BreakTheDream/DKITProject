import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest} from '@angular/common/http';
import { LocalStorageService } from './../services/local-storage.service';

@Injectable()

export class AuthInterceptor implements HttpInterceptor {

    constructor(
        private localStorageService: LocalStorageService
    ) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>{
        const mod = req.clone({setHeaders:{'Authorization': `Bearer ${this.localStorageService.getAccessToken()}`}});
        return next.handle(mod);
    }
}