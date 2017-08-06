System.register(["@angular/core", "./account.service", "../common/notification/notification.service"], function (exports_1, context_1) {
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
    var core_1, account_service_1, notification_service_1, LoginComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (account_service_1_1) {
                account_service_1 = account_service_1_1;
            },
            function (notification_service_1_1) {
                notification_service_1 = notification_service_1_1;
            }
        ],
        execute: function () {
            LoginComponent = (function () {
                function LoginComponent(accountService, notificationService) {
                    this.accountService = accountService;
                    this.notificationService = notificationService;
                }
                ;
                LoginComponent.prototype.signIn = function () {
                    var _this = this;
                    console.log(this.login);
                    console.log(this.password);
                    this.accountService.login(this.login, this.password).then(function (result) {
                        if (result.success) {
                            _this.notificationService.info("Udało się", "kokokokok");
                        }
                        else {
                            _this.notificationService.error("Bład logowania", result.error);
                        }
                    });
                };
                return LoginComponent;
            }());
            LoginComponent = __decorate([
                core_1.Component({
                    templateUrl: './login.component.html',
                }),
                __metadata("design:paramtypes", [account_service_1.AccountService, notification_service_1.NotificationService])
            ], LoginComponent);
            exports_1("LoginComponent", LoginComponent);
        }
    };
});
//# sourceMappingURL=login.component.js.map