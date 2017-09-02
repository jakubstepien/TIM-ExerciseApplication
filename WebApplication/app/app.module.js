System.register(["@angular/core", "@angular/platform-browser", "@angular/forms", "@angular/http", "./app.component", "./common/loader.component", "./common/modal/modal.component", "./common/pager/pager.component", "./common/notification/notification.component", "./app-navigation.component", "./home/home.component", "./exercise/exercises.component", "./exercise/exercise-detail.component", "./account/login.component", "./account/register.component", "./account/logout.component", "./common/http.service", "./common/user.service", "./account/account.service", "./exercise/exercises.service", "./common/notification/notification.service", "./routing/app-routing.module", "ngx-cookie", "./common/truncate.pipe", "./common/validators/minValue.validator", "./common/validators/number.validator"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, platform_browser_1, forms_1, http_1, app_component_1, loader_component_1, modal_component_1, pager_component_1, notification_component_1, app_navigation_component_1, home_component_1, exercises_component_1, exercise_detail_component_1, login_component_1, register_component_1, logout_component_1, http_service_1, user_service_1, account_service_1, exercises_service_1, notification_service_1, app_routing_module_1, ngx_cookie_1, truncate_pipe_1, minValue_validator_1, number_validator_1, AppModule;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (platform_browser_1_1) {
                platform_browser_1 = platform_browser_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (app_component_1_1) {
                app_component_1 = app_component_1_1;
            },
            function (loader_component_1_1) {
                loader_component_1 = loader_component_1_1;
            },
            function (modal_component_1_1) {
                modal_component_1 = modal_component_1_1;
            },
            function (pager_component_1_1) {
                pager_component_1 = pager_component_1_1;
            },
            function (notification_component_1_1) {
                notification_component_1 = notification_component_1_1;
            },
            function (app_navigation_component_1_1) {
                app_navigation_component_1 = app_navigation_component_1_1;
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
            function (logout_component_1_1) {
                logout_component_1 = logout_component_1_1;
            },
            function (http_service_1_1) {
                http_service_1 = http_service_1_1;
            },
            function (user_service_1_1) {
                user_service_1 = user_service_1_1;
            },
            function (account_service_1_1) {
                account_service_1 = account_service_1_1;
            },
            function (exercises_service_1_1) {
                exercises_service_1 = exercises_service_1_1;
            },
            function (notification_service_1_1) {
                notification_service_1 = notification_service_1_1;
            },
            function (app_routing_module_1_1) {
                app_routing_module_1 = app_routing_module_1_1;
            },
            function (ngx_cookie_1_1) {
                ngx_cookie_1 = ngx_cookie_1_1;
            },
            function (truncate_pipe_1_1) {
                truncate_pipe_1 = truncate_pipe_1_1;
            },
            function (minValue_validator_1_1) {
                minValue_validator_1 = minValue_validator_1_1;
            },
            function (number_validator_1_1) {
                number_validator_1 = number_validator_1_1;
            }
        ],
        execute: function () {
            AppModule = (function () {
                function AppModule() {
                }
                return AppModule;
            }());
            AppModule = __decorate([
                core_1.NgModule({
                    imports: [platform_browser_1.BrowserModule, app_routing_module_1.AppRoutingModule, forms_1.FormsModule, http_1.HttpModule, ngx_cookie_1.CookieModule.forRoot()],
                    declarations: [
                        app_component_1.AppComponent,
                        loader_component_1.LoaderComponent,
                        modal_component_1.ModalComponent,
                        home_component_1.HomeComponent,
                        notification_component_1.NotificationComponent,
                        exercises_component_1.ExercisesComponent,
                        exercise_detail_component_1.ExercseDetailComponent,
                        app_navigation_component_1.AppNavigationComponent,
                        login_component_1.LoginComponent,
                        register_component_1.RegisterComponent,
                        pager_component_1.PagerComponent,
                        logout_component_1.LogoutComponent,
                        truncate_pipe_1.TruncatePipe,
                        minValue_validator_1.MinValueDirective,
                        number_validator_1.NumberDirective
                    ],
                    providers: [
                        account_service_1.AccountService,
                        notification_service_1.NotificationService,
                        exercises_service_1.ExercisesService,
                        user_service_1.UserService,
                        {
                            provide: http_service_1.HttpService,
                            useFactory: function (backend, options, userService) {
                                return new http_service_1.HttpService(backend, options, userService);
                            },
                            deps: [http_1.XHRBackend, http_1.RequestOptions, user_service_1.UserService]
                        }
                    ],
                    bootstrap: [app_component_1.AppComponent]
                })
            ], AppModule);
            exports_1("AppModule", AppModule);
        }
    };
});
//# sourceMappingURL=app.module.js.map