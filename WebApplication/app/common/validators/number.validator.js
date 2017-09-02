System.register(["@angular/core", "@angular/forms"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, forms_1, NumberDirective, NumberDirective_1;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            }
        ],
        execute: function () {
            NumberDirective = NumberDirective_1 = (function () {
                function NumberDirective() {
                }
                NumberDirective.prototype.validate = function (c) {
                    if (c.value) {
                        if (!parseFloat(c.value)) {
                            return { number: "error" };
                        }
                    }
                };
                return NumberDirective;
            }());
            NumberDirective = NumberDirective_1 = __decorate([
                core_1.Directive({
                    selector: '[number]',
                    providers: [{ provide: forms_1.NG_VALIDATORS, useExisting: NumberDirective_1, multi: true }]
                })
            ], NumberDirective);
            exports_1("NumberDirective", NumberDirective);
        }
    };
});
//# sourceMappingURL=number.validator.js.map