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

  ngOnInit() {
  }

  closeLoginForm() {
      this.statesDispatcher.setIsLoginFormOpened(false);
      this.loginForm.reset();
  }

  login() {
      debugger
      console.log(this.loginForm.getRawValue());
      this.authService.getToken(this.loginForm.getRawValue()).subscribe(data => {
        console.log(data);
        this.authService.checkAccess().subscribe(resp => {
            console.log(resp);
        }, error => {
            console.log(error);
        })
      }, error => {
          console.log(error);
      });
  }

}
