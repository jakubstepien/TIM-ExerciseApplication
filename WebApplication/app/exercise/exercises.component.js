System.register(["@angular/core", "./exercises.service"], function (exports_1, context_1) {
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
    var core_1, exercises_service_1, ExercisesComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (exercises_service_1_1) {
                exercises_service_1 = exercises_service_1_1;
            }
        ],
        execute: function () {
            ExercisesComponent = (function () {
                function ExercisesComponent(exercisesService) {
                    this.exercisesService = exercisesService;
                    this.title = "Exercises";
                }
                ;
                ExercisesComponent.prototype.ngOnInit = function () {
                    this.exercisesService.getExercises();
                };
                return ExercisesComponent;
            }());
            ExercisesComponent = __decorate([
                core_1.Component({
                    template: "<h1>{{title}}</h1>\n    <a routerLink=\"details\">Test</a>\n    <router-outlet></router-outlet>\n    "
                }),
                __metadata("design:paramtypes", [exercises_service_1.ExercisesService])
            ], ExercisesComponent);
            exports_1("ExercisesComponent", ExercisesComponent);
        }
    };
});
//# sourceMappingURL=exercises.component.js.map