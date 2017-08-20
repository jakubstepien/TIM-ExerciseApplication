System.register(["rxjs/Subject", "rxjs/add/operator/finally", "@angular/http"], function (exports_1, context_1) {
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
    var Subject_1, http_1, HttpService;
    return {
        setters: [
            function (Subject_1_1) {
                Subject_1 = Subject_1_1;
            },
            function (_1) {
            },
            function (http_1_1) {
                http_1 = http_1_1;
            }
        ],
        execute: function () {
            HttpService = (function (_super) {
                __extends(HttpService, _super);
                function HttpService(backend, options, userService) {
                    var _this = _super.call(this, backend, options) || this;
                    _this.backend = backend;
                    _this.userService = userService;
                    _this.runningRequest = new Subject_1.Subject();
                    return _this;
                }
                Object.defineProperty(HttpService.prototype, "loading", {
                    get: function () {
                        return this.runningRequest;
                    },
                    enumerable: true,
                    configurable: true
                });
                HttpService.prototype.get = function (url, authorized, options) {
                    var _this = this;
                    this.onStart();
                    options = this.getAuthorizedOptions(authorized, options);
                    return _super.prototype.get.call(this, url, options).finally(function () { return _this.onEnd(); });
                };
                HttpService.prototype.post = function (url, body, authorized, options) {
                    var _this = this;
                    this.onStart();
                    options = this.getAuthorizedOptions(authorized, options);
                    return _super.prototype.post.call(this, url, body, options).finally(function () { return _this.onEnd(); });
                };
                HttpService.prototype.put = function (url, body, authorized, options) {
                    var _this = this;
                    this.onStart();
                    options = this.getAuthorizedOptions(authorized, options);
                    return _super.prototype.put.call(this, url, body, options).finally(function () { return _this.onEnd(); });
                };
                HttpService.prototype.delete = function (url, authorized, options) {
                    var _this = this;
                    this.onStart();
                    options = this.getAuthorizedOptions(authorized, options);
                    return _super.prototype.delete.call(this, url, options).finally(function () { return _this.onEnd(); });
                };
                HttpService.prototype.getAuthorizedOptions = function (authorized, options) {
                    if (authorized) {
                        options = options || { headers: new http_1.Headers() };
                        var token = this.userService.getToken();
                        if (token) {
                            options.headers.append("Authorization", "bearer " + token);
                        }
                    }
                    return options;
                };
                HttpService.prototype.onStart = function () {
                    this.runningRequest.next(true);
                };
                HttpService.prototype.onEnd = function () {
                    this.runningRequest.next(false);
                };
                return HttpService;
            }(http_1.Http));
            exports_1("HttpService", HttpService);
        }
    };
});
//# sourceMappingURL=http.service.js.map