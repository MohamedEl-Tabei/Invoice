import { Directive, ElementRef, Input } from '@angular/core';
import { AbstractControl, FormControl, ValidationErrors } from '@angular/forms';
import { Constants } from '../Constants';

@Directive({
  selector: '[appPasswordError]'
})
export class PasswordErrorDirective {
  @Input({ required: true }) passwordControl!: AbstractControl | null
  checks: { regex: RegExp; message: string }[] = [
    { regex: /^(?=.*[a-z]).+$/, message: "Password must contain a lowercase letter" },
    { regex: /^(?=.*[A-Z]).+$/, message: "Password must contain an uppercase letter" },
    { regex: /^(?=.*[0-9]).+$/, message: "Password must contain a number" },
    { regex: /^(?=.*[!@#$%^&*(),.?":{}|<>]).+$/, message: "Password must contain a special character" },
  ];
  constructor(private ref: ElementRef) { }
  ngOnInit() {
    this.passwordControl?.valueChanges.subscribe(() => this.updateMessage())
  }
  updateMessage() {
    const errors = this.passwordControl?.errors
    const password = this.passwordControl?.value
    if (errors) {
      this.ref.nativeElement.classList.remove(...Constants.ValidationClass.valid)
      this.ref.nativeElement.classList.add(...Constants.ValidationClass.invalid);
      if (errors['required']) this.ref.nativeElement.innerText = "Password is required"
      else if (errors['minlength']) this.ref.nativeElement.innerText = "Password must be 8 or more characters"
      else if (errors['pattern']) {
        for (let i = 0; i < this.checks.length; i++) {
          const check = this.checks[i];
          if (!check.regex.test(password)) {
            this.ref.nativeElement.innerText = check.message
            break
          }
        }
      }
    }
    else {
      this.ref.nativeElement.classList.add(...Constants.ValidationClass.valid)
      this.ref.nativeElement.innerText = "Password"
    }
  }

}
