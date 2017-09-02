System.register(["@angular/core", "@angular/http", "rxjs/add/operator/toPromise", "../common/http.service", "../common/user.service"], function (exports_1, context_1) {
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
    var core_1, http_1, http_service_1, user_service_1, AccountService;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (_1) {
            },
            function (http_service_1_1) {
                http_service_1 = http_service_1_1;
            },
            function (user_service_1_1) {
                user_service_1 = user_service_1_1;
            }
        ],
        execute: function () {
            AccountService = (function () {
                function AccountService(http, userService) {
                    this.http = http;
                    this.userService = userService;
                }
                ;
                AccountService.prototype.login = function (login, password, remember) {
                    var _this = this;
                    var body = 'grant_type=password&username=' + login + '&password=' + password;
                    var headers = new http_1.Headers();
                    headers.append('Content-Type', 'application/x-www-form-urlencoded');
                    return this.http.post('/token', body, false, { headers: headers, body: body })
                        .toPromise()
                        .then(function (response) {
                        _this.userService.storeToken(response.json(), remember);
                        return { success: true };
                    })
                        .catch(function (reason) {
                        var error = _this.getError(reason.json(), 'Nieprawidłowe dane logowania.');
                        return { success: false, error: error };
                    });
                };
                AccountService.prototype.register = function (login, password, passwordConfirm) {
                    var _this = this;
                    return this.http.post('/api/account/register', { Email: login, Password: password, ConfirmPassword: passwordConfirm })
                        .toPromise()
                        .then(function (response) {
                        return _this.login(login, password, false);
                    })
                        .catch(function (reason) {
                        var errorJson = reason.json();
                        var error = _this.getError(errorJson);
                        return { success: false, error: error };
                    });
                };
                AccountService.prototype.getError = function (modelError, errorMessage) {
                    if (errorMessage === void 0) { errorMessage = ''; }
                    if (modelError && modelError.ModelState) {
                        var modelState_1 = modelError.ModelState;
                        var modelErrors = Object.keys(modelState_1).map(function (m) { return modelState_1[m]; }).reduce(function (a, b) { return a.concat(b); });
                        return modelErrors.reduce(function (a, b) { return a + "\r\n" + b; });
                    }
                    return errorMessage;
                };
                return AccountService;
            }());
            AccountService = __decorate([
                core_1.Injectable(),
                __metadata("design:paramtypes", [http_service_1.HttpService, user_service_1.UserService])
            ], AccountService);
            exports_1("AccountService", AccountService);
        }
    };
});
//# sourceMappingURL=account.service.js.map