import { BehaviorSubject, Observable, from } from 'rxjs';
import { distinctUntilChanged, skip } from 'rxjs/operators';


export class StateProvider<T extends any> {
    private subject: BehaviorSubject<T>;

    public get state(): T { return this.subject.getValue(); }
    public set state(value: T) { this.subject.next(value); }

    constructor(initialValue?: T) {
        this.subject = new BehaviorSubject<T>(initialValue);
    }

    public get state$(): Observable<T> { return this.subject.asObservable().pipe(distinctUntilChanged()); }
    public get stateChanges$(): Observable<T> { return this.subject.pipe(skip(1), distinctUntilChanged()); }
}