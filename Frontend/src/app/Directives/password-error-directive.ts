import { Directive, ElementRef, Input } from '@angular/core';
import { AbstractControl, FormControl, ValidationErrors } from '@angular/forms';
import { Constants } from '../Constants';
import { Subscription } from 'rxjs';
import { Util } from '../util';

@Directive({
  selector: '[appPasswordError]'
})
export class PasswordErrorDirective {
  @Input({ required: true }) passwordControl!: AbstractControl | null
  subStatus?: Subscription
  checks: { regex: RegExp; message: string }[] = [
    { regex: /^(?=.*[a-z]).+$/, message: "Password must contain a lowercase letter" },
    { regex: /^(?=.*[A-Z]).+$/, message: "Password must contain an uppercase letter" },
    { regex: /^(?=.*[0-9]).+$/, message: "Password must contain a number" },
    { regex: /^(?=.*[!@#$%^&*(),.?":{}|<>]).+$/, message: "Password must contain a special character" },
  ];
  constructor(private ref: ElementRef) { }
  ngOnInit() {
    this.subStatus = this.passwordControl?.statusChanges.subscribe(() => this.updateMessage())
  }
  updateMessage() {
    const errors = this.passwordControl?.errors
    const password = this.passwordControl?.value
    let message = ""
    if (errors) {
      if (errors['required']) message = "Password is required"
      else if (errors['minlength']) message = "Password must be 8 or more characters"
      else if (errors['pattern']) {
        for (let i = 0; i < this.checks.length; i++) {
          const check = this.checks[i];
          if (!check.regex.test(password)) {
            message = check.message
            break
          }
        }
      }
      else if (errors['apiError']) message = errors['apiError'];

      Util.setInvalid(message, this.ref)
    }
    else Util.setValid("passwrd", this.ref)
  }
  ngOnDestroy() {
    this.subStatus?.unsubscribe()
  }
}
