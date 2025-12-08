import { FormControl } from "@angular/forms";

export interface SignUpForm {
    userName: FormControl<string>;
    email: FormControl<string>;
    phoneNumber: FormControl<string>;
    password: FormControl<string>;
    confirmPassword: FormControl<string>;
}
