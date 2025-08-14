import { Directive, ElementRef, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { Constants } from '../Constants';

@Directive({
  selector: '[appUserNameErrore]'
})
export class UserNameErrorDirective {
  @Input({ required: true }) userNameControl!: AbstractControl | null
  constructor(private ref: ElementRef) { }
  ngOnInit() {
    this.userNameControl?.valueChanges.subscribe(() => this.updateMessage())
  }
  updateMessage() {
    const errors = this.userNameControl?.errors;
    const userName = this.userNameControl?.value
    if (errors) {
      this.ref.nativeElement.classList.remove(...Constants.ValidationClass.valid)
      this.ref.nativeElement.classList.add(...Constants.ValidationClass.invalid);
      if (errors['required']) this.ref.nativeElement.innerText = "Name is required"
      else if (errors['minlength']) this.ref.nativeElement.innerText = "Name must be 3 or more characters"
      else if (errors['pattern']) this.ref.nativeElement.innerText = "Name must start with letter"
    }
    else {
      this.ref.nativeElement.classList.add(...Constants.ValidationClass.valid)
      this.ref.nativeElement.innerText = "name"
    }
  }


}
