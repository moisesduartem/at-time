import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { MePageComponent } from './pages/me-page/me-page.component';
import { RegisterPointPageComponent } from './pages/points/register-point-page/register-point-page.component';
import { TodayPointsPageComponent } from './pages/points/today-points-page/today-points-page.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginPageComponent, canActivate: [AuthGuard] },
  { path: 'me', component: MePageComponent, canActivate: [AuthGuard] },
  { path: 'points/register', component: RegisterPointPageComponent, canActivate: [AuthGuard] },
  { path: 'points/today', component: TodayPointsPageComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
