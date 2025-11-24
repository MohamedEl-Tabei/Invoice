import { ValidatorFn } from "@angular/forms";

export interface UserLoginIdentifier {
    label: string;
    identifier: string;
    placeholder: string;
    id: string;
    validators?: ValidatorFn[];
}
