import { FormControl } from "@angular/forms";
import { TRole } from "../../Types/TRole";

export interface SignUpForm {
    userName: FormControl<string>;
    email: FormControl<string>;
    phoneNumber: FormControl<string>;
    password: FormControl<string>;
    confirmPassword: FormControl<string>;
    role: FormControl<TRole>;
}
