import { Directive, ElementRef, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { Constants } from '../Constants';
import { Util } from '../util';
import { Subscription } from 'rxjs';

@Directive({
  selector: '[appPhoneError]'
})
export class PhoneErrorDirective {
  @Input({ required: true }) phoneControl!: AbstractControl | null;
  changedValue: string = ""
  subStutas?: Subscription
  subValue?: Subscription
  constructor(private ref: ElementRef) { }
  ngOnInit() {
    this.subValue = this.phoneControl?.valueChanges.subscribe((value) => {
      if (isFinite(value)) this.changedValue = value;
      else this.phoneControl?.setValue(this.changedValue)
    })
    this.subStutas = this.phoneControl?.statusChanges.subscribe(() => this.updateMessage())
  }
  updateMessage() {
    const errors = this.phoneControl?.errors;
    let message = ""
    if (errors) {
      if (errors['required']) message = "phone is required"
      else if (errors['pattern']) message = "phone is invalid"
      else if (errors['apiError']) message = errors['apiError'];
      Util.setInvalid(message, this.ref)
    } else Util.setValid("phone", this.ref)
  }
  ngOnDestroy() {
    this.subStutas?.unsubscribe()
    this.subValue?.unsubscribe()
  }
}
