import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MainPageModel } from './../models/mainPageModel';
import { API_URLS } from './api-urls';

@Injectable()
export class MainPageService {
    
    constructor(
        private http: HttpClient
    ) { }
    
    getAll(): Observable<MainPageModel> {
        return this.http.get<MainPageModel>(API_URLS.MAIN_PAGE_INFO_URL);
    }

}