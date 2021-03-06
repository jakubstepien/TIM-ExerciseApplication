import { Component } from '@angular/core';

import { AppNavigationComponent } from './app-navigation.component';
import { NotificationComponent } from './common/notification/notification.component';
import { LoaderComponent } from './common/loader.component';

@Component({
  selector: 'my-app',
  template: `
    <app-nav></app-nav>
    <loader></loader>
    <div class="main-container">
        <notification></notification>
        <router-outlet></router-outlet>
    </div>
  `,
})
export class AppComponent  { }
