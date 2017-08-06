System.register(["@angular/core", "./notification.service"], function (exports_1, context_1) {
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
    var core_1, notification_service_1, NotificationComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (notification_service_1_1) {
                notification_service_1 = notification_service_1_1;
            }
        ],
        execute: function () {
            NotificationComponent = (function () {
                function NotificationComponent(notificationService) {
                    this.notificationService = notificationService;
                    this.timer;
                }
                NotificationComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    this.notificationService.notification.subscribe(function (next) {
                        if (_this.timer) {
                            window.clearTimeout(_this.timer);
                        }
                        var time = next.timeToShow ? next.timeToShow : 5000;
                        _this.timer = window.setTimeout(function () { _this.show = false; _this.timer = null; }, time);
                        _this.notification = next;
                        _this.show = true;
                    });
                };
                NotificationComponent.prototype.endNotificationTime = function () {
                };
                NotificationComponent.prototype.close = function () {
                    this.show = false;
                };
                return NotificationComponent;
            }());
            NotificationComponent = __decorate([
                core_1.Component({
                    selector: 'notification',
                    templateUrl: './notivication.template.html'
                }),
                __metadata("design:paramtypes", [notification_service_1.NotificationService])
            ], NotificationComponent);
            exports_1("NotificationComponent", NotificationComponent);
        }
    };
});
//# sourceMappingURL=notification.component.js.map