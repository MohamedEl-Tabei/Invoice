import { FormControl } from "@angular/forms";

export interface SubcategoryForm {
    name: FormControl<string>;
    categoryId: FormControl<string>;
}