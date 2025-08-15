import { Directive, ElementRef, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { Constants } from '../Constants';
import { Subscription } from 'rxjs';
import { Util } from '../util';

@Directive({
  selector: '[appConfirmPasswordError]'
})
export class ConfirmPasswordErrorDirective {
  @Input({ required: true }) confirmPasswordControl!: AbstractControl | null
  @Input({ required: true }) passwordControl!: AbstractControl | null
  subPasswordStatus?: Subscription
  subConfirmPasswordStatus?: Subscription
  constructor(private ref: ElementRef) { }
  ngOnInit() {
    this.subConfirmPasswordStatus = this.confirmPasswordControl?.statusChanges.subscribe(() => this.updateMessage())
    this.subPasswordStatus = this.passwordControl?.statusChanges.subscribe(() => this.updateMessage())
  }
  updateMessage() {
    const errors = this.confirmPasswordControl?.errors
    const confirmPassword = this.confirmPasswordControl?.value
    const password = this.passwordControl?.value
    let message = ""
    if (errors || password != confirmPassword) {
      if (errors && errors['required']) message = "Confirm Password is required"
      else if (password != confirmPassword) {
        message = "Confirm Password must equal password"
        this.confirmPasswordControl?.setErrors({ notMatch: true })
      }
      else if (errors && errors['notMatch']) {
        this.confirmPasswordControl?.setErrors(null)
        Util.setValid("confirm Password", this.ref)
        return
      }
      Util.setInvalid(message, this.ref)
    }
    else Util.setValid("confirm Password", this.ref)
  }
  ngOnDestroy() {
    this.subConfirmPasswordStatus?.unsubscribe()
    this.subPasswordStatus?.unsubscribe()
  }
}
