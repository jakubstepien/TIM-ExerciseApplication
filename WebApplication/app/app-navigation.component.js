System.register(["@angular/core", "./common/user.service"], function (exports_1, context_1) {
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
    var core_1, user_service_1, AppNavigationComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (user_service_1_1) {
                user_service_1 = user_service_1_1;
            }
        ],
        execute: function () {
            AppNavigationComponent = (function () {
                function AppNavigationComponent(userService) {
                    this.userService = userService;
                    this.asdasdTest = false;
                }
                AppNavigationComponent.prototype.isLoggedIn = function () {
                    return this.userService.isLoggedIn();
                };
                AppNavigationComponent.prototype.isInRole = function (role) {
                    return this.userService.isInRole(role);
                };
                return AppNavigationComponent;
            }());
            AppNavigationComponent = __decorate([
                core_1.Component({
                    selector: 'app-nav',
                    templateUrl: './app-navigation.component.html'
                }),
                __metadata("design:paramtypes", [user_service_1.UserService])
            ], AppNavigationComponent);
            exports_1("AppNavigationComponent", AppNavigationComponent);
        }
    };
});
//# sourceMappingURL=app-navigation.component.js.map