import { Directive, ElementRef, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { Constants } from '../Constants';

@Directive({
  selector: '[appPhoneError]'
})
export class PhoneErrorDirective {
  @Input({ required: true }) phoneControl!: AbstractControl | null;
  changedValue: string = ""
  constructor(private ref: ElementRef) { }
  ngOnInit() {
    this.phoneControl?.valueChanges.subscribe((value) => {
      if (isFinite(value)) {
        this.changedValue = value;
        this.updateMessage()
      }
      else {
        this.phoneControl?.setValue(this.changedValue)
      }

    })
  }
  updateMessage() {
    const errors = this.phoneControl?.errors;
    const phone = this.phoneControl?.value
    if (errors) {
      this.ref.nativeElement.classList.remove(...Constants.ValidationClass.valid)
      this.ref.nativeElement.classList.add(...Constants.ValidationClass.invalid);
      if (errors['required']) this.ref.nativeElement.innerText = "phone is required"
      else if (errors['pattern']) this.ref.nativeElement.innerText = "phone is invalid"
    } else {
      this.ref.nativeElement.classList.add(...Constants.ValidationClass.valid)
      this.ref.nativeElement.innerText = "phone"
    }
  }

}
