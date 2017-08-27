System.register(["@angular/core", "@angular/router", "./exercises.service", "../common/notification/notification.service"], function (exports_1, context_1) {
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
    var core_1, router_1, exercises_service_1, notification_service_1, ExercisesComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (exercises_service_1_1) {
                exercises_service_1 = exercises_service_1_1;
            },
            function (notification_service_1_1) {
                notification_service_1 = notification_service_1_1;
            }
        ],
        execute: function () {
            ExercisesComponent = (function () {
                function ExercisesComponent(exercisesService, notificationService, activatedRoute) {
                    this.exercisesService = exercisesService;
                    this.notificationService = notificationService;
                    this.activatedRoute = activatedRoute;
                    this.title = "Cwiczenia";
                    this.pageSize = 20;
                }
                ;
                ExercisesComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    this.activatedRoute.params.subscribe(function (parms) {
                        _this.currentPage = +parms['page'];
                        _this.loadExercises();
                    });
                };
                ExercisesComponent.prototype.loadExercises = function () {
                    var _this = this;
                    this.exercisesService.getExercises(this.currentPage, this.pageSize).then(function (response) {
                        if (response.success) {
                            _this.exercises = response.data.Items;
                            _this.currentPage = response.data.CurrentPage;
                            _this.total = response.data.TotalCount;
                            _this.lastPage = Math.ceil(_this.total / _this.pageSize);
                        }
                        else {
                            throw new Error();
                        }
                    })
                        .catch(function (reason) {
                        console.log(reason);
                        _this.notificationService.error("Błąd pobierania ćwiczeń", '');
                    });
                };
                return ExercisesComponent;
            }());
            ExercisesComponent = __decorate([
                core_1.Component({
                    templateUrl: './exercises.component.html',
                }),
                __metadata("design:paramtypes", [exercises_service_1.ExercisesService, notification_service_1.NotificationService, router_1.ActivatedRoute])
            ], ExercisesComponent);
            exports_1("ExercisesComponent", ExercisesComponent);
        }
    };
});
//# sourceMappingURL=exercises.component.js.map