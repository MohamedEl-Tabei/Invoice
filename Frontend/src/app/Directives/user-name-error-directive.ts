import { Directive, ElementRef, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { Constants } from '../Constants';
import { Util } from '../util';
import { Subscription } from 'rxjs';

@Directive({
  selector: '[appUserNameErrore]'
})
export class UserNameErrorDirective {
  @Input({ required: true }) userNameControl!: AbstractControl | null
  private subStatus?: Subscription
  constructor(private ref: ElementRef) { }
  ngOnInit() {
    this.subStatus = this.userNameControl?.statusChanges.subscribe(() => this.updateMessage())
  }
  updateMessage() {
    const errors = this.userNameControl?.errors;
    let message = ""
    if (errors) {
      if (errors['required']) message = "Name is required"
      else if (errors['minlength']) message = "Name must be 3 or more characters"
      else if (errors['pattern']) message = "Name must start with letter"
      else if (errors['apiError']) message = errors['apiError'];
      Util.setInvalid(message, this.ref)
    }
    else Util.setValid("name", this.ref)
  }
  ngOnDestroy() {
    this.subStatus?.unsubscribe()
  }

}
