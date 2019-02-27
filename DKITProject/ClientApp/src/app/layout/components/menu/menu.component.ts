import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  @Input()
  menuActive: boolean;

  testMenuState: boolean = false;

  test() {
    this.testMenuState = !this.testMenuState;
    console.log(this.testMenuState);
  }

  constructor() { }

  ngOnInit() {
  }

}
