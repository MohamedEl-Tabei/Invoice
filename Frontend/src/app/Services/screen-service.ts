import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { TTheme } from '../Types/TTheme';
import { Constants } from '../Constants';

@Injectable({
  providedIn: 'root'
})
export class ScreenService {
  public selectTheme$: BehaviorSubject<TTheme> = new BehaviorSubject<TTheme>(localStorage.getItem('theme') as TTheme || Constants.Theme.light);
  public hideNavbar$:BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

}
