System.register(["@angular/core", "ngx-cookie"], function (exports_1, context_1) {
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
    var core_1, ngx_cookie_1, UserService;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (ngx_cookie_1_1) {
                ngx_cookie_1 = ngx_cookie_1_1;
            }
        ],
        execute: function () {
            UserService = (function () {
                function UserService(cookie) {
                    this.cookie = cookie;
                    this.tokenKey = "ExerciseAppToken";
                }
                UserService.prototype.getUserId = function () {
                    var tokenObj = this.getTokenObject();
                    if (tokenObj) {
                        return tokenObj.userId;
                    }
                };
                UserService.prototype.getToken = function () {
                    var tokenObj = this.getTokenObject();
                    if (tokenObj) {
                        return tokenObj.access_token;
                    }
                };
                UserService.prototype.storeToken = function (token) {
                    this.cookie.putObject(this.tokenKey, token);
                };
                UserService.prototype.isLoggedIn = function () {
                    return this.getTokenObject() != null;
                };
                UserService.prototype.isInRole = function (role) {
                    var tokenObj = this.getTokenObject();
                    if (!tokenObj) {
                        return false;
                    }
                    return tokenObj.roles.split(';').some(function (userRole) { return userRole === role; });
                };
                UserService.prototype.getTokenObject = function () {
                    return this.cookie.getObject(this.tokenKey);
                };
                return UserService;
            }());
            UserService = __decorate([
                core_1.Injectable(),
                __metadata("design:paramtypes", [ngx_cookie_1.CookieService])
            ], UserService);
            exports_1("UserService", UserService);
        }
    };
});
//# sourceMappingURL=user.service.js.map