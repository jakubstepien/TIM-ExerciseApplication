import { Directive, Input } from '@angular/core';
import { NG_VALIDATORS, Validators, Validator, AbstractControl, ValidationErrors } from '@angular/forms';

@Directive({
    selector: '[number]',
    providers: [{ provide: NG_VALIDATORS, useExisting: NumberDirective, multi: true }]
})
export class NumberDirective implements Validator {

    validate(c: AbstractControl): ValidationErrors | null {
        if (c.value) {
            if (!parseFloat(c.value)) {
                return { number: "error" };
            }
        }
    }

}