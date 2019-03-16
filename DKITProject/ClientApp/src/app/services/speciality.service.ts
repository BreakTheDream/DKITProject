import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { AdministrationSpecialityModel, SpecialityModel, SpecialityPreviewModel } from './../models/speciality';
import { API_URLS } from './api-urls';
import { Observable } from 'rxjs';

@Injectable()
export class SpecialityService {

    constructor(
        private http: HttpClient 
    ) { }

    addSpeciality(data: AdministrationSpecialityModel): Observable<boolean> {
        return this.http.post<boolean>(API_URLS.POST_SPECIALITY_URL, data);
    }

    editSpeciality(data: AdministrationSpecialityModel): Observable<boolean> {
        return this.http.put<boolean>(API_URLS.PUT_SPECIALITY_URL, data);
    }

    getSpeciality(id: number): Observable<SpecialityModel> {
        return this.http.get<SpecialityModel>(API_URLS.GET_SPECIALITY_URL + id);
    }

    getSpecialityForEdit(id: number): Observable<AdministrationSpecialityModel> {
        return this.http.get<AdministrationSpecialityModel>(API_URLS.GET_SPECIALITY_FOR_EDIT_URL + id);
    }

    getAllSpecialities(pageNumber: number): Observable<SpecialityPreviewModel[]> {
        return this.http.get<SpecialityPreviewModel[]>(API_URLS.GET_ALL_SPECIALITIES_URL + pageNumber);
    }

    deleteSpeciality(id: number): Observable<boolean> {
        return this.http.delete<boolean>(API_URLS.DELETE_SPECIALITY_URL + id);
    }
}