import { Component, OnInit, Input } from '@angular/core';
import { StatesStore } from './../../../states-store/states.store';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  testMenuState: boolean = false;

  constructor(
    private states: StatesStore,
  ) { }
  
  test() {
    this.testMenuState = !this.testMenuState;
    console.log(this.testMenuState);
  }
  
  ngOnInit() {
  }

}
