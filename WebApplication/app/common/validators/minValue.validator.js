System.register(["@angular/core", "@angular/forms"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, forms_1, MinValueDirective, MinValueDirective_1;
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
            MinValueDirective = MinValueDirective_1 = (function () {
                function MinValueDirective() {
                }
                MinValueDirective.prototype.validate = function (c) {
                    if (!this.minValue && !parseFloat(this.minValue))
                        throw new Error("Wrong min value parameter");
                    if (c.value && parseFloat(c.value)) {
                        var num = parseFloat(c.value);
                        if (num < parseFloat(this.minValue)) {
                            return { minValue: 'error' };
                        }
                    }
                };
                return MinValueDirective;
            }());
            __decorate([
                core_1.Input(),
                __metadata("design:type", String)
            ], MinValueDirective.prototype, "minValue", void 0);
            MinValueDirective = MinValueDirective_1 = __decorate([
                core_1.Directive({
                    selector: '[minValue]',
                    providers: [{ provide: forms_1.NG_VALIDATORS, useExisting: MinValueDirective_1, multi: true }]
                })
            ], MinValueDirective);
            exports_1("MinValueDirective", MinValueDirective);
        }
    };
});
//# sourceMappingURL=minValue.validator.js.map