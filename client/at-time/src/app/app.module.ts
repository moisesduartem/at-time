import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { InputTextModule } from 'primeng/inputtext';
import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
import { TableModule } from 'primeng/table';

import { AppRoutingModule } from './app-routing.module';
import { AuthInterceptor } from './interceptors/auth.interceptor';

import { AppComponent } from './app.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { MePageComponent } from './pages/me-page/me-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RippleModule } from 'primeng/ripple';
import { HeaderComponent } from './components/header/header.component';
import { RegisterPointPageComponent } from './pages/points/register-point-page/register-point-page.component';
import { TodayPointsPageComponent } from './pages/points/today-points-page/today-points-page.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    MePageComponent,
    HeaderComponent,
    RegisterPointPageComponent,
    TodayPointsPageComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RippleModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MenubarModule,
    InputTextModule,
    ButtonModule,
    CardModule,
    TableModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
