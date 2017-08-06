System.register(["@angular/core", "@angular/http", "rxjs/add/operator/toPromise"], function (exports_1, context_1) {
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
    var core_1, http_1, AccountService;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (_1) {
            }
        ],
        execute: function () {
            AccountService = (function () {
                function AccountService(http) {
                    this.http = http;
                }
                ;
                AccountService.prototype.login = function (login, password) {
                    var body = 'grant_type=password&username=' + login + '&password=' + password;
                    var headers = new http_1.Headers();
                    headers.append('Content-Type', 'application/x-www-form-urlencoded');
                    return this.http.post('/token', body, { headers: headers, body: body })
                        .toPromise()
                        .then(function (response) {
                        return { success: true };
                    })
                        .catch(function (reason) {
                        return { success: false, error: "Nieprawidłowe dane logowania." };
                    });
                };
                return AccountService;
            }());
            AccountService = __decorate([
                core_1.Injectable(),
                __metadata("design:paramtypes", [http_1.Http])
            ], AccountService);
            exports_1("AccountService", AccountService);
        }
    };
});
//# sourceMappingURL=account.service.js.map