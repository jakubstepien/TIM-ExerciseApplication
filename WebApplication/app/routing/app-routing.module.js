System.register(["@angular/core", "@angular/router", "../home/home.component", "../exercise/exercises.component", "../exercise/exercise-detail.component", "../account/login.component", "../account/register.component", "./loggedin-guard", "./role-guard"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, router_1, home_component_1, exercises_component_1, exercise_detail_component_1, login_component_1, register_component_1, loggedin_guard_1, role_guard_1, routes, AppRoutingModule;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (home_component_1_1) {
                home_component_1 = home_component_1_1;
            },
            function (exercises_component_1_1) {
                exercises_component_1 = exercises_component_1_1;
            },
            function (exercise_detail_component_1_1) {
                exercise_detail_component_1 = exercise_detail_component_1_1;
            },
            function (login_component_1_1) {
                login_component_1 = login_component_1_1;
            },
            function (register_component_1_1) {
                register_component_1 = register_component_1_1;
            },
            function (loggedin_guard_1_1) {
                loggedin_guard_1 = loggedin_guard_1_1;
            },
            function (role_guard_1_1) {
                role_guard_1 = role_guard_1_1;
            }
        ],
        execute: function () {
            routes = [
                { path: '', component: home_component_1.HomeComponent },
                {
                    path: 'exercises', component: exercises_component_1.ExercisesComponent,
                    canActivate: [loggedin_guard_1.LoggedInGuard],
                    children: [{
                            path: "details", component: exercise_detail_component_1.ExercseDetailComponent
                        }]
                },
                { path: 'login', component: login_component_1.LoginComponent },
                { path: 'register', component: register_component_1.RegisterComponent },
            ];
            AppRoutingModule = (function () {
                function AppRoutingModule() {
                }
                return AppRoutingModule;
            }());
            AppRoutingModule = __decorate([
                core_1.NgModule({
                    imports: [router_1.RouterModule.forRoot(routes)],
                    exports: [router_1.RouterModule],
                    providers: [loggedin_guard_1.LoggedInGuard, role_guard_1.RoleGuard],
                })
            ], AppRoutingModule);
            exports_1("AppRoutingModule", AppRoutingModule);
        }
    };
});
//# sourceMappingURL=app-routing.module.js.map