import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule, XHRBackend, RequestOptions } from '@angular/http';


import { AppComponent } from './app.component';
import { LoaderComponent } from './common/loader.component';
import { PagerComponent } from './common/pager/pager.component';
import { NotificationComponent } from './common/notification/notification.component';
import { AppNavigationComponent } from './app-navigation.component';
import { HomeComponent } from './home/home.component';
import { ExercisesComponent } from './exercise/exercises.component';
import { ExercseDetailComponent } from './exercise/exercise-detail.component';
import { LoginComponent } from './account/login.component';
import { RegisterComponent } from './account/register.component';
import { LogoutComponent } from './account/logout.component';

import { HttpService } from './common/http.service';
import { UserService } from './common/user.service';
import { AccountService } from './account/account.service';
import { ExercisesService } from './exercise/exercises.service';
import { NotificationService } from './common/notification/notification.service';

import { AppRoutingModule } from './routing/app-routing.module';
import { CookieModule } from 'ngx-cookie';

@NgModule({
    imports: [BrowserModule, AppRoutingModule, FormsModule, HttpModule, CookieModule.forRoot()],
    declarations: [
        AppComponent,
        LoaderComponent,
        HomeComponent,
        NotificationComponent,
        ExercisesComponent,
        ExercseDetailComponent,
        AppNavigationComponent,
        LoginComponent,
        RegisterComponent,
        PagerComponent,
        LogoutComponent,
    ],
    providers: [
        AccountService,
        NotificationService,
        ExercisesService,
        UserService,
        {
            provide: HttpService,
            useFactory: (backend: XHRBackend, options: RequestOptions, userService: UserService) => {
                return new HttpService(backend, options, userService);
            },
            deps: [XHRBackend, RequestOptions, UserService]
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
