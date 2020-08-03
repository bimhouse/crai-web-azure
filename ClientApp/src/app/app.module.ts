import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { CraiWorkComponent } from './crai-work/crai-work.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material.module';
import { CraiWorkService } from './services/crai-work.service';
import { CraiWorkDetailComponent } from './crai-work/crai-work-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    CraiWorkComponent,
    CraiWorkDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'work', component: CraiWorkComponent },
      { path: 'work/:id', component: CraiWorkDetailComponent }
    ]),
    BrowserAnimationsModule,
    AngularMaterialModule
  ],
  providers: [CraiWorkService],
  bootstrap: [AppComponent]
})
export class AppModule { }
