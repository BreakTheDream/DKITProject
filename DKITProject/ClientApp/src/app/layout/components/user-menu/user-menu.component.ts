import { Component, OnInit } from '@angular/core';
import { StatesStore } from './../../../states-store/states.store';
import { AuthService } from './../../../services/auth.service';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.css']
})
export class UserMenuComponent implements OnInit {

  constructor(
    private states: StatesStore,
    private authService: AuthService
  ) { }

  ngOnInit() {
  }

  logOut() {
    this.authService.logOut();
  }

}
