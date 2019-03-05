import { Injectable } from "@angular/core";

@Injectable()
export class LocalStorageService {

    setUser(data: any) {
        localStorage.setItem('access_token', data['access_token']);
        localStorage.setItem('user_name', data['user_name']);
        localStorage.setItem('role', data['role']);
    }

    getRole() {
        return localStorage.getItem('role');
    }

    getAccessToken() {
        return localStorage.getItem('access_token');
    }

    getUserName() {
        return localStorage.getItem('user_name');
    }

    userClear() {
        localStorage.clear();
    }

}