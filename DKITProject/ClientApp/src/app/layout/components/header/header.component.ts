import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { StatesStore } from './../../../states-store/states.store';
import { StatesDispatcher } from './../../../states-store/states.dispatcher';
import { LocalStorageService } from './../../../services/local-storage.service';
import { AuthService } from './../../../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(
    private states: StatesStore,
    private statesDispatcher: StatesDispatcher,
    private localStorageService: LocalStorageService,
    private authService: AuthService
  ) { }

  menuClick() {
    this.statesDispatcher.setIsMenuOpened(!this.states.isMenuOpened.state);
  }

  openLoginForm() {
    this.statesDispatcher.setIsLoginFormOpened(!this.states.isLoginFormOpened.state);
  }

  openUserMenu() {
    this.statesDispatcher.setIsUserMenuOpened(!this.states.isUserMenuOpened.state);
  }

  ngOnInit() {
    this.checkAccess();
  }

  checkAccess() {
    this.authService.checkAccess().subscribe(data => {
      this.authService.getUser();
    }, error => {
      console.log(error);
    })
  }

}
