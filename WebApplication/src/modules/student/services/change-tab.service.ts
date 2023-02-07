import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ChangeTabService {
  public changeTabSubject: Subject<number> = new Subject();
  public index: number

  constructor() {
  }

  setTabIndex(index: number) {
    this.index = index;
    this.changeTabSubject.next(index);
  }
}