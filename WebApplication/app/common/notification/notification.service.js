System.register(["@angular/core", "rxjs/Subject", "./Notification"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, Subject_1, Notification_1, NotificationService;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (Subject_1_1) {
                Subject_1 = Subject_1_1;
            },
            function (Notification_1_1) {
                Notification_1 = Notification_1_1;
            }
        ],
        execute: function () {
            NotificationService = (function () {
                function NotificationService() {
                    this.data = new Subject_1.Subject();
                }
                Object.defineProperty(NotificationService.prototype, "notification", {
                    get: function () {
                        return this.data;
                    },
                    enumerable: true,
                    configurable: true
                });
                NotificationService.prototype.info = function (title, message) {
                    if (message === void 0) { message = ""; }
                    this.alert(Notification_1.NotificationType.Info, title, message);
                };
                NotificationService.prototype.warning = function (title, message) {
                    if (message === void 0) { message = ""; }
                    this.alert(Notification_1.NotificationType.Warning, title, message);
                };
                NotificationService.prototype.error = function (title, message) {
                    if (message === void 0) { message = ""; }
                    this.alert(Notification_1.NotificationType.Error, title, message);
                };
                NotificationService.prototype.alert = function (type, title, message) {
                    if (message === void 0) { message = ""; }
                    this.data.next({ message: message, title: title, type: type });
                };
                return NotificationService;
            }());
            NotificationService = __decorate([
                core_1.Injectable()
            ], NotificationService);
            exports_1("NotificationService", NotificationService);
        }
    };
});
//# sourceMappingURL=notification.service.js.map