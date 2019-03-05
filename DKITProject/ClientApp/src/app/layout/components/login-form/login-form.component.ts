import { Component, OnInit } from '@angular/core';
import { StatesStore } from './../../../states-store/states.store';
import { StatesDispatcher } from './../../../states-store/states.dispatcher';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from './../../../services/auth.service';
import { map } from 'rxjs/operators';
import { LocalStorageService } from './../../../services/local-storage.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

    loginForm: FormGroup;

  constructor(
      private states: StatesStore,
      private statesDispatcher: StatesDispatcher,
      private authService: AuthService,
      private localStorageService: LocalStorageService
  ) { 
      this.loginForm = new FormGroup({
          'Login': new FormControl('', Validators.required),
          'Password': new FormControl('', Validators.required)
      })
  }

  errorMessage: string;

  ngOnInit() {
  }

  closeLoginForm() {
      this.statesDispatcher.setIsLoginFormOpened(false);
      this.loginForm.reset();
  }

  login() {
      this.authService.getToken(this.loginForm.getRawValue()).subscribe(() => {
        this.authService.checkAccess().subscribe(response => {
            if(!response) {
                this.authService.logOut();
                this.statesDispatcher.setIsAuthFailed(true);
                return;
            }
            this.statesDispatcher.setIsLogin(true);
            this.statesDispatcher.setIsLoginFormOpened(false);
            let role = this.localStorageService.getRole();
            if(role == 'admin') {
                this.statesDispatcher.setIsAdmin(true);
            }
        }, error => {
            console.log(error);
            this.errorMessage = error.error;
            this.statesDispatcher.setIsAuthFailed(true);
        })
      }, error => {
          console.log(error);
          this.errorMessage = error.error;
          this.statesDispatcher.setIsAuthFailed(true);
      });
  }

}
