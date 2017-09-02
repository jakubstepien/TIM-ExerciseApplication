import { Directive, Input } from '@angular/core';
import { NG_VALIDATORS, Validators, Validator, AbstractControl, ValidationErrors } from '@angular/forms';

@Directive({
    selector: '[minValue]',
    providers: [{ provide: NG_VALIDATORS, useExisting: MinValueDirective, multi: true }]
})
export class MinValueDirective implements Validator {
    @Input() minValue: string;

    validate(c: AbstractControl): ValidationErrors | null {
        if (!this.minValue && !parseFloat(this.minValue))
            throw new Error("Wrong min value parameter");


        if (c.value && parseFloat(c.value)) {
            var num = parseFloat(c.value)
            if (num < parseFloat(this.minValue)) {
                console.log(c.errors);
                return { minValue: 'error' } as ValidationErrors;
            }
        }
    }

}