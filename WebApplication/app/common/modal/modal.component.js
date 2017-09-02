System.register(["@angular/core", "@angular/common"], function (exports_1, context_1) {
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
    var core_1, common_1, ModalComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (common_1_1) {
                common_1 = common_1_1;
            }
        ],
        execute: function () {
            ModalComponent = (function () {
                function ModalComponent(location) {
                    this.location = location;
                }
                Object.defineProperty(ModalComponent.prototype, "show", {
                    get: function () {
                        return this._show;
                    },
                    set: function (value) {
                        this.toggleModalOpenOnBody(value);
                        this._show = value;
                    },
                    enumerable: true,
                    configurable: true
                });
                ModalComponent.prototype.close = function () {
                    this.toggleModalOpenOnBody(false);
                    this.location.back();
                };
                ModalComponent.prototype.ngOnDestroy = function () {
                    this.toggleModalOpenOnBody(false);
                };
                ModalComponent.prototype.toggleModalOpenOnBody = function (show) {
                    if (show)
                        document.body.classList.add('modal-open');
                    else
                        document.body.classList.remove('modal-open');
                };
                return ModalComponent;
            }());
            __decorate([
                core_1.Input(),
                __metadata("design:type", String)
            ], ModalComponent.prototype, "header", void 0);
            __decorate([
                core_1.Input(),
                __metadata("design:type", Boolean),
                __metadata("design:paramtypes", [Boolean])
            ], ModalComponent.prototype, "show", null);
            ModalComponent = __decorate([
                core_1.Component({
                    selector: 'modal',
                    templateUrl: './modal.component.html'
                }),
                __metadata("design:paramtypes", [common_1.Location])
            ], ModalComponent);
            exports_1("ModalComponent", ModalComponent);
        }
    };
});
//# sourceMappingURL=modal.component.js.map