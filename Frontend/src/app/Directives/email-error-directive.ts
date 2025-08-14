import { Directive, ElementRef, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { Constants } from '../Constants';

@Directive({
  selector: '[appEmailError]'
})
export class EmailErrorDirective {
  @Input({ required: true }) emailControl!: AbstractControl | null
  constructor(private ref: ElementRef) { }
  ngOnInit() {
    this.emailControl?.valueChanges.subscribe(() => this.updateMessage())
  }
  updateMessage() {
    const errors = this.emailControl?.errors;
    const email = this.emailControl?.value;
    if (errors) {
      this.ref.nativeElement.classList.remove(...Constants.ValidationClass.valid)
      this.ref.nativeElement.classList.add(...Constants.ValidationClass.invalid);
      if (errors['required']) this.ref.nativeElement.innerText = "Email is required"
      else if (errors['pattern']) this.ref.nativeElement.innerText = "Email is invalid"
    }
    else {
      this.ref.nativeElement.classList.add(...Constants.ValidationClass.valid)
      this.ref.nativeElement.innerText = "email"
    }
  }
}
