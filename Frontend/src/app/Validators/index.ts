import { ValidatorFn, Validators } from "@angular/forms";

export class AppValidators {
    private static passwordPattern: RegExp = /^(?=.{8,}$)(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+\[\]{};:'",.<>\/?\\|`~]).+$/;
    private static emailPattern: RegExp = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    private static phonePattern: RegExp = /^01[0,1,2,5][0-9]{8}$/;
    private static namePattern: RegExp = /^[A-Za-z][A-Za-z0-9_]{2,19}$/;
    public static readonly password: ValidatorFn[] = [Validators.required, Validators.minLength(8), Validators.pattern(this.passwordPattern)];
    public static readonly email: ValidatorFn[] = [Validators.required, Validators.email, Validators.pattern(this.emailPattern)];
    public static readonly phone: ValidatorFn[] = [Validators.required, Validators.pattern(this.phonePattern)];
    public static readonly name: ValidatorFn[] = [Validators.required, Validators.minLength(3), Validators.maxLength(20), Validators.pattern(this.namePattern)];
}