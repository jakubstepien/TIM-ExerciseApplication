System.register(["@angular/core", "@angular/router", "@angular/common", "./exercises.service", "../common/notification/notification.service"], function (exports_1, context_1) {
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
    var core_1, router_1, common_1, exercises_service_1, notification_service_1, ExercseDetailComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (common_1_1) {
                common_1 = common_1_1;
            },
            function (exercises_service_1_1) {
                exercises_service_1 = exercises_service_1_1;
            },
            function (notification_service_1_1) {
                notification_service_1 = notification_service_1_1;
            }
        ],
        execute: function () {
            ExercseDetailComponent = (function () {
                function ExercseDetailComponent(exercisesService, notificationservice, activeRoute, location, router) {
                    this.exercisesService = exercisesService;
                    this.notificationservice = notificationservice;
                    this.activeRoute = activeRoute;
                    this.location = location;
                    this.router = router;
                    this.imageUploading = false;
                }
                ExercseDetailComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    this.activeRoute.paramMap.subscribe(function (parms) {
                        var id = parms.get('id');
                        if (id) {
                            _this.isUpdate = true;
                            _this.loadExercise(id);
                        }
                        else {
                            _this.isUpdate = false;
                            _this.title = "Dodaj cwiczenie";
                            _this.exercise = { CaloriesPerHour: null, Description: "", IdExercise: "", ImageName: "", Name: "", IsFavourite: false };
                            _this.show = true;
                        }
                    });
                };
                ExercseDetailComponent.prototype.loadExercise = function (id) {
                    var _this = this;
                    this.exercisesService.getExercise(id).then(function (data) {
                        if (data.success) {
                            _this.exercise = data.data;
                            _this.show = true;
                            _this.title = "Edytuj cwiczenie";
                        }
                        else {
                            _this.notificationservice.error('Błąd pobierania ćwiczenia.');
                        }
                    })
                        .catch(function (reason) {
                        _this.notificationservice.error('Błąd pobierania ćwiczenia.');
                    });
                };
                ExercseDetailComponent.prototype.uploadImage = function (event) {
                    var _this = this;
                    this.imageUploading = true;
                    var file = event.target.files[0];
                    var result = this.exercisesService.saveImage(file, this.exercise.IdExercise)
                        .then(function (response) {
                        if (response.success) {
                            if (!_this.isUpdate) {
                                _this.exercise.IdExercise = response.data;
                            }
                            _this.exercise.ImageName = file.name;
                        }
                        else {
                            _this.notificationservice.error('Błąd zapisu obrazu');
                        }
                        _this.imageUploading = false;
                    })
                        .catch(function (reaspon) {
                        _this.imageUploading = false;
                        _this.notificationservice.error('Błąd zapisu obrazu');
                    });
                };
                ExercseDetailComponent.prototype.saveExercise = function (form) {
                    if (this.isUpdate) {
                        this.updateExercise();
                    }
                    else {
                        this.addExercise();
                    }
                };
                ExercseDetailComponent.prototype.addExercise = function () {
                    var _this = this;
                    this.exercisesService.addExercise(this.exercise)
                        .then(function (result) {
                        if (result.success) {
                            _this.router.navigate(['../'], { relativeTo: _this.activeRoute });
                        }
                        else {
                            throw new Error();
                        }
                    })
                        .catch(function (reason) {
                        _this.notificationservice.error("Błąd zapisu ćwiczenia");
                    });
                };
                ExercseDetailComponent.prototype.updateExercise = function () {
                    var _this = this;
                    this.exercisesService.updateExercise(this.exercise)
                        .then(function (result) {
                        if (result.success) {
                            _this.router.navigate(['../../'], { relativeTo: _this.activeRoute });
                        }
                        else {
                            throw new Error();
                        }
                    })
                        .catch(function (reason) {
                        _this.notificationservice.error("Błąd zapisu ćwiczenia");
                    });
                };
                return ExercseDetailComponent;
            }());
            ExercseDetailComponent = __decorate([
                core_1.Component({
                    templateUrl: './exercise-detail.component.html',
                }),
                __metadata("design:paramtypes", [exercises_service_1.ExercisesService, notification_service_1.NotificationService, router_1.ActivatedRoute, common_1.Location, router_1.Router])
            ], ExercseDetailComponent);
            exports_1("ExercseDetailComponent", ExercseDetailComponent);
        }
    };
});
//# sourceMappingURL=exercise-detail.component.js.map