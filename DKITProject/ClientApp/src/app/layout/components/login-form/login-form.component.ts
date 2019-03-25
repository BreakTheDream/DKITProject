import { Component, OnInit } from '@angular/core';
import { StatesStore } from './../../../states-store/states.store';
import { StatesDispatcher } from './../../../states-store/states.dispatcher';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from './../../../services/auth.service';
import { NotificationService } from './../../../services/notification.service';

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
      private authService: AuthService,
      private notificationService: NotificationService
  ) { 
      this.loginForm = new FormGroup({
          'Login': new FormControl('', Validators.required),
          'Password': new FormControl('', Validators.required)
      })
  }

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
            this.isSubmitDisabled = false;
            this.statesDispatcher.setIsLoginFormOpened(false);
            this.authService.getUser();
        }, error => {
            console.log(error);
            this.isSubmitDisabled = false;
            this.notificationService.setNotiofication(error.error ? error.error : error.statusText);
            this.authService.logOut();
        })
      }, error => {
          console.log(error);
          this.isSubmitDisabled = false;
          this.notificationService.setNotiofication(error.error ? error.error : error.statusText);
      });
  }

}
