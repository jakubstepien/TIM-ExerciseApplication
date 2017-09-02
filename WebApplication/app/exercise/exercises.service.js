System.register(["@angular/core", "rxjs/Subject", "../common/http.service", "../common/user.service"], function (exports_1, context_1) {
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
    var core_1, Subject_1, http_service_1, user_service_1, ExercisesService;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (Subject_1_1) {
                Subject_1 = Subject_1_1;
            },
            function (http_service_1_1) {
                http_service_1 = http_service_1_1;
            },
            function (user_service_1_1) {
                user_service_1 = user_service_1_1;
            }
        ],
        execute: function () {
            ExercisesService = (function () {
                function ExercisesService(http, userService) {
                    this.http = http;
                    this.userService = userService;
                    this.dataChanged = new Subject_1.Subject();
                    this.emptyId = "00000000-0000-0000-0000-000000000000";
                }
                ExercisesService.prototype.getExercises = function (page, pageSize) {
                    var userId = this.userService.getUserId();
                    if (userId) {
                        var promise = this.http.get('/api/exercises/user/' + userId, true, { params: { page: page.toString(), pageSize: pageSize.toString() } }).toPromise();
                        return promise.then(function (response) {
                            return { data: response.json(), success: true };
                        })
                            .catch(function (reason) {
                            return { success: false };
                        });
                    }
                    return Promise.resolve({ success: false });
                };
                ExercisesService.prototype.addExercise = function (exercise) {
                    var _this = this;
                    var userId = this.userService.getUserId();
                    if (!exercise.IdExercise) {
                        exercise.IdExercise = this.emptyId;
                    }
                    if (userId) {
                        return this.http.post('api/exercises/user/' + userId, exercise, true).toPromise()
                            .then(function (response) {
                            _this.dataChanged.next(true);
                            return { success: true };
                        })
                            .catch(function (reason) {
                            return { success: false };
                        });
                    }
                    return Promise.resolve({ success: false });
                };
                ExercisesService.prototype.getExercise = function (id) {
                    if (id) {
                        return this.http.get('api/exercises/' + id, true).toPromise()
                            .then(function (response) {
                            return { success: true, data: response.json() };
                        })
                            .catch(function (reason) {
                            return { success: false };
                        });
                    }
                    return Promise.resolve({ success: false });
                };
                ExercisesService.prototype.deleteExercise = function (id) {
                    var _this = this;
                    var userId = this.userService.getUserId();
                    if (userId && id) {
                        var promise = this.http.delete("api/exercises/" + id + "/user/" + userId, true).toPromise();
                        return promise.then(function (response) {
                            _this.dataChanged.next(true);
                            return { success: true };
                        }).catch(function (reason) {
                            return { success: false };
                        });
                    }
                    return Promise.resolve({ success: false });
                };
                ExercisesService.prototype.saveImage = function (image, exerciseId, fileName) {
                    var formData = new FormData();
                    formData.append('image', image, image.name);
                    if (exerciseId) {
                        formData.append('excerciseId', exerciseId);
                    }
                    if (!fileName) {
                        fileName = image.name;
                    }
                    formData.append('fileName', fileName);
                    return this.http.post('/api/exercises/image', formData, true).toPromise()
                        .then(function (response) {
                        var json = response.json();
                        return { success: json.Id != null, data: json.Id };
                    })
                        .catch(function (reason) {
                        return { success: false };
                    });
                };
                return ExercisesService;
            }());
            ExercisesService = __decorate([
                core_1.Injectable(),
                __metadata("design:paramtypes", [http_service_1.HttpService, user_service_1.UserService])
            ], ExercisesService);
            exports_1("ExercisesService", ExercisesService);
        }
    };
});
//# sourceMappingURL=exercises.service.js.map