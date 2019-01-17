import { EventTypes } from './enums/EventTypes';

export class Event {
    constructor(
        public id: number,
        public headline: string,
        public announce: string,  
        public content: string,
        public imgPreview: string,
        public datePost: Date,
        public dateStart: Date,
        public dateEnd: Date,
        public count: number,
        public eventType: EventTypes
    ) {}
}

export class EventPreview {
    constructor(
        public id: number,
        public headline: string,
        public announce: string,
        public imgIcon: string,
        public datePost: Date,
        public dateStart: Date,
        public dateEnd: Date,
        public count: number
    ){}
}