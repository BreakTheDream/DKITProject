import { Component, OnInit } from '@angular/core';
import { StatesDispatcher } from './../../../states-store/states.dispatcher';
import { StatesStore } from './../../../states-store/states.store';
import { Router } from '@angular/router';

@Component({
  selector: 'app-administration-menu',
  templateUrl: './administration-menu.component.html',
  styleUrls: ['./administration-menu.component.css']
})
export class AdministrationMenuComponent implements OnInit {

  constructor(
    private states: StatesStore,
    private statesDispatcher: StatesDispatcher,
    private router: Router
  ) { }

  menuStates = {
    speciality: () => this.statesDispatcher.setIsSpecialityMenuItemOpened(!this.states.isSpecialityMenuItemOpened.state)
  }

  ngOnInit() {
  }

  menuItemOpen(state: string) {
    this.menuStates[state]();
  }

  create() {
    this.router.navigate(['administration/specialities/card', 'create']);
  }

}
