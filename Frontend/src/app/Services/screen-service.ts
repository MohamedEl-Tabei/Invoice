import { Injectable, signal } from '@angular/core';
import { TTheme } from '../Types/TTheme';
import { Constants } from '../Constants';

@Injectable({
  providedIn: 'root'
})
export class ScreenService {
  public selectThemeSignal = signal<TTheme>(localStorage.getItem('theme') as TTheme || Constants.Theme.light);
}
