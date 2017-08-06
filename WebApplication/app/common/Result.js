System.register([], function (exports_1, context_1) {
    "use strict";
    var __extends = (this && this.__extends) || (function () {
        var extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return function (d, b) {
            extendStatics(d, b);
            function __() { this.constructor = d; }
            d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
        };
    })();
    var __moduleName = context_1 && context_1.id;
    var Result, DataResult;
    return {
        setters: [],
        execute: function () {
            Result = (function () {
                function Result() {
                }
                return Result;
            }());
            exports_1("Result", Result);
            DataResult = (function (_super) {
                __extends(DataResult, _super);
                function DataResult() {
                    return _super !== null && _super.apply(this, arguments) || this;
                }
                return DataResult;
            }(Result));
            exports_1("DataResult", DataResult);
        }
    };
});
//# sourceMappingURL=Result.js.map