System.register(["@angular/core"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, TruncatePipe;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            }
        ],
        execute: function () {
            TruncatePipe = (function () {
                function TruncatePipe() {
                }
                TruncatePipe.prototype.transform = function (value, args) {
                    if (args && args[0]) {
                        var limit = args[0];
                        return value.length > limit ? value.substring(0, limit) + "..." : value;
                    }
                    throw new Error("Invalid parameters");
                };
                return TruncatePipe;
            }());
            TruncatePipe = __decorate([
                core_1.Pipe({
                    name: 'truncate'
                })
            ], TruncatePipe);
            exports_1("TruncatePipe", TruncatePipe);
        }
    };
});
//# sourceMappingURL=truncate.js.map