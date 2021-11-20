import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  public constructor(
    public authService: AuthService,
    public router: Router
  ) { }

  public canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    const isInLoginPage = route.routeConfig?.path === 'login';

    if (!this.authService.isLoggedIn && !isInLoginPage) {
      this.router.navigate(['login']);
    }

    if (this.authService.isLoggedIn && isInLoginPage) {
      this.router.navigate(['me']);
    }

    return true;
  }

}
