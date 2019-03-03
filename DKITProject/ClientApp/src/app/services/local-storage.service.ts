import { Injectable } from "@angular/core";

@Injectable()
export class LocalStorageService {

    setUser(data: any) {
        localStorage.setItem('access_token', data['access_token']);
        localStorage.setItem('user_name', data['user_name']);
        localStorage.setItem('user_role', data['user_role']);
    }

    getRole() {
        return localStorage.getItem('user_role');
    }

    userClear() {
        localStorage.clear();
    }

}