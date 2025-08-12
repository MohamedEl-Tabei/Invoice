import { ValidatorFn } from "@angular/forms";

export interface UserUniqueInputData {
    label: string;
    inputType: string;
    placeholder: string;
    id: string;
    validators?: ValidatorFn[];
}
