import { EventTypes } from './enums/EventTypes';

export class Event {
    id: number;
    headline: string;
    announce: string;
    content: string;
    imgPreview: string;
    datePost: Date;
    dateStart: Date;
    dateEnd: Date;
    count: number;
    eventType: EventTypes;
}

export class EventPreview {
    id: number;
    headline: string;
    announce: string;
    imgIcon: string;
    datePost: Date;
    dateStart: Date;
    dateEnd: Date;
    count: number;
}