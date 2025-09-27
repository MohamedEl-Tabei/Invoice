import { Injectable, signal, Signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {
  public isLoading = signal(false)
  show(){
    this.isLoading.set(true);
  }
  hide(){
    this.isLoading.set(false);
  }
}
