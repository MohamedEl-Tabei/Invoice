import { FormControl } from "@angular/forms";

export interface LoginForm {
    identifier: FormControl<string>,
    password: FormControl<string>,
    rememberMe: FormControl<boolean>
}
