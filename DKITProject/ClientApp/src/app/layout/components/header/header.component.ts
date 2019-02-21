import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @Input()
  menuActive: boolean;

  @Output() menuClicked = new EventEmitter(); 
  menuClick() {
    this.menuClicked.emit();
  }

  constructor() { }

  ngOnInit() {
  }

}
