import { Component, OnInit } from '@angular/core';
import { StatesStore } from './../../../states-store/states.store';
import { StatesDispatcher } from './../../../states-store/states.dispatcher';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from './../../../services/auth.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

    loginForm: FormGroup;
    isSubmitDisabled: boolean;

  constructor(
      private states: StatesStore,
      private statesDispatcher: StatesDispatcher,
      private authService: AuthService
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
      this.isSubmitDisabled = true;
      this.authService.getToken(this.loginForm.getRawValue()).subscribe(() => {
        this.authService.checkAccess().subscribe(response => {
            if(!response) {
                this.authService.logOut();
                this.statesDispatcher.setIsAuthFailed(true);
                this.isSubmitDisabled = false;
                return;
            }
            this.isSubmitDisabled = false;
            this.statesDispatcher.setIsLoginFormOpened(false);
            this.authService.getUser();
        }, error => {
            console.log(error);
            this.errorMessage = error.error;
            this.statesDispatcher.setIsAuthFailed(true);
            this.isSubmitDisabled = false;
        })
      }, error => {
          console.log(error);
          this.errorMessage = error.error;
          this.statesDispatcher.setIsAuthFailed(true);
          this.isSubmitDisabled = false;
      });
  }

}
