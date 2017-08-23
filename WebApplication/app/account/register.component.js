System.register(["@angular/core", "@angular/router", "./account.service", "../common/notification/notification.service"], function (exports_1, context_1) {
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
    var core_1, router_1, account_service_1, notification_service_1, RegisterComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (account_service_1_1) {
                account_service_1 = account_service_1_1;
            },
            function (notification_service_1_1) {
                notification_service_1 = notification_service_1_1;
            }
        ],
        execute: function () {
            RegisterComponent = (function () {
                function RegisterComponent(accountService, notificationService, router) {
                    this.accountService = accountService;
                    this.notificationService = notificationService;
                    this.router = router;
                }
                RegisterComponent.prototype.register = function (f) {
                    var _this = this;
                    this.accountService.register(this.login, this.password, this.passwordConfirm)
                        .then(function (response) {
                        if (response.success) {
                            _this.router.navigateByUrl('/');
                        }
                        else {
                            _this.notificationService.error("Błąd rejestracji", response.error);
                        }
                    });
                };
                return RegisterComponent;
            }());
            RegisterComponent = __decorate([
                core_1.Component({
                    templateUrl: './register.component.html'
                }),
                __metadata("design:paramtypes", [account_service_1.AccountService, notification_service_1.NotificationService, router_1.Router])
            ], RegisterComponent);
            exports_1("RegisterComponent", RegisterComponent);
        }
    };
});
//# sourceMappingURL=register.component.js.map