import { Directive, ElementRef, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { Constants } from '../Constants';
import { Util } from '../util';
import { Subscription } from 'rxjs';

@Directive({
  selector: '[appEmailError]'
})
export class EmailErrorDirective {
  @Input({ required: true }) emailControl!: AbstractControl | null
  private subStatus?: Subscription
  constructor(private ref: ElementRef) { }
  ngOnInit() {
    this.subStatus = this.emailControl?.statusChanges.subscribe(() => this.updateMessage())
  }
  updateMessage() {
    const errors = this.emailControl?.errors;
    let message = ""
    if (errors) {
      if (errors['required']) message = "Email is required"
      else if (errors['pattern']) message = "Email is invalid"
      else if (errors['apiError']) message = errors['apiError'];

      Util.setInvalid(message, this.ref)
    }
    else Util.setValid("email", this.ref)
  }
  ngOnDestroy() {
    this.subStatus?.unsubscribe()
  }

}
