import { Component, OnInit } from '@angular/core';
import { StatesDispatcher } from './../../../states-store/states.dispatcher';
import { StatesStore } from './../../../states-store/states.store';

@Component({
  selector: 'app-administration-menu',
  templateUrl: './administration-menu.component.html',
  styleUrls: ['./administration-menu.component.css']
})
export class AdministrationMenuComponent implements OnInit {

  constructor(
    private states: StatesStore,
    private statesDispatcher: StatesDispatcher
  ) { }

  menuStates = {
    speciality: () => this.statesDispatcher.setIsSpecialityMenuItemOpened(!this.states.isSpecialityMenuItemOpened.state)
  }

  ngOnInit() {
  }

  menuItemOpen(state: string) {
    this.menuStates[state]();
  }

}
