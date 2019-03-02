import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { StatesStore } from './../../../states-store/states.store';
import { StatesDispatcter } from './../../../states-store/states.dispatcher';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(
    private states: StatesStore,
    private statesDispatcher: StatesDispatcter,
  ) { }

  menuClick() {
    this.statesDispatcher.setIsMenuOpened(!this.states.isMenuOpened.state);
  }

  OpenLoginForm() {
    this.statesDispatcher.setIsLoginFormOpened(!this.states.isLoginFormOpened.state);
  }

  ngOnInit() {
  }

}
