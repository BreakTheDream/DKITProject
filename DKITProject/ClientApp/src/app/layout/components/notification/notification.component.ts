import { Component, OnInit } from '@angular/core';
import { StatesStore } from './../../../states-store/states.store';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit {

  get ErrorMessage() {
    return this.states.isErrorMessage.state;
  }

  constructor(
    private states: StatesStore
  ) { }

  ngOnInit() {
  }

}
