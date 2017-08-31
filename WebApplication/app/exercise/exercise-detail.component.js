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
    var core_1, exercises_service_1, ExercseDetailComponent;
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
            ExercseDetailComponent = (function () {
                function ExercseDetailComponent(exercisesService) {
                    this.exercisesService = exercisesService;
                }
                ExercseDetailComponent.prototype.uploadImage = function (event) {
                    var file = event.target.files[0];
                    this.exercisesService.saveImage(file, "83CBF1FC-BDC6-457B-850E-E34D56122AF6");
                };
                return ExercseDetailComponent;
            }());
            ExercseDetailComponent = __decorate([
                core_1.Component({
                    templateUrl: './exercise-detail.component.html',
                }),
                __metadata("design:paramtypes", [exercises_service_1.ExercisesService])
            ], ExercseDetailComponent);
            exports_1("ExercseDetailComponent", ExercseDetailComponent);
        }
    };
});
//# sourceMappingURL=exercise-detail.component.js.map