import { ElementRef } from "@angular/core";
import { Constants } from "../Constants";

export class Util {
    public static readonly setInvalid = (message: string, ref: ElementRef) => {
        ref.nativeElement.classList.remove(...Constants.ValidationClass.valid)
        ref.nativeElement.classList.add(...Constants.ValidationClass.invalid);
        ref.nativeElement.innerText = message.replace("userName", "name").replace("phoneNumber", "phone")
    }
    public static readonly setValid = (label: string, ref: ElementRef) => {
        ref.nativeElement.classList.add(...Constants.ValidationClass.valid)
        ref.nativeElement.classList.remove(...Constants.ValidationClass.invalid);
        ref.nativeElement.innerText = label
    }
}