import { Component, OnInit } from '@angular/core';
import { StatesStore } from './../../../states-store/states.store';
import { AuthService } from './../../../services/auth.service';
import { Router } from '@angular/router';
import { StatesDispatcher } from '../../../states-store/states.dispatcher';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.css']
})
export class UserMenuComponent implements OnInit {

  constructor(
    private states: StatesStore,
    private statesDispatcher: StatesDispatcher,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  goAdminPanel() {
    this.statesDispatcher.setIsUserMenuOpened(!this.states.isUserMenuOpened.state);
    this.router.navigate(['administration']);
  }

  logOut() {
    this.authService.logOut();
  }

}
